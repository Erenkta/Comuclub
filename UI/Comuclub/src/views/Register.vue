<template>
  <div class="register-page py-5">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-md-6 col-lg-5">
          <div class="card border-0 shadow-sm">
            <div class="card-body p-4 p-md-5">
              <h1 class="h3 text-center mb-4">ComuClub'a Katıl</h1>

              <form @submit.prevent="register">
                <div class="mb-3">
                  <label for="fullname" class="form-label">İsim Soyisim</label>
                  <input type="text" class="form-control" id="fullname" placeholder="İsim Soyisim yazın" v-model="fullname" required>
                </div>

                <div class="mb-3">
                  <label for="email" class="form-label">Email</label>
                  <input type="email" class="form-control" id="email" placeholder="Email yazın" v-model="email" required>
                </div>

                <div class="mb-3">
                  <label for="password" class="form-label">Parola</label>
                  <input type="password" class="form-control" id="password" placeholder="Parola Oluşturun" v-model="password" required>
                  <small class="form-text text-muted">parola en az 8 karakterden oluşmalı</small>
                </div>

                <div class="mb-4">
                  <label for="confirmPassword" class="form-label">Parolayı Onayla</label>
                  <input type="password" class="form-control" id="confirmPassword" placeholder="Tekrardan Parolanızı girin" v-model="confirmPassword" required>
                </div>

                <!-- <div class="mb-4 form-check">
                  <input type="checkbox" class="form-check-input" id="terms" v-model="agreeTerms" required>
                  <label class="form-check-label small" for="terms">
                    I agree to the <a href="#" class="text-decoration-none">Terms of Service</a> and <a href="#" class="text-decoration-none">Privacy Policy</a>
                  </label>
                </div> -->

                <div class="d-grid mb-4">
                  <button type="submit" class="btn btn-primary py-2" :disabled="isSubmitting">
                    {{ isSubmitting ? 'Hesap Oluşturuluyor...' : 'Hesap Oluştur' }}
                  </button>
                </div>

                <div class="text-center">
                  <p class="mb-0">Daha önceden bir hesabın var mı ? <router-link to="/login" class="text-decoration-none">Giriş Yap</router-link></p>
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
  name: 'Register',
  data() {
    return {
      fullname: '',
      email: '',
      password: '',
      confirmPassword: '',
      agreeTerms: false,
      isSubmitting: false
    }
  },
  methods: {
    async register() {
      if (this.password !== this.confirmPassword) {
        alert('Parolalar Eşleşmiyor!');
        return;
      }

      if (this.password.length < 8) {
        alert('Parola en az 8 karakterden oluşmalı');
        return;
      }

      this.isSubmitting = true;

      try {
        const authStore = useAuthStore();

        // In a real app, you would validate and send to an API
        // For now, we'll just simulate a successful registration
        setTimeout(() => {
          authStore.login({
            name: this.fullname,
            email: this.email,
            password: this.password
          });

          this.$router.push('/');
        }, 1000);
      } catch (error) {
        console.error('Registration error:', error);
        alert('An error occurred during registration. Please try again.');
      } finally {
        this.isSubmitting = false;
      }
    }
  }
}
</script>

<style scoped>
.register-page {
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

.btn-accent {
  background-color: var(--accent-color);
  border-color: var(--accent-color);
  color: var(--dark-color);
}

.btn-accent:hover {
  background-color: #d9a413;
  border-color: #d9a413;
}
</style>
