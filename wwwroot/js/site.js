// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


  function buscar() {
    let cantidad_ambientes = $("#cantidad_ambientes").val();
    let pais = $("#pais").val();
    let precio = $("#precio").val();
    let pileta = $("#pileta").is(":checked");
    let parrilla = $("#parrilla").is(":checked");
    let balcon = $("#balcon").is(":checked");

    $.ajax({
        url: "/Home/AjaxFiltros",
        type: "POST",
        dataType: 'JSON',
        data: {
          
            Direccion: pais,
            Precio: precio,
            CantAmb: cantidad_ambientes,
            Pileta: pileta,
            Parrilla: parrilla,
            Balcon: balcon

        },
        success: function (response) {

            $("#divCasa").empty();
            let texto = '<div class="container-fluid"><div class="row">'
            for (var casa of response.data) {
                var txtCasa = "<div class=\"col-md-3 col-12\"> \
                                    <div class=\"card casa-card\"> \
                                        <img src='" + casa.fotoCasa + "' class=\"card-img-top\" alt=\"" + casa.nombre_casa + "\"> \
                                        <div class=\"card-body text-center\"> \
                                            <h2 class=\"card-title\">" + casa.nombre_casa + "</h2> \
                                            <h4 class=\"card-subtitle mb-2 text-muted\">" + casa.direccion_casa + "</h4> \
                                            <h4 class=\"card-subtitle mb-2 text-muted\">Precio: " + casa.precio + "</h4> \
                                            <a href='/Home/Casa?IdCasa=" + casa.idCasa + "' class=\"btn btn-primary btn-alquilar\">Alquilar</a> \
                                            <div class=\"corazon casa " + (casa.esFavorito ? "favorito" : "") + "\" id=\"" + casa.idCasa + "\" onclick=\"corazonC(" + casa.idCasa + ", this)\"> \
                                                <i class=\"fas fa-heart\"></i> \
                                            </div> \
                                        </div> \
                                    </div> \
                                </div>";
                texto += txtCasa;
            }
            texto += '</div>';
            texto += '</div>';
            $("#divCasa").html(texto);
               
        }

    });
} 


function corazonC(idCasa) {
    var corazon = idCasa;

    $.ajax({
        type: 'POST',
        url: '/Home/ToggleFavorito',
        data: { idCasa: idCasa },
        dataType: 'JSON',
        success: function (response) {

            if (response.success) {


                if (response.estaEnFavoritos) {
                    var element = document.getElementById(corazon);
                    element.classList.add('favorito');
                } else {
                    var element = document.getElementById(corazon);
                    element.classList.remove('favorito');
                }
            }
        }.bind(corazon)
    });
}
//intento de reserva

function cargarSemanasDisponibles() {
    var idCasa = $('#idCasa').val(); 
    var mes = $('#mes').val();
    var anio = $('#anio').val();

    $.ajax({
        url: '/Home/ObtenerSemanasDisponibles',
        type: 'GET',
        data: { idCasa: idCasa, mes: mes, anio: anio },
        success: function (semanasDisponibles) {
            $('#semana').empty();
            for (let i = 1; i <= 4; i++) {
                let disabled = semanasDisponibles.indexOf(i) !== -1;
            
                $('#semana').append('<option id="opcion_' + i + '" value="' + i + '" ' + (disabled ? 'disabled' : '') + '>Semana ' + i + '</option>');
                $('#opcion_'+i).css('color',(disabled ? 'red' : 'black'));
            }

            $('#semana').prop('disabled', false);
        },
        error: function (error) {
            console.error('Error al cargar semanas disponibles:', error);
            

            
        }
    });
}

$('#idCasa, #mes, #anio').on('change', function () {
    cargarSemanasDisponibles();
});