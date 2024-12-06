using frontendnet.Models;

namespace frontendnet.Services;

public class ClientesClientService(HttpClient client)
{
    public async Task PostAsync(Client cliente)
    {
        //Cambiar la URL para que únicamente sea api/cliientes
        var response = await client.PostAsJsonAsync("api/clientes", cliente);
        Console.WriteLine("Response: " + response);
        response.EnsureSuccessStatusCode();
    }
}
