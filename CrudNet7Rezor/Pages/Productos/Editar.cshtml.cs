using CrudNet7Rezor.Datos;
using CrudNet7Rezor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNet7Rezor.Pages.Productos
{
    public class EditarModel : PageModel
    {
        private readonly AplicacionDbContext _context;

        public EditarModel(AplicacionDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        [TempData]
        public string Mensaje { get; set; }


        public async Task OnGet(int id)
        {
            Producto = await _context.Producto.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDesdeDB = await _context.Producto.FindAsync(Producto.Id);
                CursoDesdeDB.NombreProducto = Producto.NombreProducto;
                CursoDesdeDB.Descripcion = Producto.Descripcion;
                CursoDesdeDB.EnStock = Producto.EnStock;
                CursoDesdeDB.Precio = Producto.Precio;

                await _context.SaveChangesAsync();
                Mensaje = "Producto editado Correctamente";
                return RedirectToAction("Index");
            }

            return RedirectToPage();
        }
    }
}
