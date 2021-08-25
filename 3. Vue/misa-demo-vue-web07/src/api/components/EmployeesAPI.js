import BaseAPI from "@/api/base/BaseAPI.js";
import BaseAPIConfig from "../base/BaseAPIConfig.js";

class EmployeesAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "v1/Employees";
  }

  /**
   * Hàm lấy dữ liệu phân trang
   * @param {*} payload
   */
   paging(pageIndex, pageSize, entityFilter, departmentId, positionId) {
    return BaseAPIConfig.get(`${this.controller}/paging?pageIndex=${pageIndex}&pageSize=${pageSize}&employeeFilter=${entityFilter}&departmentId=${departmentId}&positionId=${positionId}`);
  }
}

export default new EmployeesAPI();
