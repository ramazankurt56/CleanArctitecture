using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
public sealed record CreateUserRoleCommand(
    Guid RoleId,
    Guid UserId):IRequest<MessageResponse>;
