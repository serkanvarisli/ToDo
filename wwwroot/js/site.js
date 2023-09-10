$(function () {
    $("#showPassword").change(function () {
        const checked = $(this).is(":checked");
        if (checked) {
            $("#password").attr("type", "text");
            const metin = document.getElementById("showText").innerHTML;
        } else {
            $("#password").attr("type", "password");
            const metin = document.getElementById("showText").innerHTML;
        }
    });
});

$(document).ready(function () {
    $(".edit").click(function () {
        $(this).siblings(".save").show();
        $(this).siblings(".deger").show();
        $(this).hide();
    });
    $(".save").click(function () {
        $(this).siblings(".edit").show();
        $(this).siblings(".deger").hide();
        $(this).hide();
    });
});