<template>
  <div>
    <h1>{{headerText}}</h1>
    <edit-movie></edit-movie>
  </div>
</template>

<script>
// @ is an alias to /src
import EditMovie from '@/components/EditMovie.vue'

export default {
  name: 'edit-view',
  data () {
    return {
      headerText: ''
    }
  },
  components: {
    EditMovie,
  }
}
</script>
