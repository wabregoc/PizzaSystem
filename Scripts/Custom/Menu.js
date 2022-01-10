$(document).ready(function () {
    SearchMenu();
    loadHide();
    $("body").tooltip({ selector: '[data-toggle=tooltip]' });
});

function SearchMenu() {
    $(".search-menu-box").on('input', function () {
        var filter = $(this).val();
        $(".sidebar-menu > li").each(function () {
            if ($(this).text().search(new RegExp(filter, "i")) < 0) {
                $(this).hide();
            } else {
                $(this).show();
                if (filter != "") {
                    $(this).addClass("menu-open");
                    $(this).children(".treeview-menu").css({
                        display: "block !important"
                    })
                } else {
                    $(this).children(".treeview-menu").css({
                        display: "none !important"
                    })
                    $(this).removeClass("menu-open");
                }
            }
        });
    });
}

function loadHide() {
    $('#loading').hide();
}

function loadShow() {
    $('#loading').show();
}


