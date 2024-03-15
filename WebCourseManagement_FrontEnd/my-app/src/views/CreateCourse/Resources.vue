<template>
  <div class="content-resources">
    <v-row>
      <v-col cols="1">
        <HeaderDashboardVue class="header"></HeaderDashboardVue>
      </v-col>
      <v-col>
        <div class="container">
          <div class="content">
            <div class="content-text mt-4 mb-5">
              <p class="mb-10 mt-10">Tài nguyên</p>
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
                            icon="fa-solid fa-person-chalkboard"
                          ></font-awesome-icon>
                        </div>
                        <div class="text-center content-card-text">
                          <p>Teaching Center</p>
                        </div>
                        <div class="text-center content-card-text">
                          <span
                            >Tìm các bài viết về hoạt động giảng dạy trên
                            MyBugs, từ bước tạo khóa học đến khâu
                            marketing.</span
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
                            icon="fa-regular fa-comments"
                          ></font-awesome-icon>
                        </div>
                        <div class="text-center content-card-text">
                          <p>Cộng đồng giảng viên</p>
                        </div>
                        <div class="text-center content-card-text">
                          <span
                            >Chia sẻ tiến độ của bạn và đặt câu hỏi cho các
                            giảng viên khác trong cộng đồng của chúng tôi.</span
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
                            icon="fa-solid fa-circle-question"
                          ></font-awesome-icon>
                        </div>
                        <div class="text-center content-card-text">
                          <p>Trợ giúp và hỗ trợ</p>
                        </div>
                        <div class="text-center content-card-text">
                          <span
                            >Không tìm thấy những gì bạn cần? Nhóm Hỗ trợ của
                            chúng tôi luôn sẵn lòng trợ giúp bạn.</span
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
    // DatetimePicker
  },
};
</script>

<style scope>
.footer{
  border-radius: 0%;
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
</style>
