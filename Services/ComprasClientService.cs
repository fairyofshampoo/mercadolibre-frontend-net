using frontendnet.Models;

namespace frontendnet.Services;

public class ComprasClientService(HttpClient client)
{
    public async Task<List<Compra>?> GetAsync()
    {
        return await client.GetFromJsonAsync<List<Compra>>("api/compras");
    }
}
