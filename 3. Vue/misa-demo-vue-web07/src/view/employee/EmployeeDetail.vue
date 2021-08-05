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
            <div class="modal__text"><span>A. Thông tin chung:</span></div>

            <div class="title-layout"></div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <!-- <div class="modal__text">
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
              </div> -->
              <base-input
                label="Mã nhân viên"
                id="EmployeeCode"
                :value="employee.EmployeeCode"
                @handle-input="onChangeInput"
                placeholder="NV8888..."
                required
              />
            </div>
            <div class="info-column">
              <!-- <div class="modal__text">
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
              </div> -->
              <base-input
                label="Họ và tên"
                id="FullName"
                :value="employee.FullName"
                @handle-input="onChangeInput"
                placeholder="Nguyễn Văn A..."
                required
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <!-- <div class="modal__text">
                <span>Ngày sinh</span>
              </div>
              <input
                type="date"
                class="modal__field-input field-input-label"
                id="dDateOfBirth"
                v-model="employee.DateOfBirth"
              /> -->
              <base-input
                type="date"
                label="Ngày sinh"
                id="DateOfBirth"
                :value="employee.DateOfBirth"
                @handle-input="onChangeInput"
                required
              />
            </div>
            <div class="info-column" id="gender">
              <div class="modal__text">
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
              <!-- <div class="modal__text">
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
              </div> -->
              <base-input
                label="Số CMTND/ Căn cước"
                id="IdentityNumber"
                :value="employee.IdentityNumber"
                @handle-input="onChangeInput"
                type="number"
                placeholder="0123456789..."
                required
              />
            </div>
            <div class="info-column">
              <!-- <div class="modal__text">
                <span>Ngày cấp</span>
              </div>
              <input
                type="date"
                class="modal__field-input field-input-label"
                id="dIdentityDate"
                v-model="employee.IdentityDate"
              /> -->
              <base-input
                type="date"
                label="Ngày cấp"
                id="IdentityDate"
                :value="employee.IdentityDate"
                @handle-input="onChangeInput"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <!-- <div class="modal__text">
                <span>Nơi cấp</span>
              </div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtIdentityPlace"
                placeholder="Hà Nội..."
                v-model="employee.IdentityPlace"
              /> -->
              <base-input
                label="Nơi cấp"
                id="IdentityPlace"
                :value="employee.IdentityPlace"
                @handle-input="onChangeInput"
                placeholder="Hà Nội..."
              />
            </div>
            <div class="info-column"></div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <!-- <div class="modal__text">
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
              </div> -->
              <base-input
                label="Email"
                id="Email"
                :value="employee.Email"
                @handle-input="onChangeInput"
                type="email"
                placeholder="Example@gmail.com..."
                required
              />
            </div>
            <div class="info-column">
              <!-- <div class="modal__text">
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
              </div> -->
              <base-input
                label="Số điện thoại"
                id="PhoneNumber"
                type="number"
                :value="employee.PhoneNumber"
                @handle-input="onChangeInput"
                placeholder="0123456789..."
                required
              />
            </div>
          </div>

          <div class="info-title">
            <span>b. thông tin công việc:</span>
            <div class="title-layout"></div>
          </div>
          <div class="info-row">
            <div class="info-column" id="txtPosition">
              <div class="modal__text"><span>Vị trí</span></div>
              <base-dropdown
                @selected="selectedPosition"
                :tabindex="4"
                :dropdown="this.$dropdownData.positionDropdown"
                :optionDefault="employee"
              />
            </div>
            <div class="info-column" id="txtDepartment">
              <div class="modal__text"><span>Phòng ban</span></div>
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
              <!-- <div class="modal__text"><span>Mã số thuế cá nhân</span></div>
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
              </div> -->
              <base-input
                label="Mã số thuế cá nhân"
                id="PersonalTaxCode"
                :value="employee.PersonalTaxCode"
                @handle-input="onChangeInput" 
                type="number"
                placeholder="0123456789"
              />
            </div>

            <div class="info-column">
              <!-- <div class="modal__text"><span>Mức lương cơ bản</span></div>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtSalarye"
                placeholder="10.000.000"
                v-model="employee.Salary"
              /> -->
              <base-input
                label="Mức lương cơ bản"
                id="Salary"
                :value="employee.Salary"
                @handle-input="onChangeInput"
                format="money"
                classes="text-right"
                :iconRight="true"
              >
                <template v-slot:icon>
                  <span class="icon">(VNĐ)</span>
                </template>
              </base-input>
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <!-- <div class="modal__text"><span>Ngày gia nhập công ty</span></div>
              <input
                type="date"
                class="modal__field-input field-input-label"
                id="dJoinDate"
                v-model="employee.JoinDate"
              /> -->
              <base-input
                required
                type="date"
                label="Ngày gia nhập công ty"
                id="JoinDate"
                :value="employee.JoinDate"
                @handle-input="onChangeInput"
              />
            </div>
            <div class="info-column" id="txtWorkStatus">
              <div class="modal__text"><span>Tình trạng công việc</span></div>
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
import EmployeesAPI from "@/api/components/EmployeesAPI.js";
// import FormatData from "@/utils/format/FormatData.js";
import { required, numeric, email } from "vuelidate/lib/validators";
import EmployeeModel from "@/models/EmployeeModel.js";

