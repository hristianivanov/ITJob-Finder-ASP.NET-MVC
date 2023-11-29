// TODO This file should probably be in a plugin

// Toggle the user panel menu on mobile
$('.user-profile-toggle').on('click', function(e) {
    if (950 >= window.innerWidth) {
        e.preventDefault();
        toggleUserProfileMenu();
    }
});

var userPanelMenu = $('.user-panel-menu');
userPanelMenu.find($('.button-close')).on('click', function() {
    toggleUserProfileMenu()
});

function toggleUserProfileMenu() {
    $('body').toggleClass('disable-scroll');
    userPanelMenu.toggleClass('open');
}

// navigation sidebar toggle on medium screens in the user panel
$(document).ready(function() {
    if (1200 >= window.innerWidth) {
        $('.subscriber-sidebar').addClass('closed');
    }
})

$('.sidebar-toggle').on('click', function(e) {
    e.preventDefault();
    $('.subscriber-sidebar').toggleClass('closed');
});

// user register popup
var offcanvasFormRegister = $('.subscriber-register-wrapper');

// Post registration notice popup
var postRegPopup = $('.popup-notice-wrapper');

$('.subscriber-register-btn').on('click', function() {
    offcanvasFormRegister.addClass('open');
    offcanvasFormRegister.prev('.curtain').addClass('open');
    // offcanvasForm.height( $('body').height() );
    $('body').css('overflow', 'hidden');

});

// Validate the registration form and submit it (or throw validation error)
$('.user-register-submit').on('click', function(e) {
    var form = $(this).parent('form');

    var validationComplete = validateRegistrationForm(form);

    if (validationComplete) {
        form.submit();
    }
});

$('.curtain, .close-alert, .close-self').on('click', function() {
    offcanvasFormRegister.removeClass('open');
    postRegPopup.removeClass('open');
    offcanvasFormRegister.prev('.curtain').removeClass('open');
    postRegPopup.prev('.curtain').removeClass('open');
    $('body').css('overflow-y', 'auto');
});

// Registration form front end validation
function validateRegistrationForm($form) {

    var fName = $form.find('#fname');
    var lName = $form.find('#lname');
    var email = $form.find('#email');
    var password = $form.find('#password');
    var consent = $form.find('#subscriber-register-consent');
    var hasErrors = false;

    var fields = [fName, lName, email, password];

    // This will go through all fields and throw an error if there are empty ones.
    // It will also throw an error if the email fields contains an invalid email.
    fields.forEach(function(field) {

        if (!field.val()) {
            field.css({
                'border': '1px solid red',
                'background': 'rgba(255,0,0,0.1)'
            });
            hasErrors = true;
        }

        if (field.val() && field === email) {
            console.log('checking email...');

            // Make sure the email entered is a valid email
            if (!isEmail(field.val())) {
                console.log('email is not valid');
                hasErrors = true;
            }

        }

    });

    if (!consent.is(':checked')) {
        hasErrors = true;
        $('#consent-error').html('Трябва да се съгласите с условията, преди да се регистрирате');
    }

    if (hasErrors) {
        console.error('DEV.BG Registration form: Some fields are invalid. Please make sure all required fields are filled in and have valid information in them.');
        return false;
    }

    return true;
}

$('.subscriber-submit-changes').on('click', function(e) {
    e.preventDefault();

    var $form = $('#edit-profile-form');
    var $email = $form.find('#user-email');
    var email = $email.val();

    // Make sure the email field has an email in it, before submitting the form
    if (!isEmail(email)) {
        console.log('The email entered isn\'t a valid email');
        $email.css('border-color', 'red');
        $('.email-error').html('Въведеният имейл не е валиден.');
    } else {
        $form.submit();
    }

});

$('.subscriber-password-change').on('click', function(e) {
    e.preventDefault();

    var $form = $('#edit-password-form');
    var $pass = $('#pass').val();
    var $pass2 = $('#repeat-pass').val();

    // Make sure both password fields have the same contents
    if ($pass !== $pass2) {
        console.log('Passwords don\'t match');
        $('#pass, #repeat-pass').css('border-color', 'red');
        $('.passwords-error').html("Паролите не съвпадат.");
    } else {
        $form.submit();
    }
});



// Checks if a string is a valid email.
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}