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
            v-bind:class="{ '--hidden': isHiddenButton }"
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
          <div class="field-input--icon">
            <div class="icon-default -search"></div>
            <label>
              <input
                type="text"
                placeholder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại"
              />
            </label>
          </div>
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
        <!-- <table class="content__table" >
          <thead class="table__header">
            <tr>
              <th></th>
              <th>Mã nhân viên</th>
              <th>Họ và tên</th>
              <th>Giới tính</th>
              <th>Ngày sinh</th>
              <th>Điện thoại</th>
              <th>Email</th>
              <th>Chức vụ</th>
              <th>Phòng ban</th>
              <th>Mức lương cơ bản</th>
              <th>Tình trạng công việc</th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="employee in employees"
              :key="employee.EmployeeId"
              @dblclick="rowOnDblClick(employee.EmployeeId)"
            >
              <td>
                <div class="delete-box">
                  <input
                    type="checkbox"
                    @click="checkBoxOnClick(employee.EmployeeId, $event)"
                  />
                  <span class="checkmark"></span>
                </div>
              </td>
              <td>{{ employee.EmployeeCode }}</td>
              <td>{{ employee.FullName }}</td>
              <td>{{ employee.GenderName }}</td>
              <td>{{ employee.DateOfBirth }}</td>
              <td>{{ employee.PhoneNumber }}</td>
              <td>{{ employee.Email }}</td>
              <td>{{ employee.PositionName }}</td>
              <td>{{ employee.DepartmentName }}</td>
              <td>{{ employee.Salary }}</td>
              <td>{{ employee.WorkStatus }}</td>
            </tr>
          </tbody>
        </table> -->
        <base-table
          :columns="columns"
          :data="data"
          @rowOnDblClick="rowOnDblClick"
          @checkBoxOnClick="checkBoxOnClick"
        />
      </div>
      <div class="content__footer">
        <p>Hiển thị 1-10/10000 nhân viên</p>
        <div class="pagination">
          <img
            src="../../assets/icon/btn-firstpage.svg"
            alt="First Page"
            class="pagination__button"
          />
          <img
            src="../../assets/icon/btn-prev-page.svg"
            alt="Previous Page"
            class="pagination__button"
          />
          <div class="pagination__number active"><p>1</p></div>
          <div class="pagination__number"><p>2</p></div>
          <div class="pagination__number"><p>3</p></div>
          <div class="pagination__number"><p>4</p></div>
          <img
            src="../../assets/icon/btn-next-page.svg"
            alt="Next Page"
            class="pagination__button"
          />
          <img
            src="../../assets/icon/btn-lastpage.svg"
            alt="Last Page"
            class="pagination__button"
          />
        </div>
        <p>10 nhân viên/trang</p>
      </div>
    </div>
    <EmployeeDetailDialog
      v-bind:isHidden="isHiddenDialogDetail"
      v-bind:employeeId="employeeId"
      v-bind:mode="modeFormDetail"
      @btnAddOnClick="btnAddOnClick"
    />
    <PopupMessage
      :isHidden="isHiddenPopupMessage"
      :employeesToDelete="employeesToDelete"
      @btnDelOnClick="btnDelOnClick"
    />
  </div>
</template>

<script>
import axios from "axios";
const $ = require("jquery");

import EmployeeDetailDialog from "../employee/EmployeeDetail.vue";
import PopupMessage from "../../components/base/PopupMessage.vue";
import { columns } from "@/view/employee/EmployeeTableCols.js";

export default {
  name: "EmployeePage",
  components: { EmployeeDetailDialog, PopupMessage },
  mounted() {
    var vm = this;
    //gọi Api lấy dữ liệu
    axios
      .get("http://cukcuk.manhnv.net/v1/Employees")
      .then((res) => {
        // console.log(res.data);
        vm.data = res.data;
      })
      .catch((res) => {
        console.log(res);
      });
  },
  methods: {
    /**
     * Hiển thị form chi tiết khi ấn button thêm nhân viên
     * Author: PHDUONG(29/07/2021)
     */
    btnAddOnClick(isHidden) {
      this.isHiddenDialogDetail = isHidden;
      this.modeFormDetail = 0;
    },
    /**
     * Reload bảng dữ liệu sau khi xóa
     * Author: PHDUONG(30/07/2021)
     */
    btnReloadOnClick() {
      $("tbody").empty();
      this.data = [];
      this.isHiddenButton = true;
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
      this.isHiddenButton = isHidden;
    },

    /**
     * Hiển thị button delete và checkbox
     * Author: PHDUONG(29/07/2021)
     */
    checkBoxOnClick(employeeId, event) {

      console.log(event.target.checked);
      const deleteBoxes = document.querySelectorAll(".delete-box input");
      event.target.setAttribute(
        "checked",
        !event.target.getAttribute("checked") ? "checked" : ""
      );

      let allUnchecked = true;
      deleteBoxes.forEach((box) => {
        //   debugger
        if (box.getAttribute("checked") === "checked") {
          allUnchecked = false;
          this.isHiddenButton = false;
        }
        if (allUnchecked) {
          this.employeesToDelete = [];
          this.isHiddenButton = true;
        }
      });
      if (!allUnchecked) {
        if (
          //check trùng
          !this.employeesToDelete.some((item) => {
            return item === employeeId;
          })
        ) {
          //đưa employeeId vào 1 mảng employeeToDelete
          this.employeesToDelete.push(employeeId);
        }
      }
    },
  },
  watch: {
    /**
     * Reload dữ liệu khi dữ liệu thay đổi
     * Author: PHDUONG(31/07/2021)
     */
    data() {
      var vm = this;
      axios
        .get("http://cukcuk.manhnv.net/v1/Employees")
        .then((res) => {
          // console.log(res.data);
          vm.data = res.data;
        })
        .catch((res) => {
          console.log(res);
        });
      // this.isHiddenButton = true;
    },
  },
  data() {
    return {
      data: [],
      employeeId: "",
      employeesToDelete: [],
      isHiddenDialogDetail: true,
      isHiddenButton: true,
      isHiddenPopupMessage: true,
      isChecked: "",
      modeFormDetail: 0,
      columns: columns,
    };
  },
};
</script>