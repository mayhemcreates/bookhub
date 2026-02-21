<script setup lang="ts">
import IconGrid from '@/assets/icons/IconGrid.vue'
import IconList from '@/assets/icons/IconList.vue'

// TODO implement search
const updateSearch = (event: Event) => {
  const target = event.target as HTMLInputElement
  if (target) {
    const value = target.value
    return value
  }
}
</script>

<template>
  <form class="filter">
    <div class="search">
      <label for="search" class="sr-only">
        <span class="sr-only">Search</span>
        <span class="search__placeholder">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
            <path
              d="M480 272C480 317.9 465.1 360.3 440 394.7L566.6 521.4C579.1 533.9 579.1 554.2 566.6 566.7C554.1 579.2 533.8 579.2 521.3 566.7L394.7 440C360.3 465.1 317.9 480 272 480C157.1 480 64 386.9 64 272C64 157.1 157.1 64 272 64C386.9 64 480 157.1 480 272zM272 416C351.5 416 416 351.5 416 272C416 192.5 351.5 128 272 128C192.5 128 128 192.5 128 272C128 351.5 192.5 416 272 416z"
              fill="var(--color-grey-2)"
            />
          </svg>
          <span>Search by title or author</span>
        </span>
        <input type="text" id="search" @input="updateSearch" />
      </label>
    </div>
    <div class="sort">
      <label for="sort" class="sr-only">Sort</label>
      <select name="sort" id="sort">
        <option value="title">Sort by Title</option>
        <option value="author">Sort by Author</option>
        <option value="rating">Sort by Rating</option>
      </select>
    </div>
    <div class="view">
      <div class="view__option">
        <input type="radio" id="grid" name="view" value="grid" />
        <label for="grid" class="view__icon view__icon--left">
          <span class="sr-only">Grid</span>
          <IconGrid />
        </label>
      </div>
      <div class="view__option">
        <input type="radio" id="list" name="view" value="list" />
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
}

.search {
  flex-grow: 1;

  &__placeholder {
    position: absolute;
    top: 50%;
    left: 12px;
    transform: translateY(-50%);
    display: flex;
    align-items: center;
    gap: 8px;

    span {
      color: var(--color-grey-2);
    }

    svg {
      width: 25px;
      height: 25px;
      margin-right: 8px;
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
.view {
  display: flex;
  border-radius: 10px;
  background-color: var(--color-white);
  border: 1px solid var(--color-grey-2);
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
