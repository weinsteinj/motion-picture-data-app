import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Add from '../views/Add.vue'
import TestView from '../views/TestView.vue'
import Table from '@/views/Table.vue'
import Edit from '../views/Edit.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/add',
    name: 'add',
    component: Add
  },
  {
    path: '/test',
    name: 'test-view',
    component: TestView
  },
  {
    path: '/table',
    name: 'table',
    component: Table
  },
  {
    path: '/edit',
    name: 'edit',
    component: Edit
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
// route level code-splitting
// this generates a separate chunk (about.[hash].js) for this route
// which is lazy-loaded when the route is visited.
