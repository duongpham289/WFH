<template>
  <div class="content__footer">
    <p>
      Hiển thị
      <span style="font-weight: bold">
        {{ totalRecord == 0 ? totalRecord : (currentPage - 1) * pageSize + 1 }}-{{ currentPage == totalPage || totalRecord == 0 ? totalRecord : currentPage * pageSize}}/{{
          totalRecord
        }}</span
      >
      nhân viên
    </p>
    <div class="pagination">
      <button
        class="pagination__button first-page"
        :disabled="isInFirstPage"
        @click="onClickFirstPage"
      ></button>
      <button
        class="pagination__button prev-page"
        :disabled="isInFirstPage"
        @click="onClickPrevPage"
      ></button>
      <button
        class="pagination__number"
        v-for="page in pages"
        :key="page.name"
        @click="selectPage(page.name)"
        :disabled="page.isDisabled"
        :class="isPageActive(page.name)"
      >
        <p>{{ page.name }}</p>
      </button>
      <button
        class="pagination__button next-page"
        :disabled="isInLastPage"
        @click="onClickNextPage"
      ></button>
      <button
        class="pagination__button last-page"
        :disabled="isInLastPage"
        @click="onClickLastPage"
      ></button>
    </div>
    <div>
      <base-dropdown
        @selected="selectedPageSize"
        :dropdown="this.$enum.PAGINATE"
        :pageSize="pageSize"
        :defaultState="true"
      />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      currentPage: 1,
      maxVisibleButtons: 4,
    };
  },
  props: {
    pageIndex: {
      type: Number,
      required: true,
    },
    pageSize: {
      type: Number,
      required: true,
      default: null
    },
    totalPage: {
      type: Number,
      required: true,
    },
    totalRecord: {
      type: Number,
      required: true,
      default:0
    },
  },
  computed: {
    // nếu đang ở index đầu (===1) thì disable btn
    isInFirstPage: function () {
      return this.currentPage === 1;
    },

    // nếu đang ở index cuối(===totalPage) thì disable btn
    isInLastPage: function () {
      return this.currentPage === this.totalPage;
    },

    //tạo index đầu
    startPage: function () {

      if (this.currentPage === 1) {
        return 1;
      }

      if (this.currentPage === this.totalPage) {
        if (this.totalPage - this.maxVisibleButtons < 0) {
          return 1;
        } else return this.totalPage - this.maxVisibleButtons + 1;
      }

      return this.currentPage - 1;
    },

    //tạo index cuối
    endPage: function () {
      return Math.min(
        this.startPage + this.maxVisibleButtons - 1,
        this.totalPage
      );
    },

    // tạo các index từ index đầu(startPage) đến index cuối(endPage)
    pages: function () {
      const range = [];

      for (let i = this.startPage; i <= this.endPage; i += 1) {
        range.push({
          name: i,
          isDisabled: i === this.currentPage,
        });
      }

      return range;
    }
  },
  methods: {
    // chọn index trang đầu tiên(=1)
    onClickFirstPage() {
      this.getEmployeePagingData(1, this.pageSize);
      this.currentPage = 1;
    },

    getEmployeePagingData(page, pageSize) {
      this.$emit("pagingOnChange", page, pageSize);
    },
    // chọn index trang cuối cùng(=totalPage)
    onClickLastPage() {
      this.getEmployeePagingData(this.totalPage, this.pageSize);
      this.currentPage = this.totalPage;
    },

    // Chọn index trang ngẫu nhiễn từ range
    selectPage(page) {
      this.getEmployeePagingData(page, this.pageSize);
      this.currentPage = page;
    },

    // chọn index trang tiếp theo của index hiện tại

    onClickNextPage() {
      this.getEmployeePagingData(this.currentPage + 1, this.pageSize);
      this.currentPage += 1;
    },

    // chọn index trang phía sau index hiện tại
    onClickPrevPage() {
      this.getEmployeePagingData(this.currentPage - 1, this.pageSize);
      this.currentPage -= 1;
    },

    /**
     * Lấy dữ liệu
     * Autthor: PHDUONG(3/8/2021)
     */
    selectedPageSize(value) {
      this.pageSize = +value;
      this.currentPage = 1;
      this.$emit("getPageSize", 1, this.pageSize);
    },
    // xét index trang chọn thì class active
    isPageActive: function (page) {
      let tmp = "";

      if (this.currentPage === page) {
        tmp += " active";
      }

      return tmp;
    },
  },
  watch: {
    pageIndex: function () {
      this.currentPage = this.pageIndex;
    },
    totalRecord: function () {
      if (this.totalRecord < this.pageSize || this.totalRecord == 0) {
        this.getEmployeePagingData(1, this.pageSize);
      }
    },
  },
};
</script>