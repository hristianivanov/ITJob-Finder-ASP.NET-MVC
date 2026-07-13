document.querySelector('.upload-btn').addEventListener('click', (e) => {
	btnUpload.click();
});

const btnUpload = document.querySelector('.upload-btn input[type=file]');

const errorMsg = btnUpload.querySelector('p');

const allowedExtensions = ['png', 'jpg', 'jpeg'];

btnUpload.addEventListener("change", function (e) {
	const extension = btnUpload.value.split('.').pop().toLowerCase();

	if (allowedExtensions.indexOf(extension) === -1) {
		errorMsg.textContent = "Not an Image...";
	} else {
		const uploadedFile = URL.createObjectURL(e.target.files[0]);

		let uploadedView = document.querySelector(".upload-container .company-image");

		uploadedView.innerHTML = '';
		uploadedView.classList.add('active');
		let previewImage = new Image();
		previewImage.src = uploadedFile;
		uploadedView.appendChild(previewImage);
	}
});
