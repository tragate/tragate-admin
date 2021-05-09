$(document).ready(function () {
    $('.quoteDetail').on('click', function (e) {
        var mData = $(this).data();
        $(mData.target).find('.modal-content #container-title').html(mData.title);
        $.get(mData.url, function (data) {
            $(mData.target).find('.modal-content #container').html(data);
        }).fail(function () {
            $(mData.target).find('.modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
        });
    });
});
$(function () {
    $('ul.pagination li a').on('click', function (e) {
        e.preventDefault();
        var userId = $('#user-buyer-quotes').data('id');
        var href = $(this).attr('href') + '&userId=' + userId;

        $.get(href, function (data) {
            $('#tab-user-buyer-quotes-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-buyer-quotes-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });
});