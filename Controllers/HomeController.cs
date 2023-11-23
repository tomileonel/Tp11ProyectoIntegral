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

    public IActionResult RegistroCompleto (string Nombre, string Apellido, string Email, string Contrasena)
    {
        ViewBag.Usuario = BD.Registrarte(Nombre, Apellido, Email, Contrasena);
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

    public IActionResult ActualizarPerfil(string Nombre, string Apellido, string Email, string Contrasena, int Telefono, string FotoPerfil)
    {
        BD.EditarPerfil( Nombre,  Apellido,  Email,  Contrasena,  Telefono, FotoPerfil);
        return View();
    }

    public Registro DetallesAjaxLogin (string Email, string Contrasena)
    {
        ViewBag.usu = BD.IniciarSesion(Email, Contrasena);
        return ViewBag.usu;
    }

    public IActionResult VerificarContrasena(string Email, string Contrasena)
    {
        if (string.IsNullOrEmpty(Contrasena)  || string.IsNullOrEmpty(Email) )
        {
            ViewBag.Error = "Se deben completar todos los campos";
            return RedirectToAction("Index");
        }
        else
        {
            Registro verificar = BD.IniciarSesion(Email, Contrasena);
        
            if (verificar != null)
            {
                if (Contrasena == verificar.Contrasena)
                {
                    return RedirectToAction("Index", "Home", new {id=verificar.IDUsuario});
                }
            }
            else
            {
                ViewBag.Verificar = "El usuario y/o Contrasena ingresada son incorrectos";
            }

            return View("Index");
        }
    }
        

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


  
}
