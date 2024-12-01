using System.ComponentModel.DataAnnotations;

namespace frontendnet.Models;

public class CompraProducto
{
    [Display(Name = "Id de Compra")]
    public int? CompraId { get; set; }

    public Producto? Producto { get; set; }

}