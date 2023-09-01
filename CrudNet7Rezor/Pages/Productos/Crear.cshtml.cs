using CrudNet7Rezor.Datos;
using CrudNet7Rezor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7Rezor.Pages.Productos
{
    public class CrearModel : PageModel
    {
        private readonly AplicacionDbContext _context;

        public CrearModel(AplicacionDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Producto.FechaCreacion = DateTime.Now;

            _context.Add(Producto);
            await _context.SaveChangesAsync();
            Mensaje = "Producto creado Correctamente";
            return RedirectToPage("Index");
        }
    }
}
