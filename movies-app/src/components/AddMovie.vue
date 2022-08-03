<template>
  <div>
    <h1>{{headerText}}</h1>
    <form v-on:submit.prevent="postMovie">
      <label for="title" >Title   </label>
      <input type="text" placeholder="Title" v-model="newMovie.title">
      <br>
      <br>
      <label for="description">Description   </label>
      <input id="description-text" placeholder="Description" type="text-box" v-model="newMovie.description">
      <br>
      <br>
      <label for="releaseYear" >Release Year   </label>
      <input type="text" placeholder="Release Year" v-model="newMovie.releaseYear">
      <br>
      <br>
      <button type="submit">Save</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'add-movie',
  data () {
    return {
      headerText: 'Please Add to Movie-Vue!',
      newMovie: {
        title: '',
        description: '',
        releaseYear: null,
      },
    }
  },
  methods: {
    postMovie () {
      // create body of post request, including parsing the year to an integer
      const movieBody = {name: this.newMovie.title, description: this.newMovie.description, releaseYear: Number.parseInt(this.newMovie.releaseYear)};
      // send the axios Http-POST request to back-end server
      axios.post('https://localhost:5001/movie/', movieBody)
       .then(response => console.log(response.data));
      // send the axios Http-GET-All request to back-end server to refresh the table view after posting
      axios.get('https://localhost:5001/movie/')
       .then(response => (this.movieArray = response.data));
       // clear the form data
       this.resetMovieForm;
       // re-route user to the main data table view
       this.$router.push({name:'home'});
    },
    resetMovieForm () {
      this.newMovie = {};
    },
  },
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
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
