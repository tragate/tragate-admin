$(document).ready(function () {
    if (GetParameterByName('status') != null) {
        $("#status").val(GetParameterByName('status'));
    }
    else {
        $("#status").val(1);
    }


    //$("#searchBtn").click(function () {
    //    var url = window.location.href;
    //    var searchKey = $("#txtSearch").val();

    //    window.location = SetQueryStringParameter(url, 'searchKey', searchKey);
    //});


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

    $('.delete').on('click', function (e) {
        var url = $(this).data('url');
        var title = $(this).data('title');
        $('.modal-content #container-title').html(title);
        $.get(url, function (data) {
            $('.modal-content #container').html(data);
        }).fail(function () {
            $('.modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
        });
    });

    $('.update-lg').on('click', function (e) {
        var url = $(this).data('url');
        var title = $(this).data('title');
        $('#updateModal-lg .modal-lg .modal-content #container-title').html(title.trim());
        $.get(url, function (data) {
            $('#updateModal-lg .modal-content #container').html(data);
        }).done(function () {
            SetPresentInformation();
            GetBusinessType();
            GetEmployeeCountType();
            GetAnnualRevenueType();
            GetCity();
            GetSimilarCompanies();
            GetSimilarCompanyData();
        }).fail(function () {
            $('#updateModal-lg .modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
        });
    });

    $('#updateModal').on('hidden.bs.modal', function () {
        $(this).find("#container").html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
    });
});

function GetSimilarCompanyData() {
    var name = $("#title").data("title").split(' ')[0];
    $(".small-search").val(name);
    $.get("/companydata/search-similar?name=" + name, function (data) {
        $('#similars-data').html(data);
    }).done(function () {

    }).fail(function () {
        $('#similars-data').html("<p style=\"text-align:center;\">No content</p>");
    });
}

function GetSimilarCompanies() {
    var name = $("#title").data("title").split(' ')[0];
    $.get("/company/search-similar?name=" + name, function (data) {
        $('#similars').html(data);
    }).done(function () {

    }).fail(function () {
        $('#similars').html("<p style=\"text-align:center;\">No content</p>");
    });
}

function SetPresentInformation() {
    var title = $("#title").data("title");
    var description = $("#ProfileDescription").val();
    var profileImagePath = $("#profileImagePath").val();
    var address = $("#address").data("address");
    var email = $("#contact-email").val();
    var phone = $("#contact-phone").val();
    var website = $("#contact-website").val();

    $("#txtProfileImagePath").val(profileImagePath);
    $("#username").val(title.trim());
    $("#txtDescription").val(description);
    $("#txtAddress").val(address);

    $("#txtWebsite").val(website);
    $("#txtEmail").val(email);
    $("#txtPhone").val(phone);
}

function GetCity() {

    $("#ddlLocation").append($("<option />").val("-1").text("Loading..."));

    $.get("/common/location?parentId=1", function (data) {
        if (data == null)
            GetCity();

        if (data.success) {
            $("#ddlLocation").empty();

            $.each(data.data, function () {
                $("#ddlLocation").append($("<option />").val(this.id).text(this.name));
            });

            //set city selected
            var city = $("#city").data("city");
            city = ChangeTurkishChar(city);
            $("#ddlLocation > option").each(function () {
                if (this.text == city) {
                    $(this).attr('selected', true);
                }
            });

        } else {
            var html = "<ul class=\"ulErrors\">";
            $("#btnTransfer").text("Save");
            $("#btnTransfer").removeAttr("disabled");
            data.errors.forEach(element => {
                html += "<li>" + element + "</li>";
            });
            html += "</ul>"
            $("#result").html(html);
            $("#result").css("color", "red");
        }
    }).fail(function () {
        GetCity();
    });
}

function ChangeTurkishChar(str) {
    var charMap = {
        Ç: 'C',
        Ö: 'O',
        Ş: 'S',
        İ: 'I',
        I: 'I',
        Ü: 'U',
        Ğ: 'G',
        ç: 'c',
        ö: 'o',
        ş: 's',
        ı: 'i',
        ü: 'u',
        ğ: 'g'
    };

    str_array = str.split('');

    for (var i = 0, len = str_array.length; i < len; i++) {
        str_array[i] = charMap[str_array[i]] || str_array[i];
    }

    str = str_array.join('');

    var clearStr = str.replace(/[çöşüğı]/gi, "");

    return clearStr;
}

function GetBusinessType() {

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
        } else {
            var html = "<ul class=\"ulErrors\">";
            $("#btnTransfer").text("Save");
            $("#btnTransfer").removeAttr("disabled");
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
        } else {
            var html = "<ul class=\"ulErrors\">";
            $("#btnTransfer").text("Save");
            $("#btnTransfer").removeAttr("disabled");
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
        } else {
            var html = "<ul class=\"ulErrors\">";
            $("#btnTransfer").text("Save");
            $("#btnTransfer").removeAttr("disabled");
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



