<script setup>
import { SunIcon, MoonIcon, Bars2Icon, XMarkIcon } from '@heroicons/vue/24/solid';
import { ref } from 'vue';
import { initDarkMode, toggleDarkMode } from '@src/js/darkmode.mjs';
import { currentLanguage, changeLanguage } from '@src/js/localization.mjs';
import { screen } from '@js/screen.mjs';

const isDark = ref(false);
const showMenu = ref(false);

function setTheme(dark) {
  isDark.value = toggleDarkMode(dark) == 'dark';
}

function getLangSelection(lang) {
  return lang == currentLanguage.value;
}

function toggleMenu() {
  showMenu.value = !showMenu.value;
}

function init() {
  isDark.value = initDarkMode() == 'dark';
}

init();
</script>
<template>
  <div v-if="screen == 'regular' || (screen == 'slim' && showMenu)" class="fixed flex flex-col gap-2 noprint" :class="{ 'top-offset' : showMenu }" style="right: 2.5rem; top: 2rem;">
    <div class="flex flex-row gap-2 p-2 bg-neutral-100 dark:bg-neutral-800 rounded-xl drop-shadow-md">
        <div @click="setTheme(false)" class="icon-btn-outer rounded-full" :class="{ selected: !isDark }">
          <div class="icon-btn flex justify-center items-center bg-neutral-300 dark:bg-neutral-700 rounded-full">
            <SunIcon class="size-4" />
          </div>
        </div>
        <div @click="setTheme(true)" class="icon-btn-outer rounded-full" :class="{ 'selected-dark': isDark }">
          <div class="icon-btn flex justify-center items-center bg-neutral-300 dark:bg-neutral-700 rounded-full">
            <MoonIcon class="size-4" />
          </div>
        </div>
    </div>
    <div class="flex flex-row gap-2 p-2 bg-neutral-100 dark:bg-neutral-800 rounded-xl drop-shadow-md" style="right: 2.5rem; top: 6.5rem;">
      <div @click="changeLanguage('en')" class="icon-btn-outer lang rounded-full" :class="{ selected: getLangSelection('en') }">
        <div class="icon-btn flex justify-center items-center bg-neutral-300 dark:bg-neutral-700 rounded-full">
          en
        </div>
      </div>
      <div @click="changeLanguage('de')" class="icon-btn-outer lang rounded-full" :class="{ selected: getLangSelection('de') }">
        <div class="icon-btn flex justify-center items-center bg-neutral-300 dark:bg-neutral-700 rounded-full">
          de
        </div>
      </div>
    </div>
  </div>
  <div v-if="screen == 'slim'">
    <div class="fixed flex flex-column rounded-xl drop-shadow-md" style="right: 2.5rem; top: 2.5rem;">
        <div class="icon-btn flex justify-center items-center bg-neutral-100 dark:bg-neutral-800 rounded-full" @click="toggleMenu">
          <Bars2Icon v-if="!showMenu" class="size-4" />
          <XMarkIcon v-else class="size-4" />
        </div>
    </div>
  </div>
</template>
<style scoped>

.noprint {
  @media print {
    display: none;
  }
}

.icon-btn-outer {
  border: 3px solid;
  border-color: transparent;
  padding: 2px;
  transition: color .1s linear, background-color .1s linear, border .1s linear;
}

.icon-btn {
  width: 40px; 
  height: 40px; 
  padding: 0;
}

.top-offset {
  top: 6rem !important;
}

.lang.selected {
  border-color: var(--color-blue-600);
}

.lang.selected-dark {
  border-color: var(--color-blue-400);
}

.selected {
  border-color: var(--color-yellow-500);
}

.selected-dark {
  border-color: var(--color-yellow-300);
}
</style>