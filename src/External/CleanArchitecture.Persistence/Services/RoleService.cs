using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistence.Services;
public sealed class RoleService(RoleManager<Role> roleManager) : IRoleService
{
    public async Task CreateAsync(CreateRoleCommand request)
    {
        Role role = new()
        {
            Name = request.Name
        };
        await roleManager.CreateAsync(role);
    }
}
