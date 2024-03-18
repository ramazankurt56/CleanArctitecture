﻿using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
public sealed class CreateUserRoleCommandHandler(IUserRoleService userRoleService) : IRequestHandler<CreateUserRoleCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        await userRoleService.CreateAsync(request, cancellationToken);
        return new("Kullanıcıya rol başarıyla atandı!");
    }
}
