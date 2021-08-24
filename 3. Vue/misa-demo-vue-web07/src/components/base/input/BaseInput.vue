<template>
  <div class="input">
    <label v-if="label" class="modal__text">
      {{ label }}
      <span v-if="required" class="required">
        (<span class="required-input">*</span>)
      </span>
    </label>
    <div class="field-input">
      <input
        class="input"
        :readonly="readonly!=0 ? true: false"
        :class="[
          { 'pl-12': iconLeft === true },
          { 'pr-12': iconRight === true },
          { 'input--alert': errorMsg },
          classes,
        ]"
        :type="type"
        :max="maxDate"
        :placeholder="placeholder"
        :value="attachValue"
        @input="onChangeInput"
      />
      <div class="float--alert" v-if="validateRequired && dirty">
        Thông tin bắt buộc nhập
      </div>
      <div class="float--alert" v-if="validateEmail && dirty">
        Thông tin sai định dạng
      </div>
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
  name: "base-input",

  // #region props
  props: {
    validateRequired: {
      type: Boolean,
    },
    validateEmail: {
      type: Boolean,
    },
    dirty: {
      type: Boolean,
    },
    errorMsg: {
      type: Boolean,
      default: false,
    },
    readonly:{
      type: Number,
      default: 0
    },
    id: {
      type: String,
      required: true,
    },
    value: {
      type: [String, Number],
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
    return {
      maxDate: this.type == 'date' ? new Date().toISOString().split('T')[0] : null
    };
  },

  computed:{
      attachValue: function(){
        return this.formatData(this.type, this.value);
      }
  },

  methods: {
    /**
     * Xử lý thay đổi dữ liệu
     * Author: PHDUONG(05/08/2021)
     */
    onChangeInput(event) {
      let tmp = event.target.value;

      if (this.format === this.$enum.MONEY) {
        event.target.value = FormatData.formatMoneyOnModal(event.target.value);
        tmp = event.target.value.toString().replaceAll(".","");
        this.$emit("handleInput", {
          id: this.id,
          value: parseInt(tmp),
        });
      } else {
        this.$emit("handleInput", { id: this.id, value: tmp });
      }
    },
    /**
     * Định dạng dữ liệu chung
     * Author: PHDUONG(05/08/2021)
     */
    formatData(type, value) {
      if (type === this.$enum.DATE) {
        return FormatData.formatDate(value, true);
      }
      if (this.format === this.$enum.MONEY) {
        return FormatData.formatMoneyOnModal(value);
      }

      return value;
    },
  },
};
</script>