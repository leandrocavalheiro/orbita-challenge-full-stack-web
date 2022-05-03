import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import('../views/students/StudentListView.vue')
  },
  {
    path: '/students',
    name: 'students',
    component: () => import('../views/students/StudentListView.vue')
  },  
  {
  path: '/students/:id',
  name: 'edit-student',
  component: () => import('../views/students/StudentEditView.vue')
  },
  {
    path: '/students',
    name: 'add-student',
    component: () => import('../views/students/StudentAddView.vue')
    },   
  {
    path: '/about',
    name: 'about',
    component: () => import('../views/AboutView.vue')
  }  
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
