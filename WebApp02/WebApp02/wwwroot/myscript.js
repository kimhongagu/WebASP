document.addEventListener("DOMContentLoaded", function () {
    // Chọn một phần tử và thay đổi nội dung của nó
    var element = document.getElementById("my-element");
    element.innerHTML = "Hello from JavaScript!";

    // Xử lý sự kiện khi nút được nhấn
    var button = document.getElementById("my-button");
    button.addEventListener("click", function () {
        alert("Button Clicked!");
    });
});