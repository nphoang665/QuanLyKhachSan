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

    var kiemtra = document.querySelector('.combo_Gio_Ngay');

    if (kiemtra.value == 'Gio') {
        var checkInDate = new Date(checkInInput.value);
        var checkOutDate = new Date(checkOutInput.value);

        var duration = (checkOutDate - checkInDate) / 1000 / 60 / 60;
        var thanhtien = duration * 100000;

        document.getElementById('dukien').value = duration + ' giờ';
        document.getElementById('thanhtien').value = thanhtien;
        document.querySelector('.tien_khachhang_tra').textContent = thanhtien;
        document.getElementById('labelDuKien').textContent = document.getElementById('dukien').value;
        document.getElementById('lableThanhTien').textContent = document.getElementById('thanhtien').value;

    }
    else {
        var checkInDate = new Date(checkInInput.value);
        var checkOutDate = new Date(checkOutInput.value);

        var duration = (checkOutDate - checkInDate) / 1000 / 60 / 60 / 24;
        var thanhtien = duration * 500000;

        document.getElementById('dukien').value = duration + ' ngày';
        document.getElementById('thanhtien').value = thanhtien;
        document.querySelector('.tien_khachhang_tra').textContent = thanhtien;
        document.getElementById('labelDuKien').textContent = document.getElementById('dukien').value;
        document.getElementById('lableThanhTien').textContent = document.getElementById('thanhtien').value;
    }

   

   

}

checkInInput.addEventListener('change', updateDuration);
checkOutInput.addEventListener('change', updateDuration);
