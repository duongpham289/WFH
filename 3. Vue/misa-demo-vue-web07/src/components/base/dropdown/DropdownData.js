export default {
    restaurantDropdown: "restaurant",
    restaurant: {
        data: [{
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

    genderDropdown: "gender",
    gender: {
        data: [{
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
    
    workStatusDropdown: "work",
    workStatus: {
        data: [{
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

    departmentDropdown: "department",
    department: {
        data: [],
        select: {
            name: "DepartmentName",
            value: "DepartmentId"
        }
    },

    positionDropdown: "position",
    position: {
        data: [],
        select: {
            name: "PositionName",
            value: "PositionId"
        }
    },
}