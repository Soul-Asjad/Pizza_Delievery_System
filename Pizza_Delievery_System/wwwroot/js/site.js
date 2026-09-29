document.addEventListener('DOMContentLoaded', function () {

    const navbar = document.querySelector('.pizza-navbar');
    const categoryBar = document.querySelector('.category-nav-sticky');
    const buttons = document.querySelectorAll('.category-btn[data-target]');

    if (!categoryBar || buttons.length === 0) return;

    // --- Position the sticky bar right below the navbar ---
    function setStickyOffset() {
        const navHeight = navbar ? navbar.offsetHeight : 0;
        categoryBar.style.top = navHeight + 'px';
    }
    setStickyOffset();
    window.addEventListener('resize', setStickyOffset);

    // --- Build list of { button, section } pairs ---
    const items = [];
    buttons.forEach(function (btn) {
        const id = btn.getAttribute('data-target');
        const section = document.getElementById(id);
        if (section) items.push({ btn: btn, section: section });

        // Smooth scroll on click, accounting for sticky headers
        btn.addEventListener('click', function () {
            const target = document.getElementById(btn.getAttribute('data-target'));
            if (!target) return;

            const offset = (navbar ? navbar.offsetHeight : 0) + categoryBar.offsetHeight + 12;
            const top = target.getBoundingClientRect().top + window.pageYOffset - offset;

            window.scrollTo({ top: top, behavior: 'smooth' });
        });
    });

    // --- Highlight the active button based on scroll position ---
    function onScroll() {
        const offset = (navbar ? navbar.offsetHeight : 0) + categoryBar.offsetHeight + 30;
        const scrollPos = window.pageYOffset + offset;

        let activeId = items.length ? items[0].btn.getAttribute('data-target') : null;

        items.forEach(function (item) {
            if (item.section.offsetTop <= scrollPos) {
                activeId = item.btn.getAttribute('data-target');
            }
        });

        buttons.forEach(function (btn) {
            btn.classList.toggle('active', btn.getAttribute('data-target') === activeId);
        });

        // Add a subtle shadow once the bar is actually stuck
        categoryBar.classList.toggle('is-stuck', window.pageYOffset > categoryBar.offsetTop - 5);
    }

    window.addEventListener('scroll', onScroll, { passive: true });
    onScroll();

});