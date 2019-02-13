$(document).ready(function () {

    var docHeight = $(window).height();
    var footerHeight = $('.footer-style').height();
    var footerTop = $('.footer-style').position().top + footerHeight;

    if (footerTop < docHeight) {
        $('.footer-style').css('margin-top', 22 + (docHeight - footerTop) + 'px');
    }
});