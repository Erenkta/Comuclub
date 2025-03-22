<template>
  <div class="login-page py-5">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-md-6 col-lg-5">
          <div class="card border-0 shadow-sm">
            <div class="card-body p-4 p-md-5">
              <h1 class="h3 text-center mb-4">ComuClub'a Giriş Yap</h1>

              <form @submit.prevent="login">
                <div class="mb-3">
                  <label for="email" class="form-label">Email</label>
                  <input type="email" class="form-control" id="email" placeholder="Mail adresini yaz" v-model="email" required>
                </div>

                <div class="mb-4">
                  <label for="password" class="form-label">Parola</label>
                  <input type="password" class="form-control" id="password" placeholder="Parolanı yaz" v-model="password" required>
                  <div class="mt-2 text-end">
                    <a href="#" class="text-decoration-none small text-muted">Parolamı Unuttum</a>
                  </div>
                </div>

                <div class="d-grid mb-4">
                  <button type="submit" class="btn btn-primary py-2" :disabled="isSubmitting">
                    {{ isSubmitting ? 'Giriş Yapılıyor...' : 'Giriş Yap' }}
                  </button>
                </div>

                <div class="text-center">
                  <p class="mb-0">Hesabın yok mu ? <router-link to="/register" class="text-decoration-none">Kayıt Ol</router-link></p>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useAuthStore } from '../store';

export default {
  name: 'Login',
  data() {
    return {
      email: '',
      password: '',
      isSubmitting: false
    }
  },
  methods: {
    async login() {
      this.isSubmitting = true;

      try {
        const authStore = useAuthStore();

        // In a real app, you would validate and send to an API
        // For now, we'll just simulate a successful login
        setTimeout(() => {
          authStore.login({
            email: this.email,
            password: this.password
          });

          this.$router.push('/');
        }, 1000);
      } catch (error) {
        console.error('Login error:', error);
        alert('An error occurred during login. Please try again.');
      } finally {
        this.isSubmitting = false;
      }
    }
  }
}
</script>

<style scoped>
.login-page {
  background-color: #f9f9f9;
  min-height: 80vh;
  display: flex;
  align-items: center;
}

.card {
  border-radius: 10px;
}

.form-control {
  padding: 0.75rem 1rem;
  border-radius: 5px;
}

.form-control:focus {
  border-color: var(--primary-color);
  box-shadow: 0 0 0 0.25rem rgba(95, 81, 168, 0.25);
}
</style>
