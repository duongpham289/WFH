$(document).ready(function () {
    new EmployeePage();

    getDepartment();
    getPosition();
    dropdownOnClick();

    $("#btnSave").on("click", addEmployee);
    


})

class EmployeePage{

    listName;

    //Biến kiểm tra xem user khi click vào nút lưu là muốn sửa hay thêm mới nhân viên
    //Author: PHDUONG(28/07/2021)
    static createNewEmployee = false;

    // //Các dropdown trên trang chủ
    // //dropdown chọn nhà hàng
    // static dropdownRestaurant = new Dropdown('#dropdown__restaurant');
    // //dropdown phòng ban ở trang chủ
    // static dropdownRoom = new Dropdown('#dropdown__room');
    // //dropdown vị trí ở trang chủ
    // static dropdownRole = new Dropdown('#dropdown__role');

    // //Các dropdown trên modal
    // //dropdown giới tính
    // static modalSex = new Dropdown('#dropdown__sex');
    // //dropdown vị trị ở modal
    // static modalRole = new Dropdown('#dropdown__modal-role');
    // //dropdown phòng ban ở modal
    // static modalWorkPlace = new Dropdown('#dropdown__work-place');
    // //dropdown trạng thái làm việc
    // static modalWorkStatus = new Dropdown('#dropdown__work-status');

    constructor(){
        //Load dữ liệu
        GetData.getEmployees();

        this.initEvent();
    }
    
    /**
     * Load du lieu len table
     * CreatedBy: PHDUONG (23/07/2021)
     */
    

    //Hàm render dữ liệu bảng nhân viên
    //@params dữ liệu lấy từ server
    //Author: PHDUONG(27/07/2021)
    static renderTable = (tableData) => {
        // console.log(tableData);
        const self = this;

        tableData.forEach(employee => {
            const employeeCode = employee['EmployeeCode'];
            const fullName = employee['FullName'];
            const gender = employee['GenderName'];
            const dob = employee['DateOfBirth'];
            const phone = employee['PhoneNumber'];
            const email = employee['Email'];
            const position = employee['PositionName'];
            const department = employee['DepartmentName'];
            const salary = employee['Salary'];
            const workStatus = employee['WorkStatus'];
            const trHTML = $(`<tr data="${employee['EmployeeId']}">
                                <td>
                                    <div class="delete-box">
                                        <input type="checkbox">
                                        <span class="checkmark"></span>                    
                                    </div>                            
                                </td>
                                <td>${self.clearNull(employeeCode)}</td>
                                <td>${self.clearNull(fullName)}</td>
                                <td>${self.clearNull(gender)}</td>
                                <td>${DataFormatter.formatDate(self.clearNull(dob),false)}</td>
                                <td>${self.clearNull(phone)}</td>
                                <td>${self.clearNull(email)}</td>
                                <td>${self.clearNull(position)}</td>
                                <td>${self.clearNull(department)}</td>
                                <td>${DataFormatter.formatMoney(self.clearNull(salary))}</td>
                                <td>${DataFormatter.formatWorkStatus(self.clearNull(workStatus))}</td>
                            </tr>`);
            $('tbody').append(trHTML);
        })
    }


    static bindingDataToModal = (data) =>{
        Variables.inputEmployeeCode.val(data["EmployeeCode"]);
        Variables.inputFullName.val(data["FullName"]);
        Variables.inputDateOfBirth.val(DataFormatter.formatDate(data["DateOfBirth"],true));
        Variables.inputGenderName.text(data["GenderName"]);
        Variables.inputIdentityNumber.val(data["IdentityNumber"]);
        Variables.inputIdentityDate.val(DataFormatter.formatDate(data["IdentityDate"],true));
        Variables.inputIdentityPlace.val(data["IdentityPlace"]);
        Variables.inputEmail.val(data["Email"]);
        Variables.inputPhoneNumber.val(data["PhoneNumber"]);
        Variables.inputPositionName.text(data["PositionName"] ? data["PositionName"] : "Tất cả vị trí");
        Variables.inputDepartmentName.text(data["DepartmentName"] ? data["DepartmentName"] : "Tất cả phòng ban");
        Variables.inputJoinDate.val(DataFormatter.formatDate(data["JoinDate"],true));
        Variables.inputPersonalTaxCode.val(data["PersonalTaxCode"]);
        Variables.inputSalary.val(DataFormatter.formatMoney(data["Salary"]));
        Variables.inputWorkStatus.attr('value',DataFormatter.formatWorkStatus(data["WorkStatus"]));
    }

