<template>
  <div>
    <h1>{{headerText}}</h1>
    <copy-movie></copy-movie>
  </div>
</template>

<script>
import CopyMovie from '@/components/CopyMovie.vue'

export default {
    name: 'copy-view',
    data () {
    return {
      headerText: ''
    }
  },
    components: {
        CopyMovie,
    },
    

}
</script>

<style>

</style>