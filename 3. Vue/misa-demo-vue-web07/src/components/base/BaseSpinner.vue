<template>
  <div class="spinner__container" v-show="loading">
    <div class="spinner">
      <div class="spinner__icon">
        <pacman-loader :loading="loading" color="#01B075"></pacman-loader>
      </div>

      <div class="spinner__text">Đang tải dữ liệu...</div>
    </div>
  </div>
</template>

<script>
import PacmanLoader from "vue-spinner/src/PacmanLoader.vue";

export default {
  components: { PacmanLoader },
  props: {
    loading: {
      type: Boolean,
    },
  },
};
</script>
<style lang="css">
.spinner__container {
  position: fixed;
  width: 100%;
  height: 100%;
  left: 0;
  top: 0;
  z-index: 99999;
  background-color: rgba(0, 0, 0, 0.2);
}

.spinner {
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
}

.spinner__icon {
  display: flex;
  justify-content: center;
  padding-right: 50px;
}
.spinner__text {
  display: flex;
  justify-content: center;
  padding: 10px 0 0 0;
  font-size: 20px;
  color: #454545;
}
</style>