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