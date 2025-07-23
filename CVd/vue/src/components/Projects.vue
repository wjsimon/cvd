<script setup>

import { User } from '@js/user.mjs'
import { getResourceCurrent } from '@src/js/localization.mjs';

const props = defineProps({
    user: User
});

</script>

<template>
    <span class="text-xl p-2 mb-2 underline">{{ getResourceCurrent('projects') }}</span>
    <div class="flex flex-col flex-wrap" style="gap: 2rem;">
        <div v-for="entry in user.projects" class="flex flex-col gap-1 text-left">
            <div class="flex flex-row justify-between items-center">
                <span class="font-bold">{{ entry.description.title }}</span>
                <div class="flex flex-row gap-2">
                    <span v-for="tag in entry.tags" class="text-sm font-bold bg-yellow-500 dark:bg-yellow-400 dark:text-neutral-800 rounded-lg px-2.5 py-1.5 cursor-default" style="print-color-adjust: exact;">{{ tag }}</span>
                </div>
            </div>
            <span class="">{{ entry.description.description }}</span>
            <a :href="entry.link" target="_blank" rel="noopener noreferrer" class="font-bold self-end mt-2">{{ entry.link }}</a>
        </div>
    </div>
</template>

<style scoped>
    @reference "tailwindcss";
</style>