using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroCompraDetalle.DAL;
using RegistroCompraDetalle.Models;

namespace RegistroCompraDetalle.BLL
{
    public class ComprasBLL
    {
        private Contexto _contexto;
        
        public ComprasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        
        public bool Guardar(Compras compra)
        {
            _contexto.Compras.Add(compra);

            foreach (var item in compra.Detalle)
            {
                var producto = _contexto.Productos.Find(item.ProductoId);

                producto.Existencia += item.Cantidad;

            }

            var insertados = _contexto.SaveChanges();

            return insertados > 0;
        }

         private bool Modificar(Compras compra)
        {
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"Delete FROM ProductoDetalles where CompraId={compra.CompraId}");
                foreach(var anterior in compra.Detalle)
                {
                    _contexto.Entry(anterior).State= EntityState.Added;
                }
                _contexto.Entry(compra).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
            return paso;
        }
         public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                var compra = _contexto.Compras.Find(id);
                if (compra != null)
                {
                    _contexto.Compras.Remove(compra);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return paso;
        }

        public List<Compras> Buscar(DateTime fecha1, DateTime fecha2)
        {
            
            var fechas = _contexto.Compras
            .Where(f => f.Fecha.Date == fecha1.Date || f.Fecha.Date == fecha2.Date)
            .AsNoTracking().ToList();
            return fechas;
        }
        public Compras? Buscar(int id)
        {
            return _contexto.Compras.Include(c => c.Detalle).AsNoTracking().FirstOrDefault(c => c.CompraId == id);
        }

        public List<Compras> GetList()
        {
            return _contexto.Compras.AsNoTracking().ToList();
        }
    }
}
