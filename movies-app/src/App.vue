<template>
  <div id="app">
    <div id="nav">
      <!-- <router-link to="/">Motion Picture Data Manager</router-link> |
      <router-link to="/add">Add</router-link>  -->
      <!-- | <router-link to="/test">Test Here!</router-link>
      <router-link to="/table">Data Table!</router-link> -->
    </div>
    <router-view/>
  </div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

#app, nav, div, h1  {
  background-color: var(--main-background);
}

h1 {
  padding-bottom: 0%;
  margin-bottom: 0%;
}
#app {
  padding: 0;
  margin: 0;
  width: 100%;
  min-height: 100vh; 
}

</style>
