<template>
  <div class="toast-message" :style="`top:${80 + index * 49}px`">
    <div class="toast-message__icon" :class="style.color">
      <i :class="style.icon"></i>
    </div>
    <div class="toast-message__text">{{ message }}</div>
    <div
      class="toast-message__close"
      @click="this.$emit('close')"
      :class="style.color"
    >
      <i class="fas fa-times"></i>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    type: {
      type: String,
      required: true,
    },
    message: {
      type: String,
      required: true,
    },
    index: {
      type: Number,
      required: true,
    },
  },
  emits: ["close"],
  mounted() {
    setTimeout(() => {
      this.$emit("close");
    }, 3000);
  },
  data() {
    return {
      style: {
        icon: "fas fa-check-circle",
        color: "toast-success",
      },
      toastState: [
        {
          fail: ["toast-fail", "fas fa-exclamation-triangle"],
        },
        {
          warning: ["toast-warning"],
        },
        {
          info: ["toast-info"],
        },
        {
          success: ["toast-success", "fas fa-check-circle"],
        },
      ],
    };
  },
  methods: {
    validateState() {},
  },
  watch: {
    type: {
      immediate: true,
      handler(newVal) {
        if (newVal === "success") {
          this.style.icon = "fas fa-check-circle";
          this.style.color = "toast-success";
        }

        if (newVal === "fail") {
          this.style.icon = "fas fa-exclamation-triangle";
          this.style.color = "toast-fail";
        }
      },
    },
    // toastMessageState: function () {
    //   switch (this.toastMessageState) {
    //     case 1:
    //       this.textToastMessage = this.erorMsg;
    //       break;
    //     case 2:
    //       this.textToastMessage = "Dữ liệu đã tải thành công";
    //       break;
    //     case 3:
    //       this.textToastMessage = "Thêm mới thành công";
    //       break;
    //     case 4:
    //       this.textToastMessage = "Sửa thành công";
    //       break;
    //     case 5:
    //       this.textToastMessage = "Xóa thành công";
    //       break;
    //     case 6:
    //       this.textToastMessage = "Không có dữ liệu";
    //       break;
    //     default:
    //       break;
    //   }
    // },
    // isShowToast: function () {
    //   return this.isShowToast;
    // },
  },
};
</script>