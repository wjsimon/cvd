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
    <div v-if="user" class="resume">
        <ResumeHead :user="user" />
        <div class="flex flex-row p-2 w-full" style="gap: 2rem;">
            <div class="flex flex-col p-4" style="width: 50%;">
                <Milestones :user="user"/>
            </div>
            <div class="flex flex-row p-4" style="width: 50%;">
                <div class="flex flex-col">
                    <Skills :user="user" />
                    <div class="mt-8"></div>
                    <Projects :user="user" />
                </div>
            </div>
        </div>
    </div>
    <button v-else @click="get">go</button>
</template>

<style scoped>
    @reference "tailwindcss";

    .resume {
        @apply p-4 bg-white dark:bg-neutral-800 rounded-lg overflow-hidden;
    }
</style>