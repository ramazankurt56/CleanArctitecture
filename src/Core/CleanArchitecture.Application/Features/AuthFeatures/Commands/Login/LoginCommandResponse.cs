﻿namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
public sealed record class LoginCommandResponse(
    string Token,
    string RefreshToken,
    DateTime? RefreshTokenExpires,
    Guid UserId);

