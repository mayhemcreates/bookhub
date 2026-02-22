<script setup lang="ts">
import { ModalAction, type Book } from '@/types/types'
import BookForm from '@/components/BookForm.vue'
import DeleteBook from '@/components/DeleteBook.vue'
const props = defineProps<{
  action: ModalAction
  book: Book | null
}>()
const emit = defineEmits<{
  close: []
}>()
const closeModal = () => {
  emit('close')
}
</script>

<template>
  <div role="modal" class="modal" aria-modal="true">
    <button type="button" aria-label="close modal" class="modal__close-btn" @click="emit('close')">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
        <path
          d="M183.1 137.4C170.6 124.9 150.3 124.9 137.8 137.4C125.3 149.9 125.3 170.2 137.8 182.7L275.2 320L137.9 457.4C125.4 469.9 125.4 490.2 137.9 502.7C150.4 515.2 170.7 515.2 183.2 502.7L320.5 365.3L457.9 502.6C470.4 515.1 490.7 515.1 503.2 502.6C515.7 490.1 515.7 469.8 503.2 457.3L365.8 320L503.1 182.6C515.6 170.1 515.6 149.8 503.1 137.3C490.6 124.8 470.3 124.8 457.8 137.3L320.5 274.7L183.1 137.4z"
        />
      </svg>
    </button>
    <BookForm
      v-if="props.action === ModalAction.EDIT || props.action === ModalAction.ADD"
      :action="props.action"
      :book="props.book"
      @close="closeModal"
    />

    <DeleteBook v-if="props.action == ModalAction.DELETE" :book="props.book" @close="closeModal" />
  </div>
  <div class="overlay"></div>
</template>

<style scoped lang="scss">
.modal {
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
  height: auto;
  width: 400px;
  background: var(--color-white);
  z-index: 20;
  border-radius: 8px;
  padding: 20px;

  &__close-btn {
    position: absolute;
    top: 8px;
    right: 8px;
    background: none;
    cursor: pointer;
    border-radius: 50%;
    border: 1px solid var(--color-grey-2);
    height: 30px;
    width: 30px;
    display: flex;
    align-items: center;
    justify-content: center;

    &:hover {
      background-color: var(--color-grey-2);
    }

    svg {
      width: 24px;
      height: 24px;
    }
  }
}
.overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
}
</style>
