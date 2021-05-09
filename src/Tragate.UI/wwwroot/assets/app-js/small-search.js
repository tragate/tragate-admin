$(function(){

    $(".refresh-search").on("click",function(){
        var mode = $(this).data("id");
        var name = "";
        var url ="";
        var target;      
        if (mode === 0) {
            name = $("#companyDataSearch").val();
            url = "/companydata/search-similar?name="+name;
            target = $('#similars-data');
        }
        else{
            name = $("#companySearch").val();
            url = "/company/search-similar?name="+name;
            target = $('#similars');
        }

        target.html("<i class=\"fa fa-refresh fa-spin\" style=\"font-size:25px; margin-left:48%;\"></i>");
        $.get(url, function (data) {
            target.html(data);
        }).done(function(){
            
        }).fail(function() {
            target.html("<p style=\"text-align:center;\">No content</p>");
        });
    });

    $(document).on("click",".companydata-similar-link",function() {
        var name = $("#companyDataSearch").val();
        var link = "/companydata/list-all?searchKey="+name;
        window.open(link);
    });
})