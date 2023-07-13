using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AplicacionPruebaTecnica.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public ApplicationRole(string name) : base(name){ 
            
        }

        public virtual ICollection<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();



    }
}
