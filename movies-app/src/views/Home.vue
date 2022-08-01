<template>
  <div class="home">
    <motion-pictures>
      <table>
        <thead></thead>
        <thead></thead>
        <thead></thead>
        <thead></thead>
        <tr v-for="movie in movies" v-bind:key="movie.id"></tr>
      </table>
    </motion-pictures>
  </div>
</template>

<script>
// @ is an alias to /src
import MotionPictures from '@/components/MotionPictures.vue'

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
    MotionPictures
  }
}
</script>
