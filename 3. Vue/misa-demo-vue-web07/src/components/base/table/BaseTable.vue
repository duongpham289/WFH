<template>
  <table class="content__table">
    <thead class="table__header">
      <tr>
        <th></th>
        <th v-for="col in columns" :key="col.name" :class="col.className">
          {{ col.label }}
        </th>
      </tr>
    </thead>
    <tbody>
      <tr
        v-for="item in data"
        :key="item.id"
        @dblclick="rowOnDblClick(item[columns[0].id])"
      >
        <td>
          <div class="delete-box">
            <input type="checkbox" @click="checkBoxOnClick(item[columns[0].id], $event)" />
            <span class="checkmark"></span>
          </div>
        </td>
        <td v-for="col in columns" :key="col.name" :class="col.className">
          {{ formatText(col, item[col.name]) }}
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import FormatData from "@/utils/format/FormatData.js";

export default {
  name: "base-table",
  props: {
    columns: {
      type: Array,
      required: true,
    },
    data: {
      type: Array,
      required: true,
    },
  },
  methods: {
    /**
     * Mở modal khi double click
     * Author: PHDUONG(3/8/2021)
     */
    rowOnDblClick(id) {
      this.$emit("rowOnDblClick", id);
    },
    /**
     * Check box hiển thị khi nhấn
     * Author: PHDUONG(3/8/2021)
     */
    checkBoxOnClick(id, event) {
      this.$emit("checkBoxOnClick", id, event);
    },
    /**
     * Format dữ liệu trước khi gắn dữ liệu vào bảng
     * Author: PHDUONG(3/8/2021)
     */
    formatText(col, item) {
      let tmp = item;

      if (col.format === this.$enum.DATE) {
        tmp = FormatData.formatDate(tmp,false);
      }

      if (col.format === this.$enum.MONEY) {
        tmp = FormatData.formatMoney(tmp);
      }
      if (col.format === this.$enum.WORK) {
        tmp = FormatData.formatWorkStatus(tmp);
      }

      return tmp;
    },
  },
};
</script>