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


  function buscar() {
    let cantidad_ambientes = $("#cantidad_ambientes").val();
    let pais = $("#pais").val();
    let precio = $("#precio").val();
    let pileta = $("#pileta").is(":checked");
    let parrilla = $("#parrilla").is(":checked");
    let balcon = $("#balcon").is(":checked");

    console.log("Direccion:", pais);
    console.log("Precio:", precio);
    console.log("Pileta:", pileta);
    console.log("Parrilla:", parrilla);
    console.log("CantAmb:", cantidad_ambientes);
    console.log("Balcon:", balcon);

    $.ajax({
        url: "/Home/AjaxFiltros",
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
        success: function (response) {

                $("#divCasa").empty();
                console.log(response)

                for (var casa of response.data) {

                    var txtCasa = "<div class=\"card\" style=\"width: 18rem;\"> \
                                        <img src='" + casa.fotoCasa + "' class=\"card-img-top\" > \
                                        <div class=\"card-body\"> \
                                            <h2 class=\"card-title\">" + casa.nombre_casa + "</h2> \
                                            <h4 class=\"card-title\">" + casa.direccion_casa + "</h4> \
                                            <h4 class=\"card-title\">" + casa.precio + "</h4> \
                                            <a href='/Home/Casa?IdCasa=" + casa.idCasa + "' class=\"btn btn-primary\">Alquilar</a> \
                                        </div> \
                                    </div>";
                    $("#divCasa").append(txtCasa);

                }
            
        }

    });
} 
