/*!
* Start Bootstrap - Modern Business v5.0.6 (https://startbootstrap.com/template-overviews/modern-business)
* Copyright 2013-2022 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-modern-business/blob/master/LICENSE)
*/
// This file is intentionally blank
// Use this file to add JavaScript to your project

var header = document.getElementById("myDIV");
var litems = header.getElementsByClassName("lnks");
for (var i = 0; i < btns.length; i++) {

    litems[i].addEventListener("click", function () {
        var current = document.getElementsByClassName("active");
        current[0].className = current[0].className.replace(" active", "");
        this.className += " active";
    });

//document.addEventListener('click', function handleClick(event) {
//    console.log('user clicked: ', event.target);
//    event.target.classList.add('custom-nav');
//});

//var currentLocation = location.href;
//var menuItem = document.querySelectorAll('a');
//const menuLength = menuItem.length;
//for (var i = 0; i < menuLength; i++) {
//    if (menuItem[i].href === currentLocation) {
//        menuItem[i].className = "custom-nav";
//    }

//}