let filterInputs = document.querySelectorAll('input[type=checkbox]');
let experienceFilterInputs = document.querySelectorAll('input[type=checkbox][name=experience]');

filterInputs.forEach(input => {
    input.addEventListener('change', () => {
        let selectedLocationInputs = document.querySelectorAll('input[type=checkbox][name=location]:checked');
        let locations = Array.from(selectedLocationInputs).map(checkedInput => checkedInput.value);

        let selectedExperienceInputs = document.querySelectorAll('input[type=checkbox][name=experience]:checked');
        let experiences = Array.from(selectedExperienceInputs).map(checkedInput => checkedInput.value);

        let token = document.getElementById('RequestVerificationToken').value;

        let data = {
            locations: locations,
            experiences: experiences
        };

        $.ajax({
            url: '/JobOffer/FilterAll',
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            headers: {
                'RequestVerificationToken': token
            },
            success: function (result) {
                $('#job-offer-container').html(result);
            },
            error: function () {
                console.log('An error occurred while retrieving filtered job offers.');
            }
        });

    });
});



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