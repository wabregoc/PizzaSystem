$(document).ready(function () {
    loadHide();
});

$(document).on('click', '#acceder', function (e) {
    e.preventDefault();
    var user_login = $("#user_login").val()
    var user_password = $("#user_password").val()

    if (user_login != "" && user_password != "") {
        loadShow();
        $.ajax({
            url: urlLogin,
            cache: false,
            type: 'POST',
            data: { user_login: user_login, user_password: user_password },
            success: function (data) {
                if (data.e == 1) {
                    window.location.href = urlHome;
                }
                else {
                    swal("", "Username o Password incorrecto", "error");
                }
                loadHide();
            },
            error: function () {
                swal("Error", "Algo salio mal, intente de nuevo", "error");
                loadHide();
            }
        });
    }
    else {
        swal("", "Los campos Username y Password son requeridos", "warning");
    }
});