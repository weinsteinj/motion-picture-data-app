<template>
  <body>
    <div id="main-bar">
      <div></div>
      <h1>{{headerText}}</h1>
      <div> <button class="btn" @click="showAddForm"><em>Add </em> <i class="fa fa-plus"></i></button> </div>
    </div>
    <add-modal v-show="inAddMode"></add-modal>
    <copy-modal v-show="inCopyMode"></copy-modal>
    <edit-modal v-show="inEditMode" v-bind:activeMovie="activeMovie"></edit-modal>
    <div id="table-div">
     <table>
      <tr>
        <th @click="sortMoviesByName">{{nameColHead}}</th>
        <th @click="sortMoviesByDescription">{{descriptionColHead}}</th>
        <th @click="sortMoviesByYear">{{yearColHead}}</th>
        <th>{{actionsColHead}}</th>
      </tr>
      <tr v-for="m in $store.state.movies" v-bind:key="m.id" v-bind:activeMovieId="m.id">
        <td>{{m.name}}</td>
        <td>{{m.description}}</td>
        <td>{{m.releaseYear}}</td>
        <td>
        
          <button class="btn btn-edit" @click.prevent="showEditForm(m.id)"> <i class="fa fa-edit"></i> </button>
         
          <button class="btn btn-copy" @click="showCopyForm(m.id)"> <i class="fa fa-copy"></i> </button>
         
          <button class="btn btn-delete" @click="confirmAndDelete(m.id)" type="delete"><button> <i class="fa fa-trash"></i> </button></button>
        </td>
      </tr>
     </table>
    </div>
     <footer-cog></footer-cog>
  </body>
  
</template>

<script>
import FooterCog from '@/components/FooterCog.vue'
import apiService from '@/service/apiService.js'
import AddModal from '@/components/AddModal.vue'
import EditModal from '@/components/EditModal.vue'
import CopyModal from '@/components/CopyModal.vue'

export default {
  name: 'movie-table-modal',
  components: {
    FooterCog,
    AddModal,
    EditModal,
    CopyModal,
  },
  data () {
    return {
      activeMovie: null,  
      movie: null,
      movieArray: [],
      headerText: ' Welcome to Movie-Vue! ',
      nameColHead: 'Name',
      descriptionColHead: 'Description',
      yearColHead: 'Release Year',
      actionsColHead: 'Actions',
      ascendingSortName: true,
      ascendingSortDescription: true,
      ascendingSortYear: true,
      editMode: false,
      inAddMode: false,
      inCopyMode: false,
      inEditMode: false,
    }
  },
  computed: {
    moviesSortedByName() {
      return this.sortMoviesByName(this.movieArray);
    }
  },
  created () {
    apiService.getAllMovies()
        .then(response => {
          this.movieArray = response.data;
          this.$store.commit('ADD__ALL_MOVIES', this.movieArray)
        }) 
  },

  methods: {
    activateEditMode(id) {
        if(this.$store.state.inEditMode === false) {
        this.$store.commit('TOGGLE_EDIT_MODE')
        }
        this.setActiveMovie(id);
    },
    confirmAndDelete (id) {
      if (
        confirm('Do you wish to delete this movie record? NB: This action cannot be undone.')
      ) {
      apiService.deleteMovie(id)
      .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully deleted!");
           apiService.getAllMovies()
            .then(response => {
            if (response.status === 200) {
            this.movieArray = response.data;
            this.$store.commit('ADD__ALL_MOVIES', this.movieArray);
            this.$router.go(0);
          }
        });
         }
       })
       .catch(() => {
         alert("Sorry. An error has occurred.")
       });
      }
    },
    loadAddMovie () {
        this.activeMovie = {};
        this.$store.commit('SET_ACTIVE_MOVIE', this.activeMovie);
        if(this.$store.state.inCreateMode === false) {
        this.$store.commit('TOGGLE_CREATE_MODE')
        }
        this.showModalToggle();
    },
    setActiveMovie (id) {
        this.activeMovie = this.movieArray.find((movie) => movie.id === id);
        this.$store.commit('SET_ACTIVE_MOVIE', this.activeMovie);
    },
    showAddForm() {
        this.activeMovie = {};
        this.$store.commit('SET_ACTIVE_MOVIE', this.activeMovie);
        this.inAddMode = true;
    },
    showCopyForm(id){
        this.setActiveMovie(id)
        this.inCopyMode = true;
    },
    showEditForm(id){
      this.setActiveMovie(id);
      this.inEditMode = true;
    },
    // sort methods for each v-on:click at column heads, with toggle via boolean ascendingSort asc/desc
    sortMoviesByName () {
      if (this.ascendingSortName === true) {
        this.movieArray.sort((a,b) => a.name.localeCompare(b.name));
        this.ascendingSortName = false;
        } 
      else {
        this.movieArray.sort((a,b) => b.name.localeCompare(a.name));
        this.ascendingSortName = true;
        }
      },
    sortMoviesByDescription () {
      if (this.ascendingSortDescription === true)  {
      this.movieArray.sort((a,b) => a.description.localeCompare(b.description));
      this.ascendingSortDescription = false;
      } else {
        this.movieArray.sort((a,b) => b.description.localeCompare(a.description));
        this.ascendingSortDescription = true;
      }
    },
    sortMoviesByYear () {
      if (this.ascendingSortYear === true) {
      this.movieArray.sort((a,b) => a.releaseYear-b.releaseYear);
      this.ascendingSortYear = false;
      } else {
      this.movieArray.sort((a,b) => b.releaseYear-a.releaseYear);
      this.ascendingSortYear = true;
      }
    },
  },
}
</script>

<style scoped>
#main-bar {
  display: flex;
}
#main-bar h1 {
  flex-basis: 60;
}
#main-bar div {
 justify-content: right;
}
body {
  background-color: var(--main-background);
}
h1 {
   text-align: center;
   box-shadow: 15px 15px 50px rgba(0, 0, 0, 0.20);
   border-radius: 8px;  
}
table {
    margin-left: auto;
    margin-right: auto;
    border-radius: 8px;
    box-shadow: 30px 30px 10px rgba(0, 0, 0, 0.30);
    font-size: 1em;
}
table, th, td {
  border: 3px solid rgba(18, 118, 148, 0.315);
}
th {
  padding: 10px;
}
td {
  padding: 10px;
  text-align: left;
}
td:nth-child(3) {
  text-align: center;
}
tr {
    min-height: 50px;
}
#table-div {
    display: flex;
}
.btn {
    background-color: lightgreen;
    color: light green;
    border-color: midnightblue;
    border-radius: 8px;
    box-shadow: 0 5px 5px rgba(0, 0, 0, 0.18);
    font-size: 1.25em;
}
.btn-delete {
  background-color: lightcoral;
}
.btn-copy {
  background-color: skyblue;
}
.btn-edit {
  background-color: greenyellow;
}
tr:nth-child(even) {
  background-color: rgba(0, 0, 0, 0.123);
}
.fa-trash-can {
  background-color: lightcoral;
  padding: 0px;
}
</style>