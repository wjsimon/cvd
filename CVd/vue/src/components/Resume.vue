<script setup>

import { ref, inject, watch } from 'vue'
import { fetchUser } from '@js/fetch.mjs'
import { currentLanguage } from '@src/js/localization.mjs';

import ResumeHead from './ResumeHead.vue';
import Milestones from './Milestones.vue';
import Skills from './Skills.vue';
import Projects from './Projects.vue';

const host = inject('httphost');
const user = ref(null);
const fetched = ref(false);

async function get() {
  try {
    user.value = await fetchUser(host, 1, currentLanguage.value);
  } catch (ex) {
    console.log(ex)
  } finally {
    fetched.value = true;
  }
}

async function refresh() { //prevents an unnecessary spinner on swapping language
    fetched.value = false;
    get(); 
}

get();

watch(currentLanguage, get);
</script>

<template>
    <div v-if="user && fetched" class="resume bg-neutral-100 dark:bg-neutral-800">
        <ResumeHead :user="user" />
        <div class="resume-body" style="margin-top: 2rem; padding: 0rem 1rem;">
            <div class="grid w-full milestones-container">
                <Milestones :user="user"/>
            </div>
            <div class="grid">
                <Skills :user="user" />
                <div class="mt-8"></div>
            </div>
            <div class="grid" style="grid-column-start: 2;">
                <Projects :user="user" />
            </div>
        </div>
    </div>
    <div v-else-if="!fetched" role="status">
        <svg aria-hidden="true" class="w-16 h-16 text-neutral-300 animate-spin dark:text-neutral-600 fill-red-500" viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z" fill="currentColor"/>
            <path d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z" fill="currentFill"/>
        </svg>
        <span class="sr-only">Loading...</span>
    </div>
    <div v-else role="status">
        <div class="flex flex-col gap-1">
            <span>Loading failed... Is the endpoint available?</span>
            <span class="text-xs text-neutral-600 dark:text-neutral-400">You can also check the dev console for more information :)</span>
            <button class="border-1 dark:border-neutral-300 p-4 mt-4 bg-yellow-500 hover:bg-yellow-600 dark:text-neutral-700 active:shadow-[inset_2px_2px_2px_rgba(0,0,0,0.6)] rounded lg" @click="refresh">Retry</button>
        </div>
    </div>
</template>

<style scoped>
    @reference "tailwindcss";

    .resume {
        @apply p-4 rounded-lg overflow-hidden;

        opacity: 1;
        transition: opacity .2s linear;

        @starting-style {
            opacity: 0;
        }
    }

    .resume-body {
        @media (width <= 1560px) {
            display: flex;
            flex-direction: column;
            @apply gap-6;
        }

        @media (width > 1560px) {
            display: grid;
            @apply gap-6;
        }
    }

    .milestones-container {
        @media (width > 1560px) {
            grid-column: 1 / span 1; grid-row: 1 / span 2;
        }
    }
</style>