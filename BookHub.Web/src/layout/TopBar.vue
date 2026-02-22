<script setup lang="ts">
import { ref } from 'vue'
import IconSearch from '@/assets/icons/IconSearch.vue'
import IconAlerts from '@/assets/icons/IconAlerts.vue'
import HamburgerButton from '@/components/HamburgerButton.vue'
import { useViewHelper } from '@/composables/useViewHelper'


const showSearch = ref(false)
const { isMobile } = useViewHelper()
const toggleSearch = () => {
  showSearch.value = !showSearch.value
}
</script>
<template>
  <section class="topbar">
    <div class="topbar__nav">
      <HamburgerButton v-if="!isMobile()" />
      <div>Dashboard</div>
    </div>
    <div class="topbar__actions">
      <div class="alerts">
        <IconAlerts />

        <span class="alerts__count">3</span>
      </div>
      <div class="search">
        <button @click="toggleSearch()" aria-label="toggle search input">
          <IconSearch />
        </button>
        <div class="search__input" v-if="showSearch">
          <label for="search" class="sr-only">Search</label>
          <input type="text" placeholder="Search..." />
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
.topbar {
  padding: 8px 20px;
  background-color: var(--color-white);
  box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.25);
  height: 80px;
  display: flex;
  align-items: center;
  justify-content: space-between;

  @include mq($until: $breakpoint-lg) {
    height: 50px;
  }

  &__nav {
    display: flex;
    align-items: center;
    gap: 20px;
  }

  &__actions {
    display: flex;
    align-items: center;
    gap: 20px;
  }
}

.alerts {
  position: relative;

  &__count {
    position: absolute;
    top: -5px;
    right: -5px;
    background-color: var(--color-red);
    color: white;
    border-radius: 50%;
    padding: 2px 6px;
    font-size: 12px;
  }
}

.search {
  cursor: pointer;
  display: flex;
  align-items: center;

  svg {
    stroke: var(--color-grey-4);
  }
}
</style>
