document.addEventListener('wpcf7mailsent', function(event) {
    $('.devbg-offcanvas-form.open .contact-form-wrap').hide();
    $('.devbg-offcanvas-form.open').css('display', 'flex');
    $('.devbg-offcanvas-form.open .thank-you-wrap').removeClass('d-none');
}, false);