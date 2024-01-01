$('.section-collapse').on('click', function () {
    $(this).siblings('.child-term, .mt-25').toggle(200);
    $(this).toggleClass('collapsed');
})

function so_smooth_scroll(target = null, duration = 500, offset = 0) {
    if (!target) {
        return;
    }

    $('html, body').stop().animate({
        scrollTop: target.offset().top - offset
    }, 500, 'swing');
}