toastr.options.progressBar = true;
toastr.options.newestOnTop = false;
toastr.options.closeButton = true;

function configureToastrMessage(toastContainerClass, titleText, iconClass) {
    let toastContainer = document.getElementById('toast-container');
    let successMessageContainer = toastContainer.querySelector(`.${toastContainerClass}`);

    let newDiv = document.createElement('div');
    newDiv.classList.add('toast-title');
    newDiv.textContent = titleText;

    successMessageContainer.insertBefore(newDiv, successMessageContainer.querySelector('.toast-message'));

    let newIcon = document.createElement('i');
    newIcon.classList.add("fa-solid", iconClass);

    successMessageContainer.insertBefore(newIcon, newDiv);
}

function customToastrInfo(message, options) {
    toastr.info(message, options);
    configureToastrMessage('toast-info', 'Custom Info', 'fa-circle-info');
}

function customToastrSuccess(message, options) {
    toastr.success(message, options);
    configureToastrMessage('toast-success', 'Success', 'fa-circle-check')
}

function customToastrWarning(message, options) {
    toastr.warning(message, options)
    configureToastrMessage('toast-warning', 'Warning', 'fa-triangle-exclamation');
}

function customToastrError(message, options) {
    toastr.error(message, options);
    configureToastrMessage('toast-error', 'Error', 'fa-circle-exclamation');
}
