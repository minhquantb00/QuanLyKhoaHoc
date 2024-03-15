<template>
  <div class="tools">
    <v-row>
      <v-col cols="1">
        <HeaderDashboardVue class="header"></HeaderDashboardVue>
      </v-col>
      <v-col>
        <div class="container">
          <div class="content">
            <div class="content-text mt-4 mb-5">
              <p class="mb-10 mt-10">Công cụ</p>
            </div>
            <!-- <v-container> -->
            <v-row align="center" justify="center">
              <v-col>
                <router-link to="#" class="content-item-link">
                  <v-card
                    variant="outlined"
                    class="mx-auto card-hover"
                    max-width="400"
                  >
                    <v-card-item>
                      <div>
                        <div class="text-overline mb-1"></div>
                        <div class="text-h6 mb-1 text-center">
                          <font-awesome-icon
                            class="content-icon"
                            icon="fa-solid fa-tv"
                          ></font-awesome-icon>
                        </div>
                        <div class="text-center content-card-text">
                          <p>Video thử nghiệm</p>
                        </div>
                        <div class="text-center content-card-text">
                          <span
                            >Nhận ý kiến phản hồi miễn phí từ các chuyên gia
                            video của Udemy về âm thanh, video và cách giảng dạy
                            của bạn.</span
                          >
                        </div>
                      </div>
                    </v-card-item>
                  </v-card>
                </router-link>
              </v-col>
              <v-col>
                <router-link to="#" class="content-item-link">
                  <v-card
                    variant="outlined"
                    class="mx-auto card-hover"
                    max-width="400"
                  >
                    <v-card-item>
                      <div>
                        <div class="text-overline mb-1"></div>
                        <div class="text-h6 mb-1 text-center">
                          <font-awesome-icon
                            class="content-icon"
                            icon="fa-solid fa-chart-line"
                          ></font-awesome-icon>
                        </div>
                        <div class="text-center content-card-text">
                          <p>Thông tin chi tiết về thị trường</p>
                        </div>
                        <div class="text-center content-card-text">
                          <span
                            >Xem dữ liệu thị trường trên toàn Udemy để xây dựng
                            khóa học thành công.</span
                          >
                        </div>
                      </div>
                    </v-card-item>
                  </v-card>
                </router-link>
              </v-col>
              <v-col>
                <router-link to="#" class="content-item-link">
                  <v-card
                    variant="outlined"
                    class="mx-auto card-hover"
                    max-width="400"
                  >
                    <v-card-item>
                      <div>
                        <div class="text-overline mb-1"></div>
                        <div class="text-h6 mb-1 text-center">
                          <font-awesome-icon
                            class="content-icon"
                            icon="fa-solid fa-tag"
                          ></font-awesome-icon>
                        </div>
                        <div class="text-center content-card-text">
                          <p>Tạo hàng loạt coupon</p>
                        </div>
                        <div class="text-center content-card-text">
                          <span
                            >Tạo nhiều coupon cùng một lúc bằng cách tải file
                            CSV lên.</span
                          >
                        </div>
                      </div>
                    </v-card-item>
                  </v-card>
                </router-link>
              </v-col>
            </v-row>
            <!-- </v-container> -->
          </div>
        </div>
      </v-col>
    </v-row>
    <FooterItem class="footer"></FooterItem>
  </div>
</template>

<script>
import FooterItem from "../Header/FooterItem.vue";
import HeaderDashboardVue from "./HeaderDashboard.vue";
export default {
  components: {
    FooterItem,
    HeaderDashboardVue,
  },
};
</script>

<style scope>
.header {
  position: sticky;
  top: 0;
  z-index: 1;
}
.tools {
  height: 800px;
}
.content {
  margin: 0px 60px;
}
.content-item-link {
  text-decoration: none;
  color: #000;
}
.content-icon {
  font-size: 40px;
  margin: 20px 0px;
}
.content-text p {
  font-family: initial;
  font-size: 40px;
  font-weight: bold;
}
.card-hover {
  border-radius: 3px;
  border: 1px solid rgb(209, 209, 209);
  height: 250px;
}
.card-hover:hover {
  background: rgb(207, 207, 207);
}
.content-card-text p {
  font-weight: 700;
  font-size: 17px;
}
.footer{
  border-radius: 0px;
}
</style>
