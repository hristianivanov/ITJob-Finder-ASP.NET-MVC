/*************Homepage-job-categories*************/
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

/*************Login-register-modal*************/
const signInBtnLink = document.querySelector('.signInBtn-link');
const signUpBtnLink = document.querySelector('.signUpBtn-link');
const wrapper = document.querySelector('.modal-container');
const closeBtns = Array.from(document.querySelectorAll('.modal-container .close-form'));

signUpBtnLink.addEventListener('click', () => {
    wrapper.classList.toggle('active');
    closeBtns[0].style.display = 'none';
    setTimeout(() => {
        closeBtns[1].style.display = 'block';
    }, 1000);
});

signInBtnLink.addEventListener('click', () => {
    wrapper.classList.toggle('active');
    closeBtns[1].style.display = 'none';
    setTimeout(() => {
        closeBtns[0].style.display = 'block';
    }, 1000);
});

document.getElementById('login-btn').addEventListener('click', function (e) {
    e.preventDefault();
    document.querySelector('.modal-container').classList.add('open');
    document.querySelector('.curtain').classList.add('open');
    document.body.classList.add('login-dialog-open');
});

closeBtns.forEach(btn => btn.addEventListener('click', () => {
    document.querySelector('.modal-container').classList.remove('open');
    document.querySelector('.curtain').classList.remove('open');
    document.body.classList.remove('login-dialog-open');
}));

document.querySelector('.curtain').addEventListener('click', function () {
    document.querySelector('.modal-container').classList.remove('open');
    document.querySelector('.curtain').classList.remove('open');
    document.body.classList.remove('login-dialog-open');
});
