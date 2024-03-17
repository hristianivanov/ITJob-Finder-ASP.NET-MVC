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

    if (selectedJobLocation === "On the road") {
        locationInput.value += " Road";
    }

    form.submit();
})


var descriptionEditor = document.getElementById("description-editor");
var descriptionInput = document.getElementById("description-input");

descriptionEditor.addEventListener("input", function () {
    descriptionInput.value = descriptionEditor.innerHTML;
});

var locationDropdown = document.querySelector(".menu");
var isRemoteInput = document.getElementById("IsRemote");
let locationInput = document.getElementById("Location");
locationDropdown.addEventListener("click", function (event) {
    var target = event.target;

    if (target.tagName === "LI") {
        var selectedLocation = target.dataset.location;
        selectedJobLocation = selectedLocation;

        var isRemote = selectedLocation === "Remote" || selectedLocation === "Hybrid remote";
        isRemoteInput.value = isRemote ? "true" : "false";
    }
});
