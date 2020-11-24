<template>
  <div id="app">
    <div id="topPane">
      <header-nav/>
    </div>
    <div id="bodyContent">
      <super-bowl v-show="articleToShow == 0"/>
      <aquarium v-show="articleToShow == 1"/>
      <live-longer v-show="articleToShow == 2"/>
    </div>
    <div id="bottomPane">
      <footer-nav/>
    </div>
  </div>
</template>

<script>
import HeaderNav from '@/components/HeaderNav'
import FooterNav from '@/components/FooterNav'
import SuperBowl from '@/components/SuperBowl'
import Aquarium from '@/components/Aquarium'
import LiveLonger from '@/components/LiveLonger'

export default {
  name: 'App',
  components: {
    HeaderNav,
    FooterNav,
    SuperBowl,
    Aquarium,
    LiveLonger
  },
  data() {
    return {
      articleToShow: 0
    }
  }
}
</script>

    
<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
