<script setup lang="ts">
import type { Book } from '@/types/types'
import { useBookStore } from '@/stores/bookStore'

const props = defineProps<{
  book: Book | null
}>()
const bookStore = useBookStore()
const emit = defineEmits<{
  close: []
}>()

const deleteBook = async (id: number | null) => {
  if (id != null) {
    await bookStore.deleteBook(id)
    emit('close')
  }
}
</script>

<template>
  <div>Are you sure you want to delete {{ props.book?.title }}?</div>

  <div class="button__group">
    <button type="button" @click="deleteBook(props.book?.id ?? null)">Yes</button>
    <button type="button" @click="emit('close')">Cancel</button>
  </div>
  <div v-if="bookStore.hasPostError" class="error-list" role="alert">
    Failed to delete book. Please try again.
  </div>
</template>

<style scoped lang="scss">
.button__group {
  display: flex;
  gap: 10px;
  margin-top: 20px;

  button {
    padding: 8px 16px;
    border: none;
    cursor: pointer;
    border-radius: 4px;
    font-weight: bold;

    &:first-child {
      background-color: var(--color-red);
      color: white;
    }

    &:last-child {
      background-color: var(--color-grey-1);
      color: var(--color-black);
    }
  }
}
</style>
