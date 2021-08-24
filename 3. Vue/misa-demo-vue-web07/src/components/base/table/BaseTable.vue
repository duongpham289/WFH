<template>
  <table class="content__table">
    <thead class="table__header">
      <tr>
        <th>
          <!-- <div class="delete-box">
            <input class="checkbox" type="checkbox" @click="checkAll" />
            <span class="checkmark"></span>
          </div> -->
        </th>
        <th v-for="col in columns" :key="col.name" :class="col.className">
          {{ col.label }}
        </th>
      </tr>
    </thead>
    <tbody class="table__body">
      <tr
        v-for="item in data"
        :key="item[columns[0].id]"
        :check="changeColorOnClick(item[columns[0].id])"
        @dblclick="rowOnDblClick(item[columns[0].id])"
      >
        <td>
          <div class="delete-box">
            <input
              class="checkbox"
              type="checkbox"
              v-model="checkedId"
              :value="{ id: item[columns[0].id], code: item[columns[1].name] }"
            />
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
  data() {
    return {
      checkedId: [],
      checked: 0,
      // isCheckAll: false
    };
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
     * Thay đổi màu của row khi click vào checkbox
     * CreatedBy: PHDUONG(19/08/2021)
     */
    changeColorOnClick(id) {
      var isTrue = false;
      this.checkedId.find((item) => {
        if (item.id === id) {
          isTrue = true;
        }
      });
      return isTrue || this.isCheckAll;
    },

    // /**
    //  * Chọn tất cả bản ghi
    //  * CreatedBy: PHDUONG(19/08/2021)
    //  */
    // checkAll() {
    //   var vm = this;
    //   vm.checked++;
    //   this.isCheckAll = !this.isCheckAll;
    //   if (vm.checked == 1) {
    //     $(".checkbox").prop("checked", true);
    //     for (let index = 0; index <= vm.data.length - 1; index++) {
    //       vm.checkedId.push({
    //         id: vm.data[index].id,
    //         code: vm.data[index].name,
    //       });
    //     }
    //     vm.$emit("checkBoxOnClick", vm.checkedId);
    //   } else {
    //     $(".checkbox").prop("checked", false);
    //     vm.checkedId = [];
    //     vm.$emit("checkBoxOnClick", vm.checkedId);
    //     vm.checked = 0;
    //   }
    // },

    /**
     * Format dữ liệu trước khi gắn dữ liệu vào bảng
     * Author: PHDUONG(3/8/2021)
     */
    formatText(col, item) {
      let tmp = item;

      if (col.format === this.$enum.DATE) {
        tmp = FormatData.formatDate(tmp, false);
      }

      if (col.format === this.$enum.MONEY) {
        tmp = FormatData.formatMoneyOnTable(tmp);
      }
      if (col.format === this.$enum.WORK) {
        tmp = FormatData.formatWorkStatus(tmp);
      }
      if (col.format === this.$enum.GENDER) {
        tmp = FormatData.formatGender(tmp);
      }

      return tmp;
    },
  },

  watch: {
    checkedId: function () {
      this.$emit("checkBoxOnClick", this.checkedId);
    },
  },
};
</script>