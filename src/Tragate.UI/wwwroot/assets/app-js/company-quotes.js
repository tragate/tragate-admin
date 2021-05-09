
$(function () {
    $('#buyer-quotes').on('click',
        function () {
            var companyId = $(this).data('id');
            $('#tab-buyer-quotes-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
            $.get('/company/company-buyer-quotes?companyId=' + companyId, function (data) {
                $('#tab-buyer-quotes-wrapper').html(data);
            }).done(function () {
            }).fail(function () {
                $('#tab-buyer-quotes-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
            });
        });

    $('#seller-quotes').on('click',
        function () {
            var companyId = $(this).data('id');
            $('#tab-seller-quotes-wrapper').html('<i class="fa fa-refresh fa-spin" style="font-size:50px; margin-left:48%;"></i>');
            $.get('/company/company-seller-quotes?companyId=' + companyId, function (data) {
                $('#tab-seller-quotes-wrapper').html(data);
            }).done(function () {
            }).fail(function () {
                $('#tab-seller-quotes-wrapper').html('<p style=\"text-align:center;\">İçerik bulunmamaktadır.</p>');
            });
        });
});