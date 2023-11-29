$('.open-popup-dialog').on('click', function(e) {
    e.preventDefault();
    var targetPopupId = $(this).data('popup');
    var jobId = $(this).data('job-id');

    openPopupDialog(targetPopupId, jobId);
});

// Closing dialogs
$(document).on('click', '.popup-dialog .close-button, .popup-dialog .button-cancel', function(e) {
    e.preventDefault();

    if ($(this).hasClass('button-reload')) {
        closePopupDialog($(this), true); // Close the popup and reload the page, to clean up the url.
    } else if ($(this).hasClass('button-dirty-reload')) {
        closePopupDialog($(this), true, true); // Close the popup and reload the page, leaving the get parameters intact
    } else {

        if ($(this).hasClass('clear-params')) {
            clearParams();
        }

        closePopupDialog($(this));
    }

});

function clearParams() {
    let cleanUrl = window.location.origin + window.location.pathname;
    window.history.replaceState({}, document.title, cleanUrl);
}

function openPopupDialog(targetPopupId, targetId) {
    var targetPopup = $('#' + targetPopupId);
    targetPopup.addClass('open');
    if (targetId) {
        targetPopup.find('.spend-credits').data('target-id', targetId); // TODO this shouldn't be here and needs cleaning up.
    }
    $('body').addClass('disable-scroll');
}

function closePopupDialog(target, reload, with_url_params) {
    with_url_params = undefined === with_url_params ? false : with_url_params;

    var redirectUrl = window.location
    if (!with_url_params) {
        redirectUrl = window.location.origin + window.location.pathname;
    }

    // If we want to reload the page, don't actually close the popup, because it's a bit confusing for people
    // We'll let the page reloading wipe it away.
    // If reload is set and is true, the  get parameters will be cleared.
    // If it is set, but is false, the page will just be reloaded with the current get parameteres
    if (!reload) {
        $('.popup-open').removeClass('popup-open');
        $(target).parents('.popup-dialog').removeClass('open');
        $('body').removeClass('disable-scroll');

        // if the popup has a 'dynamic-popup' class, that means it was inserted dynamically via ajax.
        // We want to remove it entirely from the DOM upon closing.
        if ($(target).parents('.popup-dialog').hasClass('dynamic-popup')) {
            $('.dynamic-popup').remove();
        }
    } else {
        with_url_params ? window.location.reload() : window.location.replace(redirectUrl);
    }
}

/**
 * Renders a popup dialog on demand. When closed, the dialog is removed entirely from the DOMs *
 *
 * @param popupId STRING - a unique slug-like id for the popup
 * @param options OBJECT - an object, containing keys and values for valid parameters for the popup dialog component. See component-popup-dialog.php for a list of params.
 *
 * NOTE: Since it's not as easy to get home_url() in js, the image source in the options object, should be a relative to the
 * theme root path. Example: '/images/oops-emoji.svg'. We'll build the whole src on the backend.
 *
 */
function openDynamicPopup(popupId, options) {
    // Bail if the popup doesn't have an ID. Anon popups could cause trouble over ajax.
    if (!popupId) {
        console.error('A dynamic popup was called without an id. Popup didn\'t render.');
        return;
    }

    // Make sure the options passed are an object, so we don't break anything when expanding.
    if ('object' !== typeof options) {
        console.error('A non-object was passed as options for a dynamic popup. Popup didn\'t render.');
        return;
    }

    // Build the data object for our post request.
    let data = {
        'action': 'show_dynamic_popup',
        'popup_data': {
            'popup_id': popupId,
            ...options
        },
    };

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: jobsdevbg_ajax.ajax_url,
        data: data,
        success: function(data) {
            $('body').append(data);
        }
    });
}