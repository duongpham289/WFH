class GetData {
    static getEmployees = () => {
        const self = this;
        try {
            $('tbody').empty();
            $.ajax({
                url: Variables.getEmployeesApi,
                method: "GET",
            }).done(function (res) {
                EmployeePage.listName = res;
                EmployeePage.renderTable(res);
            }).fail(function (res){
                alert(res);
            })
        } catch (error) {
            console.log(error);
        }
    }

    

/**
 * Lấy dữ liệu Phòng ban
 *  CreatedBy: PHDUONG (23/07/2021)
 */
static getDepartments() {
    $.ajax({
        url: Variables.getDepartmentsApi, //địa chỉ API
        method: "GET", //phương thức
    }).done(function(res) {
        var data = res;
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
static getPositions() {
    $.ajax({
        url: Variables.getPositionsApi, //địa chỉ API
        method: "GET", //phương thức
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

}