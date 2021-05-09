
$(function () {
    $('#note').on('click', function () {
        var companyId = $(this).data('id');
        $('#tab-note-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');

        $.get('/company/company-notes?companyId=' + companyId, function (data) {
            $('#tab-note-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-note-wrapper').html("<p style=\"text-align:center;\">İçerik bulunmamaktadır...</p>");
        });
    });

    $('#btnAddNote').on('click', function (e) {
        var _this = $(this);
        $(this).prop('disabled', true);

        var companyId = $(this).data('companyid');
        var note = $('#txtNote').val();

        $.post('/company/add-company-note', { 'Description': note, 'CompanyId': companyId },
            function (data) {
                _this.prop('disabled', false);
                _this.removeAttr("disabled");
                if (data != null) {
                    if (data.success) {
                        $('#txtNote').val('');
                        toastr.success(data.message);

                        NoteList(companyId);

                    } else {
                        toastr.error(result.errors[0]);
                    }
                }
                else {
                    toastr.error('İşleminiz gerçekleşmedi.');
                }
            });
    });
});

function DeleteNote(noteId, companyId) {
    $.post('/company/delete-note', { 'noteId': noteId }, function (result) {
        if (result != null) {
            if (result.success) {
                toastr.success(result.message);

                NoteList(companyId);
            }
            else {
                toastr.error(result.errors[0]);
            }
        }
        else {
            toastr.error('İşleminiz gerçekleşmedi.');
        }
    });
}

function NoteList(companyId) {
    $.get("/company/company-notes?companyId=" + companyId, function (data) {
        $('#tab-note-wrapper').html(data);
    }).done(function () {
    }).fail(function () {
        $('#tab-note-wrapper').html("<p style=\"text-align:center;\">İçerik bulunmamaktadır...</p>");
    });
}