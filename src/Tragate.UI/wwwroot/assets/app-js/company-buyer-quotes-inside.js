$(document).ready(function () {
    $('.quoteDetail').on('click', function (e) {
        var url = $(this).data('url');
        var title = $(this).data('title');
        $('.modal-content #container-title').html(title);
        $.get(url, function (data) {
            $('.modal-content #container').html(data);
        }).fail(function () {
            $('.modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
        });
    });
});
$(function () {
    $('ul.pagination li a').on('click', function (e) {
        e.preventDefault();
        var companyId = $('#buyer-quotes').data('id');
        var href = $(this).attr('href') + '&companyId=' + companyId;

        $.get(href, function (data) {
            $('#tab-buyer-quotes-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-buyer-quotes-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });
});
