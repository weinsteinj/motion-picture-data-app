<template>
  <div>
    <h1>{{headerText}}</h1>
    <form v-on:submit.prevent="updateMovie">
      <label for="name">Name:</label><br>
      <input type="text" placeholder="Name" v-model="updatedMovie.name" 
      value="Old Title" required maxlength="50" minlength="1">
      <br>
      <label for="description">Description:</label><br>
      <textarea rows="10" cols="100" id="description-text" placeholder="Description" 
      v-model="updatedMovie.description" maxlength="500"></textarea>
      <br>
      <br>
      <label for="releaseYear" >Release Year:</label><br>
      <input type="text" placeholder="Release Year" v-model="updatedMovie.releaseYear" 
      required minlength="4" maxlength="4">
      <br>
      <br>
      <button type="submit">Save</button>
    </form>
  </div>
</template>

<script>
// import axios from 'axios'
import apiService from '@/service/apiService.js'

export default {
  name: 'edit-movie',
  data () {
    return {
      headerText: 'Please Edit the Movie Data Below',
      updatedMovie: {
        id: this.$route.params.id,
        name: this.$route.params.name,
        description: this.$route.params.description,
        releaseYear: this.$route.params.releaseYear,
      },
      movieArray: {

      },
    }
  },
  methods: {
    updateMovie () {
      if (Number.parseInt(this.updatedMovie.releaseYear) > 2300 
        || Number.parseInt(this.updatedMovie.releaseYear) < 1800
        || isNaN(Number.parseInt(this.updatedMovie.releaseYear))
      ) {
        alert("Please enter a four-digit release year, then try again.");
        return;
      } else {
      const movieBody = {id: this.updatedMovie.id, name: this.updatedMovie.name, description: this.updatedMovie.description, 
        releaseYear: Number.parseInt(this.updatedMovie.releaseYear)};
      apiService.updateMovie(this.updatedMovie.id, movieBody);
      // apiService.getAllMovies();
      this.resetMovieForm;
      this.$router.push({name:'home'});
      }
    },
    resetMovieForm () {
      this.updatedMovie = {};
    },
  },
  props: {
  }
}
</script>

<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
