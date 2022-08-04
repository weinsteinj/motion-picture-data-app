<template>
  <body>
    <h1>{{headerText}}</h1>
    <div id="table-div">
     <table>
      <tr>
        <th>{{nameColHead}}</th>
        <th>{{descriptionColHead}}</th>
        <th>{{yearColHead}}</th>
        <th>{{actionsColHead}}</th>
      </tr>
      <tr v-for="m in movieArray" v-bind:key="m.id">
        <td>{{m.name}}</td>
        <td>{{m.description}}</td>
        <td>{{m.releaseYear}}</td>
        <td>
          <router-link v-bind:to="{name: 'edit', params: {id: m.id, name: m.name, description: m.description, releaseYear: m.releaseYear}}">
            <button v-on:click="loadEditForm">Edit</button>
          </router-link>
            
          <button>Copy</button>
          <button>Delete</button>
        </td>
      </tr>
     </table>
    </div>
  </body>
</template>

<script>
import axios from 'axios'

export default {
  name: 'test-view',
  data () {
    return {
      movie: null,
      movieArray: [],
      headerText: 'Welcome to Movie-Vue!',
      nameColHead: 'Name',
      descriptionColHead: 'Description',
      yearColHead: 'Release Year',
      actionsColHead: 'Actions',
    }
  },
  created () {
    axios.get('https://localhost:5001/movie/10')
      .then(response => (this.movie = response.data))
    axios.get('https://localhost:5001/movie/')
      .then(response => (this.movieArray = response.data))
  },

  methods: {
    loadEditForm () {
     // this.$router.push({name: "edit"}, params:})
        // to do --> load edit view

     },
  }
}

</script>

<style scoped>

h1 {
   text-align: center;
}
table {
    
    margin-left: auto;
    margin-right: auto;
}

table, th, td {
  border: 1px solid black;
}

tr {
    min-height: 50px;
}
#table-div {
    display: flex;
    flex-grow: 1;
    
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