    /**
     * Hàm xóa null
     * @param {*} data Dữ liệu đầu vào
     * CreatedBy: PHDUONG (19/07/2021)
     */
    static clearNull = (data) => {
        return data ? data : '';
    }

    initEvent(){
        const self = this;

        //Dãn input theo placeholder
        Variables.textBox.attr('size', Variables.textBox.attr('placeholder').length);

        //Mở modal khi ấn thêm nhân viên
        Variables.buttonAddEmployee.click(() => EmployeePage.openModal());

        //Đóng modal khi ấn dấu x
        Variables.popupModalCloseBtn.click(() => this.closeModal());

        //Đóng modal khi ấn hủy
        Variables.cancelBtn.click(() => this.closeModal());

        //Sự kiện hiển thị checkmark khi ấn vào từng hàng
        Variables.employeesTable.on('click', 'tbody tr', function(){
            self.rowActive(this);
        })

        //Sự kiện Mở modal với thông tin nhân viên khi double click
        Variables.employeesTable.on('dblclick', 'tbody tr', function(){
            const self = this;

            EmployeePage.createNewEmployee = false;

            EmployeePage.openModal();

            Variables.employeeId = $(self).attr('data');
           try {
               $.ajax({
                   url: Variables.getEmployeesByIdApi+'/'+Variables.employeeId,
                   method: "GET",
               }).done(function (res){
                EmployeePage.bindingDataToModal(res);
                   
               })
           } catch (error) {
               
           }
        })
    }

    //Hàm kích hoạt checkbox của từng hàng
    //Author: PHDUONG(28/07/2021)
    rowActive = (self) => {
        //chọn một lượt tất cả check box để duyệt mảng
        const deleteBoxes = document.querySelectorAll('.delete-box input');
        //chọn một hàng cụ thể
        const row = $(self).children()[0];
        //chọn checkbox từ hàng đó
        const checkbox = $(row).children().children()[0];
        $(checkbox).attr('checked', !$(checkbox).attr('checked'));

        let allUnchecked = true;
        deleteBoxes.forEach(box => {
            if (box.getAttribute('checked') === 'checked') {
                allUnchecked =  false;
                Variables.buttonDelete.css('display', 'flex');
            }
            if (allUnchecked) {
                Variables.buttonDelete.css('display', 'none');
            }
        })
    }

    static openModal = () => {
        Variables.popupModalInputs.val(null);

        Variables.popupModal.css("display", "block")
    }
    closeModal = () => {
        Variables.popupModal.css("display", "none")
    }




    validateRequired = () =>{
        const self = this;
        const required = $('input[required]');
        required.blur(function(){
            console.log($(this));
            debugger
            if ($(this).val().trim() === '') {
                
            }
        })
    } 
}





/**
 * Thêm mới dữ liệu nhân viên
 * CreatedBy: PHDUONG (23/7/2021)
 */
