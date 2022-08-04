import axios from 'axios'

const http = axios.create({
  baseURL: 'https://localhost:5001'
});

export default {
  postNewMovie (movieBody) {
    return http.post('/movie/', movieBody);
  },

  getAllMovies () {
    return http.get('/movie/');
  },

  getMovie (id) {
    return http.get(`/movie/${id}`);
  },

  updateMovie (id, movieBody) {
    return http.put(`/movie/${id}`, movieBody);
  },
  deleteMovie (id) {
    return http.delete(`/movie/${id}`);
  },
}
