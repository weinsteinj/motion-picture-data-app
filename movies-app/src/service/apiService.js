import axios from 'axios'

const http = axios.create({
  baseURL: 'http://localhost:5001/movie'
})

export default {
  createNewMovie () {
    return http.postForm('')
  },

  allMovies () {
    return http.get('')
  },

  getMovie (id) {
    return http.get(`/${id}`)
  },

  updateMovie (id) {
    return http.putForm(`/${id}`)
  },
  deleteMovie (id) {
    return http.delete(`/${id}`)
  }
}
