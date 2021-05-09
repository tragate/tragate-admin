$(document).ready(function () {
    $('.quoteDetail').on('click', function (e) {
        var mmData = $(this).data();
        $(mmData.target).find('.modal-content #container-title').html(mmData.title);
        $.get(mmData.url, function (data) {
            $(mmData.target).find('.modal-content #container').html(data);
        }).fail(function () {
            $(mmData.target).find('.modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
        });
    });
});
$(function () {
    $('ul.pagination li a').on('click', function (e) {
        e.preventDefault();
        var userId = $('#user-seller-quotes').data('id');
        var href = $(this).attr('href') + '&userId=' + userId;

        $.get(href, function (data) {
            $('#tab-user-seller-quotes-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-seller-quotes-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });
});