const registerOptionContainer = document.getElementById("register-option-container");
const radioBtns = registerOptionContainer.querySelectorAll("input[type=radio]");
const radioBtnsContainers = registerOptionContainer.querySelectorAll(".radio-btn");
const createBtn = registerOptionContainer.querySelector(".section-footer > .create-btn");

const btnHrefAttribute = createBtn.getAttribute("href").toLowerCase();

radioBtnsContainers.forEach((container) =>
    container.addEventListener("click", () => {
        radioBtnsToDefaultState();

        createBtn.classList.add("active");
        container.classList.add("active");
        container.querySelector("input[type=radio]").checked = true;

        if (container.classList.contains("option-company")) {
            createBtn.textContent = "Join us as a client";
            createBtn.setAttribute("href", `${btnHrefAttribute}/register-company`);
        } else if (container.classList.contains("option-client")) {
            createBtn.textContent = "Apply as a freelancer";
            createBtn.setAttribute("href", `${btnHrefAttribute}/register-user`);
        }

    })
);

function radioBtnsToDefaultState() {
    radioBtnsContainers.forEach((container) =>
        container.classList.remove("active")
    );
    radioBtns.forEach((btn) => (btn.checked = false));
}