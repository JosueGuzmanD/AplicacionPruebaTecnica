using Microsoft.AspNetCore.Identity;
using System.Net.NetworkInformation;

namespace AplicacionPruebaTecnica.Models
{
    public class Usuarios
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set;}

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }


    }
}
