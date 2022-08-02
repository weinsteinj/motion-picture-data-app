<template>
<div></div>
</template>

<script>

import axios from 'axios'

export default {
  name: 'test-view',
  data () {
    return {
      movie: null,
      movieArray: []
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

<style scoped>

</style>
