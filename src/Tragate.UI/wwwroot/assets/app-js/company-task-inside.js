
$(function () {
    $('ul.pagination li a').on('click', function (e) {
        e.preventDefault();
        var companyId = $('#task').data('id');
        var href = $(this).attr('href') + '&companyId=' + companyId;

        $.get(href, function (data) {
            $('#tab-task-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-task-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });

});