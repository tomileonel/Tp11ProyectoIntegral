﻿using System.Diagnostics;
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
        ViewBag.Perfil = BD.Usuario;
        if(ViewBag.Perfil != null){
            foreach (var casa in ViewBag.Casas)
    {
        casa.EsFavorito = BD.EsFavorito(BD.Usuario.IDUsuario, casa.IDCasa);
    }
    }
        ViewBag.Index = true;
        
        return View();
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


public IActionResult Favoritos(int idUsu)   
{
        ViewBag.Casas = BD.VerFavoritos(idUsu);
        ViewBag.Perfil = BD.Usuario;
        if(ViewBag.Perfil != null){
            foreach (var casa in ViewBag.Casas)
    {
        casa.EsFavorito = BD.EsFavorito(BD.Usuario.IDUsuario, casa.IDCasa);
    }
    }
        ViewBag.Index = true;
        
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

   public IActionResult CerrarSesion()
    {
        BD.CerrarSesion();
        return RedirectToAction("Index");
    }

public IActionResult ToggleFavorito(int idCasa)
{

        if (BD.Usuario == null)
        {
            Console.WriteLine("BD.Usuario es nulo.");
        }

        bool estaEnFavoritos = BD.EsFavorito(BD.Usuario.IDUsuario, idCasa);

        if (estaEnFavoritos)
        {
            BD.SacarDeFavoritos(BD.Usuario.IDUsuario, idCasa);
        }
        else
        {
            BD.GuardarFavoritos(BD.Usuario.IDUsuario, idCasa);
        }

        return Json(new { success = true, estaEnFavoritos = !estaEnFavoritos });
}



    public IActionResult EditarPerfil(string Nombre, string Apellido, string Email, string Contrasena, int Telefono, string FotoPerfil)
    {
        return View();
    }

    public IActionResult ActualizarPerfil(string Nombre, string Apellido, string Contrasena, int Telefono, string FotoPerfil)
    {
        if(Nombre == null){
       Nombre = BD.Usuario.Nombre_usuario;
        }
            if (Apellido == null)
    {
        Apellido = BD.Usuario.Apellido_usuario;
    }

    if (Contrasena == null)
    {
        Contrasena = BD.Usuario.Contrasena;
    }

    if(Telefono != Math.Max(0, Telefono)){
Telefono = BD.Usuario.Telefono;
    }

    if (FotoPerfil == null)
    {
        FotoPerfil = BD.Usuario.FotoDePerfil;
    }
    
        BD.EditarPerfil( Nombre,  Apellido,  BD.Usuario.Email,  Contrasena,  Telefono, FotoPerfil);
        ViewBag.Perfil = BD.Usuario;
        return View("Perfil");
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

public IActionResult AjaxFiltros(string Direccion, float Precio, bool Pileta, bool Parrilla, int CantAmb, bool Balcon)
{

        List<Casa> casasFiltradas = BD.BuscarCasa(Direccion, Precio, Pileta, Parrilla, CantAmb, Balcon);

        return Json(new { success = true, data = casasFiltradas });
    

}



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


  
}
