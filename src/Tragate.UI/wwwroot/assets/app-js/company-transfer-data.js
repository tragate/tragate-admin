$(function () {
    $("#btnSimilarCompanySearch").on("click", function () {
        var name = "";
        var url = "";

        name = $("#txtSimilarSearch").val();
        url = "/company/get-similar-company-data-search?name=" + name;

        $('#similarCompanies').html("<i class=\"fa fa-refresh fa-spin\" style=\"font-size:25px; margin-left:48%;\"></i>");
        $.get(url, function (data) {
            $('#similarCompanies').html(data);
        }).done(function () {

        }).fail(function () {
            $('#similarCompanies').html("<p style=\"text-align:center;\">No content</p>");
        });
    });
});

function CompanyDataMatch(id, title) {
    var companyId = $('#extra').data('id');
    var name = title.trim().split(' ')[0];
    //console.log(id, companyId);

    $.post('company/update-company-data-match', { 'Id': id, 'CompanyId': companyId }, function (data) {

        if (data.success) {
            toastr.success(data.message);
            GetSimilarCompanyData();
            GetReferenceData(companyId);
        }
        else {
            toastr.error("İşleminiz gerçekleştirilemedi.");
        }
    });
}

$(function () {
    $("#extra").on("click", function () {
        var id = $(this).data('id');
        $('#tab-extra-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
        $.get("/companydata/get-data-ref?referenceUserId=" + id, function (data) {
            $('#tab-extra-wrapper').html(data);
        }).done(function () {
            GetSimilarCompanyData();
        }).fail(function () {
            $('#tab-superv-wrapper').html("<p style=\"text-align:center;\">No content</p>");
        });
    });
});
function GetReferenceData(companyId) {
    $.get('/companydata/get-data-ref?referenceUserId=' + companyId, function (data) {
        $('#tab-extra-wrapper').html(data);
    }).done(function () {
    }).fail(function () {
        $('#tab-extra-wrapper').html('<p style=\"text-align:center;\">İçerik Yok.</p>');
    });
}

function GetSimilarCompanyData() {
    var name = $("#companyTitle").data("title").split(' ')[0];
    $("#txtSimilarSearch").val(name);
    $.get("/company/get-similar-company-data-search?name=" + name, function (data) {
        $('#similarCompanies').html(data);
    }).done(function () {

    }).fail(function () {
        $('#similarCompanies').html("<p style=\"text-align:center;\">No content</p>");
    });
}
