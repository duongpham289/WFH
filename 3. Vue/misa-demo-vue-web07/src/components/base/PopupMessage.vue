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
          @click="btnDeleteEmployeeOnClick"
        >
          Xóa
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: {
    isHidden: {
      type: Boolean,
      default: true,
      required: true,
    },
    employeesToDelete: {
      type: Array,
      required: true,
    },
  },
  methods: {
    btnCancelOnClick() {
      this.$emit("btnDelOnClick", true);
    },
    btnDeleteEmployeeOnClick() {
      this.employeesToDelete.forEach((employee) => {
        try {
          axios
            .delete(`http://cukcuk.manhnv.net/v1/Employees/${employee}`)
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
    this.$emit("btnDelOnClick", true);
    },
  },
};
</script>