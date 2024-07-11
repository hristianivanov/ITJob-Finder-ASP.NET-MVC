// Function to handle click events on dropdown options
function handleOptionClick(option, select, caret, menu, selected) {
    selected.innerText = option.innerText;
    selected.classList.add('text-fade-in');

    setTimeout(() => {
        selected.classList.remove('text-fade-in');
    }, 300);

    select.classList.remove('select-clicked');
    caret.classList.remove('caret-remove');
    menu.classList.remove('menu-open');

    const options = menu.querySelectorAll('.menu li');
    options.forEach(opt => {
        opt.classList.remove('active');
    });

    option.classList.add('active');

    let dropdownType = select.parentElement.classList;

    if (dropdownType.contains("pay")) {
        payOptions(select.querySelector('.selected'), menu);
    } else if (dropdownType.contains("job-location")) {
        seniorityOptions();
    }
}

// Select dropdown elements
const dropdowns = document.querySelectorAll('.dropdown');

// Iterate over dropdowns
dropdowns.forEach(dropdown => {
    const select = dropdown.querySelector('.select');
    const caret = dropdown.querySelector('.caret');
    const menu = dropdown.querySelector('.menu');
    const selected = dropdown.querySelector('.selected');
    const options = dropdown.querySelectorAll('.menu li');

    // Toggle dropdown menu
    select.addEventListener('click', () => {
        select.classList.toggle('select-clicked');
        caret.classList.toggle('caret-rotate');
        menu.classList.toggle('menu-open');
    });

    // Handle click events on dropdown options
    options.forEach(option => {
        option.addEventListener('click', () => {
            handleOptionClick(option, select, caret, menu, selected);
        });
    });

    // Close dropdown menu when clicking outside
    window.addEventListener('click', (e) => {
        const size = dropdown.getBoundingClientRect();

        if (e.clientX < size.left ||
            e.clientX > select.right ||
            e.clientY < size.top ||
            e.clientY > size.bottom) {
            select.classList.remove('select-clicked');
            caret.classList.remove('caret-rotate');
            menu.classList.remove('menu-open');
        }
    });
});
