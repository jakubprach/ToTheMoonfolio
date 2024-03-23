using Microsoft.AspNetCore.Identity;

namespace ToTheMoonfolio.Persistence;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() { }
    public ApplicationRole(string roleName) : base(roleName) { }
}