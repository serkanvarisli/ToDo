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