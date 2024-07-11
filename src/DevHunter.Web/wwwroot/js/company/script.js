let viewBtns = document.querySelectorAll('.actions .action.view');

viewBtns.forEach(btn => {
    btn.addEventListener('click', (e) => {
        e.preventDefault();

        let applicationId = e.target.getAttribute('id');
        viewApplicationDetails(applicationId);
    })
})

function viewApplicationDetails(applicationId) {
    $.ajax({
        url: '/Company/Company/GetApplicationDetails',
        type: 'GET',
        data: { applicationId: applicationId },
        success: function (result) {
            console.log(result);

            let container = document.getElementById('application-detail');
            container.innerHTML = result;

            let curtain = container.querySelector('.curtain');
            let modal = container.querySelector('.job-application-form');
            let closeBtn = container.querySelector('.close-form');

            setTimeout(function () {
                modal.classList.add('open');
                curtain.classList.add('open');
                document.body.classList.add('form-is-open');
            }, 100);

            closeBtn.addEventListener('click', (e) => {
                e.preventDefault();
                curtain.classList.remove('open');
                modal.classList.remove('open');
                document.body.classList.remove('form-is-open');
            });

            curtain.addEventListener("click", (e) => {
                if (e.target === curtain && modal.classList.contains('open')) {
                    curtain.classList.remove('open');
                    modal.classList.remove('open');
                    document.body.classList.remove('form-is-open');
                }
            });
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}
