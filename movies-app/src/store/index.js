import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    movies: [],
    activeMovie: {},
    inEditMode: false,
  },
  mutations: {
    ADD__ALL_MOVIES (state, movieArray) {
      this.state.movies = movieArray;
    },
    SET_ACTIVE_MOVIE (state, activeMovie) {
      this.state.activeMovie = activeMovie;
    },
    TOGGLE_EDIT_MODE () {
      this.state.inEditMode = !this.state.inEditMode;
    },
    TOGGLE_CREATE_MODE () {
      this.state.inCreateMode = !this.state.inCreateMode;
    },
  },
  actions: {
  },
  modules: {
  }
})
