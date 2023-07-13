using Microsoft.AspNetCore.Identity;

namespace AplicacionPruebaTecnica.Models
{
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }

        public string UserId => User.Id;
        public string RoleId => Role.Id;

    }
}
