<script setup lang="ts">
import { useBookStore } from '@/stores/bookStore'
import BookCard from '@/components/BookCard.vue'
import { type Book } from '@/types/types'
import { onBeforeMount, ref, computed, watch } from 'vue'

const bookStore = useBookStore()
const bookListRef = ref<HTMLElement | null>(null)
const currentPage = ref(1)
const books = ref<Book[]>([])
const cardsPerPage = 5

onBeforeMount(async () => {
  if (bookStore.books.length > 0) {
    books.value = bookStore.books
    return
  }
  books.value = await bookStore.fetchBooks()
})


watch(
  () => bookStore.books,
  (newBooks) => {
    books.value = newBooks
  },
  { deep: true },
)

const totalPages = computed(() => {
  return Math.ceil(books.value.length / cardsPerPage)
})

const paginatedBooks = computed(() => {
  const start = (currentPage.value - 1) * cardsPerPage
  const end = start + cardsPerPage
  return books.value.slice(start, end)
})

const nextPage = () => {
  if (currentPage.value < totalPages.value) {
    currentPage.value++
  }
}

const prevPage = () => {
  if (currentPage.value > 1) {
    currentPage.value--
  }
}

const goToPage = (page: number) => {
  currentPage.value = page
}
</script>

<template>
  <!-- handle empty state -->
  <div v-if="books.length === 0" class="book__list--empty">
    No books available.
    <button class="cta"><span>+</span>Add Book</button>
  </div>

  <div v-else class="book__count">
    <p>{{ paginatedBooks.length }} of {{ bookStore.books.length }} books available.</p>
  </div>

  <ul class="book__list" ref="bookListRef">
    <li v-for="book in paginatedBooks" :key="book.id">
      <BookCard :book="book" />
    </li>
  </ul>

  <div v-if="totalPages > 1" class="pagination">
    <button class="pagination__btn" :disabled="currentPage === 1" @click="prevPage">
      Previous
    </button>

    <button
      v-for="page in totalPages"
      :key="page"
      class="pagination__btn"
      :class="{ 'pagination__btn--active': page === currentPage }"
      @click="goToPage(page)"
    >
      {{ page }}
    </button>

    <button class="pagination__btn" :disabled="currentPage === totalPages" @click="nextPage">
      Next
    </button>
  </div>
</template>


<style scoped lang="scss">

.book {
  &__list {
    list-style: none;
    padding: 0;
    margin: 0;
    display: flex;
    flex-direction: column;
    gap: 32px;
  }

  &__list--empty {
    margin: 30px 0;
    text-align: center;
    color: var(--color-grey-3);
  }

  &__count {
    margin: 30px 0;
    p {
      color: var(--color-grey-4);
    }
  }
}

.pagination {
  display: flex;
  justify-content: flex-end;
  margin-top: 20px;

  &__btn {
    background: var(--color-white);
    border: 1px solid var(--color-grey-3);
    padding: 8px 12px;
    margin: 0 4px;
    cursor: pointer;
    border-radius: 4px;

    &:disabled {
      opacity: 0.5;
      cursor: not-allowed;
    }

    &:hover {
      background: var(--color-blue-2);
      color: var(--color-white);
    }

    &--active {
      background: var(--color-blue-1);
      color: var(--color-white);
      border-color: var(--color-blue-1);
    }
  }
}
</style>
