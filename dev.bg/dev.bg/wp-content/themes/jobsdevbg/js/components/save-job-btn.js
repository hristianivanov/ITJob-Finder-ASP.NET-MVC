$(document).ready(function() {
    //If user clicks on some miniboard filter, the job listing items will be dynamically grenerated, so 
    //we can not bind events directly
    $('body').on('click', '.save-cta', so_save_job_clicked);

    //Show the registration popup after a user clicks the "register" link in our non-registerd user warning dialog
    //We need this bind to body, because the other elements do not exists on page load, but after dialog async pops up
    $('body').on('click', '#save-job-non-registered-user-message .secondary-text a', function(e) {
        e.preventDefault();
        $('#save-job-non-registered-user-message .close-button').click();
        $('.subscriber-register-btn').click();
    });

});

/**
 * Triggers after a save job flag is clicked
 * 
 * @returns {void}
 */
function so_save_job_clicked() {
    let $container = $(this).closest('.save-job-container');
    let job_id = $container.data('jobId');

    if ($(this).closest('.save-job-container').hasClass('saved')) {
        so_unsave_job(job_id);
    } else {
        so_save_job(job_id);
    }
}

/**
 * Saves a job trough ajax request after the flag button was clicked
 *
 * @param {number} $job_id The id of the job we want to save
 *
 * @returns {void} The clicked flag button container jquery object
 */
function so_save_job(job_id) {
    if (0 == parseInt(save_job_btn_vars.logged_in)) {
        let designPublishOptions = {
            'main_text': 'Може да запазиш обява, само ако имаш профил в DEV.bg',
            'secondary_text': 'Все още нямаш профил в DEV.BG?<br /><a href="">Регистрирай се</a>',
            'image_src': '/images/inspecting-emoji.svg',
        }
        openDynamicPopup('save-job-non-registered-user-message', designPublishOptions);
        return;
    }
    so_mark_job_saved(job_id);

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: save_job_btn_vars.ajax_url,
        data: {
            'action': 'update-user-saved-jobs',
            'job_id': job_id,
        },
        success: function(data) {
            if (data.saved_job_id == job_id) {
                so_mark_job_saved(job_id)
            } else {
                so_unmark_job_saved(job_id);
            }
        }
    });
}

/**
 * Unsaves a job trough ajax request after the flag button was clicked
 * 
 * @param {number} $job_id The id of the job we want to unsave
 *
 * @returns {void}
 */

function so_unsave_job(job_id) {
    so_unmark_job_saved(job_id);

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: save_job_btn_vars.ajax_url,
        data: {
            'action': 'remove-user-saved-job',
            'job_id': job_id,
        },
        success: function(data) {
            if (data.removed_job_id == job_id) {
                so_unmark_job_saved(job_id)
            } else {
                so_mark_job_saved(job_id);
            }
        }
    });
}

/**
 * Marks job as saved (css solid background flag button )
 * 
 * @param {number} job_id 
 */
function so_mark_job_saved(job_id) {
    $('.save-job-container[data-job-id=' + job_id + ']').addClass('saved');
}

/**
 * Unmarks job as saved (css hollow background flag button )
 * 
 * @param {number} job_id 
 */
function so_unmark_job_saved(job_id) {
    $('.save-job-container[data-job-id=' + job_id + ']').removeClass('saved');
}