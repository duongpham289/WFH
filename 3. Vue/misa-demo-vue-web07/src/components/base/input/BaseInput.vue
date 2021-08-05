<template>
  <div class="input">
    <label v-if="label" class="modal__text">
      {{ label }}
      <span v-if="required" class="required">
        (<span class="required-input">*</span>)
      </span>
    </label>
    <div class="input-group">
      <input
        class="input"
        :class="[
          { 'pl-12': iconLeft === true },
          { 'pr-12': iconRight === true },
          classes,
        ]"
        :type="type"
        :placeholder="placeholder"
        :value="valueClone"
        @input="onChangeInput"
      />
      <div class="icon-left" v-if="iconLeft">
        <slot name="icon"></slot>
      </div>
      <div class="icon-right" v-if="iconRight">
        <slot name="icon"></slot>
      </div>
    </div>
  </div>
</template>

<script>

import FormatData from "@/utils/format/FormatData.js";

export default {
  name:"base-input",

  //#region props
  props: {
    id: {
      type: String,
      required: true,
    },
    value: {
      type: [String,Number],
      required: true,
      default: "",
    },
    type: {
      type: String,
      default: "text",
    },
    format: {
      type: String,
      required: false,
    },
    label: {
      type: String,
      
    },
    placeholder: {
      type: String,
    },
    classes: {
      type: String,
    },
    iconLeft: {
      type: Boolean,
      default: false,
    },
    iconRight: {
      type: Boolean,
      default: false,
    },
    required: {
      type: Boolean,
      default: false,
    },
  },
  //#endregion
  
  emits: ["handle-input"],

  data() {
    return { valueClone: "" };
  },

  watch: {
    value(newVal) {
      debugger
      this.valueClone = this.formatData(this.type, newVal);
    },
  },

  methods: {
    /*
      Xử lý thay đổi dữ liệu
    */
    onChangeInput(event) {
      let tmp = event.target.value;
      // debugger

      if (this.format === this.$enum.MONEY) {
        event.target.value = FormatData.formatSalary(event.target.value);
        this.valueClone = FormatData.formatSalary(event.target.value);
      }

      this.$emit("handle-input", { id: this.id, value: parseInt(tmp.replaceAll(".","")) });
    },

    /*
      định dạng dữ liệu
    */
    formatData(type, value) {
      if (type === this.$enum.DATE) {
        return FormatData.formatDate(value, true);
      }

      if (this.format === this.$enum.MONEY) {
        // debugger
        return FormatData.formatSalary(value);
      }

      return value;
    },
  },
};
</script>