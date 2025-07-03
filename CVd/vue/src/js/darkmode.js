export function toggleDarkMode(dark) {
    let html = document.documentElement;
    if (dark) {
        html.classList.add('dark');
        localStorage.setItem('prefered-theme', 'dark');
        return 'dark';
    }
    else {
        html.classList.remove('dark');
        localStorage.setItem('prefered-theme', 'light');
        return 'light';
    }
}

export function initDarkMode() {
    let theme = getPreferedTheme();
    
    if (!theme) {
        toggleDarkMode(false);
        localStorage.setItem('prefered-theme', 'light');
        return 'light';
    }
    else {
        return toggleDarkMode(theme == 'dark');
    }
}

export function getPreferedTheme() {
    return localStorage.getItem('prefered-theme');
}