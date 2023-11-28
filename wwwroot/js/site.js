// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function IniciarSesion(Email, Contraseña)
{
     $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/DetallesAjaxLogin',
            data: { "Email": Email, "Contraseña": Contraseña},
            success:
                function (response)
                {
                    $(n)
                }
        }
     )   
}

$(document).ready(function() {

    $("#form-filtro").on("change", function() {
  
      var pais = $("#pais").val();
      var precio = $("#precio").val();
      var pileta = $("#pileta").is(":checked");
      var parrilla = $("#parrilla").is(":checked");
      var cantidad_ambientes = $("#cantidad_ambientes").val();
      var balcon = $("#balcon").is(":checked");
  
      $.ajax({
        url: "/filtrar",
        type: "POST",
        data: {
          pais: pais,
          precio: precio,
          pileta: pileta,
          parrilla: parrilla,
          cantidad_ambientes: cantidad_ambientes,
          balcon: balcon
        },
        success: function(data) {
          $("#resultados").html(data);
        }
      });
    });
  
  });

