var dataTable;

$(document).ready(function () {
    CargarDatatable();

});
function CargarDatatable() {
    var a = document.getElementById("eleccion").value;
    var b = document.getElementById("diputado").value;
    dataTable = $("#tblcau").DataTable({
        "ajax": {
            "url": `/admin/TRecepcionPaquetes/CargarCauDip/${b}`,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "seccion", "width": "15%" },
            { "data": "casilla", "width": "15%" },         
            { "data": "cau1", "width": "5%" },
            { "data": "cau2", "width": "5%" },
            { "data": "cau3", "width": "5%" },
            { "data": "cau4", "width": "5%" },
            { "data": "cau5", "width": "5%" },
            { "data": "cau6", "width": "5%" },
            { "data": "cau7", "width": "5%" },
            { "data": "cau8", "width": "5%" },
            { "data": "cau9", "width": "5%" },
            { "data": "cau10", "width": "5%" },
            { "data": "cau11", "width": "5%" },
            { "data": "numcau", "width": "15%" }

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