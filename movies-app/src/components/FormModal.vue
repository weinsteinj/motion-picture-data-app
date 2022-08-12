<template>
  <div id="modal-background" class="modal-overlay">
        <form class="form-movie" v-on:submit.prevent="executeFormAction">
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
        <button class="btn-cancel" @click.prevent="$emit('closeModal')" @click="resetEditMode" type="cancel">Cancel</button>
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
  name: 'form-modal',
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
      // method to differentiate save/submit operation between Add adn Edit/Copy
    executeFormAction () {
      this.$store.state.inCreateMode ? this.postMovie() : this.updatedMovie();  
    }, 
      // if form data is validated, sends POST request to server (with back-up validation) to create a new movie record
    postMovie () {
      const movieBody = {name: this.$store.state.activeMovie.name, description: this.$store.state.activeMovie.description, 
        releaseYear: Number.parseInt(this.$store.state.activeMovie.releaseYear)};
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
             this.$router.push({name:'home'});
             this.resetMovieForm;
            }
          })
        }
       })
       .catch(() => {
         alert("Sorry. An error has occurred.")
       });
    },
    // if form data is validated, sends PUT request to server (with back-up validation) to perform update
    updateMovie () {
      const movieBody = {id: this.$store.state.activeMovie.id, name: this.$store.state.activeMovie.name, description: this.$store.state.activeMovie.description, 
        releaseYear: Number.parseInt(this.$store.state.activeMovie.releaseYear)};
      apiService.updateMovie(this.$store.state.activeMovie.id, movieBody)
      .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully edited!")
           this.resetMovieForm;
           let movieArray;
          movieArray = response.data;
          this.$store.commit('ADD__ALL_MOVIES', movieArray)
          this.$router.push({name:'home'});
          this.resetEditMode();
          }
        })
      .catch(() => {
         alert("Sorry. An error has occurred.")
       });
    },
    resetEditMode () {
         if(this.$store.state.inEditMode === true) {
        this.$store.commit('TOGGLE_EDIT_MODE')
        }
    },
    // resetMovieForm () {
    //   this.updatedMovie = {};
    // },
    confirmAndDelete () {
      if (
        confirm('Do you wish to delete this movie record? NB: This action cannot be undone.')
      ) {
      apiService.deleteMovie(this.$store.state.activeMovie.id)
      .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully deleted!")
         }
       })
       .catch(() => {
         alert("Sorry. An error has occurred.")
       });
    //   this.resetMovieForm;
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
  props: 
  ['activeMovie', 'activeMovieId'],
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
/* .modal {
    height: 70vh;
    width: 70vw;
    margin: 10% 10% 10% 10%;
    padding: 10px 10px 10px 10px;
    background-color: var(--main-background) ;
} */

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