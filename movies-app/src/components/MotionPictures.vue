<template>
  <div>
    <h1>{{ headerText }}</h1>
    <v-table :data="movies">
      <thead slot="head">
          <th>{{titleColHead}}</th>
          <th>{{descriptionColHead}}</th>
          <th>{{yearColHead}}</th>
          <th>{{actionsColHead}}</th>
      </thead>
      <tbody slot="body" slot-scope="{movies}">
        <tr v-for="(movie, index) in movies" v-bind:key="index"></tr>
      </tbody>
    </v-table><button v-on:click:="loadOneMovie">Click for One Movie</button>
  </div>
</template>

<script>
import apiService from '../service/apiService'

export default {
  name: 'motion-pictures',
  computed: {
  },
  created () {
    // this.$store.commit('ADD_ALL_MOVIES')
  },
  data () {
    return {
      headerText: 'Welcome Movie-Vue!',
      titleColHead: 'Title',
      descriptionColHead: 'Description',
      yearColHead: 'Release Year',
      actionsColHead: 'Actions',
      oneMovie: {
        id: 100,
        title: '',
        description: '',
        releaseYear: ''
      }

    }
  },
  methods: {
    loadOneMovie () {
      apiService.getMovie(2).then((response) => {
        this.oneMovie = response.data
      })
    }
  },
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
thead {
  position: sticky;
}

table {
  /* display: grid;
  grid-template-columns: 1fr 3fr 1fr 1fr;
  grid-template-areas: "title-head description-head year-head actions-head"
                        "";
  width: 80%; */
}
tr {
  width: 100%
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
</style>
