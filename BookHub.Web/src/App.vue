<script setup lang="ts">
import { useBookStore } from './stores/bookStore'
import AppLayout from './layout/AppLayout.vue'


const bookStore = useBookStore()
bookStore.fetchBooks()
</script>

<template>
  <AppLayout> </AppLayout>
</template>

<style scoped></style>
