$('form.favourite-job-form').on('submit', function (e) {
    e.preventDefault();
    var jobId = $(this).attr('id');
    var btn = this[0];
    saveJob(btn, jobId);
});

function saveJob(buttonElement, jobOfferId) {
    let csrfToken = $('input[name="__RequestVerificationToken"]').val();

    $.ajax({
        url: '/JobOffer/Save',
        type: 'POST',
        headers: {
            'RequestVerificationToken': csrfToken
        },
        data: {
            id: jobOfferId
        },
        success: function (response) {
            if (response.success) {
                const text = buttonElement.querySelector('.label');

                if (response.saved) {
                    text.textContent = 'Save';
                    buttonElement.classList.remove('saved');
                } else {
                    text.textContent = 'Saved';
                    buttonElement.classList.add('saved');
                }
            } else {
                customToastrError(response.errorMsg);
            }
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

