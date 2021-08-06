export default class FormatData {
    //#region Định dạng dữ liệu ngày tháng
    /**
     * Format dữ liệu ngày sinh sang ngày/tháng/năm
     * @param {*} dob dữ liệu ngày sinh
     * CreatedBy: PHDUONG (19/07/2021)
     */
    static formatDate(str, onModal) {
        let vm = this;
        if (!str || str.length === 0) return '';
        var date = new Date(str);
        return onModal ?
            vm.dateNum(date.getFullYear()) + '-' + vm.dateNum(date.getMonth() + 1) + '-' + vm.dateNum(date.getDate()) :
            vm.dateNum(date.getDate()) + '/' + vm.dateNum(date.getMonth() + 1) + '/' + vm.dateNum(date.getFullYear());
    }

    /**
     * Hàm định dạng cụ thể ngày và tháng
     * @param {*} num 1 con số bất kỳ
     * @returns nếu số x có 1 chữ số thì trả về dưới dạng '0x', nếu không thì trả về đúng số đó
     * CreatedBy: PHDUONG(27/07/2021)
     */
    static dateNum = (num) => {
        return num < 10 ? '0' + num : num
    };
    //#endregion
    
    
    //#region Định dạng tiền tệ
    /**
     * Định dạng tiền trên form
     * @param {*} val Dữ liệu nhập vào 
     * @returns Chuỗi dữ liệu đã được định dạng
     * Author: PHDUONG(05/08/2021)
     */
    static formatMoneyOnModal(val) {
        let vm = this;
        // debugger
        var num = vm.getNumber(val);
        if (num == 0) {
          return  val = "";
        } else {
           return val = num.toLocaleString()
        }
    }
    /**
     * Dữ liệu thô (có cả chữ và số)
     * @param {*} _str Chuỗi dữ liệu đầu vào
     * @returns Chuỗi số được định dạng
     * Author: PHDUONG(05/08/2021)
     */
    static getNumber(_str) {
        // debugger
        if (_str) {
            var arr = _str.toString().split('');
            var out = new Array();
            for (var cnt = 0; cnt < arr.length; cnt++) {
                if (isNaN(arr[cnt]) == false) {
                    out.push(arr[cnt]);
                }
            }
            return Number(out.join(''));
        }
        return "";

    }

    /**
     * Định dạng tiền tệ trên table
     * @param {*} salary  Số tiền
     * CreatedBy: PHDUONG (19/07/2021)
     */
    static formatMoneyOnTable = (salary) => {
        // var salary = new Intl.NumberFormat('vn-VN', { style: 'currency', currency: 'VND' }).format(salary);
        return new Intl.NumberFormat('vn-VN', {
            style: 'currency',
            currency: 'VND'
        }).format(salary);
    }
    //#endregion

    /**
     * Định dạng Tình trạng công việc
     * @param {*} workStatus Tình trạng công việc dạng int
     * @returns Tình trạng công việc dạng strinng
     * CreatedBy: PHDUONG (19/07/2021)
     */
    static formatWorkStatus(workStatus){
        if (workStatus === null || workStatus.length === 0) return '';
        var works = ["Đang làm việc", "Đang thử việc", "Đã nghỉ việc", "Đã nghỉ hưu"]
        if (workStatus < 4) { //workStatus 5 6 chưa biết
            return workStatus = works[workStatus];
        }
        return workStatus = '';
    }
}