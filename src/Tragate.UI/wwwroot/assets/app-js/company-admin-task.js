
var userId = 0;
var companyId = 0;

$(function () {
    $('#taskModal').on('show.bs.modal', function (e) {
        //$('#detailModal-lg').modal('hide');
        var btn = $(e.relatedTarget);
        userId = btn.data('user-id');
        companyId = btn.data('company-id');
    });

    $.get('/common/company-task-type', function (result) {
        $('#ddlTaskType').append($('<option />').val(-1).text('Seçiniz...'));
        $.each(result, function () {
            $('#ddlTaskType').append($('<option />').val(this.id).text(this.value));
        });
    });

    $('#btnSaveTask').on('click', function () {
        var task = $('#txtTask').val();
        var taskType = $('#ddlTaskType').val();

        $.post('company/add-company-task', {
            'Description': task, 'ResponsibleUserId': userId, 'CompanyId': companyId, 'CompanyTaskTypeId': taskType
        }, function (data) {
            if (data !== null) {
                if (data.success) {
                    toastr.success(data.message);
                    $('#taskModal').modal('hide');
                    if (companyId != 0 && companyId != null && companyId != "" && companyId != undefined) {
                        $('#detailModal-lg').modal('show');
                        var url = '/company/company-details/' + companyId;
                        var title = 'Firma Detay';
                        $('#detailModal-lg .modal-lg .modal-content #container-title').html(title);
                        $.get(url, function (result) {
                            $('#detailModal-lg .modal-content #container').html(result);
                        }).fail(function () {
                            $('#detailModal-lg .modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
                        });
                    }
                    else {
                        location.reload();
                    }
                }
                else {
                    toastr.error(data.error[0]);
                }
            }
            else {
                toastr.error("İşleminiz gerçekleştirilemedi.");
            }
        });
    });
});

