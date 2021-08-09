<template>
  <div class="dropdown" @blur="open = false">
    <button
      class="dropdown__button"
      @click="open = !open"
      :class="open ? 'border-active' : ''"
    >
      <span class="dropdown__title" :value="selector.value">{{
        selector.name ? selector.name : dropdownName
      }}</span>
      <i class="fas fa-chevron-down" :class="open ? 'rotate-180' : ''"></i>
    </button>
    <div class="dropdown__content" v-show="open">
      <div
        v-for="item in options"
        :key="item[select.value]"
        class="dropdown__option"
        :value="item[select.value]"
        @click="selected(item)"
        :class="selector.value == item[select.value] ? 'active' : ''"
      >
        <span
          class="icon"
          :class="selector.value == item[select.value] ? '--block' : ''"
        >
          <i class="fas fa-check"></i>
        </span>
        <span class="text">{{ item[select.name] }}</span>
      </div>
    </div>
  </div>
</template>

<script>

import DropdownData from "./DropdownData.js"

export default {
  mounted() {

    document.addEventListener("click", this.close);
  },
  props: {
    dropdown: {
      type: String,
      required: true,
      default: null,
    },
    defaultState: {
      type: Boolean,
      required: true,
      default: null,
    },
  },
  methods: {
    /**
     * Bắt sự kiện click ra ngoài dropdown
     * Author: PHDUONG(3/8/2021)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        this.open = false;
      }
    },
    /**
     * Băt sự kiện click option item
     * Author: PHDUONG(3/8/2021)
     */
    selected(value) {
      if (this.options && this.select) {
        let optionItem = this.options.find((item) => {
          if (item[this.select.value] == value[this.select.value]) {
            return item;
          }
        });
        if (optionItem) {
          this.selector = {
            name: optionItem[this.select.name],
            value: optionItem[this.select.value],
          };
          this.$emit("selected", this.selector.value, this.selector.name);
        }
        this.open = false;
      }
    },
  },
  data() {
    return {
      open: false,
      select: null,
      options: null,
      dropdownName: null,
      dropdownData: DropdownData,
      selector: {
        name: "",
        value: "",
      },
    };
  },

  watch: {
    defaultState: function () {
      if (this.defaultState) {
        switch (this.dropdown) {
          case this.$enum.GENDER:
            this.dropdownName = "Giới tính";
            this.selector = { name: "", value: "" };
            break;
          case this.$enum.WORKSTATUS:
            this.dropdownName = "Tình trạng công việc";
            this.selector = { name: "", value: "" };
            break;
          case this.$enum.DEPARTMENT:
            // debugger
            this.dropdownName = "Phòng ban";
            this.selector = { name: "", value: "" };
            break;
          case this.$enum.POSITION:
            // debugger
            this.dropdownName = "Vị trí";
            this.selector = { name: "", value: "" };
            break;
        }
      }
    },
    dropdown: {
      immediate: true,
      handler() {
        switch (this.dropdown) {
          case this.$enum.RESTAURANT:
            // debugger
            this.options = DropdownData.restaurant.options;
            this.select = DropdownData.restaurant.select;
            this.dropdownName = "Nhà Hàng Biển Đông";
            break;
          case this.$enum.GENDER:
            this.options = DropdownData.gender.options;
            this.select = DropdownData.gender.select;
            this.dropdownName = "Giới tính";
            break;
          case this.$enum.WORKSTATUS:
            this.options = DropdownData.workStatus.options;
            this.select = DropdownData.workStatus.select;
            this.dropdownName = "Tình trạng công việc";
            break;


          default:
            break;
        }
      },
    },
    dropdownData: {
      deep: true,
      handler() {
        switch (this.dropdown) {
          case this.$enum.DEPARTMENT:
            this.options = DropdownData.department.options;
            this.select = DropdownData.department.select;
            this.dropdownName = "Phòng ban";
            break;
          case this.$enum.POSITION:
            this.options = DropdownData.position.options;
            this.select = DropdownData.position.select;
            this.dropdownName = "Vị trí";
            break;

          default:
            break;
        }
      },
    },
  },
  beforeDestroy() {
    document.removeEventListener("click", this.close);
  },
}
</script>