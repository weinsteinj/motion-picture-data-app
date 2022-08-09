<template>
  <body>
    <div id="main-bar">
      <div></div>
      <h1>{{headerText}}</h1>
      <div> <router-link to="/add" class="btn">Add +</router-link> </div>
    </div>
    
    <div id="table-div">
     <table>
      <tr>
        <th>{{nameColHead}}</th>
        <th>{{descriptionColHead}}</th>
        <th>{{yearColHead}}</th>
        <th>{{actionsColHead}}</th>
      </tr>
      <tr v-for="m in $store.state.movies" v-bind:key="m.id">
        <td>{{m.name}}</td>
        <td>{{m.description}}</td>
        <td>{{m.releaseYear}}</td>
        <td>
          <router-link v-bind:to="{name: 'edit', params: {id: m.id, name: m.name, description: m.description, releaseYear: m.releaseYear}}">
            <button class="btn btn-edit"> Edit </button>
          </router-link>
          <router-link v-bind:to="{name: 'copy', params: {id: m.id, name: m.name, description: m.description, releaseYear: m.releaseYear}}">  
          <button class="btn btn-copy"> Copy </button>
          </router-link>
          <button class="btn btn-delete" v-on:click.prevent="confirmAndDelete(m.id)" type="delete">Delete</button>
          <!-- <button v-bind:key="m.id" v-on:click.prevent="confirmAndDelete(m.id)" type="delete">Delete</button> -->
           <!-- <button>Delete</button> -->
        </td>
      </tr>
     </table>
    </div>
     <footer-cog></footer-cog>
  </body>
  
</template>

<script>
// import axios from 'axios'
import FooterCog from '@/components/FooterCog.vue'
import apiService from '@/service/apiService.js'

export default {
  name: 'movie-table',
  components: {
    FooterCog,
  },
  data () {
    return {
      movie: null,
      movieArray: [],
      headerText: 'Welcome to Movie-Vue!',
      nameColHead: 'Name',
      descriptionColHead: 'Description',
      yearColHead: 'Release Year',
      actionsColHead: 'Actions',
      movieInfoToCopy: '',
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
    copyMovie (id) {
      let movieToCopy;
      apiService.getMovie(id)
       .then(response => {
         if (response.status === 200) { 
            movieToCopy = response.data;
            this.movieToCopy = movieToCopy;
            } 
       }); 
    },
    confirmAndDelete (id) {
      if (
        confirm('Do you wish to delete this movie record? NB: This action cannot be undone.')
      ) {
      apiService.deleteMovie(id)
      .then(response => {
         if (response.status === 200) {
           alert("Movie record successfully deleted!")
         }
       });
      apiService.getAllMovies()
        .then(response => {
          if (response.status === 200) {
          this.movieArray = response.data;
          this.$store.commit('ADD__ALL_MOVIES', this.movieArray);
          }
        });
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
  background-color: ivory;
}

h1 {
   text-align: center;
}
table {
    
    margin-left: auto;
    margin-right: auto;
}

table, th, td {
  border: 3px solid rgba(15, 25, 70, 0.616);
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

/* td {
    margin-left: 10 px;
    margin-right: 10px;
}
thead {
    font-size: 50pt;
    min-width: 20%;
    margin-left: 50px;
    margin-right: 50px;
} */
</style>