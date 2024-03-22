<template>
  <div>
    <!-- <a-layout class="ant-layout" style="min-height: 400vh; background:#fff"> -->
    <div class="header-layout">
      <v-layout class="content-layout">
        <v-navigation-drawer
          expand-on-hover
          rail
          style="background-color: #2d2f31; color: white"
        >
          <v-list>
            <v-list-item class="logo mb-5">
              <router-link to="/">
                <img
                  src="../../assets/image/logo2.png"
                  alt="Lỗi hình ảnh"
                  width="100"
                />
              </router-link>
            </v-list-item>
            <div class="teacher">
              <router-link class="info-content" to="/user-profile">
                <v-list-item
                  :subtitle="userInfo.Email"
                  :prepend-avatar="userInfo.Image"
                  :title="userInfo.Name"
                ></v-list-item>
              </router-link>
              <hr />
              <div class="hover-teacher">
                <router-link to="#" class="info-content">
                  <p class="ml-4">Học viên</p>
                </router-link>
                <hr />
                <router-link to="#" class="info-content">
                  <p class="ml-4">Thông báo</p>
                </router-link>
                <hr />
                <router-link to="/profile-user" class="info-content">
                  <p class="ml-4">Cài đặt tài khoản</p>
                </router-link>

                <router-link to="#thanh-toan" class="info-content">
                  <p class="ml-4">Cài đặt thanh toán và thuế</p>
                </router-link>
                <hr />
                <router-link to="/public-records" class="info-content">
                  <p class="ml-4">Hồ sơ công khai</p>
                </router-link>
                <hr />
                <router-link to="#" class="info-content">
                  <p class="ml-4">Trợ giúp</p>
                </router-link>
                <router-link to="/" @click="logout" class="info-content">
                  <p class="ml-4">Đăng xuất</p>
                </router-link>
              </div>
            </div>
          </v-list>

          <v-divider></v-divider>

          <v-list density="compact" nav>
            <router-link to="/course-product" class="item-link">
              <v-list-item
                class="mb-4"
                prepend-icon="mdi-television-play"
                title="Khóa học"
                value="1"
              ></v-list-item>
            </router-link>
            <router-link to="/comment" class="item-link">
              <v-list-item
                class="mb-4"
                prepend-icon="mdi-tooltip-text-outline"
                title="Giao tiếp"
                value="2"
              ></v-list-item>
            </router-link>
            <router-link to="/efficiency" class="item-link">
              <v-list-item
                class="mb-4"
                prepend-icon="mdi-poll"
                title="Hiệu suất"
                value="3"
              ></v-list-item>
            </router-link>
            <router-link to="/tools-courses" class="item-link">
              <v-list-item
                class="mb-4"
                prepend-icon="mdi-wrench"
                title="Công cụ"
                value="4"
              ></v-list-item>
            </router-link>
            <router-link to="/resources" class="item-link">
              <v-list-item
                prepend-icon="mdi-earth"
                title="Tài nguyên"
                value="5"
              ></v-list-item>
            </router-link>
          </v-list>
        </v-navigation-drawer>

        <!-- <div style="height: 300px"></div> -->
      </v-layout>
    </div>

    <!-- </a-layout> -->
  </div>
</template>
<script steup>
import FooterItem from "../Header/FooterItem.vue";
import { useRouter } from "vue-router";
import { authApi } from "../../apis/Auth/authApi";
import { ref } from "vue";
const collapsed = ref(false);
const selectedKeys = ref(["1"]);
export default {
  components: {
    FooterItem,
  },
  data() {
    return {
      router: useRouter(),
      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null, // Thông tin người dùng
    };
  },
  created() {
    console.log(localStorage.getItem("userInfo"));
    const userInfo = localStorage.getItem("userInfo");
    // const user = await getUserById(userInfo.id);
    //   retu
    // }
  },
  // async mounted() {
  //   await this.checkAndDecodeToken();
  // },
  methods: {
    // async checkAndDecodeToken() {
    //   const accessToken = JSON.parse(localStorage.getItem("accessToken"));
    //   console.log(accessToken);
    //   if (accessToken) {
    //     try {
    //       const response = await authApi(accessToken);
    //       if (response && response.data) {
    //         console.log(response);
    //         // this.userInfo = response.data;
    //         console.log("Thông tin người dùng:", response.data);
    //       }
    //     } catch (error) {
    //       console.error("Failed to get user info:", error);
    //     }
    //   }
    // },
    logout() {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
    },
  },
};
</script>
<style scoped>
.content-layout {
  height: 100vh;
  /* position: sticky; */
}
.item-link {
  text-decoration: none;
  color: white;
}
.hover {
  width: 100px;
  height: 100px;
}
.header-layout {
  width: 250px;
  /* height: 2000px; */
}
.footer {
  border-radius: 0%;
  margin-top: 80px;
}
.teacher:hover {
  height: 450px;
  transition-timing-function: linear;
}
.teacher {
  width: 100%;
  height: 40px;
  /* background: red; */
  transition: height 0.4s;
}
.hover-teacher {
  color: white;
}
.info-content {
  text-decoration: none;
  color: white;
}
.info-content:hover {
  color: rgb(206, 85, 243);
}
</style>
