// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// function IniciarSesion(Email, Contraseña)
// {
//      $.ajax(
//         {
//             type: 'POST',
//             dataType: 'JSON',
//             url: '/Home/DetallesAjaxLogin',
//             data: { "Email": Email, "Contraseña": Contraseña},
//             success:
//                 function (response)
//                 {
//                     $(n)
//                 }
//         }
//      )   
// }
function buscar() {
  let cantidad_ambientes= $("#cantidad_ambientes").val();
  console.log(cantidad_ambientes);
  let pais = $("#pais").val();
  let precio = $("#precio").val();
  let pileta = $("#pileta").is(":checked");
  let parrilla = $("#parrilla").is(":checked");
  let balcon = $("#balcon").is(":checked");
  $.ajax({
    url: "/Home/Buscar",
    type: "POST",
    dataType: 'JSON',
    data: {
      Direccion: pais,
      Precio: precio,
      Pileta: pileta,
      Parrilla: parrilla,
      CantAmb: cantidad_ambientes,
      Balcon: balcon
    },
    success: function(data) {
  
      for (var casa of data) {
        var divCasa = document.getElementById("divCasa");
        var txtCasa = "<img src='@casa.FotoCasa' class=\"card-img-top\" > <div class=\"card-body\"> <h2 class=\"card-title\">@casa.Nombre_casa</h2> <h4 class=\"card-title\">@casa.Direccion_casa</h4> <a href='@Url.Action(\"Casa\", new { IdCasa = @casa.IDCasa })' class=\"btn btn-primary\">Alquilar</a> </div>"
        divCasa.html(txtCasa);

      }
    }
  });
}
