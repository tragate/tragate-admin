$(function(){

    var pathname = window.location.pathname; 

    $("#side-menu li a[href$='"+pathname+"']")
    .closest("li").addClass("active");
});