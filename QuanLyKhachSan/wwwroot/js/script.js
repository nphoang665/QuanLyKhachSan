const container = document.getElementById('container');
const registerBtn = document.getElementById('register');
const loginBtn = document.getElementById('login');
const forgotPw = document.getElementById('Forgot_Password');
const toggleLeft = document.querySelector('.toggle-right');
const toggleRight = document.querySelector('.toggle-right');

registerBtn.addEventListener('click', () => {
    container.classList.add("active");
});

loginBtn.addEventListener('click', () => {
    container.classList.remove("active");
});

forgotPw.addEventListener('click', (e) => {
    e.preventDefault(); // prevent the default action
    container.classList.add("forgot");
    toggleLeft.innerHTML = `
        <h1>Welcome A$AP ROYAL</h1>
        <p>Nhập tài khoản & mật khẩu của bạn để sử dụng tất cả các tính năng của trang web</p>
        <button class="hidden" id="new-login">ĐĂNG NHẬP</button>
    `;

    // Add a click event for the new "Sign In" button
    const newLoginBtn = document.getElementById('new-login');
    newLoginBtn.addEventListener('click', () => {
        container.classList.remove("forgot");
        toggleRight.innerHTML = `
            <h1>Welcome A$AP ROYAL</h1>
            <p>Đăng ký với thông tin cá nhân của bạn để sử dụng tất cả các tính năng của trang web</p>
            <button class="hidden" id="new-register">ĐĂNG KÝ</button>
        `;

        // Add a click event for the new "Register" button
        const newRegisterBtn = document.getElementById('new-register');
        newRegisterBtn.addEventListener('click', () => {
            container.classList.add("active");
        });
    });
});
