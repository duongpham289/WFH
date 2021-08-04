<template>
  <div class="input">
    <label v-if="label" class="modal__text" :for="id">
      {{ label }}
      <span v-if="required" class="required">
        (<span class="required-input">*</span>)
      </span>
    </label>
    <div class="input-group">
      <input
        :id="id"
        class="input"
        :class="[
          { 'pl-12': iconLeft === true },
          { 'pr-12': iconRight === true },
          classes,
        ]"
        :type="type"
        v-model="value"
        :placeholder="placeholder"
        @input="$emit('input', $event.target.value)"
        @keydown="$emit('keydown', $event)"
        @blur="$emit('blur', $event)"
        @keyup="$emit('keyup', $event)"
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
export default {
  props: {
    type: {
      type: String,
      default: "text",
    },
    id: {
      type: String,
    },
    value: {
      type: String,
      default: "",
    },
    label: String,
    placeholder: String,
    classes: String,
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
};
</script>