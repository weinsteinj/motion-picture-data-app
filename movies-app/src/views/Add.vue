<template>
  <div>
    <h1>{{headerText}}</h1>
    <add-movie></add-movie>
  </div>
</template>

<script>
// @ is an alias to /src
import AddMovie from '@/components/AddMovie.vue'

export default {
  name: 'add-view',
  data () {
    return {
      headerText: ''
    }
  },
  components: {
    AddMovie,
  }
}
</script>
