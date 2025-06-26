<script setup>

import { defineProps } from 'vue'
import { User} from '@js/user.mjs'

const props = defineProps({
    user: User
});

function getCategoryClass(category) {
    switch (category) {
        case 1: return 'category-1';
        case 2: return 'category-2';
        case 3: return 'category-3';
        default: return '';
    };
}
</script>

<template>
    <span class="text-xl p-2 mb-2 underline">Skills</span>
    <div class="flex flex-row flex-wrap gap-4">
        <div v-for="entry in user.skills" class="skill" :class="getCategoryClass(entry.category)">
            <span>{{ entry.displayValue }}</span>
        </div>
    </div>
</template>

<style scoped>
    @reference "tailwindcss";

    .skill {
        @apply relative inline-flex items-center justify-center p-0.5 mb-2 me-2 overflow-hidden text-sm font-medium text-neutral-900 rounded-lg;
    }

    .skill.category-1 {
        @apply bg-gradient-to-br from-purple-600 to-blue-500 group-hover:from-purple-600 group-hover:to-blue-500 hover:text-white focus:ring-4 focus:outline-none focus:ring-blue-300;
    }

    .skill.category-2 {
        @apply bg-gradient-to-br from-purple-600 to-red-500 group-hover:from-purple-600 group-hover:to-blue-500 hover:text-white focus:ring-4 focus:outline-none focus:ring-blue-300
    }

    .skill.category-3 {
        @apply bg-gradient-to-br from-purple-600 to-green-500 group-hover:from-purple-600 group-hover:to-blue-500 hover:text-white focus:ring-4 focus:outline-none focus:ring-blue-300
    }

    .skill > span {
        @apply relative px-5 py-2.5 transition-all ease-in duration-75 bg-white dark:bg-neutral-900 rounded-md hover:bg-transparent;
    }
</style>