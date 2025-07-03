<script setup>
import Resume from '@components/Resume.vue'
import Controls from '@components/Controls.vue';

</script>

<template>
  <Controls />
  <Resume />
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

</style>
