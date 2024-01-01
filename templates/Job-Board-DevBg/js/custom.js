$('.section-collapse').on('click', function () {
    $(this).siblings('.child-term, .mt-25').toggle(200);
    $(this).toggleClass('collapsed');
})

