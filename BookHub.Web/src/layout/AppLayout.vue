<script setup lang="ts">
import SideBar from './SideBar.vue'

</script>

<template>
  <div class="layout">
    <SideBar />
    <div>
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

  @include mq($until: $breakpoint-lg) {
    display: flex;
    flex-direction: column;
  }
}

.main-section {
  padding: 20px;
  background-color: var(--color-grey-1);
  height: calc(100vh - 96px);
  box-sizing: border-box;
}

.container {
  max-width: 1440px;
  margin: 0 auto;
}
</style>
