using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
public sealed class CreateRoleCommandHandler(IRoleService roleService) : IRequestHandler<CreateRoleCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await roleService.CreateAsync(request);
        return new("Rol kaydı başarıyla tamamlandı");
    }
}
