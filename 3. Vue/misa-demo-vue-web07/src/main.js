import Vue from 'vue'
import App from './App.vue'
import $ from 'jquery';

import axios from 'axios'
import VueAxios from 'vue-axios'

import Vuelidate from 'vuelidate'

Vue.use(VueAxios, axios, Vuelidate,$)
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
