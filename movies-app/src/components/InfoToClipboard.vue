<template>
  <div>
    <h2>Please click below to copy the information for your selected movie to your clipboard.</h2>
    <div id="movie-copy">
          <textarea rows="5" cols="50"
            v-on:focus="$event.target.select()"
            ref="clone"
            readonly
            v-bind:value="movieInfo"/>
          <button v-on:click="copy"> Copy </button>        
    </div>
  </div>
</template>

<script>
export default {
    created () {
    },
    data() {
      return{
        movieInfo:  `Title: ${this.$route.params.name},  Description: ${this.$route.params.description},  Release Year: ${this.$route.params.releaseYear}.`
        }
    },
    methods: {
        copy() {
            this.$refs.clone.focus();
            document.execCommand('copy');
            alert('Your movie information has been successfully copied to the system clipboard!');
            this.$router.push({name: 'home'});
        }
    },
};
</script>

<style>
#movie-copy {
    margin: auto;
    width: 60%;
    background-color: lightgreen;
    color: light green;
    border-color: midnightblue;
    border-radius: 8px;
    box-shadow: 0 5px 5px rgba(0, 0, 0, 0.18);
    font-size: 1.25em;
}
</style>