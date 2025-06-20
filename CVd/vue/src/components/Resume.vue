<script setup>

import { ref, inject } from 'vue'
import { fetchUser } from '@js/fetch.mjs'
import ResumeHead from './ResumeHead.vue';

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
        <div class="flex flex-row p-2 w-full gap-3">
            <div class="flex flex-col p-2" style="width: 50%;">
                <span class="text-xl p-2 mb-2">Milestones</span>
                <div class="flex flex-col gap-4">
                    <div v-for="entry in user.milestones" class="milestone">
                        <div class="milestone-head">
                            <span class="head-job">{{ entry.description.title }}</span>
                            <span class="head-date">{{ entry.start }} - {{ entry.end }}</span>
                        </div>
                        <div class="head-title"></div>
                        <div class="milestone-content"></div>
                    </div>
                </div>
            </div>
            <div class="border-r-1 my-4"></div>
            <div class="flex flex-col p-2" style="width: 50%;">
                <span class="text-xl p-2 mb-2">Skills</span>
                <div class="flex flex-row flex-wrap gap-4">
                    <div v-for="entry in user.skills" class="skill">
                        <span>{{ entry.displayValue }}</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <button v-else @click="get">go</button>
</template>

<style scoped>
    @reference "tailwindcss";

    .resume {
        @apply border-1 border-solid rounded-xl;
    }

    .milestone {
        @apply flex flex-col gap-1;
    }

    .milestone-head {
        @apply flex flex-row justify-between gap-4;
        text-align: start;
    }

    .head-date {
        white-space: nowrap;
    }
</style>