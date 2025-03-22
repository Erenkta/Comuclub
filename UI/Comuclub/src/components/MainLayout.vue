<template>
  <div class="main-layout">
    <Navbar />
    <main>
      <slot></slot>
    </main>
  </div>
</template>

<script>
import Navbar from './Navbar.vue';
export default {
  name: 'MainLayout',
  components: {
    Navbar,
  }
}
</script>

<style scoped>
.main-layout {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

main {
  flex: 1;
}
</style>
