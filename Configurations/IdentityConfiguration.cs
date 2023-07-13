using AplicacionPruebaTecnica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AplicacionPruebaTecnica.Configurations
{
    public class IdentityConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {

            //    modelBuilder.Entity<ApplicationRole>()
            //    .HasBaseType<IdentityRole>();

            //    modelBuilder.Entity<ApplicationUser>()
            //    .HasBaseType<IdentityUser>();
            //    modelBuilder.Entity<IdentityUserRole<string>>()
            //.HasKey(ur => new { ur.UserId, ur.RoleId });

            //    // Configuración de la relación entre AspNetUsers y AspNetUserRoles
            //    modelBuilder.Entity<IdentityUserRole<string>>()
            //        .HasOne<ApplicationUser>()
            //        .WithMany()
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();

            //    // Configuración de la relación entre AspNetRoles y AspNetUserRoles
            //    modelBuilder.Entity<IdentityUserRole<string>>()
            //        .HasOne<ApplicationRole>()
            //        .WithMany()
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();

            //    modelBuilder.Entity<IdentityUserRole<string>>()
            //.HasKey(ur => new { ur.UserId, ur.RoleId });

            //    // Configuración de la relación entre IdentityUser e IdentityUserRole
            //    modelBuilder.Entity<IdentityUserRole<string>>()
            //        .HasOne<IdentityUser>()
            //        .WithMany()
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();

            //    // Configuración de la relación entre ApplicationRole e IdentityUserRole
            //    modelBuilder.Entity<IdentityUserRole<string>>()
            //        .HasOne<ApplicationRole>()
            //        .WithMany()
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();

            modelBuilder.Entity<IdentityUserRole<string>>()
    .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasOne<ApplicationRole>()
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            modelBuilder.Entity<ApplicationUserRole>()
     .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId);



        }
    }
}
