var loginForm = document.getElementById("login-form");
var registerForm = document.getElementById("register-form");
var buttonBox = document.querySelector(".button-box");
var btn = document.getElementById("btn");
var loginContainer = document.querySelector(".login-container");

function register() {
    loginForm.classList.remove("show");
    registerForm.classList.add("show");
    buttonBox.style.left = "110px";
    btn.style.left = "0";
    loginContainer.classList.add("left-panel-active");
}

function login() {
    loginForm.classList.add("show");
    registerForm.classList.remove("show");
    buttonBox.style.left = "0";
    btn.style.left = "0";
    loginContainer.classList.remove("left-panel-active");
}
