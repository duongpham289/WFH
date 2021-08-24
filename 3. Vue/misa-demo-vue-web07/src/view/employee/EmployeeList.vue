<template>
  <div class="employee-list">
    <!-- Phần Content -->
    <BaseSpinner :loading="loading" />

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
          <combo-box
            @selected="filterDepartment"
            :combobox="this.$enum.DEPARTMENT"
            :defaultState="isReset"
            placeholder="Tất cả Phòng ban"
          />
          <combo-box
            @selected="filterPosition"
            :combobox="this.$enum.POSITION"
            :defaultState="isReset"
            placeholder="Tất cả Vị trí"
          />
        </div>
        <div class="content__filter--right">
          <div
            class="button--secondary button__icon button__reload"
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
      <base-pagination
        :pageIndex="pageIndex"
        @getPageSize="getPageSize"
        :totalPage="totalPage"
        :totalRecord="totalRecord"
        @pagingOnChange="pagingOnChange"
      />
    </div>
    <EmployeeDetailDialog
      :isHidden="isHiddenDialogDetail"
      :mode="modeFormDetail"
      ref="EmployeeDetailDialog"
      :employeeGetById="employeeGetById"
      @btnAddOnClick="btnAddOnClick"
      @btnReloadOnClick="btnReloadOnClick"
      @responseHandler="responseHandler"
    />
    <PopupMessage
      :isHidden="isHiddenPopupMessage"
      :datasToDelete="employeesToDelete"
      @btnDelOnClick="btnDelOnClick"
      @btnReloadOnClick="btnReloadOnClick"
    />
    <BaseToastMessage
      :isShowToast="isShowToast"
      :toastMessageState="toastMessageState"
      :erorMsg="errorMsg"
    />
  </div>
</template>

<script>
import EmployeesAPI from "@/api/components/EmployeesAPI.js";
import PositionAPI from "@/api/components/PositionAPI.js";
import DepartmentAPI from "@/api/components/DepartmentAPI.js";
import EmployeeDetailDialog from "../employee/EmployeeDetail.vue";
import PopupMessage from "../../components/base/PopupMessage.vue";
import BaseToastMessage from "../../components/base/BaseToastMessage.vue";
import EmployeeModel from "@/models/EmployeeModel.js";
import { columns } from "@/view/employee/EmployeeTableCols.js";

import ComboboxData from "../../components/base/combobox/ComboboxData.js";
import DropdownData from "../../components/base/dropdown/DropdownData.js";
import BaseSpinner from "../../components/base/BaseSpinner.vue";

const $ = require("jquery");

