$(function () {

    $("#btnCreate").click(function (e) {
        e.preventDefault();
        var form = $("#createForm");
        $.validator.unobtrusive.parse($('#createForm'));
        form.validate();
        if (form.valid()) {
            $(this).prop('disabled', true);
            $.post("company/create", form.serialize(), function (data) {
                if (data.success) {
                    toastr.success(data.message)
                    location.reload();
                } else {
                    toastr.error("İşleminiz gerçekleştirilemedi")
                    $(this).prop('disabled', false);
                }
            });
        }
        return false;
    });

    $("#btnUpdate").click(function (e) {
        e.preventDefault();
        var form = $("#updateForm");
        $.validator.unobtrusive.parse($('#updateForm'));
        form.validate();
        if (form.valid()) {
            $(this).prop('disabled', true);
            $.post("company/edit-company", form.serialize(), function (data) {
                if (data.success) {
                    toastr.success(data.message)
                    location.reload();
                } else {
                    toastr.error("İşleminiz gerçekleştirilemedi")
                    $(this).prop('disabled', false);
                }
            });
        }
        return false;
    });
});




