<template>
  <div class="combobox">
    <input type="text" class="combobox__input" placeholder="Tất cả phòng ban" />
    <button class="combobox__button">
      <i class="fas fa-chevron-down icon" :class="open? 'rotate-180':''"></i>
    </button>
    <div class="combobox__data department-name" value="0">
      <div class="combobox__item" value="0">
        <span class="icon"> <i class="fas fa-check"></i></span>Tất cả Phòng ban
      </div>
    </div>
  </div>
</template>