import Vue from 'vue'
import App from './App.vue'
import $ from 'jquery';

import axios from 'axios'
import VueAxios from 'vue-axios'

import 'devextreme/dist/css/dx.light.css';
import Vuelidate from 'vuelidate'

import {
  BaseTable,
} from "./components/base/table";
import { BaseCombobox } from "./components/base/combobox";

Vue.component("base-table", BaseTable);
Vue.component("combo-box", BaseCombobox);

Vue.prototype.$api = axios;

Vue.use(VueAxios, axios, $);
Vue.use(Vuelidate);
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')