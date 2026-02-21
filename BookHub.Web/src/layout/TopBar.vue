<script setup lang="ts">
import { ref } from 'vue'
import IconSearch from '@/assets/icons/IconSearch.vue'
import IconAlerts from '@/assets/icons/IconAlerts.vue'

const showSearch = ref(false)

const toggleSearch = () => {
  showSearch.value = !showSearch.value
}
</script>
<template>
  <section class="topbar">
    <div class="topbar__nav">
      <button type="button" class="hamburger">
        <span></span>
        <span></span>
        <span></span>
      </button>
      <div>Dashboard</div>
    </div>
    <div class="topbar__actions">
      <div class="alerts">
        <component :is="IconAlerts" />

        <span class="alerts__count">3</span>
      </div>
      <div class="search">
        <button @click="toggleSearch()">
          <component :is="IconSearch" />
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

.hamburger {
  height: 50px;
  width: 50px;
  background: none;
  border: none;
  cursor: pointer;

  span {
    display: block;
    width: 25px;
    height: 3px;
    background-color: var(--color-black);
    border-radius: 2px;

    &:not(:last-child) {
      margin-bottom: 5px;
    }
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
}
</style>
