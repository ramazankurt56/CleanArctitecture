using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;
public sealed class UserRole:Entity
{
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public AppUser User { get; set; }
    [ForeignKey("Role")]

    public Guid RoleId { get; set; }
    public Role Role { get; set; }
}
