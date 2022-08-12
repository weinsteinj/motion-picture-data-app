import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    movies: [],
    activeMovie: {},
    inAddMode: false,
    inCopyMode: false,
    inEditMode: false,
  },
  mutations: {
    ADD__ALL_MOVIES (state, movieArray) {
      this.state.movies = movieArray;
    },
    SET_ACTIVE_MOVIE (state, activeMovie) {
      this.state.activeMovie = activeMovie;
    },
    TOGGLE_ADD_MODE () {
      this.state.inAddMode = !this.state.inAddMode;
    },
    TOGGLE_COPY_MODE () {
      this.state.inCopyMode = !this.state.inCopyMode;
    },
    TOGGLE_EDIT_MODE () {
      this.state.inEditMode = !this.state.inEditMode;
    },
  },
  actions: {
  },
  modules: {
  }
})
