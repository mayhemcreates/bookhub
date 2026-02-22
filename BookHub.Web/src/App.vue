<script setup lang="ts">
import { useBookStore } from './stores/bookStore'
import AppLayout from './layout/AppLayout.vue'
import { useTabDetection } from './composables/useTabDetection'
import { onMounted } from 'vue'

onMounted(() => {
  const bookStore = useBookStore()
  bookStore.fetchBooks()
  useTabDetection()
})
</script>

<template>
  <AppLayout> </AppLayout>
</template>

<style scoped></style>
