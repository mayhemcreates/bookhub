<script setup lang="ts">
import SideBar from './SideBar.vue'
import TopBar from './TopBar.vue'
</script>

<template>
  <div class="layout">
    <SideBar />
    <div class="content-wrapper">
      <TopBar />
      <main class="main-section">
        <section class="container">
          <RouterView></RouterView>
        </section>

      </main>
    </div>
  </div>
</template>

<style scoped lang="scss">
.layout {
  display: grid;
  grid-template-columns: 400px 1fr;
  height: 100vh;
  overflow: hidden;

  @include mq($until: $breakpoint-lg) {
    display: flex;
    flex-direction: column;
  }
}

.content-wrapper {
  display: flex;
  flex-direction: column;
  height: 100vh;
  overflow: hidden;
}

.main-section {
  padding: 20px;
  background-color: var(--color-grey-1);
  flex: 1;
  box-sizing: border-box;
  overflow-y: auto;
}

.container {
  max-width: 1440px;
  margin: 0 auto;
}
</style>