export default {
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
      // this.employee = "";
      this.$nextTick(() => {
        this.$v.$reset();
      });
    },
    /**
     * Reload lại bảng
     * Autthor: PHDUONG(2/8/2021)
     */
    reloadTable() {
      this.$emit("btnReloadOnClick");
    },
    
    onChangeInput({ id, value }) {
      // debugger
      this.employee[id] = value;
    },
    /**
     * Lưu/sửa thông tin nhân viên
     * Autthor: PHDUONG(2/8/2021)
     */
    btnSaveOnClick() {
      this.$v.$touch();
      console.log(this.employee);
      // debugger
      // if (!this.$v.$invalid) {
      //   let vm = this;
      //   if (this.mode == 0) {
      //     console.log(vm.employee.Salary);
      //     debugger;
      //     EmployeesAPI.create(vm.employee)
      //       .then(() => {
      //         // console.log(res.data);
      //         alert("Thêm mới thành công");
      //       })
      //       .catch((error) => {
      //         // debugger
      //         switch (error.response.data.data["Server Error Code"]) {
      //           case 1048:
      //             alert("Họ tên ko được để trống"); // FullName null
      //             break;
      //           case 1062:
      //             alert("Mã nhân viên đã tồn tại"); // Trùng key
      //             break;
      //           default:
      //             alert(
      //               `Đã có lỗi xảy ra, mã lỗi: ${error.response.data.data["Server Error Code"]}, chi tiết lỗi: ${error.response.data.devMsg}`
      //             ); // end up here all the time
      //             break;
      //         }
      //       });
      //   } else {
      //     EmployeesAPI.update(vm.employeeId, vm.employee)
      //       .then(() => {
      //         // debugger
      //         // vm.employee = res.data;
      //         this.btnCancelOnClick();
      //         setTimeout(function () {
      //           this.reloadTable();
      //         }, 3000);

      //         alert("Sửa thành công, xin đợi dữ liệu tải lại");
      //       })
      //       .catch((error) => {
      //         switch (error.response.data.data["Server Error Code"]) {
      //           case 1048:
      //             alert("Họ tên ko được để trống"); // FullName null
      //             break;
      //           case 1062:
      //             alert("Mã nhân viên đã tồn tại"); // Trùng key
      //             break;
      //           default:
      //             alert(
      //               `Đã có lỗi xảy ra, mã lỗi: ${error.response.data.data["Server Error Code"]}, chi tiết lỗi: ${error.response.data.devMsg}`
      //             ); // end up here all the time
      //             break;
      //         }
      //       });
      //   }
      // }
    },
    //#region gắn dữ liệu dropdown
      /**
       * Lấy dữ liệu gender
       * Author: PHDUONG(3/8/2021)
       */
      selectedGender(value, name) {
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
      selectedDepartment(value, name) {
        this.employee.DepartmentId = value;
        this.employee.DepartmentName = name;
      },
      /**
       * Lấy dữ liệu Position vào model
       * Autthor: PHDUONG(3/8/2021)
       */
      selectedPosition(value, name) {
        this.employee.PositionId = value;
        this.employee.PositionName = name;
      },
    //#endregion
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
    // employee: {
    //   deep: true,
    //   handler() {
    //     // debugger
    //     this.employee.DateOfBirth = FormatData.formatDate(
    //       this.employee.DateOfBirth,
    //       true
    //     );
    //     this.employee.IdentityDate = FormatData.formatDate(
    //       this.employee.IdentityDate,
    //       true
    //     );
    //     this.employee.JoinDate = FormatData.formatDate(
    //       this.employee.JoinDate,
    //       true
    //     );
    //     // debugger
    //     this.employee.Salary = FormatData.formatSalary(this.employee.Salary);
    //   },
    // },
    /**
     * Lấy dữ liệu nhân viên từ server theo Id
     * Autthor: PHDUONG(2/8/2021)
     */
    employeeId: function (id) {
      // debugger
      if (id) {
        let vm = this;
        EmployeesAPI.getById(id)
          .then((res) => {
            vm.employee = res.data;
          })
          .catch((res) => {
            console.log(res);
          });
      }
    },
    /**
     * Kiểm tra thêm hay sửa
     * Autthor: PHDUONG(2/8/2021)
     */
    mode: function () {
      if (this.mode == 0) {
        this.employee = {};
        // console.log(this.employee.DepartmentName);
      }
    },
  },
};
</script>