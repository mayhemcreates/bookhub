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
<style scoped lang="scss">
.page {
  &__heading {
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-bottom: 20px;

    @include mq($until: $breakpoint-md) {
      flex-direction: column;
      align-items: flex-start;
      gap: 16px;
    }
  }

  &__title {
    font-size: 2rem;
    color: var(--color-grey-4);
    margin-bottom: 20px;

    &-wrapper {
      flex-grow: 1;
    }
  }

  &__subtitle {
    font-size: 1rem;
    color: var(--color-grey-4);
    margin-bottom: 32px;
  }
}
</style>
