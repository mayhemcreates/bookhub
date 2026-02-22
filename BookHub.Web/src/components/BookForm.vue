<script setup lang="ts">
import { computed } from 'vue'
import { useBookStore } from '@/stores/bookStore'
import { ModalAction, type Book } from '@/types/types'
import { useBookValidation } from '@/composables/useBookValidation'

const props = defineProps<{
  action: ModalAction
  book?: Book | null
}>()

const emit = defineEmits<{ close: [] }>()
const bookStore = useBookStore()
const isEditMode = computed(() => props.action === ModalAction.EDIT)
const {
  title,
  author,
  isbn,
  rating,
  comments,
  hasAttemptedSubmit,
  allErrors,
  isFormValid,
  fieldIsValid,
  clearFieldError,
  resetClearedFields,
} = useBookValidation(() => isEditMode.value)

if (props.book) {
  title.value = props.book.title
  author.value = props.book.author
  isbn.value = props.book.isbn
  rating.value = props.book.rating
  comments.value = props.book.comments
}

const formTitle = computed(() =>
  isEditMode.value ? `Update ${props.book?.title}` : 'Add New Book',
)
const submitButtonText = computed(() => (isEditMode.value ? 'Update' : 'Add Book'))

const setRating = (value: number) => {
  rating.value = value
}

const handleSubmit = async () => {
  resetClearedFields()
  hasAttemptedSubmit.value = true

  if (!isFormValid.value) return

  if (isEditMode.value && props.book) {
    const updatedBook: Book = {
      ...props.book,
      rating: rating.value,
      comments: comments.value,
    }
    const result = await bookStore.editBook(updatedBook)
    if (result) {
      emit('close')
    }
  } else {
    const newBook = {
      title: title.value,
      author: author.value,
      isbn: isbn.value,
      rating: rating.value,
      comments: comments.value,
      noteStatus: comments.value.length > 0,
      imageUrl: 'https://via.placeholder.com/150x220?text=No+Cover',
    }
    const result = await bookStore.addBook(newBook)
    if (result) {
      emit('close')
    }
  }
}
</script>

<template>
  <form class="form">
    <h2>{{ formTitle }}</h2>

    <ul v-if="hasAttemptedSubmit && allErrors.length > 0" class="error-list" role="alert">
      <li v-for="(error, index) in allErrors" :key="index">{{ error }}</li>
    </ul>

    <label for="title" class="sr-only">Title</label>
    <input
      type="text"
      id="title"
      name="title"
      placeholder="Title"
      :class="{ 'input-error': fieldIsValid.title }"
      v-model="title"
      :readonly="isEditMode"
      maxlength="100"
      @focus="clearFieldError('title')"
    />

    <label for="author" class="sr-only">Author</label>
    <input
      type="text"
      id="author"
      name="author"
      placeholder="Author"
      :class="{ 'input-error': fieldIsValid.author }"
      v-model="author"
      :readonly="isEditMode"
      maxlength="100"
      @focus="clearFieldError('author')"
    />

    <label for="isbn" class="sr-only">ISBN</label>
    <input
      type="text"
      id="isbn"
      name="isbn"
      placeholder="ISBN"
      v-model="isbn"
      :readonly="isEditMode"
      :class="{ 'input-error': fieldIsValid.isbn }"
      maxlength="100"
      @focus="clearFieldError('isbn')"
    />

    <fieldset class="rating__fieldset" :class="{ 'input-error': fieldIsValid.rating }">
      <legend class="sr-only">Rating (out of 5 stars)</legend>
      <div class="rating__input" role="radiogroup" aria-label="Book rating">
        <button
          v-for="index in 5"
          :key="index"
          type="button"
          class="rating__star"
          :aria-label="`Rate ${index} out of 5 stars`"
          :aria-pressed="rating >= index"
          @click="setRating(index)"
          @focus="clearFieldError('rating'); clearFieldError('comments')"
        >
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
            <path
              d="M341.5 45.1C337.4 37.1 329.1 32 320.1 32C311.1 32 302.8 37.1 298.7 45.1L225.1 189.3L65.2 214.7C56.3 216.1 48.9 222.4 46.1 231C43.3 239.6 45.6 249 51.9 255.4L166.3 369.9L141.1 529.8C139.7 538.7 143.4 547.7 150.7 553C158 558.3 167.6 559.1 175.7 555L320.1 481.6L464.4 555C472.4 559.1 482.1 558.3 489.4 553C496.7 547.7 500.4 538.8 499 529.8L473.7 369.9L588.1 255.4C594.5 249 596.7 239.6 593.9 231C591.1 222.4 583.8 216.1 574.8 214.7L415 189.3L341.5 45.1z"
              :fill="index <= rating ? 'var(--color-mustard)' : 'var(--color-grey-2)'"
            />
          </svg>
        </button>
      </div>
      <div class="rating-text" aria-live="polite">{{ rating }} / 5</div>
    </fieldset>

    <textarea
      name="notes"
      id="notes"
      placeholder="Your notes..."
      v-model="comments"
      rows="5"
      :class="{ 'input-error': fieldIsValid.comments || fieldIsValid.rating }"
      @focus="clearFieldError('comments'); clearFieldError('rating')"
    ></textarea>

    <button type="submit" class="cta" @click.prevent="handleSubmit">
      {{ submitButtonText }}
    </button>
  </form>
</template>
<style scoped lang="scss">
.form {
  display: flex;
  flex-direction: column;
  gap: 20px;
}

.error-list {
  background-color: #fef2f2;
  border: 1px solid #ef4444;
  border-radius: 4px;
  padding: 12px 16px 12px 32px;
  margin: 0;
  color: #dc2626;
  font-size: 14px;

  li {
    margin-bottom: 4px;
    &:last-child {
      margin-bottom: 0;
    }
  }
}

.input-error {
  border: 2px solid var(--color-red) !important;
  background-color: var(--color-pink);
}

.rating {
  &__fieldset {
    border: none;
    padding: 0;
    margin: 16px 0;
    display: flex;
    align-items: center;
    justify-content: space-between;
  }

  &__input {
    display: flex;
    gap: 8px;
    align-items: center;
    margin-bottom: 8px;
  }

  &__star {
    background: none;
    border: none;
    cursor: pointer;
    padding: 4px;
    transition: transform 0.2s;

    &:hover {
      transform: scale(1.1);
    }

    &:focus {
      outline: 2px solid var(--color-primary, #007acc);
      outline-offset: 2px;
      border-radius: 4px;
    }

    svg {
      width: 32px;
      height: 32px;
      display: block;
    }
  }

  &__text {
    font-size: 14px;
    color: var(--color-gray);
    margin-top: 4px;
  }

  .form {
    margin-top: 20px;
  }
}
</style>
