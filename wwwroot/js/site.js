// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*
    nav() is triggered by the menubutton (class navbtn)
    The function opens and closes the sidemenu by changing the width of the overlay
    It first determines whether the sidemenu is open (20%) or closed (0%)
    If the sidemenu is closed, it opens it up and the other way around
*/
function nav() {
    if (document.getElementById("nav").style.width == "0%") {
        document.getElementById("nav").style.width = "20%";
    }
    else {
        document.getElementById("nav").style.width = "0%";
    }
}