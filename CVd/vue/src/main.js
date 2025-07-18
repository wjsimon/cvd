import { createApp } from 'vue'
import './style.css'
import './css/fira-sans.css'
import App from './App.vue'
import { initLanguage, setResource } from './js/localization.mjs'
import { initScreen } from './js/screen.mjs'

initLanguage();

setResource('de', new Map([
    ['milestones', 'Lebenslauf'],
    ['skills', 'Fertigkeiten'],
    ['projects', 'Projekte'],
    ['print-info', 'Dieses Dokument ist via Druck aus einer interaktiven Website entstanden. Diese Website ist ebenfalls öffentlich auf meinem GitHub verfügbar, unter www.github.com/wjsimon/cvd']
]));

setResource('en', new Map([
    ['milestones', 'Resume'],
    ['skills', 'Skills'],
    ['projects', 'Projects'],
    ['print-info', 'This document was printed from an interactive web page. This web page is also available publicly on my github here: www.github.com/wjsimon/cvd']
]));

initScreen();

const app = createApp(App);
app.provide('httphost', 'http://localhost:5148');
app.provide('httpshost', 'https://localhost:7124');
app.mount('#app');