
$(function () {
    $('ul.pagination li a').on('click', function (e) {
        e.preventDefault();
        var companyId = $('#note').data('id');
        var href = $(this).attr('href') + '&companyId=' + companyId;

        $.get(href, function (data) {
            $('#tab-note-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-note-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });

});