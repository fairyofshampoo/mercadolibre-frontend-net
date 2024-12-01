using System.ComponentModel.DataAnnotations;

namespace frontendnet.Models;

public class Compra
{
    [Display(Name = "Id")]
    public int? CompraId { get; set; }

    [Display(Name = "Fecha de Pedido")]
    public DateTime? FechaPedido { get; set; }

    [Display(Name = "Usuario")]
    public Usuario? Usuario { get; set; }
    
    public ICollection<Producto>? Productos { get; set; }
}