$(function(){

    $("#supervisor").on("click",function(){
        var id = $(this).data('id');
        $('#tab-superv-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
        $.get("/company/company-admins?companyId="+id, function (data) {
            $('#tab-superv-wrapper').html(data);
        }).done(function(){
            
        }).fail(function() {
            $('#tab-superv-wrapper').html("<p style=\"text-align:center;\">No content</p>");
        });
    });


    $(document).on("click",".go-child",function() {
        $(".child").remove();
        var id = $(this).data("id");
        var tr= $(this).closest("tr");
        var html = "";
        $.ajax({
            method: "GET",
            url: "/companydata/get-companydata/"+id,
            success:function (result, status) {
                if (result.success) 
                {
                    html +="<tr class=\"child\" style=\"height:200px; background:#efefef;\">";
                    html +="<td colspan=\"4\">";
                    html +="<div>";
                    html +="<table class=\"table\">";
                    html +="<tr>";
                    html +="<td><label>İlgili Kişi</label></td>";
                    html +="<td>"+result.data.contactPerson+"</td>";
                    html +="</tr>";

                    html +="<tr>";
                    html +="<td><label>Kategori</label></td>";
                    html +="<td>"+result.data.category+"</td>";
                    html +="</tr>";

                    html +="<tr>";
                    html +="<td><label>Sertifika</label></td>";
                    html +="<td>"+result.data.certificate+"</td>";
                    html +="</tr>";
                    
                    html +="<tr>";
                    html +="<td><label>Şirket ve Marka</label></td>";
                    html +="<td>"+result.data.releatedCompanyAndBrand+"</td>";
                    html +="</tr>";
                   
                    html +="</div>";
                    html +="</tr>";
                    
                    tr.after(html).slideDown("fast");
                } 
                else {
                    toastr.error("İşleminiz gerçekleştirilemedi");
                    $(this).prop('disabled', false);
                    $(".transfer").removeAttr('disabled');
                }
            }
        }).fail(function(){
            toastr.error("İşleminiz gerçekleştirilemedi");
            $(this).prop('disabled', false);
            $(".transfer").removeAttr('disabled');
        });

    });
    
    $(document).on("click",".delete-data",function() {

        var result = confirm("Emin misiniz?");

        if(!result){
            return false;
        }

        $(".child").remove();
        var id = $(this).data("id");
        var tr= $(this).closest("tr");
        var html = "";
        $.ajax({
            method: "GET",
            url: "/companydata/delete-companydata/"+id,
            success:function (result, status) {
                if (result.success) 
                {
                    tr.fadeOut();
                } 
                else {
                    toastr.error("İşleminiz gerçekleştirilemedi");
                    $(this).prop('disabled', false);
                    $(".transfer").removeAttr('disabled');
                }
            }
        }).fail(function(){
            toastr.error("İşleminiz gerçekleştirilemedi");
            $(this).prop('disabled', false);
            $(".transfer").removeAttr('disabled');
        });

    });
    
})