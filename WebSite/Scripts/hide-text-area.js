
$(function () {
    $("#image-check-box").change(function () {
        if ($("#image-check-box").is(':checked')) {
            $("#image-text-box").removeClass("hide");
        }
        else {
            $("#image-text-box").addClass("hide");
            $("#image-text-box").val('');
        }
    });

    $("#video-check-box").change(function () {
        if ($("#video-check-box").is(':checked')) {
            $("#video-text-box").removeClass("hide");
        }
        else {
            $("#video-text-box").addClass("hide");
            $("#video-text-box").val('');
        }
    });

    $("#sunday-check-box").change(function () {
        if ($("#sunday-check-box").is(':checked')) {
            $("#sunday-opening").removeClass("hide");
            $("#sunday-closing").removeClass("hide");
            $("#sunday").css("color", "green");
        }
        else {
            $("#sunday-opening").addClass("hide");
            $("#sunday-closing").addClass("hide");
            $("#SundayOpening").val('');
            $("#SundayClosing").val('');
            $("#sunday").css("color", "red");
        }
    });

    $("#monday-check-box").change(function () {
        if ($("#monday-check-box").is(':checked')) {
            $("#monday-opening").removeClass("hide");
            $("#monday-closing").removeClass("hide");
            $("#monday").css("color", "green");
        }
        else {
            $("#monday-opening").addClass("hide");
            $("#monday-closing").addClass("hide");
            $("#MondayOpening").val('');
            $("#MondayClosing").val('');
            $("#monday").css("color", "red");
        }
    });

    $("#tuesday-check-box").change(function () {
        if ($("#tuesday-check-box").is(':checked')) {
            $("#tuesday-opening").removeClass("hide");
            $("#tuesday-closing").removeClass("hide");
            $("#tuesday").css("color", "green");
        }
        else {
            $("#tuesday-opening").addClass("hide");
            $("#tuesday-closing").addClass("hide");
            $("#TuesdayOpening").val('');
            $("#TuesdayClosing").val('');
            $("#tuesday").css("color", "red");
        }
    });

    $("#wednesday-check-box").change(function () {
        if ($("#wednesday-check-box").is(':checked')) {
            $("#wednesday-opening").removeClass("hide");
            $("#wednesday-closing").removeClass("hide");
            $("#wednesday").css("color", "green");
        }
        else {
            $("#wednesday-opening").addClass("hide");
            $("#wednesday-closing").addClass("hide");
            $("#WednesdayOpening").val('');
            $("#WednesdayClosing").val('');
            $("#wednesday").css("color", "red");
        }
    });

    $("#thursday-check-box").change(function () {
        if ($("#thursday-check-box").is(':checked')) {
            $("#thursday-opening").removeClass("hide");
            $("#thursday-closing").removeClass("hide");
            $("#thursday").css("color", "green");
        }
        else {
            $("#thursday-opening").addClass("hide");
            $("#thursday-closing").addClass("hide");
            $("#ThursdayOpening").val('');
            $("#ThursdayClosing").val('');
            $("#thursday").css("color", "red");

        }
    });

    $("#friday-check-box").change(function () {
        if ($("#friday-check-box").is(':checked')) {
            $("#friday-opening").removeClass("hide");
            $("#friday-closing").removeClass("hide");
            $("#friday").css("color", "green");
        }
        else {
            $("#friday-opening").addClass("hide");
            $("#friday-closing").addClass("hide");
            $("#FridayOpening").val('');
            $("#FridayClosing").val('');
            $("#friday").css("color", "red");
        }
    });

    $("#saturday-check-box").change(function () {
        if ($("#saturday-check-box").is(':checked')) {
            $("#saturday-opening").removeClass("hide");
            $("#saturday-closing").removeClass("hide");
            $("#saturday").css("color", "green");
        }
        else {
            $("#saturday-opening").addClass("hide");
            $("#saturday-closing").addClass("hide");
            $("#SaturdayOpening").val('');
            $("#SaturdayClosing").val('');
            $("#saturday").css("color", "red");
        }
    });
});
