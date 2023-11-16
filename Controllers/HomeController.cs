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
        ViewBag.Casas = BD.TraerCasas();
        return View();
    }

  public IActionResult Buscar(string Nombre, string Direccion, float Precio, bool Pileta, bool Parrilla, int CantAmb, bool Balcon)
    {
        ViewBag.Casas = BD.BuscarCasa(Nombre, Direccion, Precio, Pileta, Parrilla, CantAmb, Balcon);
        return View("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

      public IActionResult Casa(int idCasa)
    {
        ViewBag.unaCasa = BD.TraerUnaCasa(idCasa);
        return View();
    }

    public IActionResult Favoritos (int idUsu)
    {
        ViewBag.Favoritos = BD.VerFavoritos(idUsu);
        return View();
    }

    public IActionResult Registro (string Nombre, string Apellido, string Email, string Contraseña)
    {
        ViewBag.Usuario = BD.Registrarte(Nombre, Apellido, Email, Contraseña);
        return View();
    }

   public IActionResult EditarPerfil()
    {
        return View();
    }

    public IActionResult ActualizarPerfil(string Nombre, string Apellido, string Email, string Contraseña, int Telefono, string FotoPerfil)
    {
        BD.EditarPerfil( Nombre,  Apellido,  Email,  Contraseña,  Telefono, FotoPerfil);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


   
}
