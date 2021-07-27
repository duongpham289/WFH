<template>
    <div class="content">

        <!-- Phần Header của Content chi tiết:
                - Header Content
                - Nút thêm nhân viên
        -->

        <div class="content__header">
            <div class="content__header header__title">Danh sách nhân viên</div>
            <div class="button__container">
                <div class="button--primary button__icon" id="button__add-employee" @click="btnAddOnClick(1)">
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
                        <input type="text" placeholder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại">
                    </label>
                </div>
                <div class="combobox">
                    <input type="text" class="combobox__input" placeholder="Tất cả phòng ban">
                    <button class="combobox__button"><i class="fas fa-chevron-down icon"></i></button>
                    <div class="combobox__data  department-name" value="0">
                        <div class="combobox__item" value="0">
                            <span class="icon"> <i class="fas fa-check"></i></span>Tất cả Phòng ban
                        </div>
                    </div>
                </div>
                <div class="combobox">
                    <input type="text" class="combobox__input" placeholder="Tất cả vị trí">
                    <button class="combobox__button"><i class="fas fa-chevron-down icon"></i></button>
                    <div class="combobox__data position-name" value="1">
                        <div class="combobox__item" value="0">
                            <span class="icon"> <i class="fas fa-check"></i></span>Tất cả Vị trí
                        </div>
                    </div>
                </div>
            </div>
            <div class="content__filter--right">
                <div class="button--secondary button__icon" id="button__reload">
                    <div class="icon-default -reload"></div>
                </div>
            </div>
        </div>

        <!-- Phần bảng dữ liệu chính của Content -->
        <div class="content__table-container table__employee">
            <table class="content__table">
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
                    <tr v-for="employee in employees" :key="employee.EmployeeId" @dblclick="rowOnDblClick(employee.EmployeeId)">
                        <td>{{employee.EmployeeCode}}</td>
                        <td>{{employee.FullName}}</td>
                        <td>{{employee.FullName}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="content__footer">
            <p>Hiển thị 1-10/10000 nhân viên</p>
            <div class="pagination">
                <img src="../../assets/icon/btn-firstpage.svg" alt="First Page" class="pagination__button" />
                <img src="../../assets/icon/btn-prev-page.svg" alt="Previous Page" class="pagination__button" />
                <div class="pagination__number active"><p>1</p></div>
                <div class="pagination__number"><p>2</p></div>
                <div class="pagination__number"><p>3</p></div>
                <div class="pagination__number"><p>4</p></div>
                <img src="../../assets/icon/btn-next-page.svg" alt="Next Page" class="pagination__button" />
                <img src="../../assets/icon/btn-lastpage.svg" alt="Last Page" class="pagination__button" />
            </div>
            <p>10 nhân viên/trang</p>
        </div>
    </div>
</template>


<script>
import axios from 'axios'
// import VueAxios from 'vue-axios'

export default {
    name: "Content",
    components:{

    },
    created() {
        var vm = this;
        //gọi Api lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees").then(res=>{
            console.log(res.data);
            vm.employees = res.data;
        }).catch(res=>{
            console.log(res);
        })
    },
    // mounted
    // mehod

    methods: {
        btnAddOnClick(number){
            alert(number)
        },
        rowOnDblClick(employeeId){
            alert(employeeId)
        }
    },
    data() {
        return {
            employee:[]
        }
    },
}
</script>