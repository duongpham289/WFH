<template>
  <div class="popup__container" :class="{ '--hidden': isHidden }">
    <div class="popup">
      <div class="popup__btn-close">
        <!-- <img
          src="../../assets/icon/x.svg"
          alt="close button"
          class="popup__button-close"
        /> -->
        <button
          class="button--secondary button__close"
          @click="btnCancelOnClick"
        ></button>
        <!-- <div class="popup__button-close"></div> -->
      </div>

      <div class="popup__title">Xóa bản ghi</div>
      <div class="popup__body">
        <div class="popup__icon">
          <i class="fas fa-exclamation-triangle"></i>
        </div>
        <div class="popup__content">
          Bạn có chắc muốn xóa (các) nhân viên này hay không?
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
import axios from "axios";
const $ = require("jquery");

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
  methods: {
    /**
     * Hàm đóng popup message
     * Author: PHDUONG(31/07/2021)
     */
    btnCancelOnClick() {
      this.$emit("btnDelOnClick", true);
    },
    /**
     * Hàm xóa employees
     * Author: PHDUONG(31/07/2021)
     */
    btnDelDataOnClick() {
      this.datasToDelete.forEach((data) => {
        try {
          axios
            .delete(`http://cukcuk.manhnv.net/v1/Employees/${data}`)
            .then(() => {
              console.log("Xóa thành công");
            })
            .catch((res) => {
              console.log(res);
            });
        } catch (error) {
          console.log(error);
        }
      });

      $(".delete-box input").each(function () {
        this.checked = false;
      });
      this.$emit("btnDelOnClick", true);
    },
  },
};
</script>