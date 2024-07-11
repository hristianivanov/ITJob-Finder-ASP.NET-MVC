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