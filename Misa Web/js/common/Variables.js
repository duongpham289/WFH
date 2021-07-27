$(document).ready(() => {
    new Variables();
})


class Variables {
    //Biến cờ lưu tạm id của một nhân viên
    static employeeId = null;

    //Biến kiểm tra xem API đã từng được gọi chưa để load dữ liệu cho dropdown 1 lần duy nhất
    //Author: NQMinh(22/7/2021)
    static APIWasCalled = false;

    //Các element trên trang chủ
    //nút xóa nhân viên
    // static buttonDelete = $('#button__delete-employee');

    //nút thêm nhân viên
    static buttonAdd = $('#button__add-employee');

    //thanh tìm kiếm nhân viên
    // static inputSearch = $('#search-input');

    //nút refresh bảng nhân viên
    static buttonRefresh = $('#button__reload');

    //nội dung chính của web (gồm các mục tìm kiếm, bảng nhân viên, etc)
    static content = $('.content');

    //input tìm kiếm
    // static textBox = $('.text-box--default input');

    //popup modal
    static popupModal = $('.modal__container');

    //các nút paging của footer
    static paginationButtons = $('.pagination .pagination__number');

    //Các element trên table nhân viên
    static employeesTable = $('.content__table');

    //Các element trên header
    //header trái (gồm logo)
    static headerLeft = $('.header--left');
    //header phải(gồm tên nhà hàng, profile user, etc)
    static headerRight = $('.header--right');
    //logo website
    static logo = $('.header .header__logo');

    //Các element trên thanh menu bên trái
    //menu chính
    static menu = $('.menu');
    //các đường link trên thanh menu
    static menuItems = $('.menu__item');
    //các icon trong từng đường link trên thanh menu
    static menuItemIconList =  $('.menu .menu__icon');
    //các text trong từng đường link trên thanh menu
    static menuItemTextList = $('.menu .menu__item-text');
    //nút toggle trên góc trái của web
    static menuToggle = $('.header .header__toggle');

    //Các element trên popup modal
    //Input phần thông tin chung:
    static inputEmployeeCode = $('#txtEmployeeCode');
    static inputName = $('#txtFullName');
    static inputDob = $('#dDateOfBirth');
    static inputId = $('#txtIdentityNumber');
    static inputIdDate = $('#dIdentityDate');
    static inputIdPlace = $('#txIdentityPlace');
    static inputEmail = $('#txtEmail');
    static inputPhone = $('#txtPhoneNumber');
    static inputJoinDate = $('#dJoinDate');

    //Input phần thông tin công việc:
    static inputEmployeeTax = $('#txPersonalTaxCode');
    static inputIncome = $('#txtSalary');
    static popupModalInputs = $('.modal__container input');

    static submitBtn = $('#btnSave');
    static cancelBtn = $('#btnCancel');
    static popupModalCloseBtn = $('.modal__button-close');

    //Element popup message
    static alertMessage = $('.popup__container');
    static alertCloseBtn = $('.popup__button-close');
    static alertCancelBtn = $('.popup__footer .button--secondary');
    static alertDeleteBtn = $('.popup__footer .button--primary');



    static getEmployeesApi = "http://cukcuk.manhnv.net/v1/Employees";
    static getDepartmentsApi = "http://cukcuk.manhnv.net/api/Department";
    static getPositionsApi = "http://cukcuk.manhnv.net/v1/Positions";
}