using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RegistroCompraDetalle.Models;

public class Categorias
{
    [Key]
    public int CategoriaId { get; set; }
    public String? Descripcion { get; set; }
    public Categorias()
    {
    }
}
