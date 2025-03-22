<template>
  <MainLayout>
    <router-view />
  </MainLayout>
</template>

<script>
import MainLayout from './components/MainLayout.vue';

export default {
  name: 'App',
  components: {
    MainLayout
  }
}
</script>

<style>
/* Global styles can go here */
</style>
