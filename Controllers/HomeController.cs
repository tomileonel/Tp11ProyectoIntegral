using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp11ProyectoIntegral.Models;

namespace Tp11ProyectoIntegral.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Favoritos ()
    {
        ViewBag.Favoritos = BD.VerFavoritos();
        return View();
    }

    public IActionResult CasasFiltradas()
    {
        ViewBag.pileta = BD.TienePileta(pileta);
        ViewBag.parrilla = BD.TieneParrilla(parrilla);
        ViewBag.balcon = BD.TieneBalcon(balcon);
        ViewBag.cantAmbientes = BD.CantidadAmbientes(cantAmbientes);
        return View();
    }

    public IActionResult Registro ()
    {
        ViewBag.Usuario = BD.Registrarte();
        return View();
    }

   public IActionResult EditarPerfil()
    {
        return View();
    }

    public IActionResult ActualizarPerfil()
    {
        BD.EditarPerfil(nombre, apellido, mail, contraseña)
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


   
}
