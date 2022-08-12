<template>
  <div>
    <h1>{{headerText}}</h1>
    <form class="form-movie" v-on:submit.prevent="updateMovie">
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
        <div><button class="btn-save" type="submit">Save</button>
        <button class="btn-cancel" v-on:click.prevent="cancelEdit" type="cancel">Cancel</button>
        <button class="btn-delete" v-on:click.prevent="confirmAndDelete" type="delete">Delete</button>
        </div>
        <div></div>
      </div>
    </form>
  </div>
</template>

<script>
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
    // if form data is validated, sends PUT request to server (with back-up validation)
    updateMovie () {
      const movieBody = {id: this.updatedMovie.id, name: this.updatedMovie.name, description: this.updatedMovie.description, 
        releaseYear: Number.parseInt(this.updatedMovie.releaseYear)};
      apiService.updateMovie(this.updatedMovie.id, movieBody)
      .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully edited!")
           this.resetMovieForm;
           let movieArray;
          movieArray = response.data;
          this.$store.commit('ADD__ALL_MOVIES', movieArray)
          this.$router.push({name:'home'});
          }
        })
      .catch(() => {
         alert("Sorry. An error has occurred.")
       });
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
       })
       .catch(() => {
         alert("Sorry. An error has occurred.")
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
        })
        .catch(() => {
         alert("Sorry. An error has occurred.")
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
