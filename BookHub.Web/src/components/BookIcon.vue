<!-- temp component - image would be used instead -->

<script setup lang="ts">
import IconBooks from '@/assets/icons/IconBooks.vue'
</script>

<template>
  <div>
    <IconBooks />
  </div>
</template>

<style scoped lang="scss">

svg {
  width: 40px;
  height: 40px;

  @include mq($until: $breakpoint-sm) {
    width: 100px;
    height: 100px;
  }
}
</style>
