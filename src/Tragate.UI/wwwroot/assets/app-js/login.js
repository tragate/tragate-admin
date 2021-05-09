$(function () {
    $("#btnLogin").on("click", function (e) {
        e.preventDefault();
        $("span.text-danger").text("");

        var form = $("#loginForm");
        $.validator.unobtrusive.parse(form);
        form.validate();
        
        if (form.valid()) {
            $(this).prop('disabled', true);
            $(this).text("Saving");

            $.ajax({
                url: "/Account/Login",
                method: "POST",
                data: form.serialize(),
                dataType: "json"
            }).done(function (data, status) {
                if (data.success) {
                    window.location.href = getParameterByName("ReturnUrl");
                } else {
                    var html = "<ul class=\"ulErrors\">";
                    $("#btnLogin").text("Save");
                    $("#btnLogin").removeAttr("disabled");
                    data.errors.forEach(element => {
                        html += "<li>" + element + "</li>";
                    });
                    html += "</ul>"
                    $("#result").html(html);
                    $("#result").css("color", "red");
                }
            });
        }
        return false;
    });
});


function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return "";
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}