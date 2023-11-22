// For buttons with the .click-load class, warp them into a 'loading' button on click.
$(document).on('click', '.button.click-load', function() {
    $(this).addClass('loading');
})


/**
 * Button toggle logic (set with the .button-toggle class name)
 * 
 * You can attach callback functions using the .data() function
 * before-click-callback - if the callback return value evaluates to false, the toglle button will not be toggled.
 * after-click-callback - runs after the button was toggled
 */
$(document).on('click', '.button-toggle', function(e) {
    let $clicked_button = $(e.currentTarget);
    if ($clicked_button.data('before-click-callback')) {
        var obj = {
            before_click_callback: $clicked_button.data('before-click-callback')
        };
        if (!obj['before_click_callback'](e, $clicked_button)) {
            e.preventDefault();
            return false;
        }
    }
    $clicked_button.toggleClass('checked')
    if ($clicked_button.data('after-click-callback')) {
        var obj = {
            after_click_callback: $clicked_button.data('after-click-callback')
        };
        obj['after_click_callback'](e, $clicked_button);
    }
});