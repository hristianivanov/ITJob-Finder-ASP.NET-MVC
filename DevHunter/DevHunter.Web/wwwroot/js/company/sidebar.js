let sidebarNavItems = document.querySelectorAll('.sidebar-nav-list > .sidebar-nav-item');
let jobNavItem = document.querySelector('.company-name-holder .company-scroll-to-job');

jobNavItem.addEventListener('click', (e) => {
    e.preventDefault();
    const hash = e.target.getAttribute('href');
    scrollToTarget(hash, 1000);
});

sidebarNavItems.forEach(item => {
    item.addEventListener('click', (e) => {
        e.preventDefault();
        const hash = item.getAttribute('href');
        removeSideItemCurr();
        item.classList.add('current');
        scrollToTarget(hash, 1000);
    });
});

function removeSideItemCurr() {
    sidebarNavItems.forEach(item => {
        item.classList.remove('current');
    })
}

function scrollToTarget(target, duration) {
    const targetElement = document.querySelector(target);
    const startPosition = window.pageYOffset;
    const targetPosition = targetElement.getBoundingClientRect().top + window.pageYOffset;
    const distance = targetPosition - startPosition;
    let startTime = null;

    function animation(currentTime) {
        if (startTime === null) {
            startTime = currentTime;
        }
        const timeElapsed = currentTime - startTime;
        const run = ease(timeElapsed, startPosition, distance, duration);
        window.scrollTo(0, run);
        if (timeElapsed < duration) {
            requestAnimationFrame(animation);
        }
    }

    function ease(t, b, c, d) {
        t /= d / 2;
        if (t < 1) return c / 2 * t * t + b;
        t--;
        return -c / 2 * (t * (t - 2) - 1) + b;
    }

    requestAnimationFrame(animation);
}

//occurs bugs
// Listen for scroll event on the window
// window.addEventListener('scroll', () => {
//     let fromTop = window.scrollY;
//
//     // Loop through each sidebar nav item
//     sidebarNavItems.forEach(item => {
//         const section = document.querySelector(item.getAttribute('href'));
//         const sectionTop = section.offsetTop;
//         const sectionHeight = section.offsetHeight;
//
//         // Check if the current scroll position is within the section
//         if (fromTop >= sectionTop && fromTop < sectionTop + sectionHeight) {
//             removeSideItemCurr();
//             item.classList.add('current');
//         }
//     });
// });
