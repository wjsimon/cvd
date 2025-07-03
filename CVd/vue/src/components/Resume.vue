<script setup>

import { ref, inject } from 'vue'
import { fetchUser } from '@js/fetch.mjs'

import ResumeHead from './ResumeHead.vue';
import Milestones from './Milestones.vue';
import Skills from './Skills.vue';
import Projects from './Projects.vue';

const host = inject('httphost');
const user = ref(null);

async function get() {
  user.value = await fetchUser(host, 1, 'de');
}

get();
</script>

<template>
    <!-- make response, maybe even "reactive" -->
    <div v-if="user" class="resume bg-neutral-100 dark:bg-neutral-800">
        <ResumeHead :user="user" />
        <div class="resume-body">
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
    <button v-else @click="get">go</button>
</template>

<style scoped>
    @reference "tailwindcss";

    .resume {
        @apply p-4 rounded-lg overflow-hidden;
    }

    .resume-body {
        @media (width <= 1440px) {
            display: flex;
            flex-direction: column;
            @apply gap-6;
        }

        @media (width > 1440px) {
            display: grid;
            @apply gap-6;
        }
    }

    .milestones-container {
        @media (width > 1440px) {
            grid-column: 1 / span 1; grid-row: 1 / span 2;
        }
    }
</style>