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


