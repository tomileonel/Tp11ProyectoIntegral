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

    public IActionResult RegistroCompleto (string Nombre, string Apellido, string Email, string Contraseña)
    {
        ViewBag.Usuario = BD.Registrarte(Nombre, Apellido, Email, Contraseña);
        return RedirectToAction("Index");
    }

        public IActionResult Registro()
    {
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

    public Registro DetallesAjaxLogin (string Email, string Contraseña)
    {
        ViewBag.usu = BD.IniciarSesion(Email, Contraseña);
        return ViewBag.usu;
    }

    public IActionResult VerificarContraseña(string Email, string Contraseña)
    {
        if (string.IsNullOrEmpty(Contraseña)  || string.IsNullOrEmpty(Email) )
        {
            ViewBag.Error = "Se deben completar todos los campos";
            return RedirectToAction("Index");
        }
        else
        {
            Login verificar = BD.IniciarSesion(Email, Contraseña);
        
            if (verificar != null)
            {
                if (Contraseña == verificar.Contraseña)
                {
                    return RedirectToAction("Index", "Home", new {id=verificar.id});
                }
            }
            else
            {
                ViewBag.Verificar = "El usuario y/o contraseña ingresada son incorrectos";
            }

            return View("Index");
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


   
}
