<template>
  <div>
    <h1>{{headerText}}</h1>
    <form v-on:submit.prevent="postMovie">
      <label for="name">Name:</label><br>
      <input type="text" placeholder="Name" v-model="newMovie.name" maxlength="50" minlength="1" 
      id="title-input" required>
      <br>
      <br>
      <label for="description">Description:</label><br>
      <textarea rows="10" cols="100" id="description-text" placeholder="Description" 
      v-model="newMovie.description" maxlength="500"></textarea>
      <br>
      <br>
      <label for="releaseYear" >Release Year:</label><br>
      <input type="text" placeholder="Release Year" v-model="newMovie.releaseYear" 
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
  name: 'add-movie',
  data () {
    return {
      headerText: 'Please Add to Movie-Vue!',
      newMovie: {
        name: '',
        description: '',
        releaseYear: null,
      },
      isValid: false,
    }
  },
  methods: {
    postMovie () {
      
      if (Number.parseInt(this.newMovie.releaseYear) > 2300 
        || Number.parseInt(this.newMovie.releaseYear) < 1800
        || isNaN(Number.parseInt(this.newMovie.releaseYear))
      ) {
        alert("Please enter a four-digit release year, then try again.");
        return;
      } else {
      const movieBody = {name: this.newMovie.name, description: this.newMovie.description, releaseYear: Number.parseInt(this.newMovie.releaseYear)};
      apiService.postNewMovie(movieBody);
      this.resetMovieForm;
      this.$router.push({name:'home'});
      } 
    },
    resetMovieForm () {
      this.newMovie = {};
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
#title-input {
  width: 30%
}
</style>
