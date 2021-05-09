
$(function () {

    $("#file").on("change", function () {
        ReadURL(this);
    });

    var verificationId = $('#ddlVerificationType').data('id');
    $.get('/common/get-verification-type', function (result) {
        $.each(result, function () {
            $('#ddlVerificationType').append($('<option />').val(this.id).text(this.value));
        });
        if (verificationId != null && verificationId != "") {
            $("#ddlVerificationType").val(verificationId);
        }
    });

    $("#btnAddCompany").on("click", function (e) {
        var url = "";
        var mode = $("#mode").val();
        e.preventDefault();
        var form = $("#createForm");
        $.validator.unobtrusive.parse($('#createForm'));
        form.validate();
        if (form.valid()) {
            $(this).prop('disabled', true);
            var formdata = form.serialize();

            if (mode == "c")
                url = "/company/create";
            else
                url = "/company/edit-company";

            $.post(url, formdata, function (data, status) {
                $(this).prop('disabled', false);
                $("#btnAddCompany").removeAttr('disabled');
                if (data.success) {
                    toastr.success(data.message);
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                } else {
                    toastr.error("İşleminiz gerçekleştirilemedi");

                }
            }).fail(function () {
                toastr.error("İşleminiz gerçekleştirilemedi");
                $(this).prop('disabled', false);
                $("#btnAddCompany").removeAttr('disabled');
            });
        }
        return false;
    });

    $('#ddlCountry').on('change', function (e) {
        var id = $(this).val();
        GetCity(id);
    });

    $('#createModal').on('hidden.bs.modal', function () {
        $(this).find("#container").html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
    });

    $('#createModal').on('shown.bs.modal', function () {
        $("body").addClass('modal-open');
    });

});

function GetCity(id) {
    var cityId = $("#ddlCity").data("id");
    $("#ddlCity").append($("<option />").val("-1").text("Loading..."));

    $.get("/common/location?parentId=" + id, function (data) {
        if (data == null)
            GetCity(id);

        if (data.success) {
            $("#ddlCity").empty();

            $.each(data.data, function () {
                $("#ddlCity").append($("<option />").val(this.id).text(this.name));
            });

            if (cityId != null && cityId != "") {
                $("#ddlCity").val(cityId);
            }

        } else {
            var html = "<ul class=\"ulErrors\">";
            $("#btnAddCompany").text("Save");
            $("#btnAddCompany").removeAttr("disabled");
            data.errors.forEach(element => {
                html += "<li>" + element + "</li>";
            });
            html += "</ul>"
            $("#result").html(html);
            $("#result").css("color", "red");
        }
    }).fail(function () {
        GetCity(id);
    });
}

function ReadURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {

            var link = e.target.result;

            if (link == "")
                link = "/assets/images/empty-profile.png";

            $('#imgReviewer').attr('src', link);
        }

        reader.readAsDataURL(input.files[0]);
    }
}


