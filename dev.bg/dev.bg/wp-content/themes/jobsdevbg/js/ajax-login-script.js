jQuery(document).ready(function($) {
    // Perform AJAX login on form submit
    $('form#subscriber-login').on('submit', function(e) {
        $('form#subscriber-login p.status').show().text(ajax_login_object.loadingmessage);
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: ajax_login_object.ajaxurl,
            data: {
                'action': 'ajaxlogin', //calls wp_ajax_nopriv_ajaxlogin
                'username': $('form#subscriber-login #username').val(),
                'password': $('form#subscriber-login #login-password').val(),
                'security': $('form#subscriber-login #security').val()
            },
            success: function(data) {
                $('form#subscriber-login p.status').text(data.message);
                if (data.loggedin == true) {
                    document.location.href = ajax_login_object.redirecturl;
                }
            }
        });
        e.preventDefault();
    });

    // Perform AJAX password reset on form submit
    $('form#lost-password-form').on('submit', function(e) {
        $('form#lost-password-form > p.status').show().text(ajax_login_object.loadingmessage);
        e.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "json",
            url: ajax_login_object.ajaxurl,
            data: {
                'action': 'ajaxpwdreset', //calls wp_ajax_nopriv_pwdreset
                'user_login': $('form#lost-password-form #user_login').val(),
                'security': $('form#lost-password-form #pass-security').val()
            },
            success: function(response) {
                console.log(response);
                // Both cases do the same, but left in case we decide to do something else in the future
                if (response['is_reset']) {
                    $('form#lost-password-form p.status').text(response['message']);
                } else {
                    $('form#lost-password-form p.status').text(response['message']);
                }
            }
        });
    });
});