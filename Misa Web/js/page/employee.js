$(document).ready(function() {
    loadData();
    modalPopup();
    getDepartment();
    getPosition();

    dropdownOnClick();

    $("#btnSave").on("click", addEmployee);
})



function dropdownOnClick() {
    var dropBtn = "";
    var dropOtion = "";
    var dropSpan = "";

    $(".dropbtn").on("click", function() {
        $(".dropbtn").next().hide();
        $(this).next().show();
        dropBtn = $(this)[0];
        dropOtion = ($(this).next())[0];
        dropSpan = $(this).children()[0];
    })
    window.onclick = function(event) {
        if (event.target != dropBtn && event.target != dropOtion && event.target != dropSpan) {
            if (event.target.getAttribute('value') == null) {
                if (dropOtion)
                    $(".dropbtn").next().hide();
            } else {
                // debugger
                event.target.parentNode.previousElementSibling.firstElementChild.textContent = event.target.innerText
                    // console.log(event.target.textContent);
                    // console.log(event.target.parentNode.previousElementSibling.textContent);
                $(".dropbtn").next().children().css("background-color", "#fff");
                $(".dropbtn").next().children().css("color", "#000");
                event.target.style.background = "#019160";
                event.target.style.color = "#fff";
            }
        }
    }
}

function styleOption() {
    var optionItem = $(".option-item");
    window.onclick = function(event) {
        if (event.target == optionItem) {
            console.log(optionItem)
        }

    }
}

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
 * Load du lieu len table
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

            var optionItem = $(`<div class="option-item" id="${item.DepartmentId}" value="${index}">
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

            var optionItem = $(`<div class="option-item" id="${item.DepartmentId}"  value="${index}">
                            <span class="icon" > <i class="fas fa-check"></i></span>` + item.PositionName + `
                        </div>`);

            $('.position-name').append(optionItem);

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