<template>
  <div class="home">
    <motion-pictures>
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
