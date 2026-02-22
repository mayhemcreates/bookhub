import { describe, it, expect, beforeEach, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import App from '../App.vue'
import { createPinia, setActivePinia } from 'pinia'
import { useBookStore } from '@/stores/bookStore'

vi.mock('../composables/useTabDetection', () => ({
  useTabDetection: vi.fn(),
}))

vi.mock('vue-router')

beforeEach(() => {
  setActivePinia(createPinia())
})

describe('App', () => {
  it('mounts renders properly', () => {
    const pinia = createPinia()
    setActivePinia(pinia)
    const wrapper = mount(App, {
      global: {
        plugins: [pinia],
      },
    })
    expect(wrapper.findComponent({ name: 'AppLayout' }).exists()).toBe(true)
  })
})

it('fetches books on mount', async () => {
  const pinia = createPinia()
  setActivePinia(pinia)
  const bookStore = useBookStore()
  const fetchBooksSpy = vi.spyOn(bookStore, 'fetchBooks')

  mount(App, {
    global: {
      plugins: [pinia],
      stubs: {
        AppLayout: true,
      },
    },
  })

  expect(fetchBooksSpy).toHaveBeenCalledOnce()
})
