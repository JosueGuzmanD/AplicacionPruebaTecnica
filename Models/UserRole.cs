﻿using Microsoft.AspNetCore.Identity;

namespace AplicacionPruebaTecnica.Models
{
    public class UserRole : IdentityUserRole<string>
    {
       public virtual ApplicationUser User { get; set; }
      public virtual ApplicationRole Role { get; set; }


    }
}
