$(document).ready(function() {
    loadData();
    modalPopup();
    getDepartment();
    getPosition();
    dropdownOnClick();

    $("#btnSave").on("click", addEmployee);

})


/**
 * Ẩn hiện dropdown và combobox khi click
 * CreatedBy: PHDUONG (23/7/2021)
 */
function dropdownOnClick() {
    var dropBtn = "";
    var dropOtion = "";
    var dropSpan = "";

    $(".dropbtn").on("click", function() {
        $(".dropbtn").next().hide(); //đóng tất cả những dropdown đang mở
        $(this).next().show(); //mở dropdown được lựa chọn
        dropBtn = $(this)[0]; //lưu lại dom của dropdown được chọn
        dropOtion = ($(this).next())[0]; //lưu lại dom của option của dropdown được chọn
        dropSpan = $(this).children()[0]; //lưu lại dom của text span của dropdown được chọn
    })
    
    var comboboxInput ="";
    var comboboxBtn = "";
    var comboboxOtion = "";
    var comboboxBtnIcon = "";

    $(".combobox-input").on("click", function() {
            $(".combobox-input").next().next().hide(); //đóng tất cả những combobox đang mở
            $(this).next().next().show(); //mở combobox được lựa chọn
            comboboxInput = $(this)[0]; //lưu lại dom của combobox input được chọn
            comboboxBtn = ($(this).next())[0]; //lưu lại dom của combobox được chọn
            comboboxBtnIcon = ($(this).next().children())[0]; //lưu lại dom của combobox được chọn
            comboboxOtion = ($(this).next().next())[0]; //lưu lại dom của option của combobox được chọn
            // comboboxSpan = $(this).children()[0]; //lưu lại dom của text span của combobox được chọn
        })
        $(".btn-base-combobox").on("click", function() {
            // debugger
            if($(this)[0]!=comboboxBtn){
                $(".btn-base-combobox").next().hide(); //đóng tất cả những combobox đang mở
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
        if (event.target != dropBtn && event.target != dropOtion && event.target != dropSpan) { //đóng dropdown khi click vào những đối tượng khác 
            if (event.target.getAttribute('value') == null) { //đóng dropdown khi click vào những đối tượng ko có value
                if (dropOtion)
                    $(".dropbtn").next().hide(); //đóng tất cả dropdown
            } else {
                // debugger
                if (event.target.parentNode.getAttribute('class')!="base-combobox") {
                    if(!event.target.parentNode.previousElementSibling.previousElementSibling){
                    event.target.parentNode.previousElementSibling.firstElementChild.textContent = event.target.innerText; //thay tên của button bằng tên của option đang được chọn
                    event.target.parentNode.previousElementSibling.firstElementChild.setAttribute("value", event.target.getAttribute('value')); ////thay value của button bằng value của option đang được chọn
                    // debugger

                    $(".dropbtn").next().children().css("background-color", "#fff"); //set background của tất cả option
                    $(".dropbtn").next().children().css("color", "#000"); //set text color của tất cả option
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
                    $(".combobox-input").next().next().hide(); //đóng tất cả dropdown
            } else {
                // debugger
                if(event.target.getAttribute('value') == 0){
                    // debugger
                    $("table tbody tr").remove();
                    loadData(); 
                }
                    // event.target.parentNode.previousElementSibling.firstElementChild.textContent = event.target.innerText; //thay tên của button bằng tên của option đang được chọn
                    event.target.parentNode.previousElementSibling.previousElementSibling.setAttribute("value", event.target.innerText); //thay value của input bằng text của option đang được chọn
                    // debugger

                    $(".combobox-input").next().next().children().css("background-color", "#fff"); //set background của tất cả option
                    $(".combobox-input").next().next().children().css("color", "#000"); //set text color của tất cả option
                    event.target.style.background = "#019160"; //set background của option đang được chọn
                    event.target.style.color = "#fff"; //set text color của option đang được chọn
                    setTimeout(() => {  event.target.parentNode.style.display = "none"; }, 1000);
            }
        }
    }
}



/**
 * Thêm mới dữ liệu nhân viên
 * CreatedBy: PHDUONG (23/7/2021)
 */
function addEmployee() {
    var employee = {
        CreatedDate: "2021-07-21T08:58:26.162Z",
        CreatedBy: "John Wick",
        ModifiedDate: "2021-07-21T08:58:26.162Z",
        ModifiedBy: "John Wick",
        EmployeeId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        EmployeeCode: "MFa7843",
        FirstName: "Wick",
        LastName: "John",
        FullName: "string",
        Gender: 0,
        DateOfBirth: "2021-07-21T08:58:26.162Z",
        PhoneNumber: "string",
        Email: "string",
        Address: "Ha Noi",
        IdentityNumber: "string",
        IdentityDate: "2021-07-21T08:58:26.162Z",
        IdentityPlace: "string",
        JoinDate: "2021-07-21T08:58:26.162Z",
        MartialStatus: 0,
        EducationalBackground: 0,
        QualificationId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        DepartmentId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        PositionId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        WorkStatus: 0,
        PersonalTaxCode: "string",
        Salary: 0,
        PositionCode: null,
        PositionName: null,
        DepartmentCode: null,
        DepartmentName: null,
        QualificationName: "John Wick",
    };
    employee.EmployeeCode = $('#txtEmployeeCode').val();
    employee.FullName = $('#txtFullName').val();
    employee.DateOfBirth = $('#dDateOfBirth').val();
    // debugger
    $.ajax({
        url: "http://cukcuk.manhnv.net/v1/Employees",
        method: "POST",
        data: JSON.stringify(employee),
        dataType: 'json',
        contentType: 'application/json',
        success: function(result) {
            alert(result);
        },
        fail: function(error) {
            console.log(employee);
        }
    });
}
/**
 * Định dạng dữ liệu Dropdown
 * @param {*} input 
 * @param {*} val value của thẻ span trong button
 * @returns Chuỗi tương ứng
 */
function formatGender(input, val) {
    var gender = ["Nam", "Nữ", "Không xác định"];
    var position = ["Giám đốc", "Nhân viên", "Phó phòng", "Trưởng phòng"];
    var department = ["Phòng Marketting", "Phòng đào tạo", "Phòng Nhân sự", "Phòng Công nghệ"];

    switch (input) {
        case "GenderName":
            input = gender;
            break;
        case "PositionName":
            input = position;
            break;
        case "DepartmentName":
            input = department;
            break;
        default:
            break;
    }

    return input[val];

}


/**
 * Load du lieu len table
 * CreatedBy: PHDUONG (23/07/2021)
 */
function loadData() {
    $.ajax({
        url: "http://cukcuk.manhnv.net/v1/Employees", //địa chỉ API
        method: "GET", //phương thức
        //data:'', //tham số sẽ truyền lên cho API qua bpdy request
        //contentType:'json',//kiểu dữ liệu trả về
        //async: true, đồng bộ/bất đồng bộ
    }).done(function(res) {
        var data = res;
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
        alert('Có lỗi xảy ra vui lòng liên hệ MISA');
    })
}

/**
 * Hàm xóa null
 * @param {*} data Dữ liệu đầu vào
 * CreatedBy: PHDUONG (19/07/2021)
 */
function formatData(data) {
    if (data != null) {
        return data;
    } else {
        return data = '';
    }
}

/**
 * Format dữ liệu ngày sinh sang ngày/tháng/năm
 * @param {*} dob dữ liệu ngày sinh
 * CreatedBy: PHDUONG (19/07/2021)
 */
function formatDob(dob) {
    if (dob) {
        // debugger;
        var dob = new Date(dob);
        var day = dob.getDate(),
            month = dob.getMonth() + 1,
            year = dob.getFullYear();

        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;

        dob = day + '/' + month + '/' + year;
    } else {
        dob = '';
    }

    return dob;
}

/**
 * Định dạng tiền tệ
 * @param {*} salary  Số tiền
 * CreatedBy: PHDUONG (19/07/2021)
 */
function formatMoney(salary) {
    var salary = new Intl.NumberFormat('vn-VN', { style: 'currency', currency: 'VND' }).format(salary);
    return salary;
}

/**
 * Định dạng Tình trạng công việc
 * @param {*} workStatus Tình trạng công việc dạng int
 * @returns Tình trạng công việc dạng strinng
 * CreatedBy: PHDUONG (19/07/2021)
 */
function formatWorkStatus(workStatus) {
    var works = ["Đang làm việc", "Đang thử việc", "Đã nghỉ việc", "Đã nghỉ hưu"]
    if (workStatus != null && workStatus < 4) { //workStatus 5 6 chưa biết
        return workStatus = works[workStatus];
    }
    return workStatus = '';
}

/**
 * Hiệu ứng ẩn hiện modal
 * CreatedBy: PHDUONG (21/07/2021)
 */

// Get the modal
function modalPopup() {

    var modal = document.getElementById("myModal");

    // Get the button that opens the modal
    var btn = document.getElementById("myBtn");

    // Get the <span> element that closes the modal
    var btnClose = document.getElementsByClassName("popup-close")[0];
    var btnCancel = document.getElementsByClassName("m-btn-cancel")[0];

    // When the user clicks the button, open the modal 
    btn.onclick = function() {
        modal.style.display = "block";
    }

    // When the user clicks on <span> (x), close the modal
    btnClose.onclick = function() {
        modal.style.display = "none";
    }
    btnCancel.onclick = function() {
        // setTimeout(() => {  modal.style.display = "none"; }, 2000);
        modal.style.display = "none"; 
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }

    }
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

            var optionItem = $(`<div class="base-combobox-item" id="${item.DepartmentId}" value="${index+1}">
                            <span class="icon" ><i class="fas fa-check"></i></span>` + item.DepartmentName + `
                        </div>`);

            $('.department-name').append(optionItem);

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

            var optionItem = $(`<div class="base-combobox-item" id="${item.PositionId}"  value="${index+1}">
                            <span class="icon" > <i class="fas fa-check"></i></span>` + item.PositionName + `
                        </div>`);

            $('.position-name').append(optionItem);

            $(`#${item.PositionId}`).on("click", function() {
                getEmployeeByPositionId(item.PositionId);
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