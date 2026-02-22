<script setup lang="ts">
import iconBookhub from '@/assets/icons/IconBookhub.vue'
import HamburgerButton from '@/components/HamburgerButton.vue'
import MainNav from '@/components/MainNav.vue'
import UserInfo from '@/components/UserInfo.vue'
import { isMobile } from '@/composables/viewHelpers'

</script>

<template>
  <section class="sidebar">
    <header class="header">
      <a href="/">
        <component :is="iconBookhub" class="book-logo" />
        <div>BookHub</div>
      </a>
      <HamburgerButton v-if="isMobile()" />
    </header>
    <MainNav v-if="!isMobile()" />
    <UserInfo v-if="!isMobile()" />
  </section>
</template>

<style scoped lang="scss">
// global styles for child components
* {
  color: var(--color-white);
  text-decoration: none;
}

.sidebar {
  background-color: var(--color-blue-2);
  height: 100%;
  display: flex;
  flex-direction: column;

  @include mq($from: $breakpoint-lg) {
    position: sticky;
  }
}

.header {
  font-weight: 700;
  font-size: 2.875rem;
  padding: 20px;
  display: flex;
  align-items: center;
  gap: 10px;
  border-bottom: 1px solid var(--color-blue-1);

  a {display: flex; align-items: center; gap: 10px;}

  @include mq($until: $breakpoint-lg) {
    font-size: 1.5rem;
    height: 50px;
    padding: 0 20px;
    justify-content: space-between;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    background-color: var(--color-blue-2);
    z-index: 20;
    box-sizing: border-box;
  }
}


.book-logo {
  width: 40px;
  height: 40px;

  @include mq($until: $breakpoint-lg) {
    width: 30px;
    height: 30px;
  }
}
</style>
