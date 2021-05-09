$(function () {
    $('#task').on('click', function () {
        var companyId = $(this).data('id');
        $('#tab-task-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
        $.get('/company/company-tasks?companyId=' + companyId, function (data) {
            $('#tab-task-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-task-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });


    $.get('/common/company-task-type', function (result) {
        $('#ddlTaskType').append($('<option />').val(-1).text('Seçiniz...'));
        $.each(result, function () {
            $('#ddlTaskType').append($('<option />').val(this.id).text(this.value));
        });
    });

    $.get('company/get-admin-user-list', function (result) {
        $('#ddlResponsibleUser').append($('<option />').val(-1).text('Seçiniz...'));
        $.each(result, function () {
            $('#ddlResponsibleUser').append($('<option />').val(this.id).text(this.name));
        });
    });

    $('#btnAddTask').on('click', function (e) {
        var _this = $(this);
        $(this).prop('disabled', true);

        var companyId = $(this).data('companyid');
        var task = $('#txtTask').val();
        var responsibleUserId = $('#ddlResponsibleUser').val();
        var taskTypeId = $('#ddlTaskType').val();


        $.post("company/add-company-task", {
            'Description': task, 'ResponsibleUserId': responsibleUserId, 'CompanyId': companyId, 'CompanyTaskTypeId': taskTypeId
        }, function (data) {
            _this.prop('disabled', false);
            _this.removeAttr("disabled");
            if (data != null) {
                if (data.success) {
                    $('#txtTask').val('');
                    $('#ddlResponsibleUser').val('');
                    $('#ddlTaskType').val('');
                    toastr.success(data.message);

                    TaskList(companyId);
                } else {
                    toastr.error(data.errors[0]);
                }
            }
            else {
                toastr.error("İşleminiz gerçekleşmedi.");
            }
        });
    });
});

function DeleteTask(taskId, companyId) {
    $.post('/company/delete-company-task', { 'taskId': taskId }, function (result) {
        if (result != null) {
            if (result.success) {
                toastr.success(result.message);

                TaskList(companyId);
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

function TaskList(companyId) {
    $.get("/company/company-tasks?companyId=" + companyId, function (data) {
        $('#tab-task-wrapper').html(data);
    }).done(function () {
    }).fail(function () {
        $('#tab-task-wrapper').html("<p style=\"text-align:center;\">İçerik Yok.</p>");
    });
}

