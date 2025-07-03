<script setup>
import { SunIcon, MoonIcon } from '@heroicons/vue/24/solid';
import { ref } from 'vue';
import { initDarkMode, toggleDarkMode, getPreferedTheme } from '@js/darkmode';


const isDark = ref(false);

function setTheme(dark) {
  isDark.value = toggleDarkMode(dark) == 'dark';
}

function init() {
  isDark.value = initDarkMode() == 'dark';
}

init();

</script>
<template>
    <div class="flex flex-col gap-2">
        <div class="fixed flex flex-row gap-2 p-2 bg-neutral-100 dark:bg-neutral-800 rounded-xl" style="right: 1rem; top: 2rem;">
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
    </div>
</template>
<style scoped>
.icon-btn-outer {
  border: 3px solid;
  border-color: transparent;
  padding: 1px;
  transition: color .1s linear, background-color .1s linear, border .1s linear;
}

.icon-btn {
  width: 40px; 
  height: 40px; 
  padding: 0;
}

.selected {
  border-color: var(--color-yellow-500);
}

.selected-dark {
  border-color: var(--color-yellow-300);
}
</style>