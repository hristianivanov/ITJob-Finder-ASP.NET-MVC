const segments = window.location.href.split('/');
const jobId = segments[segments.length - 1];

$.ajax({
    url: '/Technology/GetJobOfferTechnologies?id=' + jobId,
    type: 'GET',
    dataType: 'json',
    success: function (data) {
        let selectedTechnologiesArray = data;

        selectedTechnologiesArray.forEach(tech => createTag(tech));
    },
    error: function (xhr, status, error) {
        console.error('Error fetching technology names:', error);
    }
});

function createTag(tag) {
    let liTag = `<li>${tag} <svg class="remove-tag-icon" onclick="removeTag(this, '${tag}')" color="rgb(88, 166, 255)" width="24" height="24" fill="none" viewBox="0 0 24 24">
					<path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5"
						  d="M17.25 6.75L6.75 17.25"/>
					<path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5"
						  d="M6.75 6.75L17.25 17.25"/>
				</svg></li>`;
    document.querySelector(".multiselect-autocomplete-tech-stack .job-tags").insertAdjacentHTML("afterbegin", liTag);
};

let seniorityInput = document.getElementById('workingExperience');
let optionsLi = document.querySelectorAll('.select .options .option');

let selectedLi = null;

optionsLi.forEach(li => {
    if (li.textContent === seniorityInput.value) {
        selectedLi = li;
        return;
    }
});
if (selectedLi) {
    selectedLi.classList.add("selected");
}

let dropDownLis = document.querySelectorAll('.dropdown .menu li');

assignJobLocation(document.getElementById('LocationType').value);

function assignJobLocation(location) {
    if (location) {
        let menuLi = getLi(location);

        menuLi.click();
    }
}

function getLi(location) {
    for (let i = 0; i < dropDownLis.length; i++) {
        if (dropDownLis[i].dataset.location === location) {
            return dropDownLis[i];
        }
    }
}
