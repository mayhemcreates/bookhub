import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router'

import MyBooks from '@/views/MyBooks.vue'
import BookView from '@/views/BookView.vue'
import IconAnalytics from '@/assets/icons/IconAnalytics.vue'
import IconBooks from '@/assets/icons/IconBooks.vue'
import IconDashboard from '@/assets/icons/IconDashboard.vue'
import IconSettings from '@/assets/icons/IconSettings.vue'
import type { Component } from 'vue/dist/vue.js'

export type CustomRouteRecordRaw = RouteRecordRaw & {
  icon?: Component
  showInNav?: boolean
}

const routes: CustomRouteRecordRaw[] = [
  { path: '/', name: 'Dashboard', component: MyBooks, icon: IconDashboard, showInNav: true },
  { path: '/books', name: 'My Books', component: MyBooks, icon: IconBooks, showInNav: true },
  {
    path: '/book/:id',
    name: 'book',
    component: BookView,
    icon: IconBooks,
    showInNav: false,
    props: true,
  },
  {
    path: '/analytics',
    name: 'Analytics',
    component: MyBooks,
    icon: IconAnalytics,
    showInNav: true,
  },
  { path: '/settings', name: 'Settings', component: MyBooks, icon: IconSettings, showInNav: true },
]

export const router = createRouter({
  history: createWebHistory(),
  routes,
})
