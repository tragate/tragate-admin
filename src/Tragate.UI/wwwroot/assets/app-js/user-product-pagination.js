
$(function () {
    $('ul.pagination li a').on('click', function (e) {
        e.preventDefault();
        var userId = $('#user-product').data('id');
        var href = $(this).attr('href') + '&userId=' + userId;

        $.get(href, function (data) {
            $('#tab-user-product-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-product-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });
});
