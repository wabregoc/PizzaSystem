$(document).ready(function () {
    GetOrdenesPizza();
});

function GetOrdenesPizza() {
    $('#orden-pizza-table').DataTable({
        "destroy": true,
        "processing": true,
        "deferRender": true,
        "autoWidth": false,
        "responsive": true,
        "select": true,
        "order": [[6, "desc"]],
        "ajax": {
            "url": urlGetOrdenesPizza,
            "cache": false,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "NumeroOrden", "name": "No Orden" },
            { "data": "NombreCompletoSolicitante", "name": "Nombre del solicitante" },
            { "data": "CantidadOrden", "name": "Cantidad" },
            { "data": "PrecioUnidad", "name": "Precio Unitario" },
            { "data": "Total", "name": "Total" },
            { "data": "OrdenCreadaPor", "name": "Usuario que ingreso la orden" },
            { "data": "FechaCreado", "name": "FechaCreado" },
            {
                "data": "Actions", "width": "8%", render: function (data, type, row) {
                    return '<button class="btn btn-sm btn-primary m-2"  id="btn-edit-orden-pizza" data-toggle="tooltip" data-placement="top" title="Edit" data-id="' + row.IdOrdenPizza + '"><i class="fas fa-edit"></i></button>' +
                        '<button class="btn btn-sm btn-danger m-2" data-toggle="tooltip" data-placement="top" title="Delete" id="delete-orden-pizza" data-id="' + row.IdOrdenPizza + '"><i class="fa fa-trash-alt "></i></button>';
                }
            }
        ],
        "columnDefs": [
            {
                "targets": [0, 2, 3, 4],
                "className": "text-center"
            },
            {
                "targets": [0, 1, 2, 3, 4, 5],
                "className": "vertical-align"
            },
            {
                "targets": [0, 1, 2, 3, 4, 5],
                "className": "line-height"
            },
            {
                "targets": [6],
                "visible": false,
                "searchable": false
            }
        ]
    });
}

$(document).on("click", "#btn-add-orden-pizza", function () {
    loadShow();
    $.ajax({
        url: urlOrdenesForm,
        type: 'POST',
        cache: false,
        success: function (data) {
            $('#div-add-edit-orden-pizza').html('');
            $('#div-add-edit-orden-pizza').html(data);
            $('#modal-add-orden-pizza').modal('show');
            $('#IdCatalogoPizza').select2({
                theme: 'bootstrap4',
                placeholder: "Selecciones una pizza",
                width: '100%'
            });
            $('#FechaRealizoOrden').datepicker({
                autoclose: true,
                todayHighlight: true
            })
            loadHide();
        },
        error: function () {
            loadHide();
            swal('Error', 'Something went wrong with the connection', 'error');
        }
    });
});

$(document).on("click", "#btn-edit-orden-pizza", function () {
    loadShow();
    $.ajax({
        url: urlOrdenesForm,
        type: 'POST',
        cache: false,
        data: { id: $(this).attr("data-id") },
        success: function (data) {
            $('#div-add-edit-orden-pizza').html('');
            $('#div-add-edit-orden-pizza').html(data);
            $('#modal-edit-orden-pizza').modal('show');
            $('#IdCatalogoPizza').select2({
                theme: 'bootstrap4',
                placeholder: "Selecciones una pizza",
                width: '100%'
            });
            $('#FechaRealizoOrden').datepicker({
                autoclose: true,
                todayHighlight: true
            })
            loadHide();
        },
        error: function () {
            loadHide();
            swal('Error', 'Something went wrong with the connection', 'error');
        }
    });
});

$(document).on('submit', '#form-add-orden-pizza', function (e) {
    e.preventDefault();
    var FormData = $("#form-add-orden-pizza").serialize();
    loadShow();
    $.ajax({
        url: urlSaveOrdenesPizza,
        type: 'POST',
        cache: false,
        data: FormData,
        success: function (data) {
            loadHide();
            if (data.e == 1) {
                swal('', data.msj, 'success');
                $('#modal-add-orden-pizza').modal('hide');
                GetOrdenesPizza();
            }
            else {
                swal('Error', 'Something went wrong with the connection', 'error');
            }
        },
        error: function () {
            loadHide();
            swal('Error', 'Something went wrong with the connection', 'error');
        }
    });
});

$(document).on('submit', '#form-edit-orden-pizza', function (e) {
    e.preventDefault();
    loadShow();
    var FormData = $("#form-edit-orden-pizza").serialize();
    $.ajax({
        url: urlEditOrdenesPizza,
        type: 'POST',
        cache: false,
        data: FormData,
        success: function (data) {
            loadHide();
            if (data.e == 1) {
                swal('', data.msj, 'success');
                $('#modal-edit-orden-pizza').modal('hide');
                GetOrdenesPizza();
            }
            else {
                swal('Error', 'Something went wrong with the connection', 'error');
            }
            loadHide();
        },
        error: function () {
            loadHide();
            swal('Error', 'Something went wrong with the connection', 'error');
        }
    });
});

$(document).on('click', '#delete-orden-pizza', function () {
    var IdShift = $(this).attr('data-id');
    swal({
        title: "Are you sure?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    })
        .then(function (willDelete) {
            if (willDelete) {
                loadShow();
                $.ajax({
                    url: urlDeleteOrdenesPizza,
                    type: 'POST',
                    cache: false,
                    data: { id: IdShift },
                    success: function (data) {
                        loadHide();
                        if (data.e == 1) {
                            swal('', data.msj, 'success');
                            GetOrdenesPizza();
                        }
                        else {
                            swal('Error', 'Something went wrong with the connection', 'error');
                        }
                    },
                    error: function () {
                        loadHide();
                        swal('Error', 'Something went wrong with the connection', 'error');
                    }
                });
            }
        });
});



