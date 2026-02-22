<script setup lang="ts">
import { ModalAction, type Book } from '@/types/types'
import { useBookStore } from '@/stores/bookStore'
import { onMounted, ref } from 'vue'
import BookIcon from '@/components/BookIcon.vue'
const bookStore = useBookStore()

const props = defineProps({
  id: String,
})

const book = ref<Book | null>(null)

const findBook = async (id: string | undefined): Promise<Book | null> => {
  if (!id) return null
  if (bookStore.books.length > 0) {
    const book = bookStore.books.find((b) => b.id === Number(id))
    return book || null
  } else {
    const books = await bookStore.fetchBooks()
    const book = books.find((b) => b.id === Number(id))
    return book || null
  }
}

onMounted(async () => {
  book.value = await findBook(props.id)
})

const emit = defineEmits<{
  openModal: [action: ModalAction, book: Book]
}>()

const handleEditBook = () => {
  if (book.value) {
    emit('openModal', ModalAction.EDIT, book.value)
  }
}
</script>
<template>
  <div class="page__heading">
    <div class="page__title-wrapper">
      <h1 class="page__title">{{ book?.title }}</h1>
    </div>

    <button class="cta cta--align-left-sm" @click="handleEditBook">
      <span>+</span>Update Book
    </button>
  </div>

  <section class="book-detail">
    <BookIcon class="book-detail__icon" />
    <div class="book-detail__info">
      <h2 class="book-detail__title">{{ book?.title }}</h2>
      <p class="book-detail__author">by {{ book?.author }}</p>
      <p class="book-detail__isbn">ISBN: {{ book?.isbn }}</p>
      <p class="book-detail__rating">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 640 640"
          class="card__star"
          v-for="index in 5"
          :key="index"
        >
          <path
            d="M341.5 45.1C337.4 37.1 329.1 32 320.1 32C311.1 32 302.8 37.1 298.7 45.1L225.1 189.3L65.2 214.7C56.3 216.1 48.9 222.4 46.1 231C43.3 239.6 45.6 249 51.9 255.4L166.3 369.9L141.1 529.8C139.7 538.7 143.4 547.7 150.7 553C158 558.3 167.6 559.1 175.7 555L320.1 481.6L464.4 555C472.4 559.1 482.1 558.3 489.4 553C496.7 547.7 500.4 538.8 499 529.8L473.7 369.9L588.1 255.4C594.5 249 596.7 239.6 593.9 231C591.1 222.4 583.8 216.1 574.8 214.7L415 189.3L341.5 45.1z"
            :fill="index <= (book?.rating ?? 0) ? 'var(--color-mustard)' : 'var(--color-grey-3)'"
          />
        </svg>
        <span class="book-detail__rating-text">{{ book?.rating }} / 5</span>
      </p>
      <p class="book-detail__comments">{{ book?.comments }}</p>
    </div>
  </section>
</template>
<style scoped lang="scss">
.book-detail {
  display: flex;
  width: 100%;
  gap: 20px;

  &__icon {
    background: $linear-gradient;
    border-radius: 5px;
    width: 200px;
    aspect-ratio: 1/1;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  &__info {
    display: flex;
    flex-direction: column;
    gap: 8px;
  }

  &__title {
    font-size: 1.25rem;
    font-weight: bold;
  }

  &__author,
  &__isbn,
  &__comments {
    font-size: 1rem;
    color: var(--color-grey-4);
  }

  &__rating {
    display: flex;
    align-items: center;

    svg {
      width: 20px;
      height: 20px;
    }

    &-text {
      margin-left: 8px;
      font-size: 0.875rem;
      color: var(--color-grey-4);
    }
  }
}
</style>
