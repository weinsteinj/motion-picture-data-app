import Vue from 'vue'
import Vuex from 'vuex'
import apiService from '../service/apiService'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    movies: []
  },
  mutations: {
    ADD__ALL_MOVIES () {
      this.state.movies = apiService.allMovies()
    }
  },
  actions: {
  },
  modules: {
  }
})
