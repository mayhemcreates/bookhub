import { createMemoryHistory, createRouter, type RouteRecordRaw } from 'vue-router'

import MyBooks from '@/views/MyBooks.vue'
import IconAnalytics from '@/assets/icons/IconAnalytics.vue'
import IconBooks from '@/assets/icons/IconBooks.vue'
import IconDashboard from '@/assets/icons/IconDashboard.vue'
import IconSettings from '@/assets/icons/IconSettings.vue'
import type { Component } from 'vue/dist/vue.js'

export type CustomRouteRecordRaw = RouteRecordRaw & {
  icon?: Component
}

const routes: CustomRouteRecordRaw[] = [
  { path: '/', name: 'Dashboard', component: MyBooks, icon: IconDashboard },
  { path: '/books', name: 'My Books', component: MyBooks, icon: IconBooks },
  { path: '/analytics', name: 'Analytics', component: MyBooks, icon: IconAnalytics },
  { path: '/settings', name: 'Settings', component: MyBooks, icon: IconSettings },
]

export const router = createRouter({
  history: createMemoryHistory(),
  routes,
})
