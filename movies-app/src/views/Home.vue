<template>
  <div class="home">
    <movie-table></movie-table>
  </div>
</template>

<script>
// @ is an alias to /src
import MovieTable from '@/components/MovieTable.vue'

export default {
  name: 'Home',
  data () {
    return {
      newMovie: {
        title: '',
        description: '',
        year: null
      }
    }
  },
  components: {
    MovieTable
  }
}
</script>
