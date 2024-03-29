﻿using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Persistence.Services;
public sealed class AuthService(UserManager<AppUser> userManager, IMapper mapper,
    IMailService mailService, IJwtProvider jwtProvider) : IAuthService
{
    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AppUser? user= await userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            throw new Exception("Kullanıcı bulunamadı");
        }
        if (user.RefreshToken != request.RefreshToken)
        {
            throw new Exception("Refresh Token Geçerli Değil");
        }
        if (user.RefreshTokenExpires<DateTime.Now)
        {
            throw new Exception("Refresh token süresi dolmuş!");
        }
        LoginCommandResponse response=await jwtProvider.CreateTokenAsync(user);
        return response;

    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.Users.Where(p => p.UserName ==
        request.UserNameOrEmail || p.Email == request.UserNameOrEmail)
            .FirstOrDefaultAsync(cancellationToken);
        if (user == null)
        {
            throw new Exception("Kullanıcı bulunamadı");
        }
       var result= await userManager.CheckPasswordAsync(user, request.Password);
        if (result)
        {
            LoginCommandResponse response = await jwtProvider.CreateTokenAsync(user);
            return response;
        }
        throw new Exception("Şifreyi yanlış girdiniz.");
    }

    public async Task RegisterAsync(RegisterCommand request)
    {
        AppUser user = mapper.Map<AppUser>(request);
        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
        string body = "";
        await mailService.SendEmailAsync(request.Email, "Mail Onayı", body);
    }


}
