// Define your route components
import Home from '../views/Home.vue'

// Routes array
const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/events',
    name: 'Events',
    component: () => import('../views/Events.vue')
  },
  {
    path: '/communities',
    name: 'Communities',
    component: () => import('../views/Communities.vue')
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('../views/Login.vue')
  },
  // {
  //   path: '/register',
  //   name: 'Register',
  //   component: () => import('../views/Register.vue')
  // }
]

export default routes
