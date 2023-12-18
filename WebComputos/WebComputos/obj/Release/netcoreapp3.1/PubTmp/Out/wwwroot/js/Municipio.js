var dataTable;
$(document).ready(function () {
    CargarDatatable();
});

function CargarDatatable() {
    dataTable = $("#tblMunicipio").DataTable({
        "ajax": {
            "url": "/admin/Municipios/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idMunicipio", "width": "5%" },
            { "data": "nombre", "width": "25%" },
            { "data": "cabMun", "width": "40%" },
            {
                "data": "idMunicipio",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/muniicipio/Detalles/${data}' class='btn btn-info text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-info'></i>Ver
                            <a/>
                           

                            `;
                },"width":"30%"
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