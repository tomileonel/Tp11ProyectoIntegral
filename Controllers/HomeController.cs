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
        ViewBag.Index = true;
        return View();
    }

  public List<Casa> Buscar(string Direccion, float Precio, bool Pileta, bool Parrilla, int CantAmb, bool Balcon)
    {
        List<Casa> CasasBuscadas = BD.BuscarCasa(Direccion, Precio, Pileta, Parrilla, CantAmb, Balcon);
        return CasasBuscadas;
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

   public IActionResult Perfil()
    {
        ViewBag.Perfil = BD.Usuario;
        return View();
    }

    public IActionResult ActualizarPerfil(string Nombre, string Apellido, string Email, string Contrasena, int Telefono, string FotoPerfil)
    {
        BD.EditarPerfil( Nombre,  Apellido,  Email,  Contrasena,  Telefono, FotoPerfil);
        return View();
    }

    public IActionResult VerificarContrasena(string Email, string Contrasena)
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
             ViewBag.Error = "El usuario o la contraseña seleccionados no son correctos";
            }
                    ViewBag.Casas = BD.TraerCasas();

            return View("Index");
        
    }

    public Casa AjaxFiltros(string Direccion, float Precio, bool Pileta, bool Parrilla, int CantAmb, bool Balcon)
    {
        ViewBag.Filtros = BD.BuscarCasa(Direccion,  Precio,  Pileta,  Parrilla,  CantAmb,  Balcon);
        return ViewBag.Filtros;
    }
        

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


  
}
