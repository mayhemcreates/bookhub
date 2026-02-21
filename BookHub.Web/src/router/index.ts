import { createMemoryHistory, createRouter } from 'vue-router'

import MyBooks from '@/views/MyBooks.vue'

const routes = [
  { path: '/', name: 'Dashboard', component: MyBooks },
  { path: '/books', name: 'My Books', component: MyBooks },
  { path: '/analytics', name: 'Analytics', component: MyBooks },
  { path: '/settings', name: 'Settings', component: MyBooks },
]

export const router = createRouter({
  history: createMemoryHistory(),
  routes,
})
