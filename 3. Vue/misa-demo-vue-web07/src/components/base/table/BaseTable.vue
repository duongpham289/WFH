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
import Common from "@/utils/Common.js";

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
    rowOnDblClick(id) {
      this.$emit("rowOnDblClick", id);
    },
    checkBoxOnClick(id, event) {
      this.$emit("checkBoxOnClick", id, event);
    },
    formatText(col, item) {
      let tmp = item;

      if (col.format === "date") {
        tmp = Common.formatDate(tmp,false);
      }

      if (col.format === "money") {
        tmp = Common.formatMoney(tmp);
      }
      if (col.format === "work") {
        tmp = Common.formatWorkStatus(tmp);
      }

      return tmp;
    },
  },
};
</script>