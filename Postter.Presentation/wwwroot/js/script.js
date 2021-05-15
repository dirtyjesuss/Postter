$(document).ready(function () {
    $('#postterSearch').on('focus', function () {
        $('.fa-search').css('color', 'var(--pinkColor)');
        $('#postterSearchBar').addClass('focused');
    });
    $('#postterSearch').on('blur', function () {
        $('.fa-search').css('color', 'var(--darkGray)');
        $('#postterSearchBar').removeClass('focused');
    });

    $('.postter-form-control').on('focus', function () {
        $(this).addClass('focused');
    });
    $('.postter-form-control').on('blur', function () {
        $(this).removeClass('focused');
    });
});