$(document).ready(function () {

    $('ul.navigation li a').each(function () {
       
       $('nav a[href^="/' + location.pathname.split("/")[1] + '"]').addClass('selected');

    });

});