function addEmployee() {
    var employee = {};
    employee.EmployeeCode = $('#txtEmployeeCode').val();
    employee.FullName = $('#txtFullName').val();
    employee.DateOfBirth = $('#dDateOfBirth').val();
    employee.Gender = $('#gender').attr('value');
    employee.GenderName =  $('#gender .dropdown__title').text()  ;
    employee.IdentityNumber = $('#txtIdentityNumber').val();
    employee.IdentityDate = $('#dIdentityDate').val();
    employee.IddentityPlace = $('#txtIdentityPlace').val();
    employee.Email = $('#txtEmail').val();
    employee.PhoneNumber = $('#txtPhoneNumber').val();
    employee.Position = $('#txtPosition').attr('value');
    employee.PositionName = $('#txtPosition .dropdown__title').text();
    employee.Department = $('#txtDepartment').attr('value');
    employee.DepartmentName = $('#txtDepartment .dropdown__title').text();
    employee.PersonalTaxCode = $('#txPersonalTaxCode').val();
    employee.Salary = $('#txtSalary').val();
    employee.JoinDate = $('#dJoinDate').val();
    employee.WorkStatus = $('#txtWorkStatus').attr('value');

    debugger
    $.ajax({
        url: "http://cukcuk.manhnv.net/v1/Employees",
        method: "POST",
        data: JSON.stringify(employee),
        dataType: 'json',
        contentType: 'application/json',
        success: function(result) {
            alert("Thêm thành công");
        },
        fail: function(error) {
            console.log(employee);
        }
    });
}



/**
 * Lấy dữ liệu Phòng ban
 *  CreatedBy: PHDUONG (23/07/2021)
 */
function getDepartment() {
    $.ajax({
        url: "http://cukcuk.manhnv.net/api/Department", //địa chỉ API
        method: "GET", //phương thức
        //data:'', //tham số sẽ truyền lên cho API qua bpdy request
        //contentType:'json',//kiểu dữ liệu trả về
        //async: true, đồng bộ/bất đồng bộ
    }).done(function(res) {
        var data = res;
        // var index = 1;
        $.each(data, function(index, item) {

            var dropdownItem = $(`<div class="dropdown__option" value="${item.DepartmentId}"><i class="fas fa-check"></i>${item.DepartmentName}</div>`);
            var comboboxtem = $(`<div class="combobox__item" value="${item.DepartmentId}"">
                                    <span class="icon" > <i class="fas fa-check"></i></span>${item.DepartmentName}
                                </div>`);
            $('#txtDepartment .dropdown__content').append(dropdownItem);
            $('.department-name').append(comboboxtem);

            $(`#${item.DepartmentId}`).on("click", function() {
                console.log(1);
            })
            index++;

        })
    }).fail(function(res) {
        //đưa ra thông báo lỗi cụ thể (tùy theo httpcode - 400, 404.500):
        //thông thường thì:
        //- Mã 400 - BadRequest -lỗi dữ liệu đầu vào từ Cilient
        //- Mã 404 - Địa chỉ URL ko hợp lệ
        // - 500 - lỗi từ phía backend - server 
        alert('Có lỗi xảy ra vui lòng liên hệ MISA');
    })
}


/**
 * Lấy dữ liệu Vị trí
 *  CreatedBy: PHDUONG (23/07/2021)
 */
function getPosition() {
    $.ajax({
        url: "http://cukcuk.manhnv.net/v1/Positions", //địa chỉ API
        method: "GET", //phương thức
        //data:'', //tham số sẽ truyền lên cho API qua bpdy request
        //contentType:'json',//kiểu dữ liệu trả về
        //async: true, đồng bộ/bất đồng bộ
    }).done(function(res) {
        var data = res;
        $.each(data, function(index, item) {

            var dropdownItem = $(`<div class="dropdown__option" value="${item.PositionId}"><i class="fas fa-check"></i>${item.PositionName}</div>`);
            $('#txtPosition .dropdown__content').append(dropdownItem);
            var comboboxtem = $(`<div class="combobox__item" value="${item.PositionId}"">
                                    <span class="icon" > <i class="fas fa-check"></i></span>${item.PositionName}
                                </div>`);
            $('.position-name').append(comboboxtem);
            $(`#${item.PositionId}`).on("click", function() {
                // getEmployeeByPositionId(item.PositionId);
                console.log(item.PositionId);
            })
            index++;
        })

    }).fail(function(res) {
        //đưa ra thông báo lỗi cụ thể (tùy theo httpcode - 400, 404.500):
        //thông thường thì:
        //- Mã 400 - BadRequest -lỗi dữ liệu đầu vào từ Cilient
        //- Mã 404 - Địa chỉ URL ko hợp lệ
        // - 500 - lỗi từ phía backend - server 
        alert('Có lỗi xảy ra vui lòng liên hệ MISA');
    })
}


