export default {
    restaurant: {
        options: [{
                RestaurantName: "Nhà Hàng Biển Đông",
                Restaurant: "0"
            },
            {
                RestaurantName: "Nhà Hàng Biển Đông",
                Restaurant: "1"
            },
            {
                RestaurantName: "Nhà Hàng Biển Đông",
                Restaurant: "2"
            }
        ],
        select: {
            name: "RestaurantName",
            value: "Restaurant"
        }
    },
    
    gender: {
        options: [{
                GenderName: "Nữ",
                Gender: "0"
            },
            {
                GenderName: "Nam",
                Gender: "1"
            },
            {
                GenderName: "Không xác định",
                Gender: "2"
            }
        ],
        select: {
            name: "GenderName",
            value: "Gender"
        }
    },

    workStatus: {
        options: [{
                WorkStatusName: "Đang làm việc",
                WorkStatus: "0"
            },
            {
                WorkStatusName: "Đang thử việc",
                WorkStatus: "1"
            },
            {
                WorkStatusName: "Đã nghỉ việc",
                WorkStatus: "2"
            }
        ],
        select: {
            name: "WorkStatusName",
            value: "WorkStatus"
        }
    },

    paginate: {
        options: [{
                PageSizeName: " nhân viên/trang",
                PageSizeVal: "25"
            },
            {
                PageSizeName: " nhân viên/trang",
                PageSizeVal: "20"
            },
            {
                PageSizeName: " nhân viên/trang",
                PageSizeVal: "15"
            },
            {
                PageSizeName: " nhân viên/trang",
                PageSizeVal: "10"
            }
        ],
        select: {
            name: "PageSizeName",
            value: "PageSizeVal"
        }
    },

    department: {
        options: [],
        select: {
            name: "DepartmentName",
            value: "DepartmentId"
        }
    },

    position: {
        options: [],
        select: {
            name: "PositionName",
            value: "PositionId"
        }
    },
}