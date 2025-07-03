<script setup>

import { defineProps } from 'vue'
import { User} from '@js/user.mjs'

const props = defineProps({
    user: User
});

</script>

<template>
<span class="text-xl p-2 mb-2 underline">Milestones</span>
<div class="flex flex-col gap-4">
    <div v-for="entry in user.milestones" class="milestone bg-neutral-100 dark:bg-neutral-800">
        <div class="milestone-head">
            <span class="head-job">{{ entry.description.row1 }}</span>
            <span class="head-date">{{ entry.start }} - {{ entry.end }}</span>
        </div>
        <div v-if="entry.description.row2" class="head-title">
            <span class="head-title">{{ entry.description.row2 }}</span>
        </div>
        <div v-if="entry.description.description" class="milestone-content">
            {{ entry.description.description }}
        </div>
    </div>
</div>
</template>

<style scoped>
    @reference "tailwindcss";

    .milestone {
        @apply flex flex-col gap-1 rounded-sm p-2 mt-2;
    }

    .milestone-head {
        @apply flex flex-row justify-between font-bold gap-4;
        text-align: start;
    }

    .head-title {
        @apply text-left;
    }

    .head-date {
        white-space: nowrap;
    }

    .milestone-content {
        @apply text-left mb-1 mt-1;
    }
</style>