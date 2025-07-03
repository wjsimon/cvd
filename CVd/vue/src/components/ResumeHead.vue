<script setup>

import { defineProps } from 'vue'
import { User} from '@js/user.mjs'

const props = defineProps({
    user: User
});

</script>
<template>
    <div class="flex flex-row p-2 mx-4 border-b-1   justify-evenly" style="font-family: sometype;">
        <div class="flex flex-col p-2 gap-1 justify-center">
            <span class="text-3xl">{{ user.surname }} {{ user.familyName }}</span>
            <div id="decorations" class="flex flex-row">
                <div v-for="(decoration, index) in user.decorations" class="decoration">
                    <span>{{ decoration.value }}</span>
                    <span v-if="index != user.decorations.length - 1">•</span>
                </div>
            </div>
        </div>
        <div class="p-4">
            <img src="../assets/profile_picture.jpeg" class="w-50 h-50 object-cover rounded-full border-4 border-yellow-500 p-1"/>
        </div>
        <div class="flex flex-row p-2 gap-2 items-center">
            <div class="flex flex-col items-start">
                <span v-for="contact in user.contacts" class="contact">{{ contact.descriptor }}:</span>
            </div>
            <div class="flex flex-col items-start">
                <span v-for="contact in user.contacts" class="contact">{{ contact.value }}</span>
            </div>
        </div>
    </div>
</template>
<style scoped>
    @reference "tailwindcss";

    #decorations {
        @apply gap-2
    }

    .decoration {
        @apply flex gap-2 text-sm text-neutral-500 dark:text-neutral-300 
    }

    .contact {
        @apply text-neutral-500 dark:text-neutral-300
    }
</style>