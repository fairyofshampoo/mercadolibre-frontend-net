using frontendnet.Models;
using frontendnet.Services;
using Microsoft.AspNetCore.Mvc;

public class ClientesController(ClientesClientService clientesService) : Controller
{
    // GET: Muestra el formulario de creación de cuenta
    public IActionResult Crear()
    {
        //return View("~/Views/Usuarios/CrearCliente.cshtml");
        return View();
    }

    // POST: Procesa el formulario de creación de cuenta
    [HttpPost]
    public async Task<IActionResult> CrearAsync(Client clienteToCreate)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await clientesService.PostAsync(clienteToCreate);
                ViewData["Message"] = "¡La cuenta se creó exitosamente!";
                ViewData["Success"] = true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                ViewData["Message"] = "Hubo un error al crear la cuenta. Inténtalo de nuevo.";
                ViewData["Success"] = false;
            }
        }

        return View("Crear");
    }

    public IActionResult CreacionExitosa()
    {
        return View();
    }
}