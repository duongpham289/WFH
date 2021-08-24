<template>
  <div class="popup__container" :class="{ '--hidden': isHidden }">
    <div class="popup">
      <div class="popup__btn-close">
        <button
          class="button--secondary button__close"
          @click="btnCancelOnClick"
        ></button>
      </div>

      <div class="popup__title">Xóa bản ghi</div>
      <div class="popup__body">
        <div class="popup__icon">
          <i class="fas fa-exclamation-triangle"></i>
        </div>
        <div class="popup__content" v-if="datasToDelete.length > 1">
          Bạn có chắc muốn xóa các nhân viên này không?
        </div>
        <div class="popup__content" v-if="datasToDelete.length == 1">
          Bạn có chắc chắn muốn xóa nhân viên có mã
          {{ this.datasToDelete[0].code }} không?
        </div>
      </div>
      <div class="popup__footer">
        <div
          class="button--secondary popup__button-cancel"
          @click="btnCancelOnClick"
        >
          Hủy
        </div>
        <div
          class="button--primary popup__button-del"
          @click="btnDelDataOnClick"
        >
          Xóa
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import EmployeesAPI from "@/api/components/EmployeesAPI.js";
// const $ = require("jquery");

export default {
  props: {
    isHidden: {
      type: Boolean,
      default: true,
      required: true,
    },
    datasToDelete: {
      type: Array,
      required: true,
    },
  },
  data() {
    return {
      // listId:[]
    };
  },
  methods: {
    /**
     * Hàm đóng popup message
     * Author: PHDUONG(31/07/2021)
     */
    btnCancelOnClick() {
      // $(".checkbox").prop("checked", false);
      this.$emit("btnDelOnClick", true);
    },
    /**
     * Hàm xóa employees
     * Author: PHDUONG(31/07/2021)
     */
    btnDelDataOnClick() {
      var listId = [];
      var vm = this;
      vm.datasToDelete.forEach((data) => {
        listId.push(data.id);
      });

      EmployeesAPI.delete(listId)
        .then((res) => {

          vm.$emit("btnDelOnClick", true);
          vm.$emit("btnReloadOnClick");

          vm.$emit("responseHandler", 5, res)
          
        })
        .catch((err) => {
          vm.$emit("responseHandler", 1, err)
        });
    },
  },
};
</script>