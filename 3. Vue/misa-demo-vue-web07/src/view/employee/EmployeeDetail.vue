<template>
  <!-- Phần Modal Popup -->
  <div class="modal__container" v-bind:class="{ '--hidden': isHidden }">
    <div class="modal">
      <!-- Modal Popup Header -->
      <div class="modal__header">
        <div class="modal__name">Thông tin nhân viên</div>
        <div class="modal__button-close">
          <button
            class="button--secondary button__close"
            @click="btnCancelOnClick"
          ></button>
        </div>
      </div>
      <!-- Modal Popup Avatar Holder -->
      <div class="modal__sidebar">
        <div class="modal__avatar-holder"></div>
        <span>(Vui lòng chọn ảnh có định dạng .jpg, .jpeg, .png, .gif)</span>
      </div>
      <!-- Modal Popup Content -->
      <div class="modal__content">
        <div class="modal__general-info">
          <div class="info-title">
            <div class="model__text"><span>A. Thông tin chung:</span></div>

            <div class="title-layout"></div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <div class="model__text">
                <span>Mã nhân viên(<span class="required-input">*</span>)</span>
              </div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtEmployeeCode"
                placeholder="NV8888..."
                required
                :class="{ 'input--alert': $v.employee.EmployeeCode.$error }"
                v-model.trim="$v.employee.EmployeeCode.$model"
              />
              <div
                class="float--alert"
                v-if="
                  !$v.employee.EmployeeCode.required &&
                  $v.employee.EmployeeCode.$dirty
                "
              >
                Thông tin bắt buộc nhập
              </div>
            </div>
            <div class="info-column">
              <div class="model__text">
                <span>Họ và tên(<span class="required-input">*</span>)</span>
              </div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtFullName"
                placeholder="Nguyễn Văn A..."
                required
                :class="{ 'input--alert': $v.employee.FullName.$error }"
                v-model.trim="$v.employee.FullName.$model"
              />
              <div
                class="float--alert"
                v-if="
                  !$v.employee.FullName.required && $v.employee.FullName.$dirty
                "
              >
                Thông tin bắt buộc nhập
              </div>
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <div class="model__text">
                <span>Ngày sinh</span>
              </div>
              <input
                type="date"
                class="modal__field-input field-input-label"
                id="dDateOfBirth"
                v-model="employee.DateOfBirth"
              />
            </div>
            <div class="info-column" id="gender">
              <div class="model__text">
                <span>Giới tính</span>
              </div>
              <base-dropdown
                @selected="selectedGender"
                :tabindex="4"
                :dropdown="this.$dropdownData.genderDropdown"
                :optionDefault="employee"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <div class="model__text">
                <span
                  >Số CMTND/ Căn cước(<span class="required-input">*</span
                  >)</span
                >
              </div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtIdentityNumber"
                placeholder="0123456789..."
                required
                :class="{ 'input--alert': $v.employee.IdentityNumber.$error }"
                v-model.trim="$v.employee.IdentityNumber.$model"
              />
              <div
                class="float--alert"
                v-if="
                  !$v.employee.IdentityNumber.required &&
                  $v.employee.IdentityNumber.$dirty
                "
              >
                Thông tin bắt buộc nhập
              </div>
              <div
                class="float--alert"
                v-if="
                  !$v.employee.IdentityNumber.numeric &&
                  $v.employee.IdentityNumber.$dirty
                "
              >
                Không dúng định dạng
              </div>
            </div>
            <div class="info-column">
              <div class="model__text">
                <span>Ngày cấp</span>
              </div>
              <input
                type="date"
                class="modal__field-input field-input-label"
                id="dIdentityDate"
                v-model="employee.IdentityDate"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <div class="model__text">
                <span>Nơi cấp</span>
              </div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtIdentityPlace"
                placeholder="Hà Nội..."
                v-model="employee.IdentityPlace"
              />
            </div>
            <div class="info-column"></div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <div class="model__text">
                <span>Email(<span class="required-input">*</span>)</span>
              </div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtEmail"
                placeholder="Example@gmail.com..."
                required
                :class="{
                  'input--alert': $v.employee.Email.$error,
                }"
                v-model.trim="$v.employee.Email.$model"
              />
              <div
                class="float--alert"
                v-if="!$v.employee.Email.required && $v.employee.Email.$dirty"
              >
                Thông tin bắt buộc nhập
              </div>
              <div
                class="float--alert"
                v-if="!$v.employee.Email.email && $v.employee.Email.$dirty"
              >
                Không dúng định dạng
              </div>
            </div>
            <div class="info-column">
              <div class="model__text">
                <span
                  >Số điện thoại (<span class="required-input">*</span>)</span
                >
              </div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtPhoneNumber"
                placeholder="0123456789..."
                required
                :class="{
                  'input--alert': $v.employee.PhoneNumber.$error,
                }"
                v-model.trim="$v.employee.PhoneNumber.$model"
              />
              <div
                class="float--alert"
                v-if="
                  !$v.employee.PhoneNumber.required &&
                  $v.employee.PhoneNumber.$dirty
                "
              >
                Thông tin bắt buộc nhập
              </div>
              <div
                class="float--alert"
                v-if="
                  !$v.employee.PhoneNumber.numeric &&
                  $v.employee.PhoneNumber.$dirty
                "
              >
                Không dúng định dạng
              </div>
            </div>
          </div>

          <div class="info-title">
            <span>b. thông tin công việc:</span>
            <div class="title-layout"></div>
          </div>
          <div class="info-row">
            <div class="info-column" id="txtPosition">
              <div class="model__text"><span>Vị trí</span></div>
              <base-dropdown
                @selected="selectedPosition"
                :tabindex="4"
                :dropdown="this.$dropdownData.positionDropdown"
                :optionDefault="employee"
              />
            </div>
            <div class="info-column" id="txtDepartment">
              <div class="model__text"><span>Phòng ban</span></div>
              <base-dropdown
                @selected="selectedDepartment"
                :tabindex="4"
                :dropdown="this.$dropdownData.departmentDropdown"
                :optionDefault="employee"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <div class="model__text"><span>Mã số thuế cá nhân</span></div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtPersonalTaxCode"
                placeholder="0123456789"
                :class="{
                  'input--alert': $v.employee.PersonalTaxCode.$error,
                }"
                v-model.trim="$v.employee.PersonalTaxCode.$model"
              />
              <div
                class="float--alert"
                v-if="
                  !$v.employee.PersonalTaxCode.numeric &&
                  $v.employee.PersonalTaxCode.$dirty
                "
              >
                Không dúng định dạng
              </div>
            </div>

            <div class="info-column">
              <div class="model__text"><span>Mức lương cơ bản</span></div>
              <DxNumberBox
                class="modal__field-input field-input-label text--right"
                v-model="employee.Salary"
                format="#,##0.## (VND)"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <div class="model__text"><span>Ngày gia nhập công ty</span></div>
              <input
                type="date"
                class="modal__field-input field-input-label"
                id="dJoinDate"
                v-model="employee.JoinDate"
              />
            </div>
            <div class="info-column" id="txtWorkStatus">
              <div class="model__text"><span>Tình trạng công việc</span></div>
              <base-dropdown
                @selected="selectedWorkStatus"
                :tabindex="4"
                :dropdown="this.$dropdownData.workStatusDropdown"
                :optionDefault="employee"
              />
            </div>
          </div>
        </div>
      </div>
      <!-- Modal Popup Footer -->
      <div class="modal__foot">
        <div
          class="button--secondary button__cancel"
          id="btnCancel"
          @click="btnCancelOnClick"
        >
          Hủy
        </div>
        <div
          class="button--primary button__icon button__save"
          id="btnSave"
          @click="btnSaveOnClick"
        >
          <i class="far fa-save"></i>
          <div class="button__text">Lưu</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import DxNumberBox from "devextreme-vue/number-box";
