let applyBtns = document.querySelectorAll('.apply-button:not(.submit-btn)');
let curtain = document.querySelector('.curtain');
let modal = document.querySelector('.job-application-form');
let closeBtn = modal.querySelector('.close-form');
let uploadHandler = modal.querySelector('.upload-handler');
let input = modal.querySelector('input[type=file]');
let fileCounter = modal.querySelector('.upload-file-counter');

uploadHandler.addEventListener("click", (e) => {
	input.click();
});

input.addEventListener('change', function () {
	fileCounter.textContent = this.files.length + ' file(s) selected';
});

applyBtns.forEach(btn => {
	btn.addEventListener("click", (e) => {
		e.preventDefault();
		openModal();
	});
});

closeBtn.addEventListener('click', (e) => {
	e.preventDefault();
	closeModal();
})

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

curtain.addEventListener("click", (e) => {
	if (e.target === curtain
		&& modal.classList.contains('open')) {
		closeModal();
	}
});
