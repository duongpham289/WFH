<template>
    <div class="page">
        <EmployeeList/>
    </div>
</template>


<script>
// import axios from "axios";
import EmployeeList from '../../view/employee/EmployeeList.vue'
// import VueAxios from 'vue-axios'

export default {
  name: "Content",
  components: {EmployeeList},
  
};
</script>