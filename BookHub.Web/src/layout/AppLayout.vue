<script setup lang="ts">
import { ref } from 'vue'
import SideBar from './SideBar.vue'
import TopBar from './TopBar.vue'
import FormModal from '@/layout/FormModal.vue'
import { ModalAction, type Book } from '@/types/types'

const modalAction = ref<ModalAction | null>(null)
const selectedBook = ref<Book | null>(null)

const handleOpenModal = (action: ModalAction, book?: Book) => {
  modalAction.value = action
  selectedBook.value = book || null
}

const closeModal = () => {
  modalAction.value = null
  selectedBook.value = null
}
</script>

<template>
  <div class="layout">
    <SideBar />
    <div class="content-wrapper">
      <TopBar />
      <main class="main-section">
        <section class="container">
          <RouterView @open-modal="handleOpenModal"></RouterView>
          <FormModal
            v-if="modalAction"
            :action="modalAction"
            :book="selectedBook"
            @close="closeModal"
          />
        </section>
      </main>
    </div>
  </div>
</template>

<style scoped lang="scss">
.layout {
  display: grid;
  grid-template-columns: 400px 1fr;

  @include mq($from: $breakpoint-lg) {
    height: 100vh;
    overflow: hidden;
  }

  @include mq($until: $breakpoint-lg) {
    display: flex;
    flex-direction: column;
  }

    @include mq($from: $breakpoint-lg, $until: $breakpoint-xl) {
    grid-template-columns: 300px 1fr;
  }
}

.content-wrapper {
  display: flex;
  flex-direction: column;

  @include mq($until: $breakpoint-lg) {
    position: relative;
    top: 50px;
  }

  @include mq($from: $breakpoint-lg) {
    height: 100vh;
    overflow: hidden;
  }
}

.main-section {
  padding: 20px;
  background-color: var(--color-grey-1);
  flex: 1;
  box-sizing: border-box;
  overflow-y: auto;

  @include mq($until: $breakpoint-lg) {
    overflow-y: initial;
  }
}

.container {
  max-width: 720px;
  margin: 0 auto;

  @include mq($from: $breakpoint-xxxl) {
    max-width: 1200px;
  }
}
</style>
