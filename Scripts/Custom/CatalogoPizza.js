$(document).ready(function () {
    GetCatalogoPizza();
});

function GetCatalogoPizza() {
    $('#catalogo-pizza-table').DataTable({
        "destroy": true,
        "processing": true,
        "deferRender": true,
        "autoWidth": false,
        "responsive": true,
        "select": true,
        "order": [[5, "desc"]],
        "ajax": {
            "url": urlGetCatalogoPizza,
            "cache": false,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "NombreProducto", "name": "Nombre Producto" },
            { "data": "CantidadPorciones", "name": "Cantidad Porciones" },
            { "data": "DescripcionProducto", "name": "Descripcion del Producto" },
            { "data": "PrecioUnidad", "name": "Precio Por Unidad" },
            { "data": "Tamano", "name": "Tamaño" },
            {
                "data": "FechaCreado", render: function (d) {
                    return (d == null) ? " " : moment(d).format("MM/DD/YYYY h:mm:ss A");
                }
            },
            {
                "data": "Actions", "width": "8%", render: function (data, type, row) {
                    return '<button class="btn btn-sm btn-primary m-2"  id="btn-edit-catalogo-pizza" data-toggle="tooltip" data-placement="top" title="Edit" data-id="' + row.IdCatalogoPizza + '"><i class="fas fa-edit"></i></button>' +
                        '<button class="btn btn-sm btn-danger m-2" data-toggle="tooltip" data-placement="top" title="Delete" id="delete-catalogo-pizza" data-id="' + row.IdCatalogoPizza + '"><i class="fa fa-trash-alt "></i></button>';
                }
            }
        ],
        "columnDefs": [
            {
                "targets": [0, 1, 3],
                "className": "text-center"
            },
            {
                "targets": [0, 1, 2, 3, 4, 5],
                "className": "vertical-align"
            },
            {
                "targets": [0, 1, 2, 3, 4, 5],
                "className": "line-height"
            }
        ]
    });
}

$(document).on("click", "#btn-add-catalogo-pizza", function () {
    loadShow();
    $.ajax({
        url: urlCatalogoPizzaForm,
        type: 'POST',
        cache: false,
        success: function (data) {
            $('#div-add-edit-catalogo-pizza').html('');
            $('#div-add-edit-catalogo-pizza').html(data);
            $('#modal-add-catalogo-pizza').modal('show');
            loadHide();
        },
        error: function () {
            loadHide();
            swal('Error', 'Something went wrong with the connection', 'error');
        }
    });
});

$(document).on("click", "#btn-edit-catalogo-pizza", function () {
    loadShow();
    $.ajax({
        url: urlCatalogoPizzaForm,
        type: 'POST',
        cache: false,
        data: { id: $(this).attr("data-id") },
        success: function (data) {
            $('#div-add-edit-catalogo-pizza').html('');
            $('#div-add-edit-catalogo-pizza').html(data);
            $('#modal-edit-catalogo-pizza').modal('show');
            loadHide();
        },
        error: function () {
            loadHide();
            swal('Error', 'Something went wrong with the connection', 'error');
        }
    });
});

$(document).on('submit', '#form-add-catalogo-pizza', function (e) {
    e.preventDefault();
    var FormData = $("#form-add-catalogo-pizza").serialize();
    loadShow();
    $.ajax({
        url: urlSaveCatalogoPizza,
        type: 'POST',
        cache: false,
        data: FormData,
        success: function (data) {
            loadHide();
            if (data.e == 1) {
                swal('', data.msj, 'success');
                $('#modal-add-catalogo-pizza').modal('hide');
                GetCatalogoPizza();
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

$(document).on('submit', '#form-edit-catalogo-pizza', function (e) {
    e.preventDefault();
    loadShow();
    var FormData = $("#form-edit-catalogo-pizza").serialize();
    $.ajax({
        url: urlEditCatalogoPizza,
        type: 'POST',
        cache: false,
        data: FormData,
        success: function (data) {
            loadHide();
            if (data.e == 1) {
                swal('', data.msj, 'success');
                $('#modal-edit-catalogo-pizza').modal('hide');
                GetCatalogoPizza();
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

$(document).on('click', '#delete-catalogo-pizza', function () {
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
                    url: urlDeleteCatalogoPizza,
                    type: 'POST',
                    cache: false,
                    data: { id: IdShift },
                    success: function (data) {
                        loadHide();
                        if (data.e == 1) {
                            swal('', data.msj, 'success');
                            GetCatalogoPizza();
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












