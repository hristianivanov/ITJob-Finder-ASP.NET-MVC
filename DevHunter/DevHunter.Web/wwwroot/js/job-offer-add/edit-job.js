selectedTechnologiesArray.forEach(tech => createTag(tech));
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

func(document.getElementById('Location').value);

function func(location) {
    if (location) {
        let menuLi = getLi(location);

        menuLi.click();
    }
}

function getLi(location) {
    for (let i = 0; i < dropDownLis.length; i++) {
        if (dropDownLis[i].textContent === location) {
            return dropDownLis[i];
        } else if (dropDownLis[i].textContent.includes("Hybrid") &&
            location.includes("Hybrid")) {
            return dropDownLis[i];
        }
    }
    return dropDownLis[0];
}

document.querySelector('.dropdown .select').addEventListener('click', () => {
    let a = document.getElementById('Location');
    if (a.value === "Remote") {
        a.value = null;
    }
})