/**
 * Ẩn hiện dropdown và combobox khi click
 * CreatedBy: PHDUONG (23/7/2021)
 */
 function dropdownOnClick() {



    var dropBtn = "";
    var dropContent = "";
    var dropSpan = "";

    $(".dropdown__button").on("click", function() {
        $(".dropdown__button").next().hide(); //đóng tất cả những dropdown đang mở
        $(this).next().show(); //mở dropdown được lựa chọn
        dropBtn = $(this)[0]; //lưu lại dom của dropdown được chọn
        dropContent = ($(this).next())[0]; //lưu lại dom của Content của dropdown được chọn
        dropSpan = $(this).children()[0]; //lưu lại dom của text span của dropdown được chọn
    })
    
    var comboboxInput ="";
    var comboboxBtn = "";
    var comboboxOtion = "";
    var comboboxBtnIcon = "";

    $(".combobox__input").on("click", function() {
            $(".combobox__input").next().next().hide(); //đóng tất cả những combobox đang mở
            $(this).next().next().show(); //mở combobox được lựa chọn
            comboboxInput = $(this)[0]; //lưu lại dom của combobox input được chọn
            comboboxBtn = ($(this).next())[0]; //lưu lại dom của combobox được chọn
            comboboxBtnIcon = ($(this).next().children())[0]; //lưu lại dom của combobox được chọn
            comboboxOtion = ($(this).next().next())[0]; //lưu lại dom của option của combobox được chọn
            // comboboxSpan = $(this).children()[0]; //lưu lại dom của text span của combobox được chọn
        })
        $(".combobox__button").on("click", function() {
            // debugger
            if($(this)[0]!=comboboxBtn){
                $(".combobox__button").next().hide(); //đóng tất cả những combobox đang mở
                // debugger
                $(this).next().show(); //mở combobox được lựa chọn
                comboboxInput = ($(this).prev())[0]; //lưu lại dom của combobox input được chọn
                comboboxBtn = $(this)[0]; //lưu lại dom của combobox btn được chọn
                comboboxBtnIcon = ($(this).children())[0]; //lưu lại dom của combobox btn icon được chọn
                comboboxOtion = ($(this).next())[0]; //lưu lại dom của option của combobox được chọn
                // comboboxSpan = $(this).children()[0]; //lưu lại dom của text span của combobox được chọn
            }
            
        })
    window.onclick = function(event) {
        // debugger
        if (event.target != dropBtn && event.target != dropContent && event.target != dropSpan) { //đóng dropdown khi click vào những đối tượng khác 
            if (event.target.getAttribute('value') == null) { //đóng dropdown khi click vào những đối tượng ko có value
                if (dropContent)
                    $(".dropdown__button").next().hide(); //đóng tất cả dropdown
            } else {
                // debugger
                if (event.target.parentNode.getAttribute('class')!="combobox") {
                    if(!event.target.parentNode.previousElementSibling.previousElementSibling){
                        // debugger
                        event.target.parentNode.previousElementSibling.firstElementChild.textContent = event.target.innerText; //thay tên của button bằng tên của option đang được chọn
                        // event.target.parentNode.previousElementSibling.firstElementChild.setAttribute("value", event.target.getAttribute('value')); ////thay value của button bằng value của option đang được chọn
                        event.target.parentNode.parentNode.parentNode.setAttribute("value",event.target.getAttribute('value'));
                        // debugger

                        $(".dropdown__button").next().children().css("background-color", "#fff"); //set background của tất cả option
                        $(".dropdown__button").next().children().css("color", "#000"); //set text color của tất cả option
                        event.target.style.background = "#019160"; //set background của option đang được chọn
                        event.target.style.color = "#fff"; //set text color của option đang được chọn

                        setTimeout(() => {  event.target.parentNode.style.display = "none"; }, 1000);
                        return 1;
                }
                }
                
                
            }
        }
        if (event.target != comboboxInput && event.target != comboboxBtn && event.target != comboboxOtion && event.target != comboboxBtnIcon) { //đóng dropdown khi click vào những đối tượng khác 
            if (event.target.getAttribute('value') == null) { //đóng dropdown khi click vào những đối tượng ko có value
                if (comboboxOtion)
                    $(".combobox__input").next().next().hide(); //đóng tất cả dropdown
            } else {
                // debugger
                if(event.target.getAttribute('value') == 0){
                    // debugger
                    // $("table tbody tr").remove();
                    // loadData(); 
                }
                    // event.target.parentNode.previousElementSibling.firstElementChild.textContent = event.target.innerText; //thay tên của button bằng tên của option đang được chọn
                    event.target.parentNode.previousElementSibling.previousElementSibling.setAttribute("value", event.target.innerText); //thay value của input bằng text của option đang được chọn
                    // debugger

                    $(".combobox__input").next().next().children().css("background-color", "#fff"); //set background của tất cả option
                    $(".combobox__input").next().next().children().css("color", "#000"); //set text color của tất cả option
                    event.target.style.background = "#019160"; //set background của option đang được chọn
                    event.target.style.color = "#fff"; //set text color của option đang được chọn
                    setTimeout(() => {  event.target.parentNode.style.display = "none"; }, 1000);
            }
        }
        if (event.target == document.getElementById("modalPopup")) {
            document.getElementById("modalPopup").style.display = "none";
        }
    }
}

