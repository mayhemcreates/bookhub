<script setup lang="ts">
import { RouterLink } from 'vue-router'
import { router, type CustomRouteRecordRaw } from '@/router'
const routes = router.options.routes as CustomRouteRecordRaw[]
</script>

<template>
  <nav class="nav">
    <ul>
      <li v-for="route in routes" :key="route.path">
        <RouterLink :to="route.path" active-class="nav__item--active">
          <div class="nav__item">
            <component :is="route.icon" class="nav__icon" />
            {{ route.name }}
          </div>
        </RouterLink>
      </li>
    </ul>
  </nav>
</template>

<style scoped lang="scss">
* {
  color: var(--color-white);
  text-decoration: none;
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
</style>
