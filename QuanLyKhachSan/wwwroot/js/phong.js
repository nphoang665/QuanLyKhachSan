﻿document.addEventListener('DOMContentLoaded', function () {



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
        var giaphong = 50000;
        var duration = ((checkOutDate - checkInDate) / 1000 / 60 / 60).toFixed(2);
        // Giá phòng theo giờ là 100000
        var thanhtien = (duration * giaphong).toFixed(2);

        document.getElementById('dukien').value = duration + ' giờ';
        document.getElementById('thanhtien').value = thanhtien;
        document.querySelector('.tien_khachhang_tra').textContent = thanhtien;
        document.getElementById('labelDuKien').textContent = document.getElementById('dukien').value;
        document.getElementById('lableThanhTien').textContent = document.getElementById('thanhtien').value;
        document.getElementById('gia-phong').value = giaphong;
        document.getElementById('labelGiaPhong').textContent = document.getElementById('gia-phong').value;
    }
  
    else {
        var checkInDate = new Date(checkInInput.value);
        var checkOutDate = new Date(checkOutInput.value);
        var giaphong = 500000;
        var duration = ((checkOutDate - checkInDate) / 1000 / 60 / 60 / 24).toFixed(2);
        // Giá phòng theo ngày là 800000
        var thanhtien = (duration * giaphong).toFixed(2);

        document.getElementById('dukien').value = duration + ' ngày';
        document.getElementById('thanhtien').value = thanhtien;
        document.querySelector('.tien_khachhang_tra').textContent = thanhtien;
        document.getElementById('labelDuKien').textContent = document.getElementById('dukien').value;
        document.getElementById('lableThanhTien').textContent = document.getElementById('thanhtien').value;
        document.getElementById('gia-phong').value = giaphong;
        document.getElementById('labelGiaPhong').textContent = document.getElementById('gia-phong').value;
    }
}


checkInInput.addEventListener('change', updateDuration);
checkOutInput.addEventListener('change', updateDuration);

function updateHangPhong() {
    var maPhong = $("#Ma_Phong").val();

    $.ajax({
        url: "/Phong/GetHangPhong?maPhong=" + maPhong,
        type: "GET",

        success: function (hangPhong) {
            $("#Hang_Phong").text(hangPhong);
            $("#Input_HangPhong").val(hangPhong);
        },
        error: function (request, status, error) {
            console.log("Lỗi: " + error);
        }
    });

}







