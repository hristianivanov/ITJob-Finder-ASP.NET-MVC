let applyBtns = document.querySelectorAll('.apply-button:not(.submit-btn)');
let curtain = document.querySelector('.curtain');
let modal = document.querySelector('.job-application-form');
if (modal) {
    let closeBtn = modal.querySelector('.close-form');
    let uploadHandler = modal.querySelector('.upload-handler');
    let input = modal.querySelector('input[type=file]');
    let fileCounter = modal.querySelector('.upload-file-counter');

    uploadHandler.addEventListener("click", (e) => {
        input.click();
    });
    if (input) {
        input.addEventListener('change', function () {
            fileCounter.textContent = this.files.length + ' file(s) selected';
        });
    }

    closeBtn.addEventListener('click', (e) => {
        e.preventDefault();
        closeModal();
    })

    curtain.addEventListener("click", (e) => {
        if (e.target === curtain
            && modal.classList.contains('open')) {
            closeModal();
        }
    });
}



applyBtns.forEach(btn => {
    btn.addEventListener("click", (e) => {
        e.preventDefault();
        openModal();
    });
});



function openModal() {
    curtain.classList.add('open');
    modal.classList.add('open');
    document.body.classList.add('form-is-open');
}

function closeModal() {
    curtain.classList.remove('open');
    modal.classList.remove('open');
    document.body.classList.remove('form-is-open');
}


$('form').submit(function (e) {
    e.preventDefault();

    var form = $(this);
    var formData = new FormData(form[0]);

    var formaction = form.find('.apply-button').attr('formaction');
    var id = formaction.split('/').pop();

    formData.append('id', id);

    let invalidDiv = document.querySelector('.form-invalid');

    $.ajax({
        url: form.attr('action'),
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: async function (response) {
            if (response.success == false) {

                invalidDiv.classList.add('active')

                let responseOutput = document.querySelector('.form-invalid .response-output');
                responseOutput.textContent = response.errorMsg;

            } else if (response.success == true) {
                invalidDiv.classList.remove('active')

                form.trigger('reset');

                closeModal();

                customToastrSuccess(response.successMsg);
            }
        },
        error: function () {
            console.error(error.statusCode);
            console.error('An error occurred while processing your request.');
        }
    });
});

