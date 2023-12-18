var dataTable;
$(document).ready(function () {
    CargarDatatable();
});

function CargarDatatable() {
    dataTable = $("#tblTipoEle").DataTable({
        "ajax": {
            "url": "/admin/TiposEleccion/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idTipoEleccion", "width": "5%" },
            { "data": "nombre", "width": "25%" },
            { "data": "siglas", "width": "40%" },
            {
                "data": "idTipoEleccion",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/TiposEleccion/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-edit'></i> Editar
                            </a>
                            &nbsp;
                            <a onclick=Delete("/Admin/TiposEleccion/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-trash-alt'></i> Eliminar
                            </a>
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

function Delete(url) {
    swal({
        title: "Esta seguro de eliminar el registro?",
        text: "Será eliminado de forma permanente",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Aceptar",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            }
        });
    });
}