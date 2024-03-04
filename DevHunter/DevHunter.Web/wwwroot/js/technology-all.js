const attachContextMenu = (() => {
    const contextMenu = document.createElement('ul');

    const hideOnResize = () => hideMenu(true);

    function hideMenu(e) {
        if (e === true || !contextMenu.contains(e.target)) {
            contextMenu.remove();
            document.removeEventListener('click', hideMenu);
            window.removeEventListener('resize', hideOnResize);
        }
    };

    const attachOption = (target, opt) => {
        const item = document.createElement('li');
        item.className = 'context-menu-item';
        item.innerHTML = `<span>${opt.label}</span>`;
        item.addEventListener('click', e => {
            e.stopPropagation();
            if (!opt.subMenu || opt.subMenu.length === 0) {
                opt.action(opt);
                hideMenu(true);
            }
        });

        target.appendChild(item);

        if (opt.subMenu && opt.subMenu.length) {
            const subMenu = document.createElement('ul');
            subMenu.className = 'context-sub-menu';
            item.appendChild(subMenu);
            opt.subMenu.forEach(subOpt => attachOption(subMenu, subOpt))
        }
    };

    const showMenu = (e, menuOptions) => {
        e.preventDefault();
        contextMenu.className = 'context-menu';
        contextMenu.innerHTML = '';
        menuOptions.forEach(opt => attachOption(contextMenu, opt))
        document.body.appendChild(contextMenu);

        const { innerWidth, innerHeight } = window;
        const { offsetWidth, offsetHeight } = contextMenu;
        let x = 0;
        let y = 0;

        if (e.clientX >= (innerWidth / 2)) {
            contextMenu.classList.add('left');
        }

        if (e.clientY >= (innerHeight / 2)) {
            contextMenu.classList.add('top');
        }

        if (e.clientX >= (innerWidth - offsetWidth)) {
            x = '-100%';
        }

        if (e.clientY >= (innerHeight - offsetHeight)) {
            y = '-100%';
        }

        contextMenu.style.left = e.clientX + 'px';
        contextMenu.style.top = e.clientY + 'px';
        contextMenu.style.transform = `translate(${x}, ${y})`;
        document.addEventListener('click', hideMenu);
        window.addEventListener('resize', hideOnResize);
    };

    return (el, options) => {
        el.addEventListener('contextmenu', (e) => showMenu(e, options));
    };
})();

document.querySelectorAll('.technology-card')
    .forEach(card => {
        attachContextMenu(card, [
            { label: "Edit", action(o) { editTechnology(card.id) } },
            { label: "Delete", action(o) { deleteTechnology(card.id) } },
        ]);
    });

function editTechnology(cardId) {
    const anchor = document.createElement('a');
    anchor.href = `/Technology/Edit/${cardId}`;
    anchor.click();
}

async function deleteTechnology(cardId) {
    const confirmation = confirm("Are you sure you want to delete this technology?");
    if (!confirm) {
        return;
    }

    let csrfToken = document.querySelector('input[name="__RequestVerificationToken"]').value;

    try {
        const response = await fetch(`/Technology/Delete/${cardId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
                'RequestVerificationToken': csrfToken
            },
            body: `id=${cardId}`
        });

        if (response.ok) {
            window.location.href = response.url;
        } else {
            console.error(`Error: ${response.status} - ${response.statusText}`);
        }
    } catch (error) {
        console.error('An error occurred:', error);
    }
}
