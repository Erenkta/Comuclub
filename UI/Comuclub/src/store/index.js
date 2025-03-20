import { defineStore } from 'pinia';

// Auth store
export const useAuthStore = defineStore('auth', {
  state: () => ({
    user: null,
    isAuthenticated: false,
    token: null
  }),

  getters: {
    getUser: (state) => state.user,
    getIsAuthenticated: (state) => state.isAuthenticated
  },

  actions: {
    login(userData) {
      // In a real app, this would make an API call to authenticate the user
      // and store the returned token
      this.user = {
        id: 1,
        name: userData.email.split('@')[0],
        email: userData.email,
        // Other user data would come from the API
      };
      this.isAuthenticated = true;
      this.token = 'dummy-jwt-token';

      // Save to localStorage (optional, for session persistence)
      localStorage.setItem('auth', JSON.stringify({
        user: this.user,
        isAuthenticated: this.isAuthenticated,
        token: this.token
      }));
    },

    logout() {
      this.user = null;
      this.isAuthenticated = false;
      this.token = null;

      // Clear localStorage
      localStorage.removeItem('auth');
    },

    checkAuth() {
      // Check if user is already logged in from localStorage
      const authData = localStorage.getItem('auth');
      if (authData) {
        const { user, isAuthenticated, token } = JSON.parse(authData);
        this.user = user;
        this.isAuthenticated = isAuthenticated;
        this.token = token;
      }
    }
  }
});

// Events store
export const useEventsStore = defineStore('events', {
  state: () => ({
    events: [],
    isLoading: false,
    error: null
  }),

  getters: {
    getEvents: (state) => state.events,
    getIsLoading: (state) => state.isLoading
  },

  actions: {
    async fetchEvents() {
      this.isLoading = true;
      try {
        // In a real app, this would be an API call
        // For now, we'll use mock data
        await new Promise(resolve => setTimeout(resolve, 500)); // Simulate API delay

        this.events = [
          {
            id: 1,
            title: 'Motosiklet Turu',
            date: 'March 23, 2025 1:00 AM',
            community: 'Motosiklet Topluluğu',
            image: 'https://www.comu.edu.tr/assets/img/comulogo-xl.png',
            location: 'Ayvalık',
            attendees: 10
          },
          {
            id: 2,
            title: 'Doğa yürüyüşü',
            date: 'March 24, 2025 1:00 AM',
            community: 'İzcilik Topluluğu',
            image: 'https://www.comu.edu.tr/assets/img/comulogo-xl.png',
            location: 'Kaz Dağları',
            attendees: 10
          }
        ];
      } catch (error) {
        this.error = error.message;
      } finally {
        this.isLoading = false;
      }
    }
  }
});

// Communities store
export const useCommunitiesStore = defineStore('communities', {
  state: () => ({
    communities: [],
    isLoading: false,
    error: null
  }),

  getters: {
    getCommunities: (state) => state.communities,
    getIsLoading: (state) => state.isLoading
  },

  actions: {
    async fetchCommunities() {
      this.isLoading = true;
      try {
        // In a real app, this would be an API call
        // For now, we'll use mock data
        await new Promise(resolve => setTimeout(resolve, 500)); // Simulate API delay

        this.communities = [
          {
            id: 1,
            name: 'Motosiklet Topluluğu',
            image: 'https://www.comu.edu.tr/assets/img/comulogo-xl.png',
            members: 963
          },
          {
            id: 2,
            name: 'İzcilik Topluluğu',
            image: 'https://www.comu.edu.tr/assets/img/comulogo-xl.png',
            members: 563
          },
          {
            id: 2,
            name: 'IEEE Topluluğu',
            image: 'https://www.comu.edu.tr/assets/img/comulogo-xl.png',
            members: 1263
          }
        ];
      } catch (error) {
        this.error = error.message;
      } finally {
        this.isLoading = false;
      }
    }
  }
});
