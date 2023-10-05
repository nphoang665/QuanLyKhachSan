document.addEventListener('DOMContentLoaded', function () {
    var addButton = document.getElementById('addButton');
    var overlay = document.getElementById('overlay');
    var closeButton = document.getElementById('closeButton');
    addButton.addEventListener('click', function () {
        overlay.style.display = 'block';
    });
    closeButton.addEventListener('click', function () {
        overlay.style.display = 'none';
    });

    var editButtons = document.getElementsByClassName('editButton');
    var overlayEdit = document.getElementsByClassName('overlayEdit')[0];
    var closeButtonEdit = document.getElementById('closeButtonEdit');

    for (var i = 0; i < editButtons.length; i++) {
        editButtons[i].addEventListener('click', function () {
            // Get the row that the edit button is in
            var row = this.parentNode.parentNode;

            // Get the data from the row
            var maNhanVien = row.cells[0].innerText;
            var tenNhanVien = row.cells[1].innerText;
            var cccd = row.cells[2].innerText;
            var gioiTinh = row.cells[3].innerText;
            var ngaySinh = row.cells[4].innerText;
            var chucVu = row.cells[5].innerText;
            var dienThoai = row.cells[6].innerText;
            var diaChi = row.cells[7].innerText;
            var ngayVaoLam = row.cells[8].innerText;
            var ghiChu = row.cells[9].innerText;

            // Format the date
            var partsNgaySinh = ngaySinh.split('/');
            var formattedNgaySinh = partsNgaySinh[2] + '-' + partsNgaySinh[1] + '-' + partsNgaySinh[0];

            var partsNgayVaoLam = ngayVaoLam.split('/');
            var formattedNgayVaoLam = partsNgayVaoLam[2] + '-' + partsNgayVaoLam[1] + '-' + partsNgayVaoLam[0];

            // Fill the input fields with the data
            document.getElementsByName('MaNhanVienSua')[0].value = maNhanVien;
            document.getElementsByName('TenNhanVienSua')[0].value = tenNhanVien;
            document.getElementsByName('CCCDSua')[0].value = cccd;
            document.getElementsByName('GioiTinhSua')[0].value = gioiTinh;
            document.getElementsByName('NgaySinhSua')[0].valueAsDate = new Date(formattedNgaySinh);
            document.getElementsByName('ChucVuSua')[0].value = chucVu;
            document.getElementsByName('DienThoaiSua')[0].value = dienThoai;
            document.getElementsByName('DiaChiSua')[0].value = diaChi;
            document.getElementsByName('NgayVaoLamSua')[0].valueAsDate = new Date(formattedNgayVaoLam);
            document.getElementsByName('GhiChuSua')[0].value = ghiChu;

            overlayEdit.style.display = 'block';
        });
    }
    closeButtonEdit.addEventListener('click', function () {
        overlayEdit.style.display = 'none';
    });
});
