const btnUpload = document.getElementById("upload_file"),
    btnOuter = document.querySelector(".technology-upload-container .panel .button_outer"),
    btnRemove = document.querySelector(".img-upload-container .file_remove");

const errorMsg = document.querySelector('.technology-upload-container .panel > .error_msg')

const allowedExtensions = ['png', 'jpg', 'jpeg'];

btnUpload.addEventListener("change", function (e) {
    const extension = btnUpload.value.split('.').pop().toLowerCase();

    if (allowedExtensions.indexOf(extension) === -1) {
        errorMsg.textContent = "Not an Image...";
    } else {
        errorMsg.textContent = "";
        btnOuter.classList.add("file_uploading");

        setTimeout(function () {
            btnOuter.classList.add("file_uploaded");
        }, 3000);

        const uploadedFile = URL.createObjectURL(e.target.files[0]);

        setTimeout(function () {
            let uploadedView = document.getElementById("uploaded_view");
            let imgElement = uploadedView.querySelector('img');
            if (imgElement) {
                imgElement.remove();
            }
            let previewImage = new Image();
            previewImage.src = uploadedFile;
            uploadedView.appendChild(previewImage);
            uploadedView.classList.add("show");
        }, 3500);
    }
});



btnRemove.addEventListener("click", function (e) {
    let uploadedView = document.getElementById("uploaded_view");
    uploadedView.classList.remove("show");
    uploadedView.querySelector("img").remove();
    btnOuter.classList.remove("file_uploading");
    btnOuter.classList.remove("file_uploaded");
});
