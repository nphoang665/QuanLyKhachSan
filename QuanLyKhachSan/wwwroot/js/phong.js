document.addEventListener('DOMContentLoaded', function () {



    var addButton = document.getElementById('DatPhong');
    //var overlay = document.getElementById('overlay');
    var closeButton = document.getElementById('closeButton');
    addButton.addEventListener('click', function () {
        overlay.style.display = 'block';
    });
    closeButton.addEventListener('click', function () {
        overlay.style.display = 'none';
    });
});
var checkInInput = document.querySelector('input[name="NgayNhan"]');
var checkOutInput = document.querySelector('input[name="NgayTra"]');

function updateDuration() {

    var kiemtra = document.getElementById('combo_Gio_Ngay');
    if (kiemtra.value == 'Gio') {
        var checkInDate = new Date(checkInInput.value);
        var checkOutDate = new Date(checkOutInput.value);

        var duration = (checkOutDate - checkInDate) / 1000 / 60 / 60;
        var thanhtien = duration * 10000;

        document.querySelector('.duration').textContent = duration + ' giờ';
        document.querySelector('.thanhtien').textContent = thanhtien;
        document.querySelector('.tien_khachhang_tra').textContent = thanhtien;
    }
    else {
        var checkInDate = new Date(checkInInput.value);
        var checkOutDate = new Date(checkOutInput.value);

        var duration = (checkOutDate - checkInDate) / 1000 / 60 / 60/24;
        var thanhtien = duration * 10000;

        document.querySelector('.duration').textContent = duration + ' ngày';
        document.querySelector('.thanhtien').textContent = thanhtien;
        document.querySelector('.tien_khachhang_tra').textContent = thanhtien;
    }
   

   

}

checkInInput.addEventListener('change', updateDuration);
checkOutInput.addEventListener('change', updateDuration);
