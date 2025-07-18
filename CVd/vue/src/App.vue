<script setup>
import Resume from '@components/Resume.vue'
import Controls from '@components/Controls.vue';

import { watch } from 'vue';
import { currentLanguage, getResourceCurrent } from '@src/js/localization.mjs';

function update() {
  console.log('language changed to ' + currentLanguage.value);
  //this.$forceUpdate();
}

watch(currentLanguage, update);
</script>

<template>
  <canvas id="canv" class="absolute left-0 top-0 w-full h-full pointer-events-none"></canvas>
  <Controls />
  <Resume />
  <div class="print-only p-2 rounded-lg text-neutral-500 dark:text-neutral-400 text-xs mt-6">
    <span>{{ getResourceCurrent('print-info') }}</span>
  </div>
</template>

<style scoped>
@reference "tailwindcss";

@font-face {
  font-family: monoglyceride;
  src: url('../src/fonts/monog___.ttf') format('truetype');
}

@font-face {
  font-family: sharetech;
  src: url('../src/fonts/ShareTechMono-Regular.ttf') format('truetype');
}

@font-face {
  font-family: sometype;
  src: url('../src/fonts/SometypeMono-Regular.ttf') format('truetype');
}

@font-face {
  font-family: majormono;
  src: url('../src/fonts/MajorMonoDisplay-Regular.ttf');
}

.print-only {
  @media not print {
    display: none;
  }
}
</style>
