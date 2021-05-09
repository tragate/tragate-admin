$(function(){
    $("ul.pagination li a").on("click", function(e){

        e.preventDefault();

        var id = $("#supervisor").data('id');
        var href =$(this).attr("href") + "&companyId=" + id;
        //"/company/company-admins?companyId="+id+"&page="+ $(this).text();

        $.get(href, function (data) {
            $('#tab-superv-wrapper').html(data);
        }).done(function(){
            
        }).fail(function() {
            $('#tab-superv-wrapper').html("<p style=\"text-align:center;\">No content</p>");
        });
    });

    $("#btnAddAdmin").on("click", function(e){
        var _this = $(this);
        $(this).prop('disabled', true);
        
        var companyId = $(this).data("companyid");
        var email = $("#txtEmail").val();
        if(!validateEmail(email)){
            alert("Lütfen geçerli bir email giriniz!");
            $(this).prop('disabled', false);
            return false;
        }

        $.post("company/add-company-admins", {companyId:companyId, email:email}, function (data) {
            _this.prop('disabled', false);
            _this.removeAttr("disabled");
            
            if (data.success) {
                toastr.success(data.message);

                $.get("/company/company-admins?companyId="+companyId, function (data) {
                    $('#tab-superv-wrapper').html(data);
                }).done(function(){
                }).fail(function() {
                    $('#tab-superv-wrapper').html("<p style=\"text-align:center;\">No content</p>");
                });
                
            } else {
                toastr.error("İşleminiz gerçekleştirilemedi");
            }
        });
    });
})

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}