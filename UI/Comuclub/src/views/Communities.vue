<template>
  <div class="communities-page">
    <div class="container py-5">
      <div class="search-section mb-5">
        <h1 class="h3 mb-4">Topluluklar</h1>

      </div>

      <!-- Loading state -->
      <div class="text-center py-5" v-if="isLoading">
        <div class="spinner-border text-primary" role="status">
          <span class="visually-hidden">Yükleniyor...</span>
        </div>
        <p class="mt-2">Topluluklar Yükleniyor...</p>
      </div>

      <!-- Communities grid -->
      <div class="row g-4" v-else>
        <!-- Community Card -->
        <div class="col-md-4 col-sm-6" v-for="community in communities" :key="community.id">
          <a href="#" class="text-decoration-none">
            <div class="card h-100 position-relative overflow-hidden">
              <img :src="community.image" class="card-img" alt="Community Image" style="height: 150px; object-fit: cover;">
              <div class="card-img-overlay d-flex flex-column justify-content-end" style="background: linear-gradient(to top, rgba(0,0,0,0.7), rgba(0,0,0,0));">
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
  </div>
</template>

<script>
import { useCommunitiesStore } from '../store';
import { storeToRefs } from 'pinia';
import { onMounted } from 'vue';

export default {
  name: 'Communities',
  setup() {
    const communitiesStore = useCommunitiesStore();
    const { communities, isLoading } = storeToRefs(communitiesStore);

    // Fetch communities when component mounts
    onMounted(() => {
      communitiesStore.fetchCommunities();
    });

    return {
      communities,
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

.card {
  border-radius: 8px;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  border: 1px solid rgba(0,0,0,0.1);
  height: 200px;
}

.card:hover {
  transform: translateY(-5px);
  box-shadow: 0 10px 20px rgba(0,0,0,0.15);
}

.card-title {
  font-size: 1.1rem;
  font-weight: 600;
  text-shadow: 0 1px 3px rgba(0,0,0,0.3);
}
</style>
