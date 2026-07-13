// load existing tech tags and pre-select seniority
const segments = window.location.href.split('/');
const jobId = segments[segments.length - 1];

$.ajax({
    url: '/Technology/GetJobOfferTechnologies?id=' + jobId,
    type: 'GET',
    dataType: 'json',
    success: function (data) {
        data.forEach(tech => {
            tags.push(tech);
            createTag(tech);
        });
    },
    error: function (xhr, status, error) {
        console.error('Error fetching technology names:', error);
    }
});

let seniorityInput = document.getElementById('workingExperience');
document.querySelectorAll('.select .options .option').forEach(li => {
    if (li.textContent === seniorityInput.value) {
        li.classList.add('selected');
    }
});

assignJobLocation(document.getElementById('LocationType').value);

function assignJobLocation(location) {
    if (!location) return;
    document.querySelectorAll('.dropdown .menu li').forEach(li => {
        if (li.dataset.location === location) li.click();
    });
}

// tech stack autocomplete (remaining technologies for edit)
let techUl = document.querySelector('.multiselect-autocomplete-tech-stack .job-tags'),
    techInput = document.querySelector('.multiselect-autocomplete-tech-stack input'),
    techContainer = document.querySelector('.job-offer-technology-tags');

let suggestContainer = document.querySelector('.multiselect-autocomplete-tech-stack .suggester');

$.ajax({
    url: '/Technology/GetRemainingTechnologies?id=' + jobId,
    type: 'GET',
    dataType: 'json',
    success: function (data) {
        suggestionsDb = data;
    },
    error: function (xhr, status, error) {
        console.error('Error fetching technology names:', error);
    }
});

let maxTags = 10,
    tags = [];

let currentFocus = -1;

techInput.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        e.preventDefault();
        let tag;
        if (currentFocus > -1) {
            let suggestion = suggestContainer.children[currentFocus];
            if (techInput.value) tag = suggestion.textContent.replace(/\s+/g, ' ');
        } else {
            tag = e.target.value.replace(/\s+/g, ' ');
        }
        if (tag && tag.length > 1 && !tags.includes(tag)) {
            if (tags.length < maxTags) {
                tag.split(',').forEach(t => {
                    tags.push(t);
                    createTag(t);
                    suggestionsDb.filter((data) => !tags.includes(data));
                });
            }
        }
        e.target.value = '';
    } else if (e.key === 'ArrowDown' || e.key === 'ArrowUp') {
        e.preventDefault();
        let suggestionsList = suggestContainer.querySelectorAll('.suggestion');
        if (suggestionsList.length > 0) {
            currentFocus = e.key === 'ArrowDown'
                ? (currentFocus + 1) % suggestionsList.length
                : (currentFocus - 1 + suggestionsList.length) % suggestionsList.length;
            suggestionsList.forEach(item => item.classList.remove('active'));
            suggestContainer.children[currentFocus].classList.add('active');
        }
    } else if (e.key === 'Escape') {
        closeSuggestions();
    } else {
        const userData = e.target.value;
        if (userData) {
            let matches = suggestionsDb
                .filter(d => d.toLocaleLowerCase().startsWith(userData.toLocaleLowerCase()) && !tags.includes(d))
                .map(d => `<li class="suggestion">${d}</li>`);
            if (e.key === 'Backspace' && techInput.value.length === 1) {
                suggestContainer.classList.remove('active');
            } else {
                suggestContainer.classList.add('active');
                showSuggestions(matches);
            }
        } else {
            suggestContainer.classList.remove('active');
        }
    }
});

function showSuggestions(list) {
    suggestContainer.innerHTML = list.length
        ? list.join('')
        : `<li class="suggestion">${techInput.value}</li>`;
}

function createTag(tag) {
    techUl.querySelectorAll('li').forEach(li => li.remove());
    tags.slice().reverse().forEach(t => {
        techUl.insertAdjacentHTML('afterbegin', `<li>${t} <svg class="remove-tag-icon" onclick="removeTag(this, '${t}')" color="rgb(88, 166, 255)" width="24" height="24" fill="none" viewBox="0 0 24 24">
    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5" d="M17.25 6.75L6.75 17.25"/>
    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5" d="M6.75 6.75L17.25 17.25"/>
</svg></li>`);
    });
    suggestContainer.classList.remove('active');
}

function removeTag(element, tag) {
    const index = tags.indexOf(tag);
    tags = [...tags.slice(0, index), ...tags.slice(index + 1)];
    element.parentElement.remove();
}

suggestContainer.addEventListener('click', (e) => {
    if (e.target.tagName === 'LI') {
        techInput.value = e.target.textContent.trim();
        techContainer.classList.remove('active');
        techInput.dispatchEvent(new KeyboardEvent('keydown', { key: 'Enter', code: 'Enter', keyCode: 13, which: 13 }));
    }
});

techContainer.addEventListener('click', () => {
    setTimeout(() => techInput.focus(), 0);
});

function closeSuggestions() {
    suggestContainer.classList.remove('active');
    techInput.blur();
}

document.addEventListener('click', (e) => {
    if (!techInput.contains(e.target) && !suggestContainer.contains(e.target)) {
        closeSuggestions();
    }
});
