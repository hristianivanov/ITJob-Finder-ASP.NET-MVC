function submitForm() {
	document.getElementById("jobSearchForm").submit();
}

let categories = document.querySelectorAll('#section-category-block .category-block');

categories.forEach(category => {
	const name = category.querySelector('.category-name').textContent.trim();

	if (name.toLowerCase().includes('backend')) {
		category.classList.add('color-back-end-development');
	} else if (name.toLowerCase().includes('infrastructure')) {
		category.classList.add('color-infrastructure');
	} else if (name.toLowerCase().includes('mobile')) {
		category.classList.add('color-mobile-development');
	} else if (name.toLowerCase().includes('frontend')) {
		category.classList.add('color-front-end-development');
	} else if (name.toLowerCase().includes('quality')) {
		category.classList.add('color-quality-assurance');
	} else if (name.toLowerCase().includes('data')) {
		category.classList.add('color-data-science');
	} else if (name.toLowerCase().includes('customer')) {
		category.classList.add('color-customer-support');
	} else if (name.toLowerCase().includes('fullstack')) {
		category.classList.add('color-full-stack-development');
	} else if (name.toLowerCase().includes('pm/ba')) {
		category.classList.add('color-pm-ba-and-more');
	} else if (name.toLowerCase().includes('erp / crm')) {
		category.classList.add('color-erp-crm-development');
	} else if (name.toLowerCase().includes('arts')) {
		category.classList.add('color-ui-ux-and-arts');
	} else if (name.toLowerCase().includes('technical')) {
		category.classList.add('color-technical-support');
	} else if (name.toLowerCase().includes('hardware')) {
		category.classList.add('color-hardware-and-engineering');
	}
});

let otherCategories = document.querySelectorAll('.homepage-other-categories .homepage-other-category');

otherCategories.forEach(category => {
	const name = category.querySelector('.cat-title').textContent.trim();

	if (name.toLowerCase().includes('junior')) {
		category.classList.add('junior-intern');
	} else if (name.toLowerCase().includes('management')) {
		category.classList.add('it-management');
	}
});
