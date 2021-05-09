

$(function () {
    $('ul.pagination li a').on('click', function (e) {
        e.preventDefault();
        var userId = $('#user-task').data('id');
        var href = $(this).attr('href') + '&userId=' + userId;

        $.get(href, function (data) {
            $('#tab-user-task-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-user-task-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });
});
