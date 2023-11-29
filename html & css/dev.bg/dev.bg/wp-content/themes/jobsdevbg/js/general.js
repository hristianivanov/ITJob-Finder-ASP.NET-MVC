/**
 * General JS functionality.
 * For the time being, this file is loaded on init and should contain stuff that make sense to be loaded on init.
 * In the future we should think about loading helpers on demand as modules.
 */

/**
 * Smooth scroll. Animates scroll to a target with aОset duration.
 *
 * @param {object} target - A jQuery object for the target we want to scroll to.
 * @param {int} duration - The duration of the scrolling animation. Default 500ms.
 * @param {int} offset (optional) An offset for the scroll target. Can be a positive or a negative number.
 */
function so_smooth_scroll(target = null, duration = 500, offset = 0) {
    // bail if no target is passed
    if (!target) {
        return;
    }

    $('html, body').stop().animate({
        scrollTop: target.offset().top - offset
    }, 500, 'swing');
}

/**
 * Check if a string begins with another string - case insensitive
 *
 * @param needle
 * @param haystack
 * @returns {boolean}
 */
function so_ci_beginning_match(needle, haystack) {
    needle = needle.toLowerCase();
    haystack = haystack.toLowerCase();
    return (0 === haystack.indexOf(needle));
}

/**
 * Check if a string contains another string - case insensitive
 * ci stands for "case insensitive" - like the sql collation names :)
 *
 * @param needle
 * @param haystack
 * @returns {boolean}
 */
function so_ci_match(needle, haystack) {
    needle = needle.toLowerCase();
    haystack = haystack.toLowerCase();
    return (-1 !== haystack.indexOf(needle));
}

// Checks if a string is a valid email.
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

//Calculate a sha256 hash of a string. Be careful, this is an async function.
async function so_sha256(message) {
    var hashHex = message;
    try {
        const msgBuffer = new TextEncoder().encode(message);
        const hashBuffer = await crypto.subtle.digest('SHA-256', msgBuffer);
        const hashArray = Array.from(new Uint8Array(hashBuffer));
        hashHex = hashArray.map(b => b.toString(16).padStart(2, '0')).join('');
    } catch (e) {
        console.log(e);
    }
    return hashHex;
}