// Toggle tema terang/gelap. Tema disimpan di localStorage & diterapkan sebagai
// atribut data-theme di <html>. Nilai awal sudah diterapkan oleh inline script di <head>
// (anti-flash) sebelum file ini jalan.
(function () {
    'use strict';

    var root = document.documentElement;

    function applyTheme(theme) {
        root.setAttribute('data-theme', theme);
        try { localStorage.setItem('theme', theme); } catch (e) { }
    }

    var toggle = document.getElementById('theme-toggle');
    if (toggle) {
        toggle.addEventListener('click', function () {
            var current = root.getAttribute('data-theme') === 'dark' ? 'dark' : 'light';
            applyTheme(current === 'dark' ? 'light' : 'dark');
        });
    }
})();
