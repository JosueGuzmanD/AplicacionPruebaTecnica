using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacionPruebaTecnica.Data;
using AplicacionPruebaTecnica.Models;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace AplicacionPruebaTecnica.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly AppBDConexion _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductoesController(AppBDConexion context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;


        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var productos = _context.Productos.Include(p => p.Variantes).ToList();

            foreach (var producto in productos)
            {
                if (producto.Variantes.Any())
                {
                    var precioMinimo = producto.Variantes.Min(v => v.Precio);
                    var precioMaximo = producto.Variantes.Max(v => v.Precio);

                    producto.PrecioMinimo = precioMinimo;
                    producto.PrecioMaximo = precioMaximo;
                }
            }

            return View(productos);
        

            return Problem("Producto no encontrado.");
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var producto = _context.Productos
        .Include(p => p.Variantes) // Cargar las variantes
        .FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }
        


            return View(producto);

        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            var producto = new Producto();
            producto.Variantes = new List<ProductoVariante>();
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            for (int i = 0; i < producto.Variantes.Count; i++)
            {
                ModelState.Remove("Variantes[" + i + "].ImagenFileName");

            }

            if (ModelState.IsValid)
            {
                foreach (var variante in producto.Variantes)
                {
                    var ImageFile = variante.ImageFile;
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        variante.ImagenFileName = fileName;
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Debe seleccionar una imagen.");
                    }
                }
              

                _context.Add(producto);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }
        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

      
        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'AppBDConexion.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
