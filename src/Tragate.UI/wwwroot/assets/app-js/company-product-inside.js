
$(function () {
    $('ul.pagination li a').on('click', function (e) {
        e.preventDefault();
        var companyId = $('#product').data('id');
        var href = $(this).attr('href') + '&companyId=' + companyId;

        $.get(href, function (data) {
            $('#tab-product-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-product-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });

});