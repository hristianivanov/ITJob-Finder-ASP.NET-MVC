let checkboxInputs = document.querySelectorAll('input[type=checkbox]');
let experienceFilterInputs = document.querySelectorAll('input[type=checkbox][name=experience]');
let locationFilterInputs = document.querySelectorAll('input[type=checkbox][name=location]');
let teamSizeFilterInputs = document.querySelectorAll('input[type=checkbox][name=staff]');

const salaryCheckBox = document.getElementById('salary-filter-slide_checkbox');

const experienceInputsArray = Array.from(experienceFilterInputs);
const locationInputsArray = Array.from(locationFilterInputs);
const teamSizeInputsArray = Array.from(teamSizeFilterInputs);

checkboxInputs.forEach(input => {
    input.addEventListener('change', () => {
        const locationInputs = locationInputsArray.filter(input => input.checked);
        const experienceInputs = experienceInputsArray.filter(input => input.checked);
        const teamSizeInputs = teamSizeInputsArray.filter(input => input.checked);

        const filters = [
            { name: 'job_location', values: locationInputs.map(input => input.value) },
            { name: 'seniority', values: experienceInputs.map(input => input.value) },
            { name: 'it_employees_count', values: teamSizeInputs.map(input => input.value) }
        ];

        window.location.href = generateURL(filters);
    });
});

const urlParams = new URLSearchParams(window.location.search);
if (salaryCheckBox) {
    if (urlParams.get('salary') === 'true') {
        salaryCheckBox.checked = true;
        salaryCheckBox.parentElement.classList.add('checked');
    }
}

function generateURL(filters) {
    const params = new URLSearchParams();

    filters.forEach(filter => {
        if (filter.values.length > 0) {
            params.append(filter.name, filter.values.join(','));
        }
    });

    if (salaryCheckBox && salaryCheckBox.checked) {
        params.append('salary', true);
    }

    const developmentParam = new URLSearchParams(window.location.search).get('development');
    if (developmentParam) {
        params.append('development', developmentParam);
    }

    return `/joboffer/all?${params.toString()}`;
}
