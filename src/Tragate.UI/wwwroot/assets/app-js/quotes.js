

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
    $.get('/common/get-quote-status',
        function (data) {
            $('#quoteStatus').append($('<option/>').val(0).text('Hepsi'));
            $.each(data,
                function () {
                    $('#quoteStatus').append($('<option/>').val(this.id).text(this.value));
                });
        }).done(function () {
            if (GetParameterByName('quoteStatus') !== null) {
                $("#quoteStatus").val(GetParameterByName('quoteStatus'));
            } else {
                $("#quoteStatus").val(0);
            }
        });

    $('#quoteStatus').change(function () {
        var url = window.location.href;
        var status = $(this).val();

        window.location = SetQueryStringParameter(url, 'quoteStatus', status);
    });
});





function GetParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');

    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);

    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function SetQueryStringParameter(uri, key, value) {
    var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = uri.indexOf('?') !== -1 ? "&" : "?";
    if (uri.match(re)) {
        return uri.replace(re, '$1' + key + "=" + value + '$2');
    }
    else {
        return uri + separator + key + "=" + value;
    }
}