const container = document.getElementById('container');
const registerBtn = document.getElementById('register');
const loginBtn = document.getElementById('login');
const forgotPw = document.getElementById('Forgot_Password');
const toggleLeft = document.querySelector('.toggle-right');
const toggleRight = document.querySelector('.toggle-right');
const ValidateTkLogin = document.getElementById('ValidateTkLogin');
const ValidateMkLogin = document.getElementById('ValidateMkLogin');
registerBtn.addEventListener('click', () => {
    ValidateTkLogin.textContent = null;
    ValidateMkLogin.textContent = null;


    container.classList.add("active");
});

loginBtn.addEventListener('click', () => {
    container.classList.remove("active");
});

forgotPw.addEventListener('click', (e) => {
    e.preventDefault(); // prevent the default action
    //xóa dữ liệu kiểm lỗi login
    ValidateTkLogin.textContent = null;
    ValidateMkLogin.textContent = null;


    container.classList.add("forgot");
    toggleLeft.innerHTML = `
        <h1>Welcome A$AP ROYAL</h1>
        <p>Nhập tài khoản & mật khẩu của bạn để sử dụng tất cả các tính năng của trang web</p>
        <button class="hidden" id="new-login">ĐĂNG NHẬP</button>
    `;

    // Add a click event for the new "Sign In" button
    const newLoginBtn = document.getElementById('new-login');
    newLoginBtn.addEventListener('click', () => {
        //xóa dữ liệu kiểm lỗi login
        ValidateTkLogin.textContent = null;
        ValidateMkLogin.textContent = null;
   

        container.classList.remove("forgot");
        toggleRight.innerHTML = `
            <h1>Welcome A$AP ROYAL</h1>
            <p>Đăng ký với thông tin cá nhân của bạn để sử dụng tất cả các tính năng của trang web</p>
            <button class="hidden" id="new-register">ĐĂNG KÝ</button>
        `;

        // Add a click event for the new "Register" button
        const newRegisterBtn = document.getElementById('new-register');
        newRegisterBtn.addEventListener('click', () => {
              //xóa dữ liệu kiểm lỗi login
            ValidateTkLogin.textContent = null;
            ValidateMkLogin.textContent = null;

            container.classList.add("active");
        });
    });
});


$(document).ready(function () {
    $("#formDangKy").submit(function (event) {
        event.preventDefault(); // ngăn chặn việc submit form theo cách thông thường
        $.ajax({
            url: '/Login/DangKy', // đường dẫn đến action DangKy trong controller của bạn
            type: 'POST',
            data: $(this).serialize(), // lấy dữ liệu từ form
            success: function (data) {
                if (data.success) {
                    // Chuyển hướng người dùng hoặc làm gì đó khác
                    window.location.href = "/Login/Index";
                } else {
                    // Hiển thị thông báo lỗi ngay dưới ô input tương ứng
                    if (data.field === "TenDangNhap") {
                        $("#input_Tk_Register").after('<span style="color:red;" id="error_Tk_Register">' + data.message + '</span>');
                    }
                    if (data.field === "Email") {
                        $("#input_Email_Register").after('<span style="color:red;" id="error_Email_Register">' + data.message + '</span>');
                    }
                    if (data.field === "MatKhau") {
                        $("#input_Mk_Register").after('<span style="color:red;" id="error_Mk_Register">' + data.message + '</span>');
                    }
                }
            }
        });
    });

    // Xóa thông báo lỗi khi người dùng nhập vào ô input
    $("#input_Tk_Register").keyup(function () {
        $("#error_Tk_Register").remove();
    });
    $("#input_Email_Register").keyup(function () {
        $("#error_Email_Register").remove();
    });
    $("#input_Mk_Register").keyup(function () {
        $("#error_Mk_Register").remove();
    });
});

//$(document).ready(function () {
//    $("#formQuenMatKhau").submit(function (event) {
//        event.preventDefault();
//        $.ajax({
//            url: '/Login/GuiMail',
//            type: 'POST',
//            data: $(this).serialize(),
//            success: function (data) {
//                if (data.success) {
//                    window.location.href = "Login/Index";
//                } else {
//                    if (data.field === "EmailForgotPassword") {
//                        $("#email_input").after('<span style="color:red;" id="error_Email_ForgotPassword">' + data.message + '</span>');
//                    }
//                }
//            }
//        });
//    });

//});