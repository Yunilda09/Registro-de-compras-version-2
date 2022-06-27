using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroCompraDetalle.Models
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public int CategoriaId { get; set; }
        public String? Descripcion { get; set; }
        public DateTime Fecha { get; set; } 
        public double Total { get; set; }
        public String? Suplidor { get; set; }
        
         [ForeignKey("CompraId")]
        public virtual List<ComprasDetalle> Detalle { get; set; } = new List<ComprasDetalle>();

        public override string ToString()
        {
            return $"Compra: Id={CompraId}, Descripcion={Descripcion}, Total={Total}";
        }
    }
}
