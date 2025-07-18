import { reactive } from 'vue';

const knownLanguages = ['en', 'de'];

var langInitialized = false;
var langMaps = new Map();

export const currentLanguage = reactive({
    value: 'en'
});

export function changeLanguage(langCode) {
    if (!knownLanguages.includes(langCode)) { return; }
    if (langCode == currentLanguage.value) { return; }

    currentLanguage.value = langCode;
    localStorage.setItem('prefered-language', currentLanguage.value);
}

export function initLanguage() {
    if (langInitialized) { return; }

    for (let i = 0; i < knownLanguages.length; i++) {
        addLanguageMap(knownLanguages[i]);
    }

    let prefLang = localStorage.getItem('prefered-language');

    if (prefLang) {
        changeLanguage(prefLang);
    }
    else {
        changeLanguage('de');
    }

    langInitialized = true;
}

export function getResource(langCode, key) {
    let map = langMaps.get(langCode);
    let value = langMaps.get(langCode).get(key);
    if (value) { return value; }

    return key;
}

export function getResourceCurrent(key) {
    return getResource(currentLanguage.value, key);
}

export function setResource(langCode, map) {
    langMaps.set(langCode, map);
}

function addLanguageMap(langCode) {
    langMaps.set(langCode, new Map());
}