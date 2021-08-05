<template>
  <div class="header">
    <div class="header__left">
      <div class="header__toggle"></div>
      <div class="header__logo"></div>
    </div>
    <div class="header__right ">
      <div class="header__title ">
        <div class="header-icon">MB</div>
        <base-dropdown
          :dropdown="this.$dropdownData.restaurantDropdown"
        />
      </div>
      <div class="header__user">
        <div class="header__user-avatar"></div>
        <div class="header__user-name mx-4">Phạm Hải Dương</div>
        <div class="header__user-option"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Header",
};
</script>
