import { createApp } from 'vue'
import './style.css'
import './css/fira-sans.css'
import App from './App.vue'

const app = createApp(App);
app.provide('httphost', 'http://localhost:5148');
app.provide('httpshost', 'https://localhost:7124');
app.mount('#app');