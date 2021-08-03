<template>
  <div class="content__footer">
    <p>Hiển thị 1-10/10000 nhân viên</p>
    <div class="pagination">
      <img
        src="@/assets/icon/btn-firstpage.svg"
        alt="First Page"
        class="pagination__button"
      />
      <img
        src="@/assets/icon/btn-prev-page.svg"
        alt="Previous Page"
        class="pagination__button"
      />
      <div class="pagination__number active"><p>1</p></div>
      <div class="pagination__number"><p>2</p></div>
      <div class="pagination__number"><p>3</p></div>
      <div class="pagination__number"><p>4</p></div>
      <img
        src="@/assets/icon/btn-next-page.svg"
        alt="Next Page"
        class="pagination__button"
      />
      <img
        src="@/assets/icon/btn-lastpage.svg"
        alt="Last Page"
        class="pagination__button"
      />
    </div>
    <p>10 nhân viên/trang</p>
  </div>
</template>