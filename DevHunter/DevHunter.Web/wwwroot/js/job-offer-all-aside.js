let collapseBtns = Array.from(document.querySelectorAll('.component-filter .filter-head .filter-collapse'));
collapseBtns.forEach(btn => {
    btn.addEventListener('click', (e) => {
        const container = e.target.parentElement.parentElement.parentElement;
        const filters = container.querySelector('.component-filter');

        if (!container.classList.contains('filters-wrap')) {
            filters.classList.toggle('collapsed');
            container.classList.toggle('collapsed');
        }
    });
});

let salarySlideCheckBox = document.getElementById('salary-filter-slide_checkbox');
salarySlideCheckBox.addEventListener('click', (e) => {
    e.target.parentElement.classList.toggle('checked');
});
let oldMoreText = '';
function seeMore(target) {
    const overflowContaienr = target.parentElement.querySelector('.filter-overflow-checkboxes');

    if (overflowContaienr.classList.contains('hidden')) {

        overflowContaienr.classList.remove('hidden');
        oldMoreText = target.textContent;
        target.textContent = 'See less';
    }
    else {
        target.textContent = oldMoreText;

        overflowContaienr.classList.add('hidden');
    }
}

let checkboxes = document.querySelectorAll('.component-filter .checkbox');

checkboxes.forEach(checkbox => {
    const count = checkbox.querySelector('.counter');

    if (count.textContent === "0") {
        checkbox.classList.add('disabled');
    }
})