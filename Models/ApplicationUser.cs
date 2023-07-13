using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionPruebaTecnica.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Column("nombre")]
        public string Nombre  { get; set; }

        [Column("apellidos")]
        public string Apellido { get; set; }

        public virtual ICollection<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();


    }
}
