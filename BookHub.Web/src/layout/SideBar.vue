<script setup lang="ts">
import iconBookhub from '@/assets/icons/IconBookhub.vue'
import iconAvatar from '@/assets/icons/IconAvatar.vue'
import MainNav from '@/components/MainNav.vue'
</script>

<template>
  <section class="sidebar">
    <header class="header">
      <a href="">
        <component :is="iconBookhub" class="book-logo" />
        BookHub
      </a>
    </header>
    <MainNav />


    <div class="user-info">
      <div class="user-info__wrapper">
        <component :is="iconAvatar" class="user-info__avatar" />
        <div class="user-info__details">
          <p class="user-info__name">Book Lover</p>
          <a href="" class="user-info__status">Reader</a>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss"> // global styles for child components
* {
  color: var(--color-white);
  text-decoration: none;
}

.sidebar {
  background-color: var(--color-blue-2);
  height: 100%;
  display: flex;
  flex-direction: column;
  position: sticky;
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

.user-info {
  padding: 20px;
  border-top: 1px solid var(--color-blue-1);

  &__avatar {
    width: 40px;
    height: 40px;
    background-color: var(--color-white);
    border-radius: 50%;
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
}
</style>
