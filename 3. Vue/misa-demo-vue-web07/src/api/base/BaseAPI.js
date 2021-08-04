import BaseAPIConfig from "../base/BaseAPIConfig.js";

export default class BaseAPI {
  constructor() {
    this.controller = null;
  }
  /**
   * Phương thức lấy tất cả dữ liệu
   */
  getAll() {
    return BaseAPIConfig.get(`${this.controller}`);
  }
  /**
   * Phương thức lấy dữ liệu theo Id
   */
  getById(id) {
    return BaseAPIConfig.get(`${this.controller}/${id}`);
  }
  /**
   * Phương thức thêm mới dữ liệu
   */
  create(body) {
    return BaseAPIConfig.post(`${this.controller}`, body);
  }
  /**
   * Hàm lấy dữ liệu phân trang
   * @param {*} payload
   */
  paging(payload) {
    return BaseAPIConfig.post(`${this.controller}/paging`, payload);
  }
  /**
   * Hàm cập nhật dữ liệu
   * @param {*} id
   * @param {*} body
   */
  update(id, body) {
    return BaseAPIConfig.put(`${this.controller}/${id}`, body);
  }
  /**
   * Hàm xóa bản ghi
   * @param {*} id
   */
  delete(id) {
    return BaseAPIConfig.delete(`${this.controller}/delete/${id}`);
  }
}
