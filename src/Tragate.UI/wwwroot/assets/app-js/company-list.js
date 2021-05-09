

$(function () {
    if (GetParameterByName('status') != null) {
        $("#status").val(GetParameterByName('status'));
    }
    else {
        $("#status").val(3);
    }

    $.get('/common/get-category-group-type', function (result) {
        $('#categoryGroup').append($('<option />').val(-1).text('Hepsi'));
        $.each(result, function () {
            $('#categoryGroup').append($('<option />').val(this.id).text(this.value));
        });
    }).done(function () {
        if (GetParameterByName('categoryGroupId') != null) {
            $("#categoryGroup").val(GetParameterByName('categoryGroupId'));
        }
        else {
            $("#categoryGroup").val(-1);
        }
    });

    $('#categoryGroup').change(function () {
        var url = window.location.href;
        var categoryGroupId = $(this).val();

        window.location = SetQueryStringParameter(url, 'categoryGroupId', categoryGroupId);
    });
    

    $("#searchBtn").click(function (e) {
        e.preventDefault();
        var url = window.location.href;
        var searchKey = $("#txtSearch").val();

        window.location = SetQueryStringParameter(url, 'searchKey', searchKey);
        return false;
    });

    $('#status').change(function () {
        var url = window.location.href;
        var status = $(this).val();

        window.location = SetQueryStringParameter(url, 'status', status);
    });


    $('.create').on('click', function (e) {
        var url = $(this).data('url');
        var title = $(this).data('title');
        $('#createModal .modal-content #container-title').html(title);
        $.get(url, function (data) {
            $('#createModal .modal-content #container').html(data);
        }).done(function () {
            GetBusinessType();
            GetEmployeeCountType();
            GetAnnualRevenueType();
            GetCountry();
        }).fail(function () {
            $('#createModal .modal-content #container').html("<p style=\"text-align:center;\">Cannot load the view!</p>");
        });
    });

})

function GetCountry() {

    var countryId = $("#ddlCountry").data("id");

    $("#ddlCountry").append($("<option />").val("-1").text("Loading..."));

    $.get("/common/location", function (data) {
        if (data == null)
            GetCountry();

        if (data.success) {
            $("#ddlCountry").empty();

            $.each(data.data, function () {
                $("#ddlCountry").append($("<option />").val(this.id).text(this.name));
            });

            if (countryId != null && countryId != "") {
                $("#ddlCountry").val(countryId);
            }
            else {
                countryId = data.data[0].id;
            }

            GetCity(countryId);

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
        GetCountry();
    });
}

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

function GetBusinessType() {

    var businessId = $("#ddlBusinessType").data("id");
    $("#ddlBusinessType").append($("<option />").val("-1").text("Loading..."));

    $.ajax({
        url: "/common/business-type",
        method: "GET",
        dataType: "json",
        async: true
    }).done(function (data, status) {
        if (data == null)
            GetBusinessType();

        if (data.success) {
            $("#ddlBusinessType").empty();
            $.each(data.data, function () {
                $("#ddlBusinessType").append($("<option />").val(this.id).text(this.value));
            });

            if (businessId != null && businessId != "") {
                $("#ddlBusinessType").val(businessId);
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
        GetBusinessType();
    });
}

function GetEmployeeCountType() {
    var employeeCountId = $("#ddlEmployeeCount").data("id");

    $("#ddlEmployeeCount").append($("<option />").val("-1").text("Loading..."));

    $.ajax({
        url: "/common/employee-count",
        method: "GET",
        dataType: "json",
        async: true
    }).done(function (data, status) {
        if (data == null)
            GetEmployeeCountType();

        if (data.success) {
            $("#ddlEmployeeCount").empty();

            $.each(data.data, function () {
                $("#ddlEmployeeCount").append($("<option />").val(this.id).text(this.value));
            });

            if (employeeCountId != null && employeeCountId != "") {
                $("#ddlEmployeeCount").val(employeeCountId);
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
        GetEmployeeCountType();
    });
}

function GetAnnualRevenueType() {
    var annualRevenueTypeId = $("#ddlAnnualRevenue").data("id");

    $("#ddlAnnualRevenue").append($("<option />").val("-1").text("Loading..."));

    $.ajax({
        url: "/common/annual-revenue",
        method: "GET",
        dataType: "json",
        async: true
    }).done(function (data, status) {
        if (data == null)
            GetAnnualRevenueType();

        if (data.success) {
            $("#ddlAnnualRevenue").empty();
            $.each(data.data, function () {
                $("#ddlAnnualRevenue").append($("<option />").val(this.id).text(this.value));
            });
            if (annualRevenueTypeId != null && annualRevenueTypeId != "") {
                $("#ddlAnnualRevenue").val(annualRevenueTypeId);
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
        GetAnnualRevenueType();
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
