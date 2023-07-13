using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AplicacionPruebaTecnica.Models;

namespace AplicacionPruebaTecnica.Controllers
{
    public class AppRolesController : Controller
    {
        private readonly RoleManager<ApplicationRole> _rolemanager;

        public AppRolesController(RoleManager<ApplicationRole> roleManager)
        {
            _rolemanager = roleManager;
        }
        //Listar todos los roles creados por los usuarios
        public IActionResult Index()
        {
            var roles = _rolemanager.Roles;
            return View(roles);
        }

        [HttpGet]

        public IActionResult Create() 
        {
            return View(); 
        }
        [HttpGet]

        public IActionResult Edit(string id)
        {
            var role = _rolemanager.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
            // Lógica para buscar y editar el rol con el ID proporcionado
        }


        [HttpPost]

        public async Task<IActionResult> Create(ApplicationRole model)
        {
            if(!_rolemanager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _rolemanager.CreateAsync(new ApplicationRole(model.Name)).GetAwaiter().GetResult();

            }

            return RedirectToAction("Index");
        }
    }
}
