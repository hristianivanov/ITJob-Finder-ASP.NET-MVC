const radioOptionsContainer = document.querySelectorAll('.select .options.radio');
radioOptionsContainer.forEach(container => {
    let radioOptions = Array.from(container.children);

    function removeLastSelectedOpt() {
        radioOptions.forEach(opt => opt.classList.remove('selected'));
    }

    radioOptions.forEach(opt => opt.addEventListener('click', () => {
        if (opt.classList.contains('selected')) {
            opt.classList.remove('selected');
        } else {
            removeLastSelectedOpt();
            opt.classList.add('selected');
        }
    }));
});

const checkBoxOptionsContainer = document.querySelectorAll('.select .options:not(.radio)');
checkBoxOptionsContainer.forEach(container => {
    let radioOptions = Array.from(container.children);

    radioOptions.forEach(opt => opt.addEventListener('click', () => {
        opt.classList.toggle('selected');
    }));
});