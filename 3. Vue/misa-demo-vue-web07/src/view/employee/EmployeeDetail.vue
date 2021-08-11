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
              <base-input
                ref="EmployeeCode"
                label="Mã nhân viên"
                id="EmployeeCode"
                placeholder="NV8888..."
                @handle-input="onChangeInput"
                :value="$v.employee.EmployeeCode.$model"
                :validateRequired="!$v.employee.EmployeeCode.required"
                :dirty="$v.employee.EmployeeCode.$dirty"
                :errorMsg="$v.employee.EmployeeCode.$error"
                required
              >
              </base-input>
            </div>
            <div class="info-column">
              <base-input
                label="Họ và tên"
                id="FullName"
                placeholder="Nguyễn Văn A..."
                @handle-input="onChangeInput"
                :value="$v.employee.FullName.$model"
                :validateRequired="!$v.employee.FullName.required"
                :dirty="$v.employee.FullName.$dirty"
                :errorMsg="$v.employee.FullName.$error"
                required
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <base-input
                label="Ngày sinh"
                id="DateOfBirth"
                type="date"
                @handle-input="onChangeInput"
                :value="employee.DateOfBirth"
              />
            </div>
            <div class="info-column" id="gender">
              <div class="modal__text">
                <span>Giới tính</span>
              </div>
              <base-dropdown
                @selected="selectedGender"
                :dropdown="this.$enum.GENDER"
                :defaultState="isHidden"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <base-input
                label="Số CMTND/ Căn cước"
                id="IdentityNumber"
                type="number"
                placeholder="0123456789..."
                @handle-input="onChangeInput"
                :value="$v.employee.IdentityNumber.$model"
                :validateRequired="!$v.employee.IdentityNumber.required"
                :dirty="$v.employee.IdentityNumber.$dirty"
                :errorMsg="$v.employee.IdentityNumber.$error"
                required
              />
            </div>
            <div class="info-column">
              <base-input
                label="Ngày cấp"
                id="IdentityDate"
                type="date"
                @handle-input="onChangeInput"
                :value="employee.IdentityDate"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
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
              <base-input
                label="Email"
                id="Email"
                type="email"
                placeholder="Example@gmail.com..."
                @handle-input="onChangeInput"
                :value="$v.employee.Email.$model"
                :validateRequired="!$v.employee.Email.required"
                :validateEmail="!$v.employee.Email.email"
                :dirty="$v.employee.Email.$dirty"
                :errorMsg="$v.employee.Email.$error"
                required
              />
            </div>
            <div class="info-column">
              <base-input
                label="Số điện thoại"
                id="PhoneNumber"
                type="number"
                placeholder="0123456789..."
                @handle-input="onChangeInput"
                :value="$v.employee.PhoneNumber.$model"
                :validateRequired="!$v.employee.PhoneNumber.required"
                :dirty="$v.employee.PhoneNumber.$dirty"
                :errorMsg="$v.employee.PhoneNumber.$error"
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
                :dropdown="this.$enum.POSITION"
                :defaultState="isHidden"
              />
            </div>
            <div class="info-column" id="txtDepartment">
              <div class="modal__text"><span>Phòng ban</span></div>
              <base-dropdown
                @selected="selectedDepartment"
                :dropdown="this.$enum.DEPARTMENT"
                :defaultState="isHidden"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
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
                :dropdown="this.$enum.WORKSTATUS"
                :defaultState="isHidden"
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
import { required, email } from "vuelidate/lib/validators";
import EmployeeModel from "@/models/EmployeeModel.js";

export default {
  validations: {
    employee: {
      EmployeeCode: { required },
      FullName: { required },
      IdentityNumber: { required },
      Email: { required, email },
      PhoneNumber: { required },
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
      this.employee = EmployeeModel.initData();
      
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

    /**
     * Đưa dữ liệu tương ứng vào object employee khi nhập input từ modal
     * Autthor: PHDUONG(06/08/2021)
     */
    onChangeInput({ id, value }) {
      this.employee[id] = value;
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
              alert("Thêm mới thành công");
            })
            .catch((error) => {
              console.log(error);
            });
        } else {
          EmployeesAPI.update(vm.employeeId, vm.employee)
            .then(() => {
              this.btnCancelOnClick();
              setTimeout(function () {
                this.reloadTable();
              }, 3000);

              alert("Sửa thành công, xin đợi dữ liệu tải lại");
            })
            .catch((error) => {
              console.log(error);
            });
        }
      }
    },

    //#region Gắn dữ liệu dropdown

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
    
    /**
     * Auto Focus vào ô EmployeeCode
     * Autthor: PHDUONG(11/08/2021)
     */
    autoFocus(){
      this.$nextTick(() =>{
        this.$refs.EmployeeCode.$el.childNodes[1].childNodes[0].focus();
      })
    }
  },
  data() {
    return {
      employee: EmployeeModel.initData(),
      name: "",
    };
  },
  watch: {
    /**
     * Lấy dữ liệu nhân viên từ server theo Id
     * Autthor: PHDUONG(2/8/2021)
     */
    employeeId: function (id) {
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
     * Kiểm tra hành động hiện tai là thêm hay sửa
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