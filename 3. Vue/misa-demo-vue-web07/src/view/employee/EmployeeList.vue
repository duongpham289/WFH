<template>
  <div class="employee-list">
    <!-- Phần Content -->

    <div class="content">
      <!-- Phần Header của Content chi tiết:
                        - Header Content
                        - Nút thêm nhân viên
                -->

      <div class="content__header">
        <div class="content__header header__title">Danh sách nhân viên</div>
        <div class="button__container">
          <div
            class="button--primary"
            id="button__delete-employee"
            v-if="this.employeesToDelete.length"
            @click="btnDelOnClick(false)"
          >
            <div class="button__text">Xóa nhân viên</div>
          </div>
          <div
            class="button--primary button__icon"
            id="button__add-employee"
            @click="btnAddOnClick(false)"
          >
            <div class="icon-default -add"></div>
            <div class="button__text">Thêm nhân viên</div>
          </div>
        </div>
      </div>

      <!-- Phần Filter của Content chi tiết:
                        - Search theo thuộc tinh của Nhân viên
                        - Filter theo Phòng ban
                        - Filter theo Vị trí
                -->
      <div class="content__filter">
        <div class="content__filter--left">
          <base-input
            :iconLeft="true"
            id=""
            value=""
            placeholder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại"
            style="width: 350px"
          >
            <template v-slot:icon>
              <img src="../../assets/icon/search.png" alt="search" />
            </template>
          </base-input>
          <div class="combobox">
            <input
              type="text"
              class="combobox__input"
              placeholder="Tất cả phòng ban"
            />
            <button class="combobox__button">
              <i class="fas fa-chevron-down icon"></i>
            </button>
            <div class="combobox__data department-name" value="0">
              <div class="combobox__item" value="0">
                <span class="icon"> <i class="fas fa-check"></i></span>Tất cả
                Phòng ban
              </div>
            </div>
          </div>
          <div class="combobox">
            <input
              type="text"
              class="combobox__input"
              placeholder="Tất cả vị trí"
            />
            <button class="combobox__button">
              <i class="fas fa-chevron-down icon"></i>
            </button>
            <div class="combobox__data position-name" value="1">
              <div class="combobox__item" value="0">
                <span class="icon"> <i class="fas fa-check"></i></span>Tất cả Vị
                trí
              </div>
            </div>
          </div>
        </div>
        <div class="content__filter--right">
          <div
            class="button--secondary button__icon"
            id="button__reload"
            @click="btnReloadOnClick"
          >
            <div class="icon-default -reload"></div>
          </div>
        </div>
      </div>

      <!-- Phần bảng dữ liệu chính của Content -->
      <div class="content__table-container table__employee">
        <base-table
          :columns="columns"
          :data="employeesData"
          @rowOnDblClick="rowOnDblClick"
          @checkBoxOnClick="checkBoxOnClick"
        />
      </div>
      <base-pagination />
    </div>
    <EmployeeDetailDialog
      v-bind:isHidden="isHiddenDialogDetail"
      v-bind:employeeId="employeeId"
      v-bind:mode="modeFormDetail"
      @btnAddOnClick="btnAddOnClick"
      @btnReloadOnClick="btnReloadOnClick"
    />
    <PopupMessage
      :isHidden="isHiddenPopupMessage"
      :datasToDelete="employeesToDelete"
      @btnDelOnClick="btnDelOnClick"
    />
  </div>
</template>

<script>
import EmployeesAPI from "@/api/components/EmployeesAPI.js";
// import PositionAPI from "@/api/components/PositionAPI.js";
// import DepartmentAPI from "@/api/components/DepartmentAPI.js";
import EmployeeDetailDialog from "../employee/EmployeeDetail.vue";
import PopupMessage from "../../components/base/PopupMessage.vue";
import { columns } from "@/view/employee/EmployeeTableCols.js";

const $ = require("jquery");

export default {
  name: "EmployeePage",
  components: { EmployeeDetailDialog, PopupMessage },
  created() {
    var vm = this;

    EmployeesAPI.getAll()
      .then((res) => {
        vm.employeesData = res.data;
      })
      .catch((err) => {
        console.log(err);
      });
  },
  methods: {
    //#region Phương thức xử lí dữ liệu

    /**
     * Hiển thị form chi tiết khi ấn button thêm nhân viên
     * Author: PHDUONG(29/07/2021)
     */
    btnAddOnClick(isHidden) {
      this.isHiddenDialogDetail = isHidden;
      this.modeFormDetail = 0;
      this.employeeId = "";
    },

    /**
     * Reload bảng dữ liệu sau khi xóa
     * Author: PHDUONG(30/07/2021)
     */
    btnReloadOnClick() {
      
      $('.checkbox').prop('checked', false);
      this.employeesToDelete =[]
      this.employeesData = [];
    },

    /**
     * Hiển thị form chi tiết khi ấn 2 lần vào 1 hàng thông tin nhân viên
     * Author: PHDUONG(29/07/2021)
     */
    rowOnDblClick(empId) {
      this.isHiddenDialogDetail = false;
      this.employeeId = empId;
      this.modeFormDetail = 1;
    },

    /**
     * Hiển thị message chắc chắn xóa
     * Author: PHDUONG(31/07/2021)
     */
    btnDelOnClick(isHidden) {
      this.isHiddenPopupMessage = isHidden;
      if (isHidden) {
        this.employeesToDelete = [];
      }
    },

    /**
     * Hiển thị button delete và checkbox
     * Author: PHDUONG(29/07/2021)
     */
    checkBoxOnClick(employeeId, employeeCode, event) {
      // debugger
      event.target.setAttribute("checked", event.target.checked);

      if (event.target.getAttribute("checked") === "true") {
        this.employeesToDelete.push({id:employeeId, code:employeeCode});
      } else {
        var removeIndex = this.employeesToDelete.map(function(item) { return item.id; }).indexOf(employeeId);
        this.employeesToDelete.splice(removeIndex, 1);
      }
    },
    //#endregion
  },
  watch: {
    /**
     * Reload bảng khi dữ liệu thay đổi
     * Author: PHDUONG(31/07/2021)
     */
    employeesData() {
      var vm = this;
      //gọi Api lấy dữ liệu

      EmployeesAPI.getAll()
        .then((res) => {
          vm.employeesData = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
  data() {
    return {
      employeesData: [],
      employeeId: "",
      employeeCode: "",
      employeesToDelete: [],
      isHiddenDialogDetail: true,
      isHiddenPopupMessage: true,
      isChecked: "",
      modeFormDetail: 0,
      columns: columns,
    };
  },
};
</script>