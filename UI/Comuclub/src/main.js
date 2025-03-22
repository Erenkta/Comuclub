import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { createRouter, createWebHistory } from 'vue-router'

// Import Bootstrap CSS and JS
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.bundle.min.js'

// Import custom CSS
import './assets/styles/main.css'

import App from './App.vue'
import routes from './router'

// Create the router instance
const router = createRouter({
  history: createWebHistory(),
  routes
})

// Create the Pinia store
const pinia = createPinia()

// Create the app instance
const app = createApp(App)

// Use the plugins
app.use(router)
app.use(pinia)

// Mount the app
app.mount('#app')
