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
const modalContainer = document.querySelector('.modal-container');
const curtain = document.querySelector('.curtain');
const loginBtn = document.getElementById('login-btn');
const registerBtn = document.getElementById('register-btn');
const closeBtns = Array.from(document.querySelectorAll('.modal-container .close-form'));

// Open modal
loginBtn.addEventListener('click', function (e) {
    e.preventDefault();
    showModal();
});
registerBtn.addEventListener('click', function (e) {
    e.preventDefault();
    switchDialog(1, 0, 0);
    showModal();
});

// Close modal
closeBtns.forEach(btn => btn.addEventListener('click', closeModal));

curtain.addEventListener('click', closeModal);

// Switch dialog
signUpBtnLink.addEventListener('click', () => switchDialog(1, 0));
signInBtnLink.addEventListener('click', () => switchDialog(0, 1));

function showModal() {
    modalContainer.classList.add('open');
    curtain.classList.add('open');
    document.body.classList.add('login-dialog-open');
}

function closeModal() {
    modalContainer.classList.remove('open', 'active');
    curtain.classList.remove('open');
    document.body.classList.remove('login-dialog-open');
    closeBtns[1].style.display = 'none';
    closeBtns[0].style.display = 'block';
}

function switchDialog(indexToShow, indexToHide, timeout = 1000) {
    modalContainer.classList.toggle('active');
    closeBtns[indexToHide].style.display = 'none';
    setTimeout(() => {
        closeBtns[indexToShow].style.display = 'block';
    }, timeout);
}



/* Validation*/
 //let loginSubmitBtn = document.getElementById('submit-login-btn')

 //loginSubmitBtn.addEventListener('click', (e) => {
 //    e.preventDefault();

 //    let form = e.currentTarget.parentElement;

 //    let validationComplete = validateRegistrationForm(form);

 //    if (validationComplete) {
 //        form.submit();
 //    }
 //})

 //// Registration form front end validation
 //function validateRegistrationForm(loginForm) {
 //    let emailInput = loginForm.querySelector('input[name="Email"]');
 //    let passwordInput = loginForm.querySelector('input[name="Password"]');
 //    let hasErrors = false;

 //    let fields = [emailInput, passwordInput];

 //    fields.forEach(function (field) {

 //        if (!field.value) {
 //            hasErrors = true;
 //        }

 //        if (field.value && field === emailInput) {
 //            if (!isEmail(field.value)) {
 //                hasErrors = true;
 //            }
 //        }
 //    });

 //    return !hasErrors;
 //}

 //// Checks if a string is a valid email.
 //function isEmail(email) {
 //    let regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
 //    return regex.test(email);
 //}