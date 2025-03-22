<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-white">
    <div class="container">
      <!-- Logo -->
      <router-link class="navbar-brand" to="/">
        <span class="fw-bold fs-4">ComuClub</span>
      </router-link>

      <!-- Mobile toggle button -->
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
        aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <!-- Nav links -->
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav me-auto">
          <li class="nav-item">
            <router-link class="nav-link" to="/">Anasayfa</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link" to="/events">Etkinlikler</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link" to="/communities">Topluluklar</router-link>
          </li>
        </ul>

        <!-- Auth buttons -->
        <div class="d-flex">
          <!-- When logged out -->
          <template v-if="!isAuthenticated">
            <router-link to="/login" class="btn btn-dark me-2" style="color: white !important;">Giriş Yap</router-link>
            <!-- <router-link to="/register" class="btn btn-primary" style="color: white !important;">Kayıt Ol</router-link> -->
          </template>

          <!-- When logged in -->
          <div class="dropdown" v-else>
            <button class="btn btn-outline-secondary dropdown-toggle d-flex align-items-center" type="button"
              id="userDropdown" data-bs-toggle="dropdown" aria-expanded="false">
              <span class="user-avatar me-2">{{ userInitials }}</span>
              <span>{{ userName }}</span>
            </button>
            <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="userDropdown">
              <li><a class="dropdown-item" href="#">My Profile</a></li>
              <li><a class="dropdown-item" href="#">My Communities</a></li>
              <li><a class="dropdown-item" href="#">My Events</a></li>
              <li><hr class="dropdown-divider"></li>
              <li><a class="dropdown-item" href="#" @click.prevent="logout">Log Out</a></li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import { useAuthStore } from '../store';
import { storeToRefs } from 'pinia';

export default {
  name: 'Navbar',
  setup() {
    const authStore = useAuthStore();
    const { isAuthenticated, user } = storeToRefs(authStore);

    // Check if user is already logged in from localStorage
    authStore.checkAuth();

    return {
      isAuthenticated,
      user,
      logout: authStore.logout
    };
  },
  computed: {
    userName() {
      return this.user?.name || '';
    },
    userInitials() {
      if (!this.user?.name) return '';
      return this.user.name.split(' ')
        .map(n => n[0])
        .join('')
        .toUpperCase();
    }
  }
}
</script>

<style scoped>
.navbar-brand {
  display: flex;
  align-items: center;
  font-weight: 700;
}

.navbar-brand span:first-child {
  font-size: 30px;
  margin-right: 5px;
}

.dropdown-header {
  font-weight: bold;
  color: var(--primary-color);
  padding-top: 0.5rem;
  padding-bottom: 0.2rem;
}

.dropdown-menu {
  min-width: 250px;
  padding: 0.5rem;
}

.navbar .router-link-active {
  color: var(--primary-color) !important;
  font-weight: 500;
}

.navbar-nav .nav-link {
  padding: 0.5rem 1rem;
}

.btn {
  padding: 0.4rem 1.5rem;
  font-weight: 500;
}

.user-avatar {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 30px;
  height: 30px;
  border-radius: 50%;
  background-color: var(--primary-color);
  color: white;
  font-size: 0.8rem;
  font-weight: bold;
}
</style>
