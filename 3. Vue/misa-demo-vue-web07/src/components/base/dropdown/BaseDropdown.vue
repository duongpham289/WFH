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
          :class="selector.value == item[select.value] ? '--show' : ''"
        >
          <i class="fas fa-check"></i>
        </span>
        <span class="text">{{ item[select.name] }}</span>
      </div>
    </div>
  </div>
</template>

<script>

import PositionAPI from "@/api/components/PositionAPI.js";
import DepartmentAPI from "@/api/components/DepartmentAPI.js";

export default {
  mounted() {
    

    PositionAPI.getAll()
      .then((res) => {
        this.$dropdownData.position.data = res.data;
      })
      .catch((err) => {
        console.log(err);
      });

    DepartmentAPI.getAll()
      .then((res) => {
        this.$dropdownData.department.data = res.data;
      })
      .catch((err) => {
        console.log(err);
      });

    document.addEventListener("click", this.close);
  },
  props: {
    optionDefault: {
      type: Object,
      default: () => {},
    },
    tabindex: {
      type: Number,
    },
    dropdown: {
      type: String,
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
          this.$emit("selected", this.selector.value,this.selector.name);
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
      data: this.$dropdownData,
      selector: {
        name: "",
        value: "",
      },
    };
  },

  watch: {
    dropdown: {
      immediate: true,
      handler() {
        switch (this.dropdown) {
          case this.$dropdownData.restaurantDropdown:
            this.options = this.$dropdownData.restaurant.data;
            this.select = this.$dropdownData.restaurant.select;
            this.dropdownName = "Nhà Hàng Biển Đông";
            break;
          case this.$dropdownData.genderDropdown:
            this.options = this.$dropdownData.gender.data;
            this.select = this.$dropdownData.gender.select;
            this.dropdownName = "Giới tính";
            break;
          case this.$dropdownData.workStatusDropdown:
            this.options = this.$dropdownData.workStatus.data;
            this.select = this.$dropdownData.workStatus.select;
            this.dropdownName = "Tình trạng công việc";
            break;
          

          default:
            break;
        }
      },
    },
    data:{
        deep: true,
        handler(){
          switch (this.dropdown) {
            case this.$dropdownData.departmentDropdown:
            // debugger
            this.options = this.$dropdownData.department.data;
            this.select = this.$dropdownData.department.select;
            this.dropdownName = "Phòng ban";
            break;
          case this.$dropdownData.positionDropdown:
            // debugger
            this.options = this.$dropdownData.position.data;
            this.select = this.$dropdownData.position.select;
            this.dropdownName = "Vị trí";
            break;
          
            default:
              break;
          }
        }
    },
    optionDefault: {
      immediate: true,
      handler() {
        if (this.optionDefault && this.select && this.options)
          this.selected(this.optionDefault);
      },
    },
  },
  beforeDestroy() {
    document.removeEventListener("click", this.close);
  },
};
</script>