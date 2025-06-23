<script setup>

import { defineProps } from 'vue'
import { User} from '@js/user.mjs'

const props = defineProps({
    user: User
});

</script>

<template>
<span class="text-xl p-2 mb-2">Milestones</span>
<div class="flex flex-col gap-4">
    <div v-for="entry in user.milestones" class="milestone">
        <div class="milestone-head">
            <span class="head-job">{{ entry.description.row1 }}</span>
            <span class="head-date">{{ entry.start }} - {{ entry.end }}</span>
        </div>
        <div class="head-title">
            <span class="head-title">{{ entry.description.row2 }}</span>
        </div>
        <div class="milestone-content">
            {{ entry.description.description }}
        </div>
    </div>
</div>
</template>

<style scoped>
    @reference "tailwindcss";

    .milestone {
            @apply flex flex-col gap-1 rounded-lg bg-gray-100 p-2 mt-2;
        }

    .milestone-head {
        @apply flex flex-row justify-between font-bold gap-4 mb-1;
        text-align: start;
    }

    .head-title {
        @apply text-left;
    }

    .head-date {
        white-space: nowrap;
    }

    .milestone-content {
        @apply text-left;
    }
</style>