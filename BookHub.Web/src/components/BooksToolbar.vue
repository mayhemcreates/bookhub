<script setup lang="ts">
import IconGrid from '@/assets/icons/IconGrid.vue'
import IconList from '@/assets/icons/IconList.vue'
import IconSearch from '@/assets/icons/IconSearch.vue'
import { useBookStore } from '@/stores/bookStore'
import { ViewOption } from '@/types/types'
import { ref } from 'vue'

let debounceTimer: ReturnType<typeof setTimeout> | null = null
const selectedView = ref<ViewOption>(ViewOption.LIST) // default to list view

const bookStore = useBookStore()

const updateSearch = (event: Event) => {
  const target = event.target as HTMLInputElement
  if (target) {
    const value = target.value

    // Debounce the search to avoid too many API calls while typing
    if (debounceTimer) {
      clearTimeout(debounceTimer)
    }

    debounceTimer = setTimeout(() => {
      if (value.trim() === '') {
        bookStore.fetchBooks()
      } else {
        bookStore.searchBooks(value)
      }
    }, 300)
  }
}
</script>

<template>
  <form class="filter">
    <div class="search">
      <label for="search" class="sr-only">
        <span class="sr-only">Search</span>
        <span class="search__placeholder">
          <IconSearch />
        </span>
        <input
          type="text"
          id="search"
          placeholder="Search by title or author"
          @input="updateSearch"
        />
      </label>
    </div>
    <div class="sort">
      <label for="sort" class="sr-only">Sort</label>
      <select
        name="sort"
        id="sort"
        @change="bookStore.fetchBooks(($event.target as HTMLSelectElement).value)"
      >
        <option value="title">Sort by Title</option>
        <option value="author">Sort by Author</option>
      </select>
    </div>
    <div class="view">
      <div class="view__option">
        <input type="radio" id="grid" name="view" :value="ViewOption.GRID" v-model="selectedView" />
        <label for="grid" class="view__icon view__icon--left">
          <span class="sr-only">Grid</span>
          <IconGrid />
        </label>
      </div>
      <div class="view__option">
        <input type="radio" id="list" name="view" :value="ViewOption.LIST" v-model="selectedView" />
        <label for="list" class="view__icon view__icon--right">
          <span class="sr-only">List</span>
          <IconList />
        </label>
      </div>
    </div>
  </form>
</template>

<style scoped lang="scss">
.filter {
  display: flex;
  gap: 20px;

  @include mq($until: $breakpoint-lg) {
    flex-wrap: wrap;
    gap: 12px;
  }
}

.search {
  flex-grow: 1;

  @include mq($until: $breakpoint-sm) {
    width: 100%;
  }
  
  input {
    padding-left: 50px;
    font-size: 1rem;
  }

  &__placeholder {
    position: absolute;
    top: 50%;
    left: 12px;
    transform: translateY(-50%);
    display: flex;
    align-items: center;
    gap: 8px;

    span {
      color: var(--color-grey-3);
    }

    svg {
      width: 25px;
      height: 25px;
      margin-right: 8px;
      stroke: var(--color-grey-3);
    }
  }

  label {
    position: relative;
  }

  input {
    width: 100%;
    box-sizing: border-box;
  }
}

.sort {
  @include mq($until: $breakpoint-lg) {
    flex-grow: 1;

    select {
      width: 100%;
    }
  }
}
.view {
  display: flex;
  border-radius: 10px;
  background-color: var(--color-white);
  border: 1px solid var(--color-grey-3);
  height: 48px;

  &__option {
    cursor: pointer;
    display: block;
    position: relative;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    width: 48px;

    input {
      position: absolute;
      opacity: 0;
      cursor: pointer;
      height: 0;
      width: 0;
    }

    input:checked + .view__icon {
      background-color: var(--color-blue-1);

      svg {
        fill: var(--color-white);
      }
    }

    input:focus-visible + .view__icon {
      outline: 2px solid var(--focus-ring);
      outline-offset: 2px;
    }
  }

  &__icon {
    display: block;
    position: absolute;
    top: 0;
    left: 0;
    height: 100%;
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    cursor: pointer;

    svg {
      width: 20px;
      height: 20px;
    }

    &--left {
      border-top-left-radius: 10px;
      border-bottom-left-radius: 10px;
    }
    &--right {
      border-top-right-radius: 10px;
      border-bottom-right-radius: 10px;
    }
  }
}
</style>

<!-- Global styles for focus state of view options when using keyboard navigation -->
<style lang="scss">
body.js-user-is-tabbing .view__option input:focus + .view__icon {
  outline: 4px solid var(--focus-ring);
  position: relative;
  z-index: 999;
  border-radius: 4px;
}
</style>
