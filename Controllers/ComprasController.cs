using frontendnet.Models;
using frontendnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontendnet
{
    [Authorize(Roles = "Administrador")]
    public class ComprasController(ComprasClientService compra) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            List<Compra>? lista = [];
            try
            {
                lista = await compra.GetAsync();
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return RedirectToAction("Salir", "Auth");
            }
            return View(lista);
        }
    }
}