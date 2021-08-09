<template>
  <div class="combobox" @blur="open = false">
    <input
      type="text"
      class="combobox__input"
      :placeholder="placeholder"
      @click="open = !open"
      :value="selector.name"
    />
    <button
      class="combobox__button"
      @click="open = !open"
      :class="open ? 'border-active' : ''"
    >
      <i class="fas fa-chevron-down" :class="open ? 'rotate-180' : ''"></i>
    </button>
    <div class="combobox__data" v-show="open">
      <div
        class="combobox__item"
        v-for="item in options"
        :key="item[select.value]"
        :value="item[select.value]"
        @click="selected(item)"
        :class="selector.value == item[select.value] ? 'active' : ''"
      >
        <span
          class="icon"
          :class="selector.value == item[select.value] ? '--block' : ''"
        >
          <i class="fas fa-check"></i></span
        >{{ item[select.name] }}
      </div>
    </div>
  </div>
</template>

<script>
import ComboboxData from "./ComboboxData.js"

export default {
  created() {
    document.addEventListener("click", this.close);
  },
  props: {
    combobox: {
      type: String,
      required: true,
      default: null,
    },
    placeholder:{
      type: String,
    },
    defaultState:{
      type: Boolean,
    }
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
      selector: {
        name: "",
        value: "",
      },
    };
  },

  watch: {
    combobox: {
      immediate: true,
      handler() {
        switch (this.combobox) {
          case this.$enum.DEPARTMENT:
            this.options = ComboboxData.department.options;
            this.select = ComboboxData.department.select;
            break;
          case this.$enum.POSITION:
            // debugger
            this.options = ComboboxData.position.options;
            this.select = ComboboxData.position.select;
            break;

          default:
            break;
        }
      },
    },
    defaultState: function(){
      if (this.defaultState) {
        switch (this.combobox) {
          case this.$enum.DEPARTMENT:
            this.selector = { name: "", value: "" };
            break;
          case  this.$enum.POSITION:
            this.selector = { name: "", value: "" };
            break;

          default:
            break;
        }
      }
    }
  },
  beforeDestroy() {
    document.removeEventListener("click", this.close);
  },
};
</script>