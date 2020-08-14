import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/permissions/create',
    name: 'CreatePermission',
    component: () => import('@/views/permissions/CreatePermission.vue')
  },
  {
    path: '/permissions/update/:id',
    name: 'UpdatePermission',
    component: () => import('@/views/permissions/UpdatePermission.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
