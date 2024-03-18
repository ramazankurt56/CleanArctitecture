using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;
public sealed class AppUser:IdentityUser<Guid>
{
    public AppUser()
    {
        Id = Guid.NewGuid();
    }
    public string NameLastName { get; set; }=string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime? RefreshTokenExpires { get; set; }

}
