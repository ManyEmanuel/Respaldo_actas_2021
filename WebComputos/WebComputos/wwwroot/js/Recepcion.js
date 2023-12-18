var dataTable;

$(document).ready(function () {
    
    CargarDatatable();
    FechaInicial();
    ListaCasilla();
    IdCasilla();
    Actualizar();
    
    Sobre();
    Paquete();
    Observaciones();
    Fecha();
    CombinaTodo();
});



function CargarDatatable() {
    dataTable = $("#tblRecepcion").DataTable({
        "ajax": {
            "url": "/admin/TRecepcionPaquetes/CargarDa",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "seccion", "width": "10%" },
            { "data": "casilla", "width": "10%" },
            { "data": "recep", "width": "10%" },
            { "data": "idr", "width": "10%", "visible": false },
            {
                "data": "idr",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/TRecepcionPaquetes/Detalle/${data}' class='btn btn-info text-white' style='cursor:pointer; width:120px;' >
                            <i class='fas fa-list'></i> Ver Detalle
                            </a>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "decimal": ",",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 de 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "width": "100%"
        }
    });
}
function FechaInicial() {
    var hoy = new Date();
    var dd = hoy.getDate();
    var mm = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    hoy = dd + '/' + mm + '/' + yyyy;
    document.getElementById("fini").value = hoy;
}

function ListaCasilla() {
    $("#Seccion").change(function () {
        var url = "/admin/TRecepcionPaquetes/Casillaid";
        var ddlsourse = "#Seccion";
        $.getJSON(url, { id: $(ddlsourse).val() }, function (data) {
            var items = '';
            $("#casid").empty();
            $.each(data, function (i, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#casid").html(items);
            document.getElementById("casid").focus();
        })
    });
}

function IdCasilla(){
    $("#casid").focus(function () {
        var a = document.getElementById("casid").value;
        document.getElementById("idcas").value = a;
        console.log(document.getElementById("idcas").value);
    });

    $("#casid").change(function () {
        var a = document.getElementById("casid").value;
        document.getElementById("idcas").value = a;
        console.log(document.getElementById("idcas").value);
    });
}



function Actualizar() {
    $("#Guardar").click(function () {
        var url = "/admin/TRecepcionPaquetes/Cambiar";
        var b = document.getElementById("casid").value;
        $.getJSON(url, { id: b }, function (data) {
           
        })
    })
}



function Sobre(){
    $("input[name=Sobre]").click(function () {
        var sobre = $('input:radio[name=Sobre]:checked').val();
        document.getElementById("sobrePrep").value = sobre;
    });
}

function Paquete() {
    $("input[name=Paquete]").click(function () {
        var paq = $('input:radio[name=Paquete]:checked').val();
        document.getElementById("PaqPrep").value = paq;
    });
}

function Observaciones() {
     $("input[name=obs]").click(function () {
        var obs = $('input:radio[name=obs]:checked').val();
        document.getElementById("Resob").value = obs;
    });
}

function Fecha() {
    $("#Guardar").click(function () {
        var hoy = new Date();
        var dd = hoy.getDate();
        var mm = hoy.getMonth() + 1;
        var yyyy = hoy.getFullYear();

        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }
        hoy = dd + '/' + mm + '/' + yyyy;
        document.getElementById("Fecsis").value = hoy;

        var hor = new Date();
        var hh = hor.getHours();
        var min = hor.getMinutes();
        hor = hh + ':' + min;
        document.getElementById("Horsis").value = hor;

    });
}





