using Microsoft.EntityFrameworkCore;
using RegistroCompraDetalle.DAL;
using RegistroCompraDetalle.Models;

namespace RegistroCompraDetalle.BLL
{
    public class ProductosBLL
    {
        private Contexto _contexto;
        public ProductosBLL(Contexto contexto)
        {
            _contexto = contexto; 
        }
       
        public Productos? Buscar(int Id)
        {
           var producto = _contexto.Productos
                .AsNoTracking()
                .FirstOrDefault(p => p.ProductoId == Id);

            return producto;
        }

        public List<Productos> GetList()
        {
           return _contexto.Productos.AsNoTracking().ToList();
        }
    }
}
