import Vue from 'vue'
import App from './App.vue'
import $ from 'jquery';

import axios from 'axios'
import VueAxios from 'vue-axios'

import 'devextreme/dist/css/dx.light.css';
import Vuelidate from 'vuelidate'

import Enum from "./enums/TypeEnum.js"
import DropdownData from "./components/base/dropdown/DropdownData.js"

import {
  BaseTable,
  BasePagination
} from "./components/base/table";
import {
  BaseCombobox
} from "./components/base/combobox";
import {
  BaseDropdown
} from "./components/base/dropdown";
import {
  BaseInput
} from "./components/base/input";

Vue.component("base-table", BaseTable);
Vue.component("base-pagination", BasePagination);
Vue.component("combo-box", BaseCombobox);
Vue.component("base-dropdown", BaseDropdown);
Vue.component("base-input", BaseInput);

Vue.prototype.$api = axios;
Vue.prototype.$enum = Enum;
Vue.prototype.$dropdownData = DropdownData;

Vue.use(VueAxios, axios, $);
Vue.use(Vuelidate);
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')