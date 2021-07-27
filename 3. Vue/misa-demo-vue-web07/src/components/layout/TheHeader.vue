<template>
  <div class="header">
    <div class="header--left">
      <div class="header__toggle"></div>
      <div class="header__logo"></div>
    </div>
    <div class="header--right">
      <div class="header__title">
        <div class="header-icon">MB</div>
        <div class="dropdown" id="dropdown__restaurant">
          <button class="dropdown__button">
            <span class="dropdown__title">Nhà Hàng Biển Đông</span>
            <i class="fas fa-chevron-down"></i>
          </button>
          <div class="dropdown__content dropdown__content--hidden">
            <a href="#" class="dropdown__link--active"
              ><i class="fas fa-check"></i>Nhà hàng Biển Đông</a
            >
            <a href="#"><i class="fas fa-check"></i>Nhà hàng Biển Đông</a>
          </div>
        </div>
      </div>
      <div class="header__user">
        <div class="header__user-avatar"></div>
        <div class="header__user-name">Phạm Hải Dương</div>
        <div class="header__user-option"></div>
      </div>
    </div>
  </div>
</template>

<script>
 export default {
  name: 'Header'
}
</script>

<style scoped>
    @import url("../../css/common/layouts/Header.css");
</style>