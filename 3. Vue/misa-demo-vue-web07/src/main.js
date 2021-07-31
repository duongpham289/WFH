import Vue from 'vue'
import App from './App.vue'
import $ from 'jquery';

import axios from 'axios'
import VueAxios from 'vue-axios'

import Vuelidate from 'vuelidate'

import {
  BaseTable,
} from "./components/base/table";

Vue.component("base-table", BaseTable);

Vue.use(VueAxios, axios,$);
Vue.use(Vuelidate);
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
