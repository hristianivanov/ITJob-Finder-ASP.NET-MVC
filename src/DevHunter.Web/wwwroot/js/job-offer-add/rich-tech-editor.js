let optionsButtons = document.querySelectorAll(".option-button");
let stylingBtns = document.querySelectorAll(".options button:not(:nth-last-child(-n+2))");

const modifyText = (command, defaultUi, value) => {
    document.execCommand(command, defaultUi, value);
};

optionsButtons.forEach((button) => {
    button.addEventListener("click", () => {
        modifyText(button.id, false, null);
    });
});

stylingBtns.forEach(btn => {
    btn.addEventListener("click", (e) => {
        e.preventDefault();
        let clickedButton = e.currentTarget;
        clickedButton.classList.toggle("active");
    });
});

const orderNumberBtn = document.getElementById('insertOrderedList');
const orderBulletBtn = document.getElementById('insertUnorderedList');

orderNumberBtn.addEventListener('click', (e) => {
    e.preventDefault();

    if (e.currentTarget.classList.contains('active')) {
        e.currentTarget.classList.remove('active');
    } else {
        orderBulletBtn.classList.remove('active');
        e.currentTarget.classList.add('active');
    }
})
orderBulletBtn.addEventListener('click', (e) => {
    e.preventDefault();

    if (e.currentTarget.classList.contains('active')) {
        e.currentTarget.classList.remove('active');
    } else {
        orderNumberBtn.classList.remove('active');
        e.currentTarget.classList.add('active');
    }
})