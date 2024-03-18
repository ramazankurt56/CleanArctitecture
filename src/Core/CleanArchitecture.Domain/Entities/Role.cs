using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;
public sealed class Role:IdentityRole<Guid>
{
    public Role()
    {
        Id = Guid.NewGuid();
    }
}
