
$(function () {
    $('#product').on('click', function () {
        var companyId = $(this).data('id');
        $('#tab-product-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
        $.get('/company/company-products?companyId=' + companyId, function (data) {
            $('#tab-product-wrapper').html(data);
        }).done(function () {
        }).fail(function () {
            $('#tab-product-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
        });
    });
});