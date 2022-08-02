<template>
  <body>
        <h1>{{headerText}}</h1>
    <table>
      <tr>
        <th>{{titleColHead}}</th>
        <th>{{descriptionColHead}}</th>
        <th>{{yearColHead}}</th>
        <th>{{actionsColHead}}</th>
      </tr>
      <tr v-for="m in movieArray" v-bind:key="m.id">
        <td>{{m.name}}</td>
        <td>{{m.description}}</td>
        <td>{{m.releaseYear}}</td>
        <td></td>
      </tr>
    </table>
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
      titleColHead: 'Title',
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
  }
}

</script>

<style>
h1 {
   text-align: center;
}
table {
    
    margin-left: auto;
    margin-right: auto;
}
</style>