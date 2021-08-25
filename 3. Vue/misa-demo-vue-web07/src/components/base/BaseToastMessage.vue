<template>
  <div class="toast-message" v-if="isShowToast">
    <div
      class="toast-message__icon"
      :class="toastMessageState == 1 ? 'toast-warning' : 'toast-success'"
    >
      <i :class="toastMessageState == 1 ?'fas fa-exclamation-triangle':'fas fa-check-circle'" ></i>
    </div>
    <div class="toast-message__text">{{ textToastMessage }}</div>
    <div
      class="toast-message__close"
      :class="toastMessageState == 1 ? 'toast-warning' : 'toast-success'"
    >
      <i class="fas fa-times"></i>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    isShowToast: {
      type: Boolean,
      required: true,
    },
    toastMessageState: {
      type: Number,
      required: true,
    },
    erorMsg: {
      type: String,
    },
  },
  data() {
    return {
      textToastMessage: "", // 1 - thành công, 2 - thông báo, 3 - cảnh báo, 4 - lỗi
    };
  },
  methods: {
    validateState() {},
  },
  watch: {
    toastMessageState: function () {
      switch (this.toastMessageState) {
        case 1:
          this.textToastMessage = this.erorMsg;
          break;
        case 2:
          this.textToastMessage = "Dữ liệu đã tải thành công";
          break;
        case 3:
          this.textToastMessage = "Thêm mới thành công";
          break;
        case 4:
          this.textToastMessage = "Sửa thành công";
          break;
        case 5:
          this.textToastMessage = "Xóa thành công";
          break;

        default:
          break;
      }
    },
    isShowToast: function () {
      return this.isShowToast;
    },
  },
};
</script>