<template>
  <div class="events-page">
    <div class="container py-5">
      <div class="search-section mb-5">
        <h1 class="h3 mb-4">Etkinlikler</h1>
      </div>

      <!-- Loading state -->
      <div class="text-center py-5" v-if="isLoading">
        <div class="spinner-border text-primary" role="status">
          <span class="visually-hidden">Yükleniyor...</span>
        </div>
        <p class="mt-2">Etkinlikler Yükleniyor...</p>
      </div>

      <!-- Event list -->
      <div v-else>
        <!-- Event Date Section -->
        <div class="date-section mb-4">
          <h2 class="h5 mb-3">23 Mart, Pazar</h2>

          <div class="card mb-4" v-for="event in events.filter(e => e.date.includes('March 23'))" :key="event.id">
            <div class="card-body p-4">
              <div class="row">
                <div class="col-md-8">
                  <h3 class="h4 mb-3">
                    <a href="#" class="text-decoration-none text-dark">{{ event.title }}</a>
                  </h3>
                  <p class="mb-2">{{ event.date }}, Topluluk: <a href="#" class="text-decoration-none">{{ event.community }}</a></p>
                  <span class="tag tag-online">
                    <i class="bi bi-broadcast me-1"></i> {{ event.location }}
                  </span>

                  <div class="d-flex mt-3 align-items-center">
                    <span class="text-muted">{{ event.attendees }} üye katılıyor</span>
                  </div>
                </div>
                <div class="col-md-4">
                  <img :src="event.image" alt="Event" class="img-fluid rounded" style="width: 100%; max-height: 150px; object-fit: contain;">
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- Next Event Date Section -->
        <div class="date-section mb-4">
          <h2 class="h5 mb-3">24 Mart, Pazar</h2>

          <div class="card mb-4" v-for="event in events.filter(e => e.date.includes('March 24'))" :key="event.id">
            <div class="card-body p-4">
              <div class="row">
                <div class="col-md-8">
                  <h3 class="h4 mb-3">
                    <a href="#" class="text-decoration-none text-dark">{{ event.title }}</a>
                  </h3>
                  <p class="mb-2">{{ event.date }}, Topluluk: <a href="#" class="text-decoration-none">{{ event.community }}</a></p>
                  <span class="tag tag-online">
                    <i class="bi bi-broadcast me-1"></i> {{ event.location }}
                  </span>

                  <div class="d-flex mt-3 align-items-center">
                    <span class="text-muted">{{ event.attendees }} üye katılıyor</span>
                  </div>
                </div>
                <div class="col-md-4">
                  <img :src="event.image" alt="Event" class="img-fluid rounded" style="width: 100%; max-height: 150px; object-fit: contain;">
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useEventsStore } from '../store';
import { storeToRefs } from 'pinia';
import { onMounted } from 'vue';

export default {
  name: 'Events',
  setup() {
    const eventsStore = useEventsStore();
    const { events, isLoading } = storeToRefs(eventsStore);

    // Fetch events when component mounts
    onMounted(() => {
      eventsStore.fetchEvents();
    });

    return {
      events,
      isLoading
    };
  }
}
</script>

<style scoped>
.active {
  background-color: var(--primary-color);
  color: white;
  border-color: var(--primary-color);
}

.btn-outline-secondary {
  border-color: #d0d0d0;
  color: #666;
}

.btn-outline-primary {
  border-color: var(--primary-color);
  color: var(--primary-color);
}

.btn-outline-primary:hover {
  background-color: var(--primary-color);
  color: white;
}

.card {
  border-radius: 8px;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  border: 1px solid rgba(0,0,0,0.1);
}

.card:hover {
  transform: translateY(-3px);
  box-shadow: 0 5px 15px rgba(0,0,0,0.1);
}

.rounded-pill {
  border-radius: 50px !important;
}
</style>
