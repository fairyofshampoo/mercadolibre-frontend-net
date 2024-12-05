using System.ComponentModel.DataAnnotations;

namespace frontendnet.Models;

public class Pedido
{
    [Display(Name = "Id")]
    public int? PedidoId { get; set; }

    [Display(Name = "Producto")]
    public Producto? Producto { get; set; }

    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
    [Display(Name = "Total a pagar")]
    public decimal Total { get; set; }

    [Display(Name = "UsuarioId")]
    public string? UsuarioId { get; set; }

    [Display(Name = "Usuario")]
    public UsuarioPedido? Usuario { get; set; }

    [Display(Name = "Fecha")]
    public DateTime? Fecha { get; set; }
}
