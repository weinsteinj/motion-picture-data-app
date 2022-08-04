import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    movies: []
  },
  mutations: {
    ADD__ALL_MOVIES (state, movieArray) {
      this.state.movies = movieArray;
    }
  },
  actions: {
  },
  modules: {
  }
})
