using System.ComponentModel.DataAnnotations;

namespace CrudNet7Rezor.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display (Name = "Nombre del producto")]
        public String NombreProducto { get; set; }
        [Display (Name = "Descripción")]
        public String Descripcion { get; set; }
        [Display (Name = "Cantidad en Stock")]
        public int EnStock { get; set; }
        public int Precio { get; set; }
        [Display (Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set;}
    }
}
