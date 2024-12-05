using frontendnet.Models;
using frontendnet.Services;
using Microsoft.AspNetCore.Mvc;

public class ClientesController(ClientesClientService clientesService) : Controller
{
    // GET: Muestra el formulario de creación de cuenta
    public IActionResult Crear()
    {
        return View();
    }

    // POST: Procesa el formulario de creación de cuenta
    [HttpPost]
    public async Task<IActionResult> CrearAsync(Client clienteToCreate)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine("Creando cliente...");
            try
            {
                await clientesService.PostAsync(clienteToCreate);
                return RedirectToAction("Index", "Auth");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Entró al catch");
                Console.WriteLine(ex.Message);
                if (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    ModelState.AddModelError("", "No fue posible crear la cuenta. Inténtelo de nuevo.");
            }
        }
        
        Console.WriteLine("Error al crear cliente...");
        
        return View(clienteToCreate);
    }
}