import EmployeesAPI from "@/api/components/EmployeesAPI.js";
import PositionAPI from "@/api/components/PositionAPI.js";
import DepartmentAPI from "@/api/components/DepartmentAPI.js";
import FormatData from "@/utils/format/FormatData.js";
import { required, numeric, email } from "vuelidate/lib/validators";
import EmployeeModel from "@/models/EmployeeModel.js";

export default {
  components: {
    DxNumberBox,
  },
  validations: {
    employee: {
      EmployeeCode: { required },
      FullName: { required },
      IdentityNumber: { required, numeric },
      Email: { required, email },
      PhoneNumber: { required, numeric },
      PersonalTaxCode: { numeric },
    },
  },
  created() {

    PositionAPI.getAll()
      .then((res) => {
        this.$dropdownData.position.data = res.data;
      })
      .catch((err) => {
        console.log(err);
      });

    DepartmentAPI.getAll()
      .then((res) => {
        this.$dropdownData.department.data = res.data;
      })
      .catch((err) => {
        console.log(err);
      });
  },
  props: {
    isHidden: {
      type: Boolean,
      default: true,
      required: true,
    },
    employeeId: {
      type: String,
      required: true,
    },
    mode: {
      type: Number,
      required: true,
      default: 0, // 0 là thêm 1 là sửa
    },
  },
  methods: {
    /**
     * Tắt màn hình EmployeeDetail
     * Autthor: PHDUONG(2/8/2021)
     */
    btnCancelOnClick() {
      this.$emit("btnAddOnClick", true);
    },
    /**
     * Lưu/sửa thông tin nhân viên
     * Autthor: PHDUONG(2/8/2021)
     */
    btnSaveOnClick() {
      this.$v.$touch();

      if (!this.$v.$invalid) {
        let vm = this;
        if (this.mode == 0) {
          console.log(vm.employee.Salary);
          debugger;
          EmployeesAPI.create(vm.employee)
            .then(() => {
              // console.log(res.data);
              alert("Thêm mới thành công");
            })
            .catch((error) => {
              // debugger
              switch (error.response.data.data["Server Error Code"]) {
                case 1048:
                  alert("Họ tên ko được để trống"); // FullName null
                  break;
                case 1062:
                  alert("Mã nhân viên đã tồn tại"); // Trùng key
                  break;
                default:
                  alert(
                    `Đã có lỗi xảy ra, mã lỗi: ${error.response.data.data["Server Error Code"]}, chi tiết lỗi: ${error.response.data.devMsg}`
                  ); // end up here all the time
                  break;
              }
            });
        } else {
          EmployeesAPI.create(vm.employeeId, vm.employee)
            .then(() => {
              // console.log(res.data);
              // vm.employee = res.data;
              alert("Sửa thành công");
            })
            .catch((error) => {
              switch (error.response.data.data["Server Error Code"]) {
                case 1048:
                  alert("Họ tên ko được để trống"); // FullName null
                  break;
                case 1062:
                  alert("Mã nhân viên đã tồn tại"); // Trùng key
                  break;
                default:
                  alert(
                    `Đã có lỗi xảy ra, mã lỗi: ${error.response.data.data["Server Error Code"]}, chi tiết lỗi: ${error.response.data.devMsg}`
                  ); // end up here all the time
                  break;
              }
            });
        }
      }
    },

    /**
     * Lấy dữ liệu gender
     * Author: PHDUONG(3/8/2021)
     */
    selectedGender(value,name) {
      this.employee.Gender = +value;
      this.employee.GenderName = name;
    },
    /**
     * Lấy dữ liệu WorkStatus vào model
     * Autthor: PHDUONG(3/8/2021)
     */
    selectedWorkStatus(value) {
      this.employee.WorkStatus = +value;
    },
    /**
     * Lấy dữ liệu Department vào model
     * Autthor: PHDUONG(3/8/2021)
     */
    selectedDepartment(value,name) {
      this.employee.DepartmentId = value;
      this.employee.DepartmentName = name;
    },
    /**
     * Lấy dữ liệu Position vào model
     * Autthor: PHDUONG(3/8/2021)
     */
    selectedPosition(value,name) {
      this.employee.PositionId = value;
      this.employee.PositionName = name;
    },
  },
  data() {
    return {
      employee: EmployeeModel.initData(),
      name: "",
    };
  },
  watch: {
    /**
     * Format thông tin ngày tháng trước khi gắn lên form
     * Autthor: PHDUONG(2/8/2021)
     */
    employee: {
      deep: true,
      handler() {
        this.employee.DateOfBirth = FormatData.formatDate(
          this.employee.DateOfBirth,
          true
        );
        this.employee.IdentityDate = FormatData.formatDate(
          this.employee.IdentityDate,
          true
        );
        this.employee.JoinDate = FormatData.formatDate(
          this.employee.JoinDate,
          true
        );
      },
    },
    /**
     * Lấy dữ liệu nhân viên từ server theo Id
     * Autthor: PHDUONG(2/8/2021)
     */
    employeeId: function (id) {
      let vm = this;
      EmployeesAPI.getById(id)
        .then((res) => {
          vm.employee = res.data;
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Kiểm tra thêm hay sửa
     * Autthor: PHDUONG(2/8/2021)
     */
    mode: function () {
      if (this.mode == 0) {
        this.employee = {};
      }
    },
  },
};
</script>