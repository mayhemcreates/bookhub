<script setup lang="ts">
import BookList from '@/components/BookList.vue'
import BooksToolbar from '@/components/BooksToolbar.vue'
import { ModalAction, type Book } from '@/types/types'

const emit = defineEmits<{
  openModal: [action: ModalAction, book?: Book]
}>()

const handleOpenModal = (action: ModalAction, book?: Book) => {
  emit('openModal', action, book)
}

const handleAddBook = () => {
  emit('openModal', ModalAction.ADD)
}

</script>
<template>
  <div class="page__heading">
    <div class="page__title-wrapper">
      <h1 class="page__title">My Books</h1>
      <p class="page__subtitle">Manage your book collection and discover new reads.</p>
    </div>

    <button class="cta cta--align-left-sm" @click="handleAddBook"><span>+</span>Add Book</button>
  </div>
  <BooksToolbar />
  <BookList @open-modal="handleOpenModal" />
</template>