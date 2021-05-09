$(function(){

    if(getParameterByName('detail') != null){
        var id = getParameterByName("company");
        $("#detailModal-lg").modal('show');
        getDetail("/company/company-details/"+id, "Firma Düzenle");
    }

    $('.detail-lg').on('click', function (e) {
        getDetail($(this).data('url'), $(this).data('title'));
    });

    $('#detailModal-lg').on('hidden.bs.modal', function () {
        //$(this).find("#container").html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
    });

    $('#detailModal-lg').on('shown.bs.modal', function () {
        $("body").addClass('modal-open');
    });
});

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
    
    $('#detailModal-lg .modal-lg .modal-content #container-title').html(title);
    $.get(url, function (data) {
        $('#detailModal-lg .modal-content #container').html(data);
    }).fail(function() {
        $('#detailModal-lg .modal-content #container').html("<p style=\"text-align:center;\">No content</p>");
    });
}
// .modal-open .modal