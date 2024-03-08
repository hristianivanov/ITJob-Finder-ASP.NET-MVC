const dropdown = document.querySelector('.dropdown');
const input = dropdown.querySelector('.input-field');
const selectedOpt = dropdown.querySelector('.select > .selected');


function seniorityOptions() {
    console.log(selectedOpt.textContent)

    switch (selectedOpt.textContent) {
        case 'Remote': {
            input.style.display = 'none';
        } break;
        default : input.style.display = 'block';
    }
}


var workingExperienceInput = document.getElementById("workingExperience");
var btnSubmit = document.querySelector(".job-offer-add-form button[type=submit]");
var form = document.querySelector('.job-offer-add-form');


btnSubmit.addEventListener("click", (e) => {
    e.preventDefault();

    var option =  document.querySelector(".seniority .options .selected");
    if (option) {
        workingExperienceInput.value = option.textContent;
    }

    form.submit();
})
