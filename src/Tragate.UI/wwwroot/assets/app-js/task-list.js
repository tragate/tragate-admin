
$(function () {
    $.get('/common/get-status', function (data) {
        $('#status').append($('<option />').val(0).text('Hepsi'));
        $.each(data, function () {
            $('#status').append($('<option />').val(this.id).text(this.value));
        });
    }).done(function () {
        if (GetParameterByName('status') !== null) {
            $("#status").val(GetParameterByName('status'));
        }
        else {
            $("#status").val(3);
        }
    });

    $.get('/company-task/get-admin-user-list', function (data) {
        $('#created-user').append($('<option />').val(0).text('Tümü'));
        $.each(data, function () {
            $('#created-user').append($('<option />').val(this.id).text(this.name));
        });
    }).done(function () {
        if (GetParameterByName('createduser') !== null) {
            $('#created-user').val(GetParameterByName('createduser'));
        }
    });

    $.get('/company-task/get-admin-user-list', function (data) {
        $.each(data, function () {
            $('#responsible-user').append($('<option />').val(this.id).text(this.name));
        });
    }).done(function () {
        if (GetParameterByName('responsibleuser') !== null) {
            $('#responsible-user').val(GetParameterByName('responsibleuser'));
        }
    });

    $('.detail-lg').on('click', function (e) {
        getDetail($(this).data('url'), $(this).data('title'));
    });



    $('#created-user').change(function () {
        var url = window.location.href;
        var createdUser = $(this).val();

        window.location = SetQueryStringParameter(url, 'createduser', createdUser);
    });

    $('#responsible-user').change(function () {
        var url = window.location.href;
        var responsibleUser = $(this).val();

        window.location = SetQueryStringParameter(url, 'responsibleuser', responsibleUser);
    });

    $('#status').change(function () {
        var url = window.location.href;
        var status = $(this).val();

        window.location = SetQueryStringParameter(url, 'status', status);
    });
});

function CompanyTaskStatusUpdate(taskId) {

    if (!confirm('İşlemi yapmak istediğinize emin misiniz?')) {
        return false;
    }

    $.post('company-task/task-status-change',
        { 'TaskId': taskId }, function (data) {

            if (data != null) {
                if (data.success) {
                    toastr.success(data.message);
                    location.reload();
                }
                else {
                    toastr.error(data.errors[0]);
                }
            }
            else {
                toastr.error("İşleminiz gerçekleşmedi.");
            }
        });
}

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

function getDetail(url, title) {
    $('#detailModal-lg .modal-lg .modal-content #container-title').html(title);
    $.get(url, function (data) {
        $('#detailModal-lg .modal-content #container').html(data);
    }).fail(function () {
        $('#detailModal-lg .modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
    });
}

