class DataFormatter{
     

    /**
     * Format dữ liệu ngày sinh sang ngày/tháng/năm
     * @param {*} dob dữ liệu ngày sinh
     * CreatedBy: PHDUONG (19/07/2021)
     */
    static formatDob = (dob,onModal) => {
        if (!dob) return '';
        if (dob.length === 0) return '';
        var date = new Date(dob);
        return onModal ?
            `${this.dateNum(date.getFullYear())}-${this.dateNum(date.getMonth() + 1)}-${this.dateNum(date.getDate())}` :
            `${this.dateNum(date.getDate())}/${this.dateNum(date.getMonth() + 1)}/${this.dateNum(date.getFullYear())}`;
    }

    //Hàm định dạng cụ thể ngày và tháng
    //@params 1 con số bất kỳ
    //@returns nếu số x có 1 chữ số thì trả về dưới dạng '0x', nếu không thì trả về đúng số đó
    //Author: PHDUONG(27/07/2021)
    static dateNum = (num) => {
        return num < 10 ? '0' + num : num
    };

    /**
     * Định dạng tiền tệ
     * @param {*} salary  Số tiền
     * CreatedBy: PHDUONG (19/07/2021)
     */
    static formatMoney = (salary)=> {
        if (!salary) return '';
        var salary = new Intl.NumberFormat('vn-VN', { style: 'currency', currency: 'VND' }).format(salary);
        return salary;
    }

    /**
     * Định dạng Tình trạng công việc
     * @param {*} workStatus Tình trạng công việc dạng int
     * @returns Tình trạng công việc dạng strinng
     * CreatedBy: PHDUONG (19/07/2021)
     */
    static formatWorkStatus = (workStatus) => {
        var works = ["Đang làm việc", "Đang thử việc", "Đã nghỉ việc", "Đã nghỉ hưu"]
        if (workStatus != null && workStatus < 4) { //workStatus 5 6 chưa biết
            return workStatus = works[workStatus];
        }
        return workStatus = '';
    }
}