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
   * Phương thức lấy code mới
   * @param {*} propName 
   * @returns 
   */
  getNewCode(){
    return BaseAPIConfig.get(`${this.controller}/getCode`);
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
  paging(pageIndex, pageSize, entityFilter) {
    return BaseAPIConfig.get(`${this.controller}/paging?pageIndex=${pageIndex}&pageSize=${pageSize}&entityFilter=${entityFilter}`);
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
  delete(listId) {
    return BaseAPIConfig.post(`${this.controller}/delete`,listId);
  }
}
