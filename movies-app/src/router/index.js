import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeModal from '../views/HomeModal.vue'
// import Add from '../views/Add.vue'
// import Table from '@/views/Table.vue'
// import Edit from '../views/Edit.vue'
// import Copy from '@/views/Copy.vue'
// import TestModal from '@/views/TestModal.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeModal
  },
  // {
  //   path: '/add',
  //   name: 'add',
  //   component: Add
  // },
  // {
  //   path: '/table',
  //   name: 'table',
  //   component: Table
  // },
  // {
  //   path: '/edit',
  //   name: 'edit',
  //   component: Edit
  // },
  // {
  //   path: '/copy',
  //   name: 'copy',
  //   component: Copy
  // },
  // {
  //   path: '/test',
  //   name: 'test-modal-view',
  //   component: TestModal
  // },
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
