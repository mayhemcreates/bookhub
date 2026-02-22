<script setup lang="ts">
import { RouterLink } from 'vue-router'
import { router, type CustomRouteRecordRaw } from '@/router'
import { computed } from 'vue'

const routes = router.options.routes as CustomRouteRecordRaw[]
const navRoutes = computed(() => routes.filter(route => route.showInNav))

const emit = defineEmits(['closeNav'])

const handleNavClick = () => {
  emit('closeNav')
}
</script>

<template>
  <nav class="nav">
    <ul class="nav__list">
      <li v-for="route in navRoutes" :key="route.path">
        <RouterLink :to="route.path" active-class="nav__item--active" @click="handleNavClick">
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

    @include mq($until: $breakpoint-lg) {
      padding: 8px 20px;
    }

    &:hover {
      background-color: var(--color-blue-1);
    }

    &--active {
      .nav__item {
        background-color: var(--color-blue-1);
        border-left: 3px solid var(--color-mustard);

        @include mq($until: $breakpoint-lg) {
          background-color: transparent;
          border-left: none;
          border-bottom: 3px solid var(--color-mustard);
        }
      }
    }
  }

  &__list {
    @include mq($until: $breakpoint-lg) {
      display: flex;
      flex-direction: column;
      gap: 40px;
    }
  }

  &__icon {
    width: 20px;
    height: 20px;
  }
}
</style>
