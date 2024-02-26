<template>
    <div class="dropdown_menu_one">
                    <a th:href="@{/movie/movie-type}" onclick="overLoad()"><i class='bx bx-movie-play'></i>Thể loại phim</a>
                    <a th:href="@{/movie/language}" onclick="overLoad()"
                    ><i class='bx bx-world'></i>Ngôn ngữ phim</a
                    >
                    <a th:href="@{/movie/director}" onclick="overLoad()"><i class='bx bxs-user'></i>Đạo diễn phim</a>
                    <a th:href="@{/movie/performer}" onclick="overLoad()"><i class='bx bxs-group'></i>Diễn viên phim</a>
                    <a th:href="@{/rated/find-all}" onclick="overLoad()"><i class='bx bx-child'></i>Phân loại độ
                        tuổi</a>
                    <a th:href="@{/service/service-type}" onclick="overLoad()"><i class='bx bxl-slack'></i>Thể loại
                        dịch vụ</a>
                </div>
</template>
<script>
export default {
    
}
$(document).ready(function () {
    $('.sub-btn_one').click(function () {
        $(this).next('.dropdown_menu_one').slideToggle();
        $(this).find('.dropdown_one').toggleClass('rotate');
    })
});
</script>
<style scoped>
.dropdown_one {
  margin-left: 50px;
}
.dropdown_menu_one a {
  padding: 10px 0px 10px 30px;
}
.admin-menu a .dropdow_one {
  position: absolute;
  right: 0;
  transition: 0.3s ease;
}
.admin-menu .dropdown_menu_one {
  background-color: #414141;
  border-radius: 4px;
  display: none;
}
</style>