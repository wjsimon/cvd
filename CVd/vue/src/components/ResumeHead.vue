<script setup>

import { User } from '@js/user.mjs'
import { darkMode } from '@src/js/darkmode.mjs';

const props = defineProps({
    user: User
});

</script>
<template>
    <div class="grid grid-responsive p-2 mx-4 border-b-1 justify-evenly" style="font-family: sometype;">
        <div class="flex flex-col p-2 gap-1 justify-center">
            <span class="text-3xl">{{ user.surname }} {{ user.familyName }}</span>
            <div id="decorations" class="flex flex-row">
                <div v-for="(decoration, index) in user.decorations" class="decoration text-neutral-500 dark:text-neutral-400">
                    <span>{{ decoration.value }}</span>
                    <span v-if="index != user.decorations.length - 1">•</span>
                </div>
            </div>
        </div>
        <div class="pp-container p-4">
            <img v-if="darkMode.isDark" class="pp-src-dark object-cover rounded-full border-4 border-yellow-500 dark:border-yellow-300 p-1" style="width: 100%; height: 100%;"/>
            <img v-else class="pp-src object-cover rounded-full border-4 border-yellow-500 dark:border-yellow-300 p-1" style="width: 100%; height: 100%;"/>
        </div>
        <div class="flex flex-row p-2 gap-2 items-center">
            <div class="flex flex-col items-start">
                <span v-for="contact in user.contacts" class="contact text-neutral-500 dark:text-neutral-400">{{ contact.descriptor }}:</span>
            </div>
            <div class="flex flex-col items-start">
                <span v-for="contact in user.contacts" class="contact text-neutral-500 dark:text-neutral-400">{{ contact.value }}</span>
            </div>
        </div>
    </div>
</template>
<style scoped>
    @reference "tailwindcss";

    #decorations {
        @apply gap-2 items-center justify-center flex-wrap;
    }

    .grid-responsive {
        justify-items: center;
        align-items: center;
        
        @media (width <= 1560px) {
            grid-template-columns: auto 200px;
            grid-template-rows: auto auto;
        }

        @media (width > 1560px) {
            grid-template-columns: auto 250px auto;
        }

        .one { grid-area: one; }
        .two { grid-area: two; }
        .three { grid-area: three; }
    }

    .decoration {
        @apply flex gap-2 text-sm items-center; 
    }

    .contact {
    }

    .pp-container {
        width: 250px; 
        height: 250px;
        transition: width .2s linear, height .2s linear;

        @media (width <= 1560px) {
            grid-column-start: 2;
            grid-row: span 2;
        }

        @media (width <= 1050px) {
            grid-column-start: 2;
            grid-row: span 2;
            width: 200px; 
            height: 200px;
        }
    }

    .pp-src {
        content: url("../assets/profile_picture.jpeg");
        opacity: 1;
        transition: opacity .1s linear;

        @starting-style {
            opacity: 0;
        }
    }

    .pp-src-dark {
        content: url("../assets/profile_picture_dark.jpeg");
        opacity: 1;
        transition: opacity .1s linear;

        @starting-style {
            opacity: 0;
        }
    }
</style>