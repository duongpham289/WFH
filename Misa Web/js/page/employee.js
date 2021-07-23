$(document).ready(function () {
    loadData();
})

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
    }).done(function (res) {
        var data = res;
        $.each(data, function (index, item) {

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
                    <td><div><span>`+ item.EmployeeCode + `</span></div></td>
                    <td><div title="`+ fullName + `"><span>` + fullName + `</span></div></td>
                    <td><div ><span>`+ genderName + `</span></div></td>
                    <td><div><span>`+ dateOfBirth + `</span></div></td>
                    <td><div><span>`+ phoneNumber + `</span></div></td>
                    <td><div title="`+ email + `"><span>`+ email + `</span></div></td>
                    <td><div  title="`+ positionName + `"><span>`+ positionName + `</span></div></td>
                    <td><div  title="`+ departmentName + `"><span>`+ departmentName + `</span></div></td>
                    <td class="salary"><div><span>`+ salary + `</span></div></td>
                    <td><div  title="`+ workStatus + `"><span>`+ workStatus + `</span></div></td>
                </tr>`);

            $('table tbody').append(tr);
            // debugger;
        })

    }).fail(function (res) {
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
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("popup-close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function() {
  modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
  modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}


/**
 * Ẩn hiện dropdown và xoay mũi tên tương ứng
 * CreatedBy: PHDUONG (21/07/2021)
 */

var y = '';
/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
/**
 * Ẩn hiện dropdown
 * @param {*} id tag id
 * CreatedBy: PHDUONG (21/07/2021)
 */
function myFunction(id) {
    document.getElementById(id).classList.toggle("show");
    
    var x = document.getElementById('m-'+id);
    y = x;
    if($(".show").length){
        x.style.transform = 'rotate(-135deg)';
    }
}
//lấy tất cả các button menu
var buttons = document.getElementsByClassName('dropbtn');
//lấy tất cả các thẻ chứa menu con
var contents = document.getElementsByClassName('dropdown-content');
//lặp qua tất cả các button menu và gán sự kiện
for (var i = 0; i < buttons.length; i++) {
    buttons[i].addEventListener("click", function(){
        //lấy value của button
        var id = this.value;
        //ẩn tất cả các menu con đang được hiển thị
        for (var i = 0; i < contents.length; i++) {
            contents[i].classList.remove("show");
        }
        //hiển thị menu vừa được click
        myFunction(id);
    });
}
// Close the dropdown if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {

    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
  if($(".show").length == 0){
    y.style.transform = 'rotate(45deg)';
    }
}

