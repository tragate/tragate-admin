
$(document).ready(function () {
    $('.userDetail').on('click', function (e) {
        var mData = $(this).data();
        $(mData.target).find('.modal-content #container-title').html(mData.title);
        $.get(mData.url, function (data) {
            $(mData.target).find('.modal-content #container').html(data);
        }).fail(function () {
            $(mData.target).find('.modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
        });
    });
});  