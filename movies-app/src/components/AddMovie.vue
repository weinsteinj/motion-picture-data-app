<template>
  <div>
    <h1>{{headerText}}</h1>
    <form class="form-movie" v-on:submit.prevent="postMovie">
      <label for="name">Name:</label><br>
      <input type="text" placeholder="Name" v-model="newMovie.name" maxlength="50" minlength="1" 
      id="title-input" required>
      <br>
      <br>
      <label for="description">Description:</label><br>
      <textarea rows="10" cols="50" id="description-text" placeholder="Description" 
      v-model="newMovie.description" maxlength="500"></textarea>
      <br>
      <br>
      <label for="releaseYear" >Release Year:</label><br>
      <input type="number" placeholder="Release Year" 
      v-model="newMovie.releaseYear" 
      required min=1800 max=2300>
      <br>
      <br>
      <div id="action-button-area">
        <div></div>
        <div>
          <button class="btn-save" type="submit">Save</button>
          <button class="btn-cancel" v-on:click.prevent="cancelEdit" type="cancel">Cancel</button>
        </div>
        <div></div>
      </div>
    </form>
  </div>
</template>

<script>
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
    }
  },
  methods: {
    // if form data is validated, sends POST request to server (with back-up validation)
    postMovie () {
      this.isInvalidYear = false;
      const movieBody = {name: this.newMovie.name, description: this.newMovie.description, releaseYear: Number.parseInt(this.newMovie.releaseYear)};
      apiService.postNewMovie(movieBody)
       .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully saved!")
         }
       });
      this.resetMovieForm;
      // api call returns promise; if status is OKAY, data received is used to mutate datastore before hiding form;
      apiService.getAllMovies()
      .then(response => {
          if (response.status === 200) {
          let movieArray;
          movieArray = response.data;
          this.$store.commit('ADD__ALL_MOVIES', movieArray);
          this.$router.push({name:'home'});
          }
        });
    },
    resetMovieForm () {
      this.newMovie = {};
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
