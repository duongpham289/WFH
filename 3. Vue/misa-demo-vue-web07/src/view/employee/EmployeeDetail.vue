<template>
  <!-- Phần Modal Popup -->
  <div
    class="modal__container"
    v-bind:class="{ '--hidden': isHidden }"
  >
    <div class="modal">
      <!-- Modal Popup Header -->
      <div class="modal__header">
        <div class="modal__name">Thông tin nhân viên</div>
        <div class="modal__button-close">
          <button class="button--secondary button__close"  @click="btnCancelOnClick"></button>
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
            <span>A. Thông tin chung:</span>
            <div class="title-layout"></div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <span>Mã nhân viên(<span class="required-input">*</span>)</span>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtEmployeeCode"
                placeholder="NV8888..."
                required
                v-model="employee.EmployeeCode"
              />
              <!-- <div class="error" v-if="!$v.name.required">Field is required</div> -->
            </div>
            <div class="info-column">
              <span>Họ và tên(<span class="required-input">*</span>)</span>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtFullName"
                placeholder="Nguyễn Văn A..."
                required
                v-model="employee.FullName"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <span>Ngày sinh</span>
              <input
                type="date"
                class="modal__field-input field-input-label"
                id="dDateOfBirth"
                v-model="employee.DateOfBirth"
              />
            </div>
            <div class="info-column" id="gender">
              <span>Giới tính</span>
              <div class="dropdown" id="dropdown__gender">
                <button class="dropdown__button dropdown__modal--button">
                  <span class="dropdown__title">{{ employee.GenderName ? employee.GenderName : "Chọn giới tính" }}</span>
                  <i class="fas fa-chevron-down"></i>
                </button>
                <div class="dropdown__content dropdown__content--hidden">
                  <div class="dropdown__option" value="0">
                    <i class="fas fa-check"></i>Nữ
                  </div>
                  <div class="dropdown__option" value="1">
                    <i class="fas fa-check"></i>Nam
                  </div>
                  <div class="dropdown__option" value="2">
                    <i class="fas fa-check"></i>Khác
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <span
                >Số CMTND/ Căn cước(<span class="required-input">*</span>)</span
              >
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtIdentityNumber"
                placeholder="0123456789..."
                required
                v-model="employee.txtIdentityNumber"
              />
            </div>
            <div class="info-column">
              <span>Ngày cấp</span>
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
              <span>Nơi cấp</span>
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
              <span>Email(<span class="required-input">*</span>)</span>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtEmail"
                placeholder="Example@gmail.com..."
                required
                v-model="employee.Email"
              />
            </div>
            <div class="info-column">
              <span>Số điện thoại (<span class="required-input">*</span>)</span>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtPhoneNumber"
                placeholder="0123456789..."
                required
                v-model="employee.PhoneNumber"
              />
            </div>
          </div>

          <div class="info-title">
            <span>b. thông tin công việc:</span>
            <div class="title-layout"></div>
          </div>
          <div class="info-row">
            <div class="info-column" id="txtPosition">
              <span>Vị trí</span>
              <div class="dropdown">
                <button class="dropdown__button dropdown__modal--button">
                  <span class="dropdown__title">{{ employee.PositionName ? employee.PositionName : "Vị trí" }}</span>
                  <i class="fas fa-chevron-down"></i>
                </button>
                <div class="dropdown__content dropdown__content--hidden"></div>
              </div>
            </div>
            <div class="info-column" id="txtDepartment">
              <span>Phòng ban</span>
              <div class="dropdown">
                <button class="dropdown__button dropdown__modal--button">
                  <span class="dropdown__title">{{ employee.DepartmentName ? employee.DepartmentName : "Phòng ban" }}</span>
                  <i class="fas fa-chevron-down"></i>
                </button>
                <div class="dropdown__content dropdown__content--hidden"></div>
              </div>
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <span>Mã số thuế cá nhân</span>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtPersonalTaxCode"
                placeholder="0123456789"
                v-model="employee.PersonalTaxCode"
              />
            </div>
            <div class="info-column">
              <span>Mức lương cơ bản</span>
              <input
                type="text"
                class="modal__field-input field-input-label"
                id="txtSalary"
                placeholder="10.000.000"
                v-model="employee.Salary"
              />
            </div>
          </div>
          <div class="info-row">
            <div class="info-column">
              <span>Ngày gia nhập công ty</span>
              <input
                type="date"
                class="modal__field-input field-input-label"
                id="dJoinDate"
                v-model="employee.JoinDate"
              />
            </div>
            <div class="info-column" id="txtWorkStatus">
              <span>Tình trạng công việc</span>
              <div class="dropdown">
                <button class="dropdown__button dropdown__modal--button">
                  <span class="dropdown__title">{{ employee.WorkStatus ? employee.WorkStatus : "Tình trạng công việc" }}</span>
                  <i class="fas fa-chevron-down"></i>
                </button>
                <div class="dropdown__content dropdown__content--hidden">
                  <div class="dropdown__option" value="0">
                    <i class="fas fa-check"></i>Đang làm việc
                  </div>
                  <div class="dropdown__option" value="1">
                    <i class="fas fa-check"></i>Đang thử việc
                  </div>
                  <div class="dropdown__option" value="2">
                    <i class="fas fa-check"></i>Đã nghỉ việc
                  </div>
                  <div class="dropdown__option" value="3">
                    <i class="fas fa-check"></i>Đang nghỉ hưu
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- Modal Popup Footer -->
      <div class="modal__foot">
        <div class="button--secondary button__cancel" id="btnCancel" @click="btnCancelOnClick">Hủy</div>
        <div class="button--primary button__icon button__save" id="btnSave"  @click="btnSaveOnClick">
          <i class="far fa-save"></i>
          <div class="button__text">Lưu</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import axios from "axios";
