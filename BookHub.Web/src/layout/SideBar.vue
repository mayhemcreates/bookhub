<script setup lang="ts">
import { RouterLink } from 'vue-router'
import { router } from '@/router/index'

</script>
<template>
  <section class="sidebar">
    <header class="header">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="book-logo">
        <path
          d="M256 141.3l0 309.3 .5-.2C311.1 427.7 369.7 416 428.8 416l19.2 0 0-320-19.2 0c-42.2 0-84.1 8.4-123.1 24.6-16.8 7-33.4 13.9-49.7 20.7zM230.9 61.5L256 72 281.1 61.5C327.9 42 378.1 32 428.8 32L464 32c26.5 0 48 21.5 48 48l0 352c0 26.5-21.5 48-48 48l-35.2 0c-50.7 0-100.9 10-147.7 29.5l-12.8 5.3c-7.9 3.3-16.7 3.3-24.6 0l-12.8-5.3C184.1 490 133.9 480 83.2 480L48 480c-26.5 0-48-21.5-48-48L0 80C0 53.5 21.5 32 48 32l35.2 0c50.7 0 100.9 10 147.7 29.5z"
        />
      </svg>
      <a href="">BookHub</a>
    </header>
    <nav class="nav">
      <ul>
        <li v-for="route in router.options.routes" :key="route.path">
          <RouterLink :to="route.path" active-class="nav__item--active">
            <div class="nav__item">
              {{ route.name }}
            </div>
          </RouterLink>
        </li>
      </ul>
    </nav>
    <div class="user-info">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" class="user-info__avatar">
        <path
          d="M399 384.2C376.9 345.8 335.4 320 288 320l-64 0c-47.4 0-88.9 25.8-111 64.2 35.2 39.2 86.2 63.8 143 63.8s107.8-24.7 143-63.8zM0 256a256 256 0 1 1 512 0 256 256 0 1 1 -512 0zm256 16a72 72 0 1 0 0-144 72 72 0 1 0 0 144z"
        />
      </svg>
      <div class="user-info__wrapper">
        <div class="user-info__details">
          <p class="user-info__name">Book Lover</p>
          <a href="" class="user-info__status">Reader</a>
        </div>
      </div>
    </div>
  </section>
</template>
<style scoped lang="scss">
* {
  color: var(--color-white);
  text-decoration: none;
}

.sidebar {
  background-color: var(--color-blue-2);
  height: 100%;
  display: flex;
  flex-direction: column;
}

.header {
  font-weight: 700;
  font-size: 2.875rem;
  padding: 20px;
  display: flex;
  align-items: center;
  gap: 10px;
  border-bottom: 1px solid var(--color-blue-1);
}

.nav {
  flex-grow: 1;
  margin-top: 20px;

  &__item {
    padding: 20px 0 20px 40px;
    display: flex;
    align-items: center;
    gap: 10px;

    &:hover {
      background-color: var(--color-blue-1);
    }

    &--active {
      .nav__item {
        background-color: var(--color-blue-1);
        border-left: 3px solid var(--color-mustard);
      }
    }
  }

  &__icon {
    width: 20px;
    height: 20px;
  }
}

.user-info {
  padding: 20px;
  border-top: 1px solid var(--color-blue-1);

  &__avatar {
    width: 40px;
    height: 40px;
    background-color: var(--color-white);
    border-radius: 50%;
    path {
      fill: var(--color-blue-1);
    }
  }
  &__wrapper {
    display: flex;
    align-items: center;
    gap: 20px;
    width: 100%;
  }

  &__name {
    font-weight: 500;
    font-size: 1.125rem;
  }

  &__status {
    font-size: 0.875rem;
    color: var(--color-gray);
  }
}
.book-logo {
  width: 40px;
  height: 40px;
  path {
    fill: var(--color-mustard);
  }
}
</style>
