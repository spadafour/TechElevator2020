<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png" />
    <product-review v-bind:name="productName"></product-review>
  </div>
</template>

<script>
import ProductReview from "./components/ProductReview.vue";

export default {
  name: "app",
  components: {
    ProductReview
  },
  data(){
    return {
      productName: 'Rum Parties for Dummies'
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  max-width: 800px;
  margin: 60px auto 0 auto;
}
</style>
