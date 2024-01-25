window.addEventListener('load', () => {
    let collapseBtns = Array.from(document.querySelectorAll('.component-filter .filter-head .filter-collapse'));

    collapseBtns.forEach(btn => {
        btn.addEventListener('click', (e) => {
            e.target.closest('.component-filter').children[1].classList.toggle('collapsed');
            e.target.parentElement.parentElement.parentElement.classList.toggle('collapsed');
        });
    });

    let salarySlideCheckBox = document.getElementById('salary-filter-slide_checkbox');

    salarySlideCheckBox.addEventListener('click',(e) => {
        e.target.parentElement.classList.toggle('checked');
    });
});
