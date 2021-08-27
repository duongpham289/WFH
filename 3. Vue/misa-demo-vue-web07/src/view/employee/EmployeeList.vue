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
            placeholder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại"
            @handleInput="onChangeInput"
            :value="search.employeeFilter"
            style="width: 350px"
          >
            <template v-slot:icon>
              <img src="../../assets/icon/search.png" alt="search" />
            </template>
          </base-input>
          <combo-box
            @selected="filterDepartment"
            :combobox="this.$enum.DEPARTMENT"
            placeholder="Tất cả Phòng ban"
          />
          <combo-box
            @selected="filterPosition"
            :combobox="this.$enum.POSITION"
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
        :pageSize="pageSize"
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
      v-for="(item,index) in toastList"
      :index="index"
      :key="item.id"
      :type="item.type"
      :message="item.message"
      @close="closeToast(item.id)"
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
import { v4 as uuidv4 } from "uuid";

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
    this.getEmployeePagingData(
      this.pageIndex,
      this.pageSize,
      this.search.employeeFilter,
      this.search.departmentId,
      this.search.positionId
    );
    this.getDropdownData();
  },
  methods: {
    //#region Phương thức xử lí dữ liệu

    /**
     * Lấy dữ liệu nhân viên từ Api
     * Author: PHDUONG(08/08/2021)
     */
    getEmployeePagingData(
      pageIndex,
      pageSize,
      employeeFilter,
      departmentId,
      positionId
    ) {
      var vm = this;
      vm.loading = true;

      EmployeesAPI.paging(
        pageIndex,
        pageSize,
        employeeFilter,
        departmentId,
        positionId
      )
        .then((res) => {
          vm.employeesData = res.data.data;
          vm.pageIndex = pageIndex;

          if (res.data) {
            vm.totalRecord = res.data.totalRecord;
            vm.totalPage = Math.ceil(vm.totalRecord / vm.pageSize);
          } else {
            vm.totalRecord = 0;
            vm.totalPage = 1;
          }

          this.loading = false;
          if (res.data.data) {
            this.setToast("success", "Tải dữ liệu thành công");
            // vm.responseHandler(2, "");
          } else {
            this.setToast("info", "Không có dữ liệu");
            // vm.responseHandler(6, "");
          }
        })
        .catch((err) => {
          var message = vm.responseHandler(err);
          this.setToast("fail", message);
        });
    },

    /**
     * Xử lý dữ liệu trả về
     * CreatedBy: PHDUONG(24/08/2021)
     */
    responseHandler(err) {
      // let vm = this;
      // if (status == 1) {
      this.loading = false;
      switch (err.response.status) {
        case 400:
          this.toastMessageState = status;

          if (err.response.data.userMsg) return err.response.data.userMsg;
          else return "Sai cú pháp URL";

        case 404:
          this.toastMessageState = status;

          if (err.response.data.userMsg) return err.response.data.userMsg;
          else return "Không tìm thấy đường dẫn";

        case 500:
          this.toastMessageState = status;

          if (err.response.data.userMsg) return err.response.data.userMsg;
          else return "Lỗi hệ thống, vui lòng liên hệ MISA";

        default:
          console.log(err.response.status);
          break;
      }
      //   setTimeout(function () {
      //     vm.isShowToast = true;
      //   }, 400);
      //   setTimeout(function () {
      //     vm.isShowToast = false;
      //   }, 5000);
      // } else {
      //   vm.loading = false;
      //   vm.toastMessageState = status;
      //   setTimeout(function () {
      //     vm.isShowToast = true;
      //   }, 400);
      //   setTimeout(function () {
      //     vm.isShowToast = false;
      //   }, 2000);
      // }
    },

    /**
        Truyền nội dung toast message
    */
    setToast(type, message) {
      this.toastList.push({
        id: uuidv4(),
        type: type,
        message: message,
        isShowed: true,
      });
    },
    /** 
      Đóng toast message
    */
    closeToast(id) {
      this.toastList = this.toastList.filter((item) => {
        return !(item.id === id);
      });
    },

    /**
     * Xử lý chuyển trang
     * CreatedBy: PHDUONG(24/08/2021)
     */
    pagingOnChange(pageIndex, pageSize) {
      this.pageIndex = pageIndex;
      this.pageSize = pageSize;
      this.getEmployeePagingData(
        pageIndex,
        pageSize,
        this.search.employeeFilter,
        this.search.departmentId,
        this.search.positionId
      );
    },

    /**
     * Xử lý đổi số nhân viên/trang
     * CreatedBy: PHDUONG(24/08/2021)
     */
    getPageSize(pageIndex, pageSize) {
      this.pageSize = pageSize;
      this.getEmployeePagingData(
        pageIndex,
        this.pageSize,
        this.search.employeeFilter,
        this.search.departmentId,
        this.search.positionId
      );
    },

    /**
     * Xử lý lấy dữ liệu dropdown
     * CreatedBy: PHDUONG(24/08/2021)
     */
    getDropdownData() {
      var vm = this;
      PositionAPI.getAll()
        .then((res) => {
          DropdownData.position.options = res.data;

          [].push.apply(ComboboxData.position.options, res.data);
          // debugger
        })
        .catch((err) => {
          vm.responseHandler(1, err);
        });

      DepartmentAPI.getAll()
        .then((res) => {
          DropdownData.department.options = res.data;

          [].push.apply(ComboboxData.department.options, res.data);
          // debugger
        })
        .catch((err) => {
          vm.responseHandler(1, err);
        });
    },

    onChangeInput({ value }) {
      clearTimeout(this.timeoutItem);
      this.timeoutItem = setTimeout(() => {
        this.search.employeeFilter = value;
        this.getEmployeePagingData(
          this.pageIndex,
          this.pageSize,
          this.search.employeeFilter,
          this.search.departmentId,
          this.search.positionId
        );
      }, 500);
    },

    /**
     * Lọc dữ liệu Phòng ban
     * CreatedBy: PHDUONG(25/08/2021)
     */
    filterDepartment(value) {
      this.search.departmentId = value;
      this.getEmployeePagingData(
        1,
        this.pageSize,
        this.search.employeeFilter,
        this.search.departmentId,
        this.search.positionId
      );
    },

    /**
     * Lọc dữ liệu Vị trí
     * CreatedBy: PHDUONG(25/08/2021)
     */
    filterPosition(value) {
      console.log(value);
      this.search.positionId = value;
      this.getEmployeePagingData(
        1,
        this.pageSize,
        this.search.employeeFilter,
        this.search.departmentId,
        this.search.positionId
      );
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
    },

    /**
     * Reload bảng dữ liệu sau khi xóa
     * Author: PHDUONG(30/07/2021)
     */
    btnReloadOnClick() {
      $(".checkbox").prop("checked", false);
      this.employeesToDelete = [];
      this.employeesData = [];
      this.getEmployeePagingData(
        this.pageIndex,
        this.pageSize,
        this.search.employeeFilter,
        this.search.departmentId,
        this.search.positionId
      );
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
          vm.responseHandler(1, err);
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
      pageSize: 15,
      totalPage: 0,
      totalRecord: 0,

      isShowToast: false,
      toastMessageState: 0,
      errorMsg: "",
      toastList: [],

      search: {
        departmentId: "",
        positionId: "",
        employeeFilter: "",
      },

      employeesData: [],
      employeeGetById: EmployeeModel.initData(),
      employeesToDelete: [],
      columns: columns,

      isHiddenDialogDetail: true,
      modeFormDetail: 0,

      isHiddenPopupMessage: true,
      loading: true,
    };
  },
};
</script>