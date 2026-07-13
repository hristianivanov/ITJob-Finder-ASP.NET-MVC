// select-option
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

// dropdown
const dropdown = document.querySelector('.dropdown');
const input = dropdown.querySelector('.input-field');
const selectedOpt = dropdown.querySelector('.select > .selected');

function seniorityOptions() {
    input.style.display = selectedOpt.textContent === 'Remote' ? 'none' : 'block';
}

function payOptions(select, menu) {
    const container = menu.parentElement.parentElement;
    const salaryInputsContainer = container.querySelector('.two-input-field-pay');
    salaryInputsContainer.classList.add('range');
    if (select.textContent === 'Range') {
        container.classList.remove('range');
        salaryInputsContainer.children[2].classList.remove('range');
        salaryInputsContainer.children[1].style.display = 'block';
        salaryInputsContainer.children[0].style.display = 'block';
    } else {
        container.classList.add('range');
        salaryInputsContainer.children[2].classList.add('range');
        salaryInputsContainer.children[1].style.display = 'none';
        salaryInputsContainer.children[0].style.display = 'none';
    }
}

function handleOptionClick(option, select, caret, menu, selected) {
    selected.innerText = option.innerText;
    selected.classList.add('text-fade-in');
    setTimeout(() => selected.classList.remove('text-fade-in'), 300);

    select.classList.remove('select-clicked');
    caret.classList.remove('caret-remove');
    menu.classList.remove('menu-open');

    menu.querySelectorAll('.menu li').forEach(opt => opt.classList.remove('active'));
    option.classList.add('active');

    const dropdownType = select.parentElement.classList;
    if (dropdownType.contains('pay')) {
        payOptions(select.querySelector('.selected'), menu);
    } else if (dropdownType.contains('job-location')) {
        seniorityOptions();
    }
}

document.querySelectorAll('.dropdown').forEach(d => {
    const select = d.querySelector('.select');
    const caret = d.querySelector('.caret');
    const menu = d.querySelector('.menu');
    const selected = d.querySelector('.selected');

    select.addEventListener('click', () => {
        select.classList.toggle('select-clicked');
        caret.classList.toggle('caret-rotate');
        menu.classList.toggle('menu-open');
    });

    d.querySelectorAll('.menu li').forEach(option => {
        option.addEventListener('click', () => handleOptionClick(option, select, caret, menu, selected));
    });

    window.addEventListener('click', (e) => {
        const size = d.getBoundingClientRect();
        if (e.clientX < size.left || e.clientX > size.right ||
            e.clientY < size.top || e.clientY > size.bottom) {
            select.classList.remove('select-clicked');
            caret.classList.remove('caret-rotate');
            menu.classList.remove('menu-open');
        }
    });
});

// form submit
const workingExperienceInput = document.getElementById('workingExperience');
const btnSubmit = document.querySelector('.job-offer-add-form button[type=submit]');
const form = document.querySelector('.job-offer-add-form');

btnSubmit.addEventListener('click', (e) => {
    e.preventDefault();

    const option = document.querySelector('.seniority .options .selected');
    if (option) workingExperienceInput.value = option.textContent;

    const selectedTechnologies = [];
    document.querySelectorAll('.job-offer-technology-tags .job-tags > li').forEach(stack => {
        selectedTechnologies.push(stack.textContent.trim());
    });
    document.getElementById('selectedTechnologiesInput').value = JSON.stringify(selectedTechnologies);

    form.submit();
});

const descriptionEditor = document.getElementById('description-editor');
const descriptionInput = document.getElementById('description-input');
const locationType = document.getElementById('LocationType');
const salaryType = document.getElementById('SalaryType');

descriptionEditor.addEventListener('input', function () {
    descriptionInput.value = descriptionEditor.innerHTML;
});

document.querySelector('.menu').addEventListener('click', (event) => {
    if (event.target.tagName === 'LI') locationType.value = event.target.dataset.location;
});

document.querySelector('.dropdown.pay .menu').addEventListener('click', (event) => {
    if (event.target.tagName === 'LI') salaryType.value = event.target.dataset.location;
});

loadLocation();

function loadLocation() {
    if (!locationType.value && !salaryType.value) return;
    document.querySelectorAll('.dropdown .menu li').forEach(li => {
        if (li.dataset.location == locationType.value || li.dataset.location == salaryType.value) {
            const d = li.closest('.dropdown');
            handleOptionClick(li, d.querySelector('.select'), d.querySelector('.caret'), d.querySelector('.menu'), d.querySelector('.selected'));
        }
    });
}
