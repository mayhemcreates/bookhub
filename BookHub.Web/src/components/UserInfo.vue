<script setup lang="ts">
import iconAvatar from '@/assets/icons/IconAvatar.vue'
</script>

<template>
  <div class="user-info">
    <div class="user-info__wrapper">
      <component :is="iconAvatar" class="user-info__avatar" />
      <div class="user-info__details">
        <p class="user-info__name">Book Lover</p>
        <a href="" class="user-info__status">Reader</a>
      </div>
    </div>
  </div>
</template>
<style scoped lang="scss">
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
</style>
