<script setup>

import { defineProps } from 'vue'
import { User} from '@js/user.mjs'

const props = defineProps({
    user: User
});

</script>

<template>
    <span class="text-xl p-2 mb-2">Projects</span>
    <div class="flex flex-col flex-wrap" style="gap: 2rem;">
        <div v-for="entry in user.projects" class="flex flex-col gap-1 text-left">
            <span class="font-bold">{{ entry.description.title }}</span>
            <span class="">{{ entry.description.description }}</span>
        </div>
    </div>
</template>

<style scoped>
    @reference "tailwindcss";
</style>