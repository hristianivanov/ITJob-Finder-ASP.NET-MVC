let filterInputs = document.querySelectorAll('input[type=checkbox]');
let experienceFilterInputs = document.querySelectorAll('input[type=checkbox][name=experience]');
let locationFilterInputs = document.querySelectorAll('input[type=checkbox][name=location]');
let teamSizeFilterInputs = document.querySelectorAll('input[type=checkbox][name=staff]');

const salaryCheckBox = document.getElementById('salary-filter-slide_checkbox');

const experienceInputsArray = Array.from(experienceFilterInputs);
const locationInputsArray = Array.from(locationFilterInputs);
const teamSizeInputsArray = Array.from(teamSizeFilterInputs);

filterInputs.forEach(input => {
    input.addEventListener('change', () => {
        const locationInputs = locationInputsArray.filter(input => input.checked);
        const experienceInputs = experienceInputsArray.filter(input => input.checked);
        const teamSizeInputs = teamSizeInputsArray.filter(input => input.checked);

        const locationFilter = {
            name: 'job_location',
            values: locationInputs.map(input => input.value)
        };

        const experienceFilter = {
            name: 'seniority',
            values: experienceInputs.map(input => input.value)
        };

        const teamSizeFilter = {
            name: 'it_employees_count',
            values: teamSizeInputs.map(input => input.value)
        }

        const filters = [locationFilter, experienceFilter, teamSizeFilter];

        const url = generateURL(filters, input.name);

        window.location.href = url;

        window.onscroll = function (e) {
            localStorage.setItem("scrollpos", window.scrollY);
        };
    });
});

document.addEventListener("DOMContentLoaded", function (event) {
    var scrollpos = localStorage.getItem("scrollpos");
    if (scrollpos) window.scrollTo(0, scrollpos);
});

const urlParams = new URLSearchParams(window.location.search);
const salaryParam = urlParams.get('salary');

if (salaryParam === 'true') {
    salaryCheckBox.checked = true;
    salaryCheckBox.parentElement.classList.add("checked");
}

function generateURL(filters) {
    const baseUrl = '/joboffer/all';
    const params = new URLSearchParams();

    filters.forEach(filter => {
        if (filter.values.length > 0) {
            params.append(filter.name, filter.values.join(','));
        }
    });

    if (salaryCheckBox.checked) {
        params.append("salary", true);
    }

    return `${baseUrl}?${params.toString()}`;
}

//filterInputs.forEach(input => {
//    input.addEventListener('change', () => {
//        let selectedLocationInputs = document.querySelectorAll('input[type=checkbox][name=location]:checked');
//        let locations = Array.from(selectedLocationInputs).map(checkedInput => checkedInput.value);

//        let selectedExperienceInputs = document.querySelectorAll('input[type=checkbox][name=experience]:checked');
//        let experiences = Array.from(selectedExperienceInputs).map(checkedInput => checkedInput.value);

//        let token = document.getElementById('RequestVerificationToken').value;

//        let data = {
//            locations: locations,
//            experiences: experiences
//        };

//        $.ajax({
//            url: '/JobOffer/FilterAll',
//            type: 'POST',
//            data: JSON.stringify(data),
//            contentType: 'application/json',
//            headers: {
//                'RequestVerificationToken': token
//            },
//            success: function (result) {
//                $('#job-offer-container').html(result);
//            },
//            error: function () {
//                console.log('An error occurred while retrieving filtered job offers.');
//            }
//        });

//    });
//});



//$('input[type="checkbox"][name="location"]').on('change', function () {
//	var selectedLocations = $('input[type="checkbox"][name="location"]:checked').map(function () {
//		return $(this).val();
//	}).get();

//	$.ajax({
//		url: '@Url.Action("GetFilteredJobOffers", "JobOffer")',
//		type: 'POST',
//		dataType: 'html',
//		data: {
//			locations: selectedLocations
//		},
//		success: function (result) {
//			$('#job-offer-container').html(result);
//		},
//		error: function () {
//			console.log('An error occurred while retrieving filtered product data.')
//		}
//	});
//});