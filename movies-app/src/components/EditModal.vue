<template>
  <div id="modal-background" class="modal-overlay">
        <form class="form-movie" v-on:submit.prevent="updateMovie">
            <h2>{{headerText}}</h2>
            <label  for="name">Name:</label><br>
                <input id="movie-name" type="text" placeholder="Name" v-model="$store.state.activeMovie.name" 
                value="Old Title" required maxlength="50" minlength="1" >
      
            <br>
            <label for="description">Description:</label><br>
             <textarea rows="10" cols="50" id="description-text" placeholder="Description" 
                 v-model="$store.state.activeMovie.description" maxlength="500"></textarea>
             <br>
             <br>
            <label for="releaseYear" >Release Year:</label><br>
            <input id="movie-year" type="number" placeholder="Release Year" v-model="$store.state.activeMovie.releaseYear" 
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
  name: 'edit-modal',
  data () {
    return {
      headerText: 'Please Edit the Movie Data Below',
    }
  },
    methods: {
    // if form data is validated, sends PUT request to server (with back-up validation)
    updateMovie () {
      const movieBody = {id: this.activeMovie.id, name: this.activeMovie.name, description: this.activeMovie.description, 
        releaseYear: Number.parseInt(this.activeMovie.releaseYear)};
      apiService.updateMovie(this.activeMovie.id, movieBody)
      .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully edited!")
           this.resetMovieForm;
           let movieArray;
          movieArray = response.data;
          this.$store.commit('ADD__ALL_MOVIES', movieArray)
          this.$router.go(0);
          }
        })
      .catch(() => {
         alert("Sorry. An error has occurred.")
       });
    },
    resetMovieForm () {
      this.activeMovie = {};
    },
    confirmAndDelete () {
      if (
        confirm('Do you wish to delete this movie record? NB: This action cannot be undone.')
      ) {
      apiService.deleteMovie(this.activeMovie.id)
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
          this.$router.go(0);
          }
        })
        .catch(() => {
         alert("Sorry. An error has occurred.")
       });
      }
    },
    cancelEdit () {
      this.$router.go(0);
    },
  },
    props: {
        activeMovie: {},
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