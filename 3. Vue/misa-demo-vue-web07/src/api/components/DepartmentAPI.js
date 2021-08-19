import BaseAPI from "@/api/base/BaseAPI.js";

class DepartmentAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "v1/Departments";
  }
}

export default new DepartmentAPI();
