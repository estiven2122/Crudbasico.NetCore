using CrudNet7Rezor.Datos;
using CrudNet7Rezor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7Rezor.Pages.Productos
{
    public class IndexModel : PageModel
    {

        private readonly AplicacionDbContext _context;

        public IndexModel(AplicacionDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> Productos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Productos = await _context.Producto.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
  
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            Mensaje = "Producto borrado Correctamente";
            return RedirectToPage("Index");
        }
    }
}
