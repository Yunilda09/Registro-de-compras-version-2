using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RegistroCompraDetalle.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string? Descripcion { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public double Existencia { get; set; }
        
    }
}