// import { required, minLength } from 'vuelidate/lib/validators';

export default {
  setup() {},
  // validations: {
  //    name: {
  //     required,
  //     minLength: minLength(4)
  //   },
  // },
  props: {
    isHidden: {
      type: Boolean,
      default: true,
      required: true
    },
    employeeId: {
      type: String,
      required: true
    },
    mode: {
      type: Number,
      required:true,
      default: 0 // 0 là thêm 1 là sửa
    }
  },
  methods: {
    btnCancelOnClick() {
      this.$emit('btnAddOnClick', true);
    },
    btnSaveOnClick() {
      let vm = this;
      if (this.mode == 0) {
        axios
        .post(`http://cukcuk.manhnv.net/v1/Employees/`, vm.employee)
        .then(() => {
            // console.log(res.data);
            alert("Thêm mới thành công")
        })
        .catch((error) => {
          // debugger
          switch (error.response.data.data["Server Error Code"]) {
            case 1048:
                alert("Cột Họ tên ko được để trống");  // FullName null
                break;
            case 1062:
                alert("Mã nhân viên đã tồn tại");  // Trùng key
                break;
            default:
                alert(`Đã có lỗi xảy ra, mã lỗi: ${error.response.data.data["Server Error Code"]}, chi tiết lỗi: ${error.response.data.devMsg}`);  // end up here all the time
                break;
            }
        });
      } else {
        axios
        .put(`http://cukcuk.manhnv.net/v1/Employees/${vm.employeeId}`, vm.employee)
        .then(() => {
            // console.log(res.data);
            // vm.employee = res.data;
            alert("Sửa thành công")
        })
        .catch((error) => {
          switch (error.response.data.data["Server Error Code"]) {
            case 1048:
                alert("Cột Họ tên ko được để trống");  // FullName null
                break;
            case 1062:
                alert("Mã nhân viên đã tồn tại");  // Trùng key
                break;
            default:
                alert(`Đã có lỗi xảy ra, mã lỗi: ${error.response.data.data["Server Error Code"]}, chi tiết lỗi: ${error.response.data.devMsg}`);  // end up here all the time
                break;
            }
        });
      }
    },
    // setName(value) {
    //   this.name = value
    //   this.$v.name.$touch()
    // },
  },
  data() {
    return {
      employee: {},
      //  name: '',
    }
  },
  watch:{
    employee: function () {
      console.log(this.employee);
    },
    employeeId: function (val) {
      let vm = this;

      axios
        .get(`http://cukcuk.manhnv.net/v1/Employees/${val}`)
        .then((res) => {
            // console.log(res.data);
            vm.employee = res.data;
        })
        .catch((res) => {
            console.log(res);
        });
    },
    mode: function () {
      if (this.mode == 0) {
        this.employee = {}
      }
    }
  },
  computed: {
    testEmployeeId: function () {
      return this.employeeId;
    }
  }
};
</script>