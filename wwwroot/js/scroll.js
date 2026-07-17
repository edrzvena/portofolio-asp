// Interaksi scroll: smooth-scroll ke section, scroll-spy (nav aktif), menu mobile,
// animasi reveal, dan toggle "Read more" di kartu proyek.
// Port dari hooks/useScrollEffects.js + komponen React terkait.
(function () {
    'use strict';

    var HEADER_OFFSET = 64; // tinggi navbar (4rem)

    // --- Smooth scroll ke section berdasarkan data-scroll-to ---
    function scrollToSection(id) {
        var el = document.getElementById(id);
        if (!el) return;
        var top = el.getBoundingClientRect().top + window.pageYOffset - HEADER_OFFSET;
        window.scrollTo({ top: top, behavior: 'smooth' });
    }

    document.querySelectorAll('[data-scroll-to]').forEach(function (btn) {
        btn.addEventListener('click', function () {
            scrollToSection(btn.getAttribute('data-scroll-to'));
            closeMobileMenu();
        });
    });

    // --- Menu mobile ---
    var menuToggle = document.getElementById('menu-toggle');
    var mobilePanel = document.getElementById('navbar-mobile');
    var iconMenu = menuToggle ? menuToggle.querySelector('.icon-menu') : null;
    var iconClose = menuToggle ? menuToggle.querySelector('.icon-close') : null;

    function setMenu(open) {
        if (!mobilePanel || !menuToggle) return;
        mobilePanel.classList.toggle('is-open', open);
        menuToggle.setAttribute('aria-expanded', open ? 'true' : 'false');
        if (iconMenu) iconMenu.style.display = open ? 'none' : 'block';
        if (iconClose) iconClose.style.display = open ? 'block' : 'none';
    }
    function closeMobileMenu() { setMenu(false); }

    if (menuToggle) {
        menuToggle.addEventListener('click', function () {
            var isOpen = mobilePanel.classList.contains('is-open');
            setMenu(!isOpen);
        });
    }

    // --- Scroll-spy: tandai nav link aktif ---
    var sectionIds = ['skills', 'experience', 'education', 'certificates', 'projects', 'contact'];

    function updateActiveNav() {
        var scrollPos = window.pageYOffset + HEADER_OFFSET + 36; // +100px kira-kira seperti versi React
        var active = null;
        for (var i = 0; i < sectionIds.length; i++) {
            var el = document.getElementById(sectionIds[i]);
            if (!el) continue;
            var top = el.offsetTop;
            var bottom = top + el.offsetHeight;
            if (scrollPos >= top && scrollPos < bottom) { active = sectionIds[i]; break; }
        }
        document.querySelectorAll('[data-nav], [data-nav-mobile]').forEach(function (link) {
            var id = link.getAttribute('data-nav') || link.getAttribute('data-nav-mobile');
            link.classList.toggle('is-active', id === active);
        });
    }

    var ticking = false;
    window.addEventListener('scroll', function () {
        if (!ticking) {
            window.requestAnimationFrame(function () { updateActiveNav(); ticking = false; });
            ticking = true;
        }
    }, { passive: true });
    updateActiveNav();

    // --- Reveal on scroll ---
    var reveals = document.querySelectorAll('.reveal');
    if ('IntersectionObserver' in window && reveals.length) {
        var observer = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    entry.target.classList.add('is-visible');
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold: 0.12 });
        reveals.forEach(function (el) { observer.observe(el); });
    } else {
        reveals.forEach(function (el) { el.classList.add('is-visible'); });
    }

    // --- "Read more" pada kartu proyek ---
    document.querySelectorAll('.project-card').forEach(function (card) {
        var desc = card.querySelector('.project-desc');
        var btn = card.querySelector('.readmore-btn');
        if (!desc || !btn) return;

        // Tampilkan tombol hanya jika teks benar-benar terpotong saat di-clamp.
        if (desc.scrollHeight > desc.clientHeight + 1) {
            btn.style.display = 'inline-block';
        }

        btn.addEventListener('click', function () {
            var clamped = desc.classList.toggle('clamped');
            btn.textContent = clamped ? btn.getAttribute('data-more') : btn.getAttribute('data-less');
        });
    });
})();
