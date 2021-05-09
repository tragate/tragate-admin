$(function () {
    if(getParameterByName('detail') != null){
        var id = getParameterByName("company-data");
        $("#updateModal-lg").modal('show');
        getDetail("companydata/edit-companydata/"+id, "Firma Transfer");
    }

    $(".transfer").click(function (e) {
        e.preventDefault();
        var statusId=$(this).data("id");

        if($('.chbPatchCompany[name="company"]').is(':checked')){
            var id = $("#Id").val();
            companyId = $('input[name=company]:checked').val();
            type="Patch";
            url = "/companydata/edit-companydata/" +id+"/"+companyId;

            $(this).prop('disabled', true);
            $.ajax({
                type: type,
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message)
                        setTimeout(function(){location.reload();}, 2000);
                    } else {
                        toastr.error("İşleminiz gerçekleştirilemedi")
                        $(this).prop('disabled', false);
                    }
                },
                error: function(){
                    toastr.error("İşleminiz gerçekleştirilemedi");
                    $(this).prop('disabled', false);
                    $("#btnTransfer").removeAttr('disabled');
                }
            });
        }
        else
        {
            $("#statusId").val(statusId);
            var form = $("#updateForm");
            $.validator.unobtrusive.parse($('#updateForm'));
            form.validate();
            if (form.valid() && CheckMultiSelectValidity()) {
                $(this).prop('disabled', true);
                var formdata = form.serialize();

                $.ajax({
                    method: "POST",
                    url: "/companydata/edit-companydata",
                    data: formdata,
                    success:function (data, status) {
                        if (data.success) 
                        {
                            toastr.success(data.message)
                            setTimeout(function(){location.reload();}, 2000);
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
            }
        }
        return false;
    });

    $("#btnCancel").click(function (e) {
        var type="Delete";
        var id = $("#Id").val();
        var url = "/companydata/edit-companydata/" +id;
        
        $(this).prop('disabled', true);
        $.ajax({
            type: type,
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message)
                    setTimeout(function(){location.reload();}, 2000);
                } else {
                    toastr.error("İşleminiz gerçekleştirilemedi")
                    $(this).prop('disabled', false);
                }
            },
            error: function(){
                toastr.error("İşleminiz gerçekleştirilemedi");
                $(this).prop('disabled', false);
                $("#btnTransfer").removeAttr('disabled');
            }
        });
    });

    $('#updateModal-lg').on('hidden.bs.modal', function () {
        $(this).find("#container").html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
    });
});

function CheckMultiSelectValidity(){
    var count =0;
    if($("#categories").val() == "")
    {
        $("#CategoryIdsValidation").html("Zorunlu alan");
        count++;
    }

    if($("#ddlBusinessType").val() == "")
    {
        $("#BusinessTypeListValidation").html("Zorunlu alan");
        count++;
    }
    
    return count == 0;

}
function readURL(input) {

    if (input.files && input.files[0]) {
      var reader = new FileReader();
  
      reader.onload = function(e) {
        $('#imgReviewer').attr('src', e.target.result);
      }
  
      reader.readAsDataURL(input.files[0]);
    }
 }
  

 function SelectValid() {
    var businessType = $("#ddlBusinessType");
    var countryId = $("#ddlCountry");
    var stateId = $("#ddlState");
    var count = 0;

    if (businessType.val() == "-1") {
        $(businessType).closest("div.form-group").find("span.text-danger").text("Business type is required");
        count++;
    }

    if (countryId.val() == "-1") {
        $(countryId).closest("div.form-group").find("span.text-danger").text("Country is required");
        count++;
    }

    if (stateId.val() == "-1") {
        $(stateId).closest("div.form-group").find("span.text-danger").text("State is required");
        count++;
    }

    return count == 0;

}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function getDetail(url, title){
    
    $('#updateModal-lg .modal-lg .modal-content #container-title').html(title);
    $.get(url, function (data) {
        $('#updateModal-lg .modal-content #container').html(data);
    }).fail(function() {
        $('#updateModal-lg .modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
    });
}

