using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionPruebaTecnica.Models
{
    public class ApplicationUserEditViewModel
    {
        public virtual ApplicationUser  User { get; set; }
      
        public string SelectedRoleName { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> RoleItems { get; set; }

        public ApplicationUserEditViewModel()
        {
        }

    }
}
