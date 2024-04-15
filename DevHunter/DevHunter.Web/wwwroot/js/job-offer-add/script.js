const dropdown = document.querySelector('.dropdown');
const input = dropdown.querySelector('.input-field');
const selectedOpt = dropdown.querySelector('.select > .selected');

function seniorityOptions() {
    switch (selectedOpt.textContent) {
        case 'Remote': {
            input.style.display = 'none';
        } break;
        default: input.style.display = 'block';
    }
}


var workingExperienceInput = document.getElementById("workingExperience");
var btnSubmit = document.querySelector(".job-offer-add-form button[type=submit]");
var form = document.querySelector('.job-offer-add-form');

btnSubmit.addEventListener("click", (e) => {
    e.preventDefault();

    var option = document.querySelector(".seniority .options .selected");

    if (option) {
        workingExperienceInput.value = option.textContent;
    }

    var techStack = document.querySelectorAll(".job-offer-technology-tags .job-tags > li");
    var selectedTechnologies = [];

    if (techStack) {
        techStack.forEach(stack => {
            let name = stack.textContent.trim();
            selectedTechnologies.push(name);
        });
    }

    document.getElementById('selectedTechnologiesInput').value = JSON.stringify(selectedTechnologies);

    form.submit();
})


var descriptionEditor = document.getElementById("description-editor");
var descriptionInput = document.getElementById("description-input");
let locationType = document.getElementById('LocationType');
let salaryType = document.getElementById('SalaryType');

descriptionEditor.addEventListener("input", function () {
    descriptionInput.value = descriptionEditor.innerHTML;
});

var locationDropdown = document.querySelector(".menu");
var salaryDrpdown = document.querySelector(".dropdown.pay .menu");
let locationInput = document.getElementById("Location");

salaryDrpdown.addEventListener("click", function (event) {
    var target = event.target;

    if (target.tagName === "LI") {
        var selectedSalary = target.dataset.location;

        salaryType.value = selectedSalary;
    }
});
locationDropdown.addEventListener("click", function (event) {
    var target = event.target;

    if (target.tagName === "LI") {
        var selectedLocation = target.dataset.location;

        locationType.value = selectedLocation;
    }
});
loadLocation();
function loadLocation() {
    if (locationType.value || salaryType.value) {
        let lis = document.querySelectorAll('.dropdown .menu li');
        lis.forEach(li => {
            if (li.dataset.location == locationType.value ||
            li.dataset.location == salaryType.value) {
                const dropdown = li.closest('.dropdown');
                const select = dropdown.querySelector('.select');
                const caret = dropdown.querySelector('.caret');
                const menu = dropdown.querySelector('.menu');
                const selected = dropdown.querySelector('.selected');

                // Call the handleOptionClick function with appropriate parameters
                handleOptionClick(li, select, caret, menu, selected);
            }
        });
    }
}

function handleOptionClick(option, select, caret, menu, selected) {
    selected.innerText = option.innerText;
    selected.classList.add('text-fade-in');

    setTimeout(() => {
        selected.classList.remove('text-fade-in');
    }, 300);

    select.classList.remove('select-clicked');
    caret.classList.remove('caret-remove');
    menu.classList.remove('menu-open');

    const options = menu.querySelectorAll('.menu li');
    options.forEach(opt => {
        opt.classList.remove('active');
    });

    option.classList.add('active');

    let dropdownType = select.parentElement.classList;

    if (dropdownType.contains("pay")) {
        payOptions(select.querySelector('.selected'), menu);
    } else if (dropdownType.contains("job-location")) {
        seniorityOptions();
    }
}

function payOptions(select, menu) {
    let container = menu.parentElement.parentElement;
    let salaryInputsContainer = container.querySelector('.two-input-field-pay');
    salaryInputsContainer.classList.add('range');
    switch (select.textContent) {
        case 'Range': {
            container.classList.remove('range');
            salaryInputsContainer.children[2].classList.remove('range');
            salaryInputsContainer.children[1].style.display = 'block';
            salaryInputsContainer.children[0].style.display = 'block';
        } break;
        default:
            container.classList.add('range');
            salaryInputsContainer.children[2].classList.add('range');
            salaryInputsContainer.children[1].style.display = 'none';
            salaryInputsContainer.children[0].style.display = 'none';;
    }
}