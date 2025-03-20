<template>
  <div class="home-page">
    <!-- Hero Section -->
    <section class="hero-section text-white py-5 position-relative"
      style="background-image: url('https://tercihim.comu.edu.tr/template/tercihim/img/usSiluet1.png'); background-size: cover; background-position: center;">
      <div class="position-absolute top-0 start-0 w-100 h-100 bg-primary opacity-75"></div>
      <div class="container position-relative">
        <div class="row align-items-center">
          <div class="col-lg-6 mb-5 mb-lg-0">
            <h1 class="display-4 fw-bold mb-3">ÇOMÜ Topluluklar sayfasına hoş geldiniz</h1>
            <p class="lead mb-4">ÇOMÜ topluluklarının toplandığı tek adres</p>
          </div>
        </div>
      </div>
    </section>


    <!-- Events Section -->
    <section class="py-5">
      <div class="container">
        <div class="d-flex justify-content-between align-items-center mb-4">
          <h2 class="h3 mb-0">
            <span class="text-muted">Etkinlikler</span>
          </h2>
          <router-link to="/events" class="btn btn-dark"> Bütün etkinlikleri göster</router-link>
        </div>

        <div class="row g-4" v-if="!isLoadingEvents">
          <!-- Event Card 1 -->
          <div class="card mb-4" v-for="event in events" :key="event.id">
            <div class="card-body p-4">
              <div class="row">
                <div class="col-md-8">
                  <h3 class="h4 mb-3">
                    <a href="#" class="text-decoration-none text-dark">{{ event.title }}</a>
                  </h3>
                  <p class="mb-2">{{ event.date }}, Topluluk: <a href="#" class="text-decoration-none">{{
                      event.community }}</a></p>
                  <span v-if="event.location == 'online'" class="tag tag-online">

                    <i class="bi bi-broadcast me-1"></i> {{ event.location }}
                  </span>
                  <span v-else>
                    Konum: {{ event.location }}
                  </span>

                  <div class="d-flex mt-3 align-items-center">
                    <span class="text-muted">{{ event.attendees }} üye katılıyor</span>
                  </div>
                </div>
                <div class="col-md-4">
                  <img :src="event.image" alt="Event" class="img-fluid rounded"
                    style="width: 100%; max-height: 150px; object-fit: contain;">
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Communities Section -->
    <section class="py-5 bg-light">
      <div class="container">
        <div class="d-flex justify-content-between align-items-center mb-4">
          <h2 class="h3 mb-0">
            <span class="ms-2">Topluluklar</span>
          </h2>
          <router-link to="/communities" class="btn btn-dark"> Bütün toplulukları göster</router-link>
        </div>

        <div class="row g-4 " v-if="!isLoadingCommunities">
          <!-- Community Card -->
          <div class="col-md-4 col-sm-6" v-for="community in communities" :key="community.id">
            <a href="#" class="text-decoration-none">
              <div class="card h-100 position-relative overflow-hidden">
                <img :src="community.image" class="card-img" alt="Community Image"
                  style="height: 150px; object-fit: cover;">
                <div class="card-img-overlay d-flex flex-column justify-content-end"
                  style="background: linear-gradient(to top, rgba(0,0,0,0.7), rgba(0,0,0,0));">
                  <h5 class="card-title text-white">{{ community.name }}</h5>
                  <div class="d-flex align-items-center">
                    <span class="text-white">{{ community.members }} üye</span>
                  </div>
                </div>
              </div>
            </a>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import { useEventsStore, useCommunitiesStore } from '../store';
import { storeToRefs } from 'pinia';
import { onMounted } from 'vue';
export default {
  name: 'Home',
  setup() {
    const eventStore = useEventsStore();
    const communitiesStore = useCommunitiesStore();
    const { communities, isLoadingCommunities } = storeToRefs(communitiesStore);
    const { events, isLoadingEvents } = storeToRefs(eventStore);

    onMounted(() => {
      communitiesStore.fetchCommunities();
      eventStore.fetchEvents();
    });
    return {
      events,
      communities,
      isLoadingCommunities,
      isLoadingEvents
    };
  }
}
</script>

<style scoped>
.card {
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.card:hover {
  transform: translateY(-5px);
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1);
}

.tag {
  display: inline-block;
  padding: 0.3rem 0.8rem;
  border-radius: 30px;
  font-size: 0.8rem;
  font-weight: 500;
}

.tag-online {
  background-color: rgba(95, 81, 168, 0.1);
  color: var(--primary-color);
}

.btn-warning {
  background-color: var(--accent-color);
  border-color: var(--accent-color);
}
</style>