export default {
  name: "EmployeePage",
  components: {
    EmployeeDetailDialog,
    PopupMessage,
    BaseSpinner,
    BaseToastMessage,
  },
  created() {
    this.getEmployeePagingData(this.pageIndex, this.pageSize);
    this.getDropdownData();
  },
  methods: {
    //#region Phương thức xử lí dữ liệu

    /**
     * Lấy dữ liệu nhân viên từ Api
     * Author: PHDUONG(08/08/2021)
     */
    getEmployeePagingData(pageIndex, pageSize, employeeFilter) {
      var vm = this;
      vm.loading = true;

      EmployeesAPI.paging(pageIndex, pageSize, employeeFilter)
        .then((res) => {
          vm.employeesData = res.data.data;
          vm.totalRecord = res.data.totalRecord;
          vm.totalPage = Math.ceil(vm.totalRecord / vm.pageSize);
          vm.responseHandler(2, "");
        })
        .catch((err) => {
          vm.responseHandler(1, err);
        });
    },

    responseHandler(status, err) {
      let vm = this;
      if (status == 1) {
        switch (err.response.status) {
          case 400:
            vm.loading = false;
            vm.toastMessageState = status;

            if (err.response.data.userMsg)
              vm.errorMsg = err.response.data.userMsg;
            else vm.errorMsg = err.response.status + " Sai cú pháp URL";

            setTimeout(function () {
              vm.isShowToast = true;
            }, 400);
            setTimeout(function () {
              vm.isShowToast = false;
            }, 5000);

            break;

          case 404:
            vm.loading = false;
            vm.toastMessageState = status;

            if (err.response.data.userMsg)
              vm.errorMsg = err.response.data.userMsg;
            else
              vm.errorMsg = err.response.status + " Không tìm thấy đường dẫn";

            setTimeout(function () {
              vm.isShowToast = true;
            }, 400);
            setTimeout(function () {
              vm.isShowToast = false;
            }, 5000);

            break;

          case 500:
            vm.loading = false;
            vm.toastMessageState = status;

            if (err.response.data.userMsg)
              vm.errorMsg = err.response.data.userMsg;
            else
              vm.errorMsg =
                err.response.status + " Lỗi hệ thống, vui lòng liên hệ MISA";

            setTimeout(function () {
              vm.isShowToast = true;
            }, 400);
            setTimeout(function () {
              vm.isShowToast = false;
            }, 5000);

            break;

          default:
            if (err.response.data.userMsg) {
              vm.loading = false;
              vm.toastMessageState = status;

              vm.errorMsg = err.response.data.userMsg;
              setTimeout(function () {
                vm.isShowToast = true;
              }, 400);
              setTimeout(function () {
                vm.isShowToast = false;
              }, 5000);
            }
            break;
        }
      } else {
        vm.loading = false;
        vm.toastMessageState = status;
        setTimeout(function () {
          vm.isShowToast = true;
        }, 400);
        setTimeout(function () {
          vm.isShowToast = false;
        }, 2000);
      }
    },

    pagingOnChange(pageIndex, pageSize) {
      this.pageIndex = pageIndex;
      this.pageSize = pageSize;
      this.getEmployeePagingData(pageIndex, pageSize);
    },

    getPageSize(pageIndex, pageSize) {
      this.pageSize = pageSize;
      this.getEmployeePagingData(pageIndex, this.pageSize);
    },

    getDropdownData() {
      var vm = this;
      PositionAPI.getAll()
        .then((res) => {
          DropdownData.position.options = res.data;

          [].push.apply(ComboboxData.position.options, res.data);
          // debugger
        })
        .catch((err) => {
          vm.responseHandler(0, err);
        });

      DepartmentAPI.getAll()
        .then((res) => {
          DropdownData.department.options = res.data;

          [].push.apply(ComboboxData.department.options, res.data);
          // debugger
        })
        .catch((err) => {
          vm.responseHandler(0, err);
        });
    },
    /**
     *
     */
    filterDepartment(value, name) {
      console.log(value, name);
    },
    filterPosition(value, name) {
      console.log(value, name);
    },

    /**
     * Hiển thị form chi tiết khi ấn button thêm nhân viên
     * Author: PHDUONG(29/07/2021)
     */
    btnAddOnClick(isHidden) {
      this.isHiddenDialogDetail = isHidden;
      this.modeFormDetail = 0;
      this.$refs.EmployeeDetailDialog.autoFocusWhenAdd();
      $("input").val("");
      this.employeeId = "";
    },

    /**
     * Reload bảng dữ liệu sau khi xóa
     * Author: PHDUONG(30/07/2021)
     */
    btnReloadOnClick() {
      $(".checkbox").prop("checked", false);
      this.employeesToDelete = [];
      this.isReset = true;
      this.employeesData = [];
      this.getEmployeePagingData(this.pageIndex, this.pageSize);
    },

    /**
     * Hiển thị form chi tiết khi ấn 2 lần vào 1 hàng thông tin nhân viên
     * Author: PHDUONG(29/07/2021)
     */
    rowOnDblClick(empId) {
      let vm = this;

      EmployeesAPI.getById(empId)
        .then((res) => {
          vm.employeeGetById = res.data;
          vm.isHiddenDialogDetail = false;
          vm.$refs.EmployeeDetailDialog.autoFocusWhenUpdate();
          vm.modeFormDetail = 1;
        })
        .catch((err) => {
          vm.responseHandler(0, err);
        });
    },

    /**
     * Hiển thị message chắc chắn xóa
     * Author: PHDUONG(31/07/2021)
     */
    btnDelOnClick(isHidden) {
      this.isHiddenPopupMessage = isHidden;
    },

    /**
     * Hiển thị button delete và checkbox
     * Author: PHDUONG(29/07/2021)
     */
    checkBoxOnClick(checkedId) {
      if (checkedId.length > 0) {
        // debugger;
        this.employeesToDelete = [];

        for (let index = 0; index <= checkedId.length - 1; index++) {
          this.employeesToDelete.push({
            id: checkedId[index].id,
            code: checkedId[index].code,
          });
        }
      } else {
        this.employeesToDelete = [];
      }
    },

    //#endregion
  },
  data() {
    return {
      pageIndex: 1,
      pageSize: 10,
      totalPage: 0,
      totalRecord: 0,
      isShowToast: false,
      toastMessageState: 0,
      errorMsg: "",
      employeeFilter: null,
      employeesData: [],
      employeeGetById: EmployeeModel.initData(),
      employeesToDelete: [],
      isHiddenDialogDetail: true,
      isHiddenPopupMessage: true,
      isReset: false,
      modeFormDetail: 0,
      columns: columns,
      loading: true,
    };
  },
};
</script>