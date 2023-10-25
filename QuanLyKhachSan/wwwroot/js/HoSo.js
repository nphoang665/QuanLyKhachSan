var sections = ['Employee_Id', 'Pesonal_Information', 'Hotel_Account', 'Connected_Account', 'Login_Management'];
var navItems = document.querySelectorAll('.nav_account_manager li');

sections.forEach(function (sectionId, index) {
    var section = document.getElementById(sectionId);

    section.addEventListener('mouseover', function () {
        navItems[index].style.color = 'red';
    });

    section.addEventListener('mouseout', function () {
        navItems[index].style.color = '#b8b8b8';
    });
});
document.getElementById('Email_ipt').addEventListener('input', function (e) {
    var originalEmail = 'nhutbmt123321@gmail.com';
    var currentEmail = e.target.value;
    var saveButton = document.querySelector('.btn-save-infor');
    if (originalEmail !== currentEmail) {
        saveButton.style.backgroundColor = 'red';
        saveButton.style.color = 'white';
        saveButton.style.border = '1px solid red';
        saveButton.disabled = false;
    } else {
        saveButton.style.backgroundColor = '';
        saveButton.style.color = '';
        saveButton.style.border = '';
        saveButton.disabled = true;
    }
});

function checkInput() {
    var currentPwd = document.getElementById('current-pwd_ipt').value;
    var newPwd = document.getElementById('new-pwd_ipt').value;
    var confirmNewPwd = document.getElementById('confirm-new-pwd_ipt').value;
    var saveButton = document.querySelector('.btn-save-account');

    if (currentPwd === '' || newPwd === '' || confirmNewPwd === '') {
        saveButton.disabled = true;
        saveButton.style.backgroundColor = '';
        saveButton.style.color = '';
        saveButton.style.border = '';
    } else {
        saveButton.disabled = false;
        saveButton.style.backgroundColor = 'red';
        saveButton.style.color = 'white';
        saveButton.style.border = '1px solid red';
    }
}

document.getElementById('current-pwd_ipt').addEventListener('input', checkInput);
document.getElementById('new-pwd_ipt').addEventListener('input', checkInput);
document.getElementById('confirm-new-pwd_ipt').addEventListener('input', checkInput);

var inputIds = ['Email_ipt', 'current-pwd_ipt', 'new-pwd_ipt', 'confirm-new-pwd_ipt'];
for (var i = 0; i < inputIds.length; i++) {
    var input = document.getElementById(inputIds[i]);
    input.addEventListener('focus', function () {
        this.style.backgroundColor = '#373636'; // Thay đổi màu nền khi nhập
    });
    input.addEventListener('blur', function () {
        this.style.backgroundColor = ''; // Quay lại màu nền ban đầu khi không nhập
    });
    input.addEventListener('mouseover', function () {
        this.style.backgroundColor = '#373636'; // Thay đổi màu nền khi di chuột qua
    });
    input.addEventListener('mouseout', function () {
        this.style.backgroundColor = ''; // Quay lại màu nền ban đầu khi di chuột ra khỏi
    });
}

