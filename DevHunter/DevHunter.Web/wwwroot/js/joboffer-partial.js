function saveJob(buttonElement, jobOfferId) {
    $.ajax({
        url: '/JobOffer/Save',
        type: 'GET', // Should it be POST instead of GET?
        data: { id: jobOfferId },
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
            console.error(status);
        }
    });
}
