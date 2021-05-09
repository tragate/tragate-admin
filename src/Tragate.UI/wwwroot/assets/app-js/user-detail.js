
$(function () {
    $('#user-company').on('click', function () {
        var userId = $(this).data('id');
        $('#tab-user-company-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
        $.get('/user/user-companies?userId=' + userId, function (data) {
            $('#tab-user-company-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-company-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });

    $('#user-product').on('click', function () {
        var userId = $(this).data('id');
        $('#tab-user-prodcut-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
        $.get('/user/user-products?userId=' + userId, function (data) {
            $('#tab-user-product-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-product-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });

    $('#user-task').on('click', function () {
        var userId = $(this).data('id');
        $('#tab-user-task-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
        $.get('/user/user-tasks?userId=' + userId, function (data) {
            $('#tab-user-task-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-task-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });

    $('#user-note').on('click', function () {
        var userId = $(this).data('id');
        $('#tab-user-note-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
        $.get('/user/user-notes?userId=' + userId, function (data) {
            $('#tab-user-note-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-note-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });

    $('#user-buyer-quotes').on('click', function () {
        var userId = $(this).data('id');
        $.get('/user/user-buyer-qoutes?userId=' + userId, function (data) {
            $('#tab-user-buyer-quotes-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-buyer-quotes-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });

    $('#user-seller-quotes').on('click', function () {
        var userId = $(this).data('id');
        $.get('/user/user-seller-qoutes?userId=' + userId, function (data) {
            $('#tab-user-seller-quotes-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-seller-quotes-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });
});