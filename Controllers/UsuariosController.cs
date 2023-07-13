using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacionPruebaTecnica.Data;
using AplicacionPruebaTecnica.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;
using X.PagedList;
using Microsoft.IdentityModel.Tokens;

namespace AplicacionPruebaTecnica.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppBDConexion _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsuariosController(AppBDConexion context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(int? numpag, string filtroActual)
        {
            var usuarios = await _context.AspNetUsers.Include(u => u.Roles).ToListAsync();
            var pageNumber = numpag ?? 1; // Obtener el número de página actual
            var pageSize = 10; // Tamaño de la página

            var pagedList = usuarios.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
        //GET: Usuarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.AspNetUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.AspNetUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _roleManager.Roles.Select(r => new SelectListItem
            {
                Value = r.Id,
                Text = r.Name,
                Selected = !user.Roles.IsNullOrEmpty() && user.Roles.First().Role.Name == r.Name //_userManager.IsInRoleAsync(user, r.Name).Result
            }).ToListAsync();

            var model = new ApplicationUserEditViewModel
            {
                User = user,
                RoleItems = roles.ToList(),
                SelectedRoleName = user.Roles.IsNullOrEmpty() ? "" : user.Roles.First().Role.Name,
            };

            return View(model);
        }
        //POST: Usuarios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUserEditViewModel model)
        {
            if (id != model.User.Id)
            {
                return NotFound();
            }

            ModelState.Remove("RoleItems");
            if (ModelState.IsValid)
            {
                //var user = await _context.AspNetUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                var user = await _context.AspNetUsers.FindAsync(model.User.Id);

                if (user == null)
                {
                    return NotFound();
                }

                // Actualizar los datos del usuario con los valores del modelo
                user.Nombre = model.User.Nombre;
                user.Apellido = model.User.Apellido;
                user.Email = model.User.Email;

                _context.AspNetUsers.Update(user); // Utilizar el método Update para marcar la entidad como modificada

                await _context.SaveChangesAsync();


                var userManagerUser = await _userManager.FindByIdAsync(model.User.Id);

                foreach (var role in user.Roles)
                {
                    await _userManager.RemoveFromRoleAsync(userManagerUser, role.Role.Name);
                }


                await _userManager.AddToRoleAsync(userManagerUser, model.SelectedRoleName);

                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }


        //GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.AspNetUsers.FindAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
        }

        //POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.AspNetUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}


