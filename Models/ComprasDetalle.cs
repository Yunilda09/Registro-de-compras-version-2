using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroCompraDetalle.Models
{
    public class ComprasDetalle
    {
        [Key]
        public int CompraDetalleId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        [NotMapped]
        public string? Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }
        [NotMapped]
        public double Importe { 
            get { return Cantidad * Costo; }
        }
        
         public ComprasDetalle(string descripcion, double cantidad, double costo)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
            Costo = costo;
        }
        public ComprasDetalle(){}

        public override string? ToString()
        {
            return $"Detalle # {CompraDetalleId}, ProductoId= {ProductoId} , cantidad={Cantidad} ";
        }
    }
}