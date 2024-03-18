using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;

namespace CleanArchitecture.Persistence.Services;
public sealed class UserRoleService(IUserRoleRepository repository,IUnitOfWork unitOfWork) : IUserRoleService
{
    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole userRole = new()
        {
            RoleId = request.RoleId,
            UserId = request.UserId,
        };
        await repository.AddAsync(userRole,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
