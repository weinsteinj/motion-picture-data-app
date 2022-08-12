<template>
  <div id="modal-background" class="modal-overlay">
        <form class="form-movie" v-on:submit.prevent="postMovie">
            <h2>{{headerText}}</h2>
            <label  for="name">Name:</label><br>
                <input id="movie-name" type="text" placeholder="Name" v-model="activeMovie.name" 
                value="Old Title" required maxlength="50" minlength="1" >
      
            <br>
            <label for="description">Description:</label><br>
             <textarea rows="10" cols="50" id="description-text" placeholder="Description" 
                 v-model="activeMovie.description" maxlength="500"></textarea>
             <br>
             <br>
            <label for="releaseYear" >Release Year:</label><br>
            <input id="movie-year" type="number" placeholder="Release Year" v-model="activeMovie.releaseYear" 
                required min=1800 max=2300 >
      
            <br>
            <br>
            <div id="action-button-area">
             <div></div>
        <div><button class="btn-save" type="submit">Save</button>
        <button class="btn-cancel" @click.prevent="cancelEdit" @click="resetEditMode" type="cancel">Cancel</button>
        <button class="btn-delete" v-if="$store.state.inEditMode" @click.prevent="confirmAndDelete" @click="resetEditMode" type="delete">Delete</button>
        </div>
        <div></div>
      </div>
    </form>
  </div>
</template>

<script>
import apiService from '@/service/apiService.js'

export default {
  name: 'add-modal',
  data () {
    return {
      activeMovie: {
        id: null,
        name: '',
        description: '',
        releaseYear: null,
      },
      headerText: 'Please Add to Movie-Vue!',
    
    }
  },
  methods: {
    // if form data is validated, sends POST request to server (with back-up validation)
    postMovie () {
      this.isInvalidYear = false;
      const movieBody = {name: this.activeMovie.name, description: this.activeMovie.description, releaseYear: Number.parseInt(this.activeMovie.releaseYear)};
      apiService.postNewMovie(movieBody)
      // api call returns promise; if status is OKAY, data received is used to mutate datastore before hiding form;
       .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully saved!");
          apiService.getAllMovies()
           .then(response => {
             if (response.status === 200) {
             let movieArray;
             movieArray = response.data;
             this.$store.commit('ADD__ALL_MOVIES', movieArray);
             this.$router.go(0);
             this.resetMovieForm;
            }
          })
        }
       })
       .catch(() => {
         alert("Sorry. An error has occurred.")
       });
    },
    resetMovieForm () {
      this.activeMovie = {};
    },
    cancelEdit () {
      this.$router.go(0);
    },
  },
}

</script>

<style scoped>
.modal-overlay {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    display: flex;
    justify-content: center;
    background-color: #B5E48Cda;
}
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