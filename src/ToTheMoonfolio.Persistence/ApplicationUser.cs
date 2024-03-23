using Microsoft.AspNetCore.Identity;

namespace ToTheMoonfolio.Persistence;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ApplicationUser()
    {
    }

    public ApplicationUser(string userName) : base(userName)
    {
    }
}