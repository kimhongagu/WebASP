// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const changeColorButton = document.getElementById("changeColorButton");
const content = document.getElementById("container");

const colors = ["lightblue", "lightgreen", "light red", "lightpink", "lightyellow"];

function changeBackgroundColor() {
    const randomColor = colors[Math.floor(Math.random() * colors.length)];

    content.style.backgroundColor = randomColor;

}

changeColorButton.addEventListener("click", changeBackgroundColor);
