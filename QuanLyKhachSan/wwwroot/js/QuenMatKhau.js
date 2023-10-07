$(document).ready(function () {
    // Handle the Send Email button click
    $('#sendEmail').click(function () {
        var email = $('#email').val();
        $.post("/QuenMatKhau/GuiMail", { Email: email }, function (data) {
            if (data.success) {
                // Show the next step
                $('#step1').hide();
                $('#step2').show();
            } else {
                // Show an error message
                $('#message').text(data.message);
            }
        });
    });

    // Handle the Confirm Code button click
    $('#confirmCode').click(function () {
        var confirmId = $('#confirmId').val();
        $.post("/QuenMatKhau/XacNhanMa", { ConfirmId: confirmId }, function (data) {
            if (data.success) {
                // Show the next step
                $('#step2').hide();
                $('#step3').show();
            } else {
                // Show an error message
                $('#message').text(data.message);
            }
        });
    });

    // Handle the Reset Password button click
    $('#resetPassword').click(function () {
        var newPassword = $('#newPassword').val();

        $.post("/QuenMatKhau/DoiMatKhau", { NewPassword: newPassword }, function (data) {
            if (data.success) {
                // Show a success message
                $('#message').text('Mật khẩu đã được đặt lại thành công!');
            } else {
                // Show an error message
                $('#message').text(data.message);
            }
        });
    });
});
