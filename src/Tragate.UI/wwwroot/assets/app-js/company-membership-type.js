
$(function () {
    $.get('/common/get-membership-type', function (result) {
        $('#ddlMembershipType').append($('<option />').val(-1).text('Seçiniz...'));
        $.each(result, function () {
            $('#ddlMembershipType').append($('<option />').val(this.id).text(this.value));
        });
    });

    $.get('/common/get-membership-package-type', function (result) {
        $('#ddlMembershipPackageType').append($('<option />').val(-1).text('Seçiniz...'));
        $.each(result, function () {
            $('#ddlMembershipPackageType').append($('<option />').val(this.id).text(this.value));
        });
    });

    $('#btnMembershipPackageUpdate').on('click', function () {
        var _this = $(this);
        $(this).prop('disabled', true);

        var companyId = $('#membership').data('id');
        var membershipType = $('#ddlMembershipType').val();
        var membershipPackage = $('#ddlMembershipPackageType').val();
        var startDate = $('#startDate').val();
        var endDate = $('#endDate').val();

        $.post('company/update-membership', { 'CompanyId': companyId, 'MembershipTypeId': membershipType, 'MembershipPackageId': membershipPackage, 'StartDate': startDate, 'EndDate': endDate }, function (result) {
            _this.prop('disabled', false);
            _this.removeAttr("disabled");
            if (result != null) {
                if (result.success) {
                    toastr.success(result.message);
                }
                else {
                    toastr.error(result.errors[0]);
                }
            }
            else {
                toastr.error("İşleminiz gerçekleşmedi.");
            }

        });
    });
});