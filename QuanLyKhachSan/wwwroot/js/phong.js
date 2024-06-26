﻿document.addEventListener('DOMContentLoaded', function () {
    var addButton = document.getElementById('DatPhong');
    var closeButton = document.getElementById('closeButton');
    addButton.addEventListener('click', function () {
        overlay.style.display = 'block';
        updateHangPhong(); // Gọi hàm updateHangPhong() sau khi hiển thị overlay

     

    });
    closeButton.addEventListener('click', function () {
        overlay.style.display = 'none';
        // Tạo một phần tử select mới
        var selectElement = document.createElement('select');

        // Đặt id cho phần tử mới
        selectElement.id = 'Ma_Phong';

        // Add attributes to the select element
        selectElement.className = 'combo';
        selectElement.style.width = '100px';
        selectElement.setAttribute('asp-for', 'Phong');
        selectElement.setAttribute('onchange', 'updateHangPhong()');

        // Lấy phần tử cũ
        var oldElement = document.getElementById('Ma_Phong');

        // Thay thế phần tử cũ bằng phần tử mới
        oldElement.parentNode.replaceChild(selectElement, oldElement);

        // Gọi API để lấy danh sách các phòng
        $.ajax({
            url: '/Phong/GetRooms', // Đường dẫn đến API của bạn
            type: 'GET',
            success: function (rooms) {
                // Thêm các tùy chọn vào phần tử select mới từ danh sách phòng
                for (var i = 0; i < rooms.length; i++) {
                    var option = document.createElement('option');
                    option.value = rooms[i].maPhong;
                    option.text = 'P.' + rooms[i].maPhong;
                    selectElement.appendChild(option);
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});



var checkInInput = document.querySelector('input[name="NgayNhan"]');
var checkOutInput = document.querySelector('input[name="NgayTra"]');

function updateDuration() {
    var maPhong = document.getElementById('Ma_Phong').value;
    var kiemtra = document.querySelector('.combo_Gio_Ngay');

    // Gọi API để lấy giá phòng
    $.ajax({
        url: '/Phong/GetRoomPrice',
        type: 'GET',
        data: { maPhong: maPhong },
        success: function (room) {
            var giaphong;
            if (kiemtra.value == 'Gio') {
                giaphong = parseFloat(room.giaTheoGio);
                var checkInDate = new Date(checkInInput.value);
                var checkOutDate = new Date(checkOutInput.value);
                var duration = ((checkOutDate - checkInDate) / 1000 / 60 / 60).toFixed(2);
                var thanhtien = Math.round(duration * giaphong);

        document.getElementById('dukien').value = duration + ' giờ';
        document.getElementById('thanhtien').value = thanhtien;
        document.querySelector('.tien_khachhang_tra').textContent = thanhtien;
        document.getElementById('labelDuKien').textContent = document.getElementById('dukien').value;
        document.getElementById('lableThanhTien').textContent = document.getElementById('thanhtien').value;
        document.getElementById('gia-phong').value = giaphong;
        document.getElementById('labelGiaPhong').textContent = document.getElementById('gia-phong').value;
            } else {
                giaphong = parseFloat(room.giaTheoNgay);
                var checkInDate = new Date(checkInInput.value);
                var checkOutDate = new Date(checkOutInput.value);
                var duration = ((checkOutDate - checkInDate) / 1000 / 60 / 60 / 24).toFixed(2);
                var thanhtien = Math.round(duration * giaphong);


        document.getElementById('dukien').value = duration + ' ngày';
        document.getElementById('thanhtien').value = thanhtien;
        document.querySelector('.tien_khachhang_tra').textContent = thanhtien;
        document.getElementById('labelDuKien').textContent = document.getElementById('dukien').value;
        document.getElementById('lableThanhTien').textContent = document.getElementById('thanhtien').value;
        document.getElementById('gia-phong').value = giaphong;
        document.getElementById('labelGiaPhong').textContent = document.getElementById('gia-phong').value;
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
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

function popUpNhanPhong(maPhong) {
    // Get the overlay element
    var overlay = document.getElementById('overlay');

    // Show the overlay
    overlay.style.display = 'block';

    // Update the room number in the popup
    document.getElementById('Ma_Phong').value = maPhong;

        // Update the room type in the popup
    updateHangPhong();

    // Attach event listeners to the check-in and check-out inputs
    var checkInInput = document.querySelector('input[name="NgayNhan"]');
    var checkOutInput = document.querySelector('input[name="NgayTra"]');
    checkInInput.addEventListener('change', updateDuration);
    checkOutInput.addEventListener('change', updateDuration);

    // Call updateDuration to calculate the initial values
    updateDuration();
}

function popUpTraPhong(maPhong) {
    // Cập nhật tiêu đề của popup với mã phòng

    document.querySelector('.form-TraPhong h1').textContent = 'Xác nhận trả phòng-P.' + maPhong;
    document.getElementById('ma-phong_thanhtoan').textContent = 'P.' + maPhong;
    document.getElementById('input_Phong_ThanhToan').value = maPhong;
    $.ajax({
        url: '/Phong/LayTenKhachHang',
        type: 'GET',
        data: { maPhong: maPhong },
        success: function (data,data1) {
            // 'data' chính là đối tượng đặt phòng trả về từ controller
            $('#ten_kh').text(data.tenKhachHang);
      
        },

    });
    $.ajax({
        url: '/Phong/LaySoNguoiO',
        type: 'GET',
        data: { maPhong: maPhong },
        success: function (data) {
            // 'data' chính là đối tượng đặt phòng trả về từ controller
            $('#so_Nguoi_O').text("|Số người ở: "+data.soNguoiO);

        },

    });

    $.ajax({
        url: '/Phong/LayThanhToan',
        type: 'GET',
        data: { maPhong: maPhong },
        success: function (data) {
            // 'data' chính là đối tượng đặt phòng trả về từ controller
            $('#Hang_Phong_ThanhToan').text(data.hinhThuc);
            $('#Ngay_Nhan_ThanhToan').val(data.ngayNhan);
            $('#Ngay_Tra_ThanhToan').val(data.ngayTra);
            $('#Tong_Tien_Thanh_Toan').text(data.thanhTien);
            $('#Du_Kien_ThanhToan').text(data.duKien);
            $('#Ma_Dat_Phong_ThanhToan').text(data.maDatPhong);
            $('#Gia_Phong_ThanhToan').text(data.giaPhong);
            $('#Nhan_Vien_ThanhToan').text(data.maNhanVien);
        },

    });



    // Hiển thị popup
    document.getElementById('TraPhong').style.display = 'block';
}


function Close_TraPhong() {
    document.getElementById('TraPhong').style.display = 'none';

}

function DongTraPhong() {
    var dongTraPhong = document.getElementById('Dong_Tra_Phong');
    dongTraPhong.display = 'none';
}

function checkRoomStatus(maPhong) {

    $.ajax({
        url: '/Phong/CheckRoom',
        type: 'GET',
        data: { maPhong: maPhong },
        success: function (isBooked) {
            if (isBooked) {
                // If the room is already booked, show the checkout popup
                popUpTraPhong(maPhong);
            } else {
                popUpNhanPhong(maPhong);
                // Tạo một phần tử input mới
                var inputElement = document.createElement('input');
                

                // Đặt id cho phần tử mới
                inputElement.id = 'Ma_Phong';
                inputElement.name = 'Phong';

                // Đặt thuộc tính readonly
                inputElement.readOnly = true;

                // Lấy phần tử cũ
                var oldElement = document.getElementById('Ma_Phong');

                // Lấy dữ liệu từ phần tử select cũ
                var selectedValue = oldElement.options[oldElement.selectedIndex].value;
                // Đặt giá trị cho phần tử input mới
                inputElement.value = selectedValue;

                // Thay thế phần tử cũ bằng phần tử mới
                oldElement.parentNode.replaceChild(inputElement, oldElement);

                document.getElementById('Ma_Phong').style.width="80px"
            }
        },
       error: function (error) {
        console.log(error);
    } 
    });
}

$("#form_DatPhong").submit(function (e) {
    e.preventDefault(); // Ngăn chặn việc tải lại trang

    $.ajax({
        url: '/Phong/NhanPhong', // Replace 'YourControllerName' with the name of your controller
        type: "POST",
        data: $(this).serialize(),
        success: function (response) {
            var messageElement = document.getElementById('message');
            if (response.success) {
                messageElement.innerText = response.message;
                messageElement.style.color = 'green';
                window.location.href = "/Phong/Index";

            } else {
                messageElement.innerText = response.message;
                messageElement.style.color = 'red';
            }
        }
    });
});

$(document).ready(function () {
    $('#Tra_Phong').click(function (e) {
        e.preventDefault();

        var Phong = $('#input_Phong_ThanhToan').val();
        var khachDaThanhToan = $('input[name="khachDaThanhToan"]').val();

        $.ajax({
            url: '/Phong/ThanhToan',  
            type: 'POST',
            data: {
                Phong: Phong,
                khachDaThanhToan: khachDaThanhToan
            },
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    window.location.href = "/Phong/Index";
                } else {
                    $('#message_TraPhong').text(response.message);
                }
            },
            error: function (error) {
                console.log(error);
                $('#message_TraPhong').text('Có lỗi xảy ra, vui lòng thử lại.');
            }
        });
    });
});




$(document).ready(function () {
    $("#toggle-button1").addClass("active");
    $(".tri-state-toggle-button").click(function () {
        $(".tri-state-toggle-button").removeClass("active");
        var id = $(this).attr('id');
        $("#" + id).addClass("active");
    });
});




function filterRooms(status) {
    var rooms = document.getElementsByClassName('room');
    for (var i = 0; i < rooms.length; i++) {
        if (status === 'all') {
            rooms[i].style.display = 'block';
        } else if (status === 'booked' && rooms[i].classList.contains('booked')) {
            rooms[i].style.display = 'block';
        } else if (status === 'empty' && !rooms[i].classList.contains('booked')) {
            rooms[i].style.display = 'block';
        } else {
            rooms[i].style.display = 'none';
        }
    }
}
$(document).ready(function () {
    // Hàm để lấy tên và mã khách hàng
    function layTenKhachHang() {
        var maKhachHang = $("#select_mkh").val();
        if (maKhachHang) {
            $.ajax({
                url: '/Phong/LayTenKhachHangDatPhong',
                type: 'GET',
                data: { maKhachHang: maKhachHang },
                success: function (tenKhachHang) {
                    $("#labelMaKhachHang").text(tenKhachHang);
                },
                error: function (request, status, error) {
                    console.log("Error while fetching Khách Hàng: " + error);
                }
            });
        }
    }

    // Hàm để lấy tên và mã nhân viên
    function layTenNhanVien() {
        var maNhanVien = $("#select_mnv").val();
        if (maNhanVien) {
            $.ajax({
                url: '/Phong/LayTenNhanVienDatPhong',
                type: 'GET',
                data: { maNhanVien: maNhanVien },
                success: function (tenNhanVien) {
                    $("#labelMaNhanVien").text(tenNhanVien);
                },
                error: function (request, status, error) {
                    console.log("Error while fetching Nhân Viên: " + error);
                }
            });
        }
    }

    // Gọi các hàm khi trang tải lên
    layTenKhachHang();
    layTenNhanVien();

    // Gọi các hàm khi người dùng thay đổi lựa chọn
    $("#select_mkh").change(layTenKhachHang);  // Gọi hàm khi thẻ select thay đổi
    $("#select_mnv").change(layTenNhanVien);  // Gọi hàm khi thẻ select thay đổi
});
