using System.Security.Claims;
using frontend.Models;
using frontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontendnet;

[Authorize]
public class PerfilController(PerfilClientService perfil) : PerfilController
{
    public async Task<IActionResult> IndexAsync()
    {
        AuthUser? usuario = null;
        try
        {
            ViewBag.timeRemaining = await perfil.ObtenTiempoAsync();

            //Obtiene el perfil del usuario
            usuario = new AuthUser
            {
                Email = User.FindFirstValue(ClaimTypes.Name)!,
                Nombre = User.FindFirstValue(ClaimTypes.GivenName)!,
                Rol = User.FindFirstValue(ClaimTypes.Role)!,
                Jwt = User.FindFirstValue("jwt")!
            };
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return RedirectToAction("Salir", "Auth");
        }
        return View(usuario);
    }
}