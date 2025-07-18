import { reactive } from 'vue';

export const darkMode = reactive({
    isDark: false
});

export function toggleDarkMode(dark) {
    let html = document.documentElement;
    if (dark) {
        html.classList.add('dark');
        localStorage.setItem('prefered-theme', 'dark');
        darkMode.isDark = true;
        return 'dark';
    }
    else {
        html.classList.remove('dark');
        localStorage.setItem('prefered-theme', 'light');
        darkMode.isDark = false;
        return 'light';
    }
}

export function initDarkMode() {
    let theme = getPreferedTheme();
    
    if (!theme) {
        toggleDarkMode(false);
        localStorage.setItem('prefered-theme', 'light');
        darkMode.isDark = false;
        return 'light';
    }
    else {
        darkMode.isDark = true;
        return toggleDarkMode(theme == 'dark');
    }
}

export function getPreferedTheme() {
    return localStorage.getItem('prefered-theme');
}