using AplicacionPruebaTecnica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AplicacionPruebaTecnica.Configurations;
using Microsoft.Extensions.Options;


namespace AplicacionPruebaTecnica.Data
{
    public class AppBDConexion : IdentityDbContext<

      ApplicationUser, // TUser
    ApplicationRole, // TRole
    string, // TKey
    IdentityUserClaim<string>, // TUserClaim
    ApplicationUserRole, // TUserRole,
    IdentityUserLogin<string>, // TUserLogin
    IdentityRoleClaim<string>, // TRoleClaim
    IdentityUserToken<string> // TUserToken
        >

    {
        public AppBDConexion(DbContextOptions<AppBDConexion> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<ProductoVariante> ProductoVariantes { get; set; }
        public DbSet<ApplicationUserEditViewModel> ApplicationUserEditViewModels { get; set; }

        public DbSet<ApplicationUser> AspNetUsers { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<ApplicationUserEditViewModel>().HasNoKey();

            modelBuilder.Entity<ApplicationUserRole>()
                        .HasOne(p => p.User)
                        .WithMany(b => b.Roles)
                        .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.Roles)
                .HasForeignKey(p => p.RoleId);

        }




    }


    }


