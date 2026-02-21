<script setup lang="ts">
import BooksToolbar from '@/components/BooksToolbar.vue'
import BookList from '@/components/BookList.vue'

</script>
<template>
  <div class="page__heading">
    <div>
      <h1 class="page__title">My Books</h1>
      <p class="page__subtitle">Manage your book collection and discover new reads.</p>
    </div>

    <button class="cta"><span>+</span>Add Book</button>
  </div>
  <BooksToolbar />
  <BookList  />
</template>
<style scoped lang="scss">
.page {
  &__heading {
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-bottom: 20px;
  }

  &__title {
    font-size: 2rem;
    color: var(--color-grey-4);
    margin-bottom: 20px;
  }

  &__subtitle {
    font-size: 1rem;
    color: var(--color-grey-4);
    margin-bottom: 32px;
  }
}
</style>
