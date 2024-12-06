using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace frontendnet.Models;

public class Pedido
{
    [Display(Name = "Id")]
    [JsonPropertyName("pedidoid")]
    public int? PedidoId { get; set; }

    [Display(Name = "Email")]
    public required string Email { get; set; }

    [Display(Name = "Producto")]
    [JsonPropertyName("productoid")]
    public required int? ProductoId { get; set; }

    [Display(Name = "Fecha")]
    public DateTime Fecha { get; set; }

    [Display(Name = "Total")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
    public decimal Total { get; set; }
}