function getEmployeeByPositionId(id){
    $.ajax({
        url: "http://cukcuk.manhnv.net/v1/Employees/Filter?positionId=", //địa chỉ API
        method: "GET", //phương thức
        data: JSON.stringify(id),
        //contentType:'json',//kiểu dữ liệu trả về
        //async: true, đồng bộ/bất đồng bộ
    }).done(function(res) {
        var data = res;
        $("table tbody tr").remove();

        $.each(data, function(index, item) {

            var fullName = formatData(item['FullName']);
            var genderName = formatData(item['GenderName']);
            var dateOfBirth = formatDob(item['DateOfBirth']);
            var phoneNumber = formatData(item['PhoneNumber']);
            var email = formatData(item['Email']);
            var positionName = formatData(item['PositionName']);
            var departmentName = formatData(item['DepartmentName']);
            var salary = formatMoney(item['Salary']);
            var workStatus = formatWorkStatus(item['WorkStatus']);

            var tr = $(`<tr>
                    <td class="row-selected"><div><span>` + item.EmployeeCode + `</span></div></td>
                    <td><div title="` + fullName + `"><span>` + fullName + `</span></div></td>
                    <td><div ><span>` + genderName + `</span></div></td>
                    <td><div><span>` + dateOfBirth + `</span></div></td>
                    <td><div><span>` + phoneNumber + `</span></div></td>
                    <td><div title="` + email + `"><span>` + email + `</span></div></td>
                    <td><div  title="` + positionName + `"><span>` + positionName + `</span></div></td>
                    <td><div  title="` + departmentName + `"><span>` + departmentName + `</span></div></td>
                    <td class="salary"><div><span>` + salary + `</span></div></td>
                    <td><div  title="` + workStatus + `"><span>` + workStatus + `</span></div></td>
                </tr>`);

            $('table tbody').append(tr);
            // debugger;
        })

    }).fail(function(res) {
        //đưa ra thông báo lỗi cụ thể (tùy theo httpcode - 400, 404.500):
        //thông thường thì:
        //- Mã 400 - BadRequest -lỗi dữ liệu đầu vào từ Cilient
        //- Mã 404 - Địa chỉ URL ko hợp lệ
        // - 500 - lỗi từ phía backend - server 
        console.log(res);
    })
}