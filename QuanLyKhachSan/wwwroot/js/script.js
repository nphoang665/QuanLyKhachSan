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
        <h1>Welcome Back!</h1>
        <p>Enter your personal details and start journey with us</p>
        <button class="hidden" id="new-login">Sign In</button>
    `;

    // Add a click event for the new "Sign In" button
    const newLoginBtn = document.getElementById('new-login');
    newLoginBtn.addEventListener('click', () => {
        container.classList.remove("forgot");
        toggleRight.innerHTML = `
            <h1>Hello, Friend!</h1>
            <p>Register with your personal details to use all of site features</p>
            <button class="hidden" id="new-register">Sign Up</button>
        `;

        // Add a click event for the new "Register" button
        const newRegisterBtn = document.getElementById('new-register');
        newRegisterBtn.addEventListener('click', () => {
            container.classList.add("active");
        });
    });
});
