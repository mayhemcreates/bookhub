<script setup lang="ts">
import {type Book } from '@/types/types'

const props = defineProps({
  book: {
    type: Object as () => Book,
    required: true,
  },
})

</script>
<template>
  <div class="card">
    <div class="card__detail">
      <div class="card__icon">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
          <path
            d="M480 576L192 576C139 576 96 533 96 480L96 160C96 107 139 64 192 64L496 64C522.5 64 544 85.5 544 112L544 400C544 420.9 530.6 438.7 512 445.3L512 512C529.7 512 544 526.3 544 544C544 561.7 529.7 576 512 576L480 576zM192 448C174.3 448 160 462.3 160 480C160 497.7 174.3 512 192 512L448 512L448 448L192 448zM224 216C224 229.3 234.7 240 248 240L424 240C437.3 240 448 229.3 448 216C448 202.7 437.3 192 424 192L248 192C234.7 192 224 202.7 224 216zM248 288C234.7 288 224 298.7 224 312C224 325.3 234.7 336 248 336L424 336C437.3 336 448 325.3 448 312C448 298.7 437.3 288 424 288L248 288z"
            fill="white"
          />
        </svg>
      </div>
      <div>
        <h2 class="card__title">{{ props.book.title }}</h2>
        <p class="card__author">{{ props.book.author }}</p>
        <div class="card__detail card__detail--mt">
          <p class="card__isbn">ISBN: {{ props.book.isbn }}</p>
          <div v-if="props.book.noteStatus" class="card__note">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
              <path
                d="M576 304C576 436.5 461.4 544 320 544C282.9 544 247.7 536.6 215.9 523.3L97.5 574.1C88.1 578.1 77.3 575.8 70.4 568.3C63.5 560.8 62 549.8 66.8 540.8L115.6 448.6C83.2 408.3 64 358.3 64 304C64 171.5 178.6 64 320 64C461.4 64 576 171.5 576 304z"
              />
            </svg>
            <p>Has Notes</p>
          </div>
        </div>
      </div>
    </div>
    <div class="card__status">
      <div class="card__rating">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 640 640"
          class="card__star"
          v-for="index in 5"
          :key="index"
        >
          <path
            d="M341.5 45.1C337.4 37.1 329.1 32 320.1 32C311.1 32 302.8 37.1 298.7 45.1L225.1 189.3L65.2 214.7C56.3 216.1 48.9 222.4 46.1 231C43.3 239.6 45.6 249 51.9 255.4L166.3 369.9L141.1 529.8C139.7 538.7 143.4 547.7 150.7 553C158 558.3 167.6 559.1 175.7 555L320.1 481.6L464.4 555C472.4 559.1 482.1 558.3 489.4 553C496.7 547.7 500.4 538.8 499 529.8L473.7 369.9L588.1 255.4C594.5 249 596.7 239.6 593.9 231C591.1 222.4 583.8 216.1 574.8 214.7L415 189.3L341.5 45.1z"
            :fill="index <= props.book.rating ? 'var(--color-mustard)' : 'var(--color-grey-3)'"
          />
        </svg>
        <div class="card__rating-text">{{ props.book.rating }} / 5</div>
      </div>

      <div class="card__actions">
        <button class="card__button">
          <span class="sr-only">Edit</span>
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
            <path
              d="M535.6 85.7C513.7 63.8 478.3 63.8 456.4 85.7L432 110.1L529.9 208L554.3 183.6C576.2 161.7 576.2 126.3 554.3 104.4L535.6 85.7zM236.4 305.7C230.3 311.8 225.6 319.3 222.9 327.6L193.3 416.4C190.4 425 192.7 434.5 199.1 441C205.5 447.5 215 449.7 223.7 446.8L312.5 417.2C320.7 414.5 328.2 409.8 334.4 403.7L496 241.9L398.1 144L236.4 305.7zM160 128C107 128 64 171 64 224L64 480C64 533 107 576 160 576L416 576C469 576 512 533 512 480L512 384C512 366.3 497.7 352 480 352C462.3 352 448 366.3 448 384L448 480C448 497.7 433.7 512 416 512L160 512C142.3 512 128 497.7 128 480L128 224C128 206.3 142.3 192 160 192L256 192C273.7 192 288 177.7 288 160C288 142.3 273.7 128 256 128L160 128z"
            />
          </svg>
        </button>
        <button class="card__button">
          <span class="sr-only">View</span>
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
            <path
              d="M320 96C239.2 96 174.5 132.8 127.4 176.6C80.6 220.1 49.3 272 34.4 307.7C31.1 315.6 31.1 324.4 34.4 332.3C49.3 368 80.6 420 127.4 463.4C174.5 507.1 239.2 544 320 544C400.8 544 465.5 507.2 512.6 463.4C559.4 419.9 590.7 368 605.6 332.3C608.9 324.4 608.9 315.6 605.6 307.7C590.7 272 559.4 220 512.6 176.6C465.5 132.9 400.8 96 320 96zM176 320C176 240.5 240.5 176 320 176C399.5 176 464 240.5 464 320C464 399.5 399.5 464 320 464C240.5 464 176 399.5 176 320zM320 256C320 291.3 291.3 320 256 320C244.5 320 233.7 317 224.3 311.6C223.3 322.5 224.2 333.7 227.2 344.8C240.9 396 293.6 426.4 344.8 412.7C396 399 426.4 346.3 412.7 295.1C400.5 249.4 357.2 220.3 311.6 224.3C316.9 233.6 320 244.4 320 256z"
            />
          </svg>
        </button>
        <button class="card__button">
          <span class="sr-only">Delete</span>
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640">
            <path
              d="M232.7 69.9L224 96L128 96C110.3 96 96 110.3 96 128C96 145.7 110.3 160 128 160L512 160C529.7 160 544 145.7 544 128C544 110.3 529.7 96 512 96L416 96L407.3 69.9C402.9 56.8 390.7 48 376.9 48L263.1 48C249.3 48 237.1 56.8 232.7 69.9zM512 208L128 208L149.1 531.1C150.7 556.4 171.7 576 197 576L443 576C468.3 576 489.3 556.4 490.9 531.1L512 208z"
            />
          </svg>
        </button>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.card {
  background: var(--color-white);
  border-radius: 8px;
  padding: 20px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  display: flex;
  align-items: stretch;
  justify-content: space-between;

  @include mq($until: $breakpoint-lg) {
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-template-row: 1fr 1fr;
  }

  &__author {
    font-size: 1rem;
    color: var(--color-grey-4);
    margin-top: 8px;
  }
  &__title {
    font-size: 1.25rem;
    color: var(--color-grey-4);
  }

  &__isbn {
    font-size: 0.875rem;
    color: var(--color-grey-4);
  }

  &__detail {
    display: flex;
    gap: 20px;

    &--mt {
      margin-top: 16px;
    }
  }

  &__icon {
    background: $linear-gradient;
    border-radius: 5px;
    width: 70px;
    display: flex;
    justify-content: center;
    align-items: center;

    svg {
      width: 40px;
      height: 40px;
    }
  }

  &__note {
    display: flex;
    align-items: center;
    color: var(--color-green);

    svg {
      height: 16px;
      width: 16px;
      fill: var(--color-green);
    }
  }

  &__status {
    display: flex;
    align-items: center;
    gap: 8px;

    @include mq($until: $breakpoint-lg) {
      flex-direction: column;
      align-items: flex-end;
    }
  }

  &__rating {
    display: flex;
    align-items: center;

    &-text {
      margin-left: 8px;
      font-size: 0.875rem;
      color: var(--color-grey-4);
    }
  }

  &__star {
    width: 20px;
    height: 20px;
  }

  &__actions {
    display: flex;
    gap: 8px;
  }

  &__button {
    background-color: var(--color-grey-2);
    border: none;
    cursor: pointer;
    padding: 8px;
    border-radius: 4px;

    &:hover {
      background-color: var(--color-grey-3);
    }

    svg {
      width: 16px;
      height: 16px;
      fill: var(--color-grey-4);
    }
  }
}
</style>
