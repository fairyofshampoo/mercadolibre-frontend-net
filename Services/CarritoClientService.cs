using System.Text.Json;
using frontendnet.Models;

namespace frontendnet.Services;

public class CarritoClientService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string SessionKeyCarrito = "Carrito";

    public CarritoClientService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<Producto>?> ObtenerCarrito()
    {
        var session = _httpContextAccessor.HttpContext?.Session;
        var carritoJson = session?.GetString(SessionKeyCarrito);
        return carritoJson == null ? new List<Producto>() : JsonSerializer.Deserialize<List<Producto>>(carritoJson)!;
    }

    public async Task GuardarCarrito(List<Producto> carrito)
    {
        var session = _httpContextAccessor.HttpContext?.Session;
        var carritoJson = JsonSerializer.Serialize(carrito);
        session?.SetString(SessionKeyCarrito, carritoJson);
    }

    public async Task AgregarAlCarrito(Producto producto)
    {
        var carrito = await ObtenerCarrito();
        carrito?.Add(producto);
        await GuardarCarrito(carrito);
    }

    public async Task LimpiarCarrito()
    {
        var session = _httpContextAccessor.HttpContext?.Session;
        session?.Remove(SessionKeyCarrito);
    }

    public async Task EliminarDelCarrito(int id)
    {
        var carrito = await ObtenerCarrito();
        carrito?.RemoveAll(p => p.ProductoId == id);
        await GuardarCarrito(carrito);
    }
}