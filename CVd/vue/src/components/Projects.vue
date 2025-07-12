<script setup>

import { User} from '@js/user.mjs'

const props = defineProps({
    user: User
});

</script>

<template>
    <span class="text-xl p-2 mb-2 underline">Projects</span>
    <div class="flex flex-col flex-wrap" style="gap: 2rem;">
        <div v-for="entry in user.projects" class="flex flex-col gap-1 text-left">
            <div class="flex flex-row justify-between">
                <span class="font-bold">{{ entry.description.title }}</span>
            </div>
            <span class="">{{ entry.description.description }}</span>
            <a :href="entry.link" class="font-bold self-end mt-2">{{ entry.link }}</a>
        </div>
    </div>
</template>

<style scoped>
    @reference "tailwindcss";
</style>