<script setup lang="ts">
import { ref, watch } from 'vue'
import MainNav from './MainNav.vue';
import { useViewHelper } from '@/composables/useViewHelper'

const navIsOpen = ref(false)
const { isMobile } = useViewHelper();

const openNav = () => {
  if(!isMobile()) return // hamburger not implemented for desktop as duplicates sidebar
  navIsOpen.value = !navIsOpen.value
}

watch(navIsOpen, (isOpen) => {
  if (isOpen) {
    document.body.style.overflow = 'hidden'
  } else {
    document.body.style.overflow = ''
  }
})
</script>

<template>
  <button type="button" class="hamburger" @click="openNav()">
    <span class="hamburger__line" :class="{ 'hamburger__line--open': navIsOpen }"></span>
    <span class="hamburger__line" :class="{ 'hamburger__line--open': navIsOpen }"></span>
    <span class="hamburger__line" :class="{ 'hamburger__line--open': navIsOpen }"></span>
  </button>   
  <MainNav v-if="navIsOpen" @closeNav="navIsOpen = false" class="nav__mobile" />
</template>

<style scoped lang="scss">
.hamburger {
  height: 50px;
  width: 50px;
  background: none;
  border: none;
  cursor: pointer;

  &__line {
    display: block;
    width: 25px;
    height: 3px;
    background-color: var(--color-white);
    transition: all 0.3s ease;
    border-radius: 2px;

    &:not(:last-child) {
      margin-bottom: 5px;
    }
    &--open:nth-child(1) {
      transform: translateY(8px) rotate(45deg);
    }
    &--open:nth-child(2) {
      opacity: 0;
    }
    &--open:nth-child(3) {
      transform: translateY(-8px) rotate(-45deg);
    }

    @include mq($from: $breakpoint-lg) {
    background-color: var(--color-black);
    }
  }
}

.nav {
  &__mobile {
    position: absolute;
    top: 50px;
    left: 0;
    width: 100%;
    height: calc(100vh);
    background-color: var(--color-blue-2);
    z-index: 1000;
    gap: 40px;
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-top: 0;
    padding-top: 40px;
  }
}
</style>
