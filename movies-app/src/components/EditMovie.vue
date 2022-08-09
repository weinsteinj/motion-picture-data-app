<template>
  <div>
    <h1>{{headerText}}</h1>
    <form v-on:submit.prevent="updateMovie">
      <label  for="name">Name:</label><br>
      <input id="movie-name" type="text" placeholder="Name" v-model="updatedMovie.name" 
      value="Old Title" required maxlength="50" minlength="1" >
      
      <br>
      <label for="description">Description:</label><br>
      <textarea rows="10" cols="50" id="description-text" placeholder="Description" 
      v-model="updatedMovie.description" maxlength="500"></textarea>
      <br>
      <br>
      <label for="releaseYear" >Release Year:</label><br>
      <input id="movie-year" type="number" placeholder="Release Year" v-model="updatedMovie.releaseYear" 
      required min=1800 max=2300 >
      
      <br>
      <br>
      <div id="action-button-area">
        <div></div>
        <div><button type="submit">Save</button>
        <button v-on:click.prevent="cancelEdit" type="cancel">Cancel</button>
        <button v-on:click.prevent="confirmAndDelete" type="delete">Delete</button>
        </div>
        <div></div>
      </div>
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
      this.resetMovieForm;
      let movieArray;
      apiService.getAllMovies()
        .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully edited!")
          movieArray = response.data;
          this.$store.commit('ADD__ALL_MOVIES', movieArray)
          this.$router.push({name:'home'});
          }
        });
      }
    },
    resetMovieForm () {
      this.updatedMovie = {};
    },
    confirmAndDelete () {
      if (
        confirm('Do you wish to delete this movie record? NB: This action cannot be undone.')
      ) {
      apiService.deleteMovie(this.updatedMovie.id)
      .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully deleted!")
         }
       });
      this.resetMovieForm;
      let movieArray;
      apiService.getAllMovies()
        .then(response => {
          if (response.status === 200) {
          movieArray = response.data;
          this.$store.commit('ADD__ALL_MOVIES', movieArray);
          this.$router.push({name:'home'});
          }
        });
      
      }
    },
    cancelEdit () {
      this.$router.push({name:'home'});
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
#action-button-area {
      display: flex;
      justify-content: space-around;
}
#action-button-area div {
      display: flex;
      justify-content: space-evenly;
}

input:invalid {
    border: 2px solid red;
}
input:valid {
    border: 2px solid black;
}



</style>
