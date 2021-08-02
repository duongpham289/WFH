<template>
  <div id="app">
   <Header />
   <Menu />
   <Content />
  </div>
</template>

<script>
import Header from './components/layout/TheHeader.vue'
import Menu from './components/layout/TheMenu.vue'
import Content from './components/layout/TheContent.vue'




export default {
  name: 'App',
  components: {
    Header,Menu,Content

  }
}
</script>

<style>
  @import url('./assets/css/common/Style.css');
  @import url('./assets/font/fontawesome-5.15.1/css/all.min.css');
</style>
