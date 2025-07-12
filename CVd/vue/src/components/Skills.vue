<script setup>

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
        <div v-for="entry in user.skills" class="skill dark:skill-dark" :class="getCategoryClass(entry.category)">
            <span class="bg-neutral-100 dark:bg-neutral-800">{{ entry.displayValue }}</span>
        </div>
    </div>
</template>

<style scoped>
    @reference "tailwindcss";

    .skill {
        @apply relative inline-flex items-center justify-center p-0.5 mb-2 me-2 overflow-hidden text-sm font-medium rounded-sm;
        font-family: sharetech;
    }

    .skill.category-1 {
        @apply border-2 border-blue-700;
    }

    .skill.category-2 {
        @apply border-2 border-red-500;
    }

    .skill.category-3 {
        @apply border-2 border-green-600;
    }

    .skill.category-1-f {
        @apply rounded-lg bg-gradient-to-br from-purple-600 to-blue-500 group-hover:from-purple-600 group-hover:to-blue-500 hover:text-white focus:ring-4 focus:outline-none focus:ring-blue-300;
    }

    .skill.category-2-f {
        @apply rounded-lg bg-gradient-to-br from-purple-600 to-red-500 group-hover:from-purple-600 group-hover:to-blue-500 hover:text-white focus:ring-4 focus:outline-none focus:ring-blue-300
    }

    .skill.category-3-f {
        @apply rounded-lg bg-gradient-to-br from-purple-600 to-green-500 group-hover:from-purple-600 group-hover:to-blue-500 hover:text-white focus:ring-4 focus:outline-none focus:ring-blue-300
    }

    .skill > span {
        @apply relative px-5 py-2.5 transition-all ease-in duration-75 rounded-xs
    }

    .skill.category-1 > span {
        @apply hover:bg-blue-400; /*900*/
    }

    .skill.category-2 > span {
        @apply hover:bg-red-300; /*800*/
    }

    .skill.category-3 > span {
        @apply hover:bg-green-300; /*700*/
    }

</style>