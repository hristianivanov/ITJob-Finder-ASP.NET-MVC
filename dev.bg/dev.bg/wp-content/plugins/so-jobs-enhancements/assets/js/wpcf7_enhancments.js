jQuery(document).ready(function() {
    //Choose which form buttons we want to be protected
    submit_obj = jQuery('.user-application-form :input[type="submit"], .anon-application-form :input[type="submit"], .report-form-wrapper :input[type="submit"]');

    if (!submit_obj) {
        return;
    }

    //Set appropriate form and button data for later handling.
    submit_obj.each(function() {
        var $form = jQuery(this).closest('form.wpcf7-form');
        $form.data('so-submit-once', 1);
        jQuery(this).data('so-old-value', jQuery(this).attr('value'));
        jQuery(this).addClass('so-has-old-value');
    });


    submit_obj.click(function(event) {
        var $form = jQuery(this).closest('form.wpcf7-form');
        if (!$form.data('so-submit-once')) {
            return;
        }

        if ($form.data('so-disable-submit') == true) {
            //Don't allow new submitting until previous one is not finished
            return false;
        }

        $form.find('.so-has-old-value').attr('value', sо_wpcf7_enhancments.submit_label_sending).css('background-color', 'gray');
        $form.data('so-disable-submit', true);
        return true;
    })
});

function so_wpcf7_allow_submit(event) {
    if (!event.detail.contactFormId) {
        return;
    }
    var $form = jQuery('#' + event.detail.unitTag + ' form');

    //Since current event was triggered, the submission is completed and we can allow further submissions of the form
    $form.data('so-disable-submit', false);

    $form.find('.so-has-old-value').each(function() {
        //Restore previous buttons values if any
        jQuery(this).attr('value', jQuery(this).data('so-old-value')).css('background-color', '#304ffe');
    });
}

document.addEventListener('wpcf7invalid', so_wpcf7_allow_submit);
document.addEventListener('wpcf7mailsent', so_wpcf7_allow_submit);
document.addEventListener('wpcf7mailfailed', so_wpcf7_allow_submit);