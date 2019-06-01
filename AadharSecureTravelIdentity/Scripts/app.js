$(document).ready(function () {
    //
    $("#btnReset").click(function () {
        $(this).closest('form').find("input[type=text], textarea").val("");
    });
});