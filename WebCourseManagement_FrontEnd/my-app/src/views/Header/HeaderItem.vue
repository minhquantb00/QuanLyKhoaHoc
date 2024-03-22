<template>
  <div>
    <div id="header-course">
      <div class="container d-flex">
        <div class="logo mt-1">
          <a class="" href="/">
            <img
              src="../../assets/image/logo2.png"
              width="120px"
              height="60px"
            />
          </a>
        </div>
        <v-row>
          <v-col cols="6">
            <div class="search-header d-flex mt-3">
              <div class="search-icon">
                <font-awesome-icon
                  icon="fa-solid fa-magnifying-glass"
                ></font-awesome-icon>
              </div>
              <div class="search-input">
                <input
                  class="search-input-item"
                  type="text"
                  placeholder="Tìm kiếm từ khóa"
                />
              </div>
            </div>
          </v-col>
          <v-col>
            <div class="header-left d-flex">
              <v-row>
                <v-col cols="2">
                  <div class="mt-6">
                    <div class="course-me">
                      <font-awesome-icon
                        style="font-size: 20px"
                        icon="fa-solid fa-book"
                      ></font-awesome-icon>
                      <span class=""> Khóa học của tôi </span>
                      <div class="hover-course-me">
                        <p class="mb-5 text-center">
                          Cho phép nhóm của bạn truy cập vào hơn 25.000 khóa học
                          hàng đầu của Udemy, ở mọi nơi và mọi lúc.
                        </p>
                        <div class="text-center">
                          <!-- <router-link to="/my-course"> -->
                          <v-btn
                            :disabled="loading"
                            :loading="loading"
                            class="text-none"
                            color="black"
                            size="x-large"
                            variant="flat"
                            @click="LessonCourses"
                          >
                            Khóa học của bạn
                          </v-btn>
                          <!-- </router-link> -->
                        </div>
                      </div>
                    </div>
                  </div>
                </v-col>
                <v-col cols="3">
                  <div class="">
                    <div class="mt-6 ml-16">
                      <div class="teaching-header">
                        <font-awesome-icon
                          style="font-size: 20px"
                          icon="fa-solid fa-school"
                        ></font-awesome-icon>
                        <span> Giảng dạy</span>
                        <div class="hover-teaching">
                          <p class="mb-5 text-center">
                            Ở đây bạn có thể tạo những video giảng dạy của riêng
                            bạn trên Mybugs. Bạn đã sẵn sàng chưa ?
                          </p>
                          <div class="text-center">
                            <!-- <router-link to="/course-product"> -->
                            <v-btn
                              :disabled="disabled"
                              :loading="loading"
                              class="text-none"
                              color="black"
                              size="x-large"
                              variant="flat"
                              @click="startTeaching"
                            >
                              Bắt đầu giảng dạy
                            </v-btn>
                            <!-- </router-link> -->
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </v-col>
                <v-col cols="1">
                  <div class="ml-6">
                    <div class="mt-3">
                      <div class="cart-header">
                        <v-btn class="text-none" icon variant="text">
                          <v-badge color="purple-accent-4" content="9" floating>
                            <font-awesome-icon
                              style="font-size: 22px"
                              icon="fa-solid fa-cart-shopping"
                            />
                          </v-badge>
                        </v-btn>

                        <div class="hover-cart">
                          <p class="mb-5 text-center">Giỏ hàng của bạn</p>
                          <div class="text-center">
                            <router-link to="/cart-products">
                              <v-btn
                                :disabled="loading"
                                :loading="loading"
                                class="text-none"
                                color="black"
                                size="x-large"
                                variant="flat"
                                @click="loading = !loading"
                              >
                                Vào giỏ hàng của bạn
                              </v-btn>
                            </router-link>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </v-col>
                <v-col cols="6">
                  <div v-if="userInfo" class="mr-14" style="margin-top: 10px">
                    <v-row>
                      <v-col class="text-right ml-11">
                        <v-btn class="text-none" icon variant="text" dot>
                          <v-badge
                            color="purple-accent-4"
                            content="9"
                            floating
                            dot
                          >
                            <font-awesome-icon
                              style="font-size: 25px"
                              icon="fa-regular fa-bell"
                            />
                          </v-badge>
                        </v-btn>
                      </v-col>
                      <v-col class="text-right mr-4">
                        <v-menu
                          v-model="menu"
                          :close-on-content-click="false"
                          location="bottom"
                        >
                          <template v-slot:activator="{ props }">
                            <v-btn
                              color="black"
                              variant="text"
                              icon
                              class="text-none"
                              v-bind="props"
                            >
                              <v-avatar
                                size="50"
                                :image="userInfo.Image"
                              ></v-avatar>
                            </v-btn>
                          </template>

                          <v-card min-width="300">
                            <router-link
                              to="/user-profile"
                              class="user-header-link"
                            >
                              <v-list>
                                <v-list-item
                                class="user-list-item"
                                  :prepend-avatar="userInfo.Image"
                                  :subtitle="userInfo.Email"
                                  :title="userInfo.Name"
                                >
                                </v-list-item>
                              </v-list>
                            </router-link>
                            <v-divider></v-divider>

                            <v-list>
                              <router-link
                                to="#"
                                class="header-content-user-link"
                              >
                                <v-list-item>Học tập</v-list-item>
                              </router-link>
                              <router-link
                                to="#"
                                class="header-content-user-link"
                              >
                                <v-list-item>
                                  <v-title> Giỏ hàng của tôi </v-title>
                                  <template v-slot:append>
                                    <v-badge
                                      color="purple"
                                      content="6"
                                      inline
                                    ></v-badge>
                                  </template>
                                </v-list-item>
                              </router-link>
                              <router-link
                                to="#"
                                class="header-content-user-link"
                              >
                              </router-link>
                              <router-link
                                to="/start-teaching"
                                class="header-content-user-link"
                                @click="startTeaching"
                              >
                                <v-list-item
                                  >Bảng điều khiển của giảng viên</v-list-item
                                >
                              </router-link>
                            </v-list>
                            <v-divider></v-divider>
                            <router-link
                              to="#"
                              class="header-content-user-link"
                            >
                              <v-list-item>
                                <v-title> Thông báo </v-title>
                                <template v-slot:append>
                                  <v-badge
                                    color="purple"
                                    content="6"
                                    inline
                                  ></v-badge>
                                </template>
                              </v-list-item>
                            </router-link>
                            <router-link
                              to="#"
                              class="header-content-user-link"
                            >
                              <v-list-item>
                                <v-title> Tin nhắn </v-title>
                                <template v-slot:append>
                                  <v-badge
                                    color="purple"
                                    content="6"
                                    inline
                                  ></v-badge>
                                </template>
                              </v-list-item>
                            </router-link>

                            <v-divider></v-divider>
                            <router-link
                              to="/public-records"
                              class="header-content-user-link"
                            >
                              <v-list-item>Hồ sơ công khai</v-list-item>
                            </router-link>
                            <router-link
                              to="/profile-user"
                              class="header-content-user-link"
                            >
                              <v-list-item>Cài đặt tài khoản</v-list-item>
                            </router-link>
                            <a href="/">
                              <v-btn
                                :disabled="loading"
                                :loading="loading"
                                class="text-none"
                                color="black"
                                size="x-large"
                                variant="tonal"
                                block
                                @click="logout()"
                                ><font-awesome-icon
                                  icon="fa-solid fa-right-from-bracket"
                                ></font-awesome-icon
                              ></v-btn>
                            </a>
                          </v-card> </v-menu
                      ></v-col>
                    </v-row>
                  </div>
                  <!-- Nếu không có thông tin người dùng, hiển thị nút Đăng nhập và Đăng ký -->
                  <div v-else class="d-flex align-items-center mt-2 ml-7">
                    <router-link to="/login" class="account-link">
                      <v-btn variant="outlined" class="ma-2"> Đăng nhập </v-btn>
                    </router-link>
                    <router-link to="/register" class="account-link">
                      <v-btn variant="flat" color="black"> Đăng ký </v-btn>
                    </router-link>
                  </div>
                </v-col>
              </v-row>
            </div>
          </v-col>
        </v-row>
      </div>
    </div>
  </div>
</template>

<script>
import { useRouter } from "vue-router";
import { authApi } from "../../apis/Auth/authApi";
import useEmitter from "../../helpers/useEmitter";
console.log(localStorage.getItem("userInfo"));
export default {
  data() {
    return {
      fav: true,
      menu: false,
      message: false,
      hints: true,
      router: useRouter(),
      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null,
    };
  },
  created() {
    console.log(localStorage.getItem("userInfo"));
  },
  methods: {
    logout() {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
    },
    async startTeaching() {
      console.log("Vào đấy");
      if (this.userInfo) {
        this.router.push({ path: "/course-product" });
      } else {
        console.log("vào đây");
        this.router.push({ path: "/login" });
      }
    },
    async LessonCourses() {
      if (!this.userInfo) {
        this.router.push("/login");
      } else {
        this.router.push("/my-course");
      }
    },
  },
};
</script>

<style scoped>
.user-header-link{
  text-decoration: none;
}
.user-list-item:hover{
  color: blueviolet;
}
.account-link {
  color: black;
}
#header-course {
  height: 72px;
  /* background-color: rgb(255, 255, 255); */
  background: transparent;
  backdrop-filter: blur(40px);
  box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px,
    rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
  padding: 0 40px;
  position: fixed;
  width: 100%;
  z-index: 2;
}
.logo-header {
  line-height: 72px;
  background-color: rgb(226, 226, 226);
  border: none;
}
.search-header {
  padding-left: 20px;

  border: 1px rgb(61, 60, 60) solid;
  margin: 0 40px;
  border-radius: 40px;
  line-height: 45px;
}
.search-header input {
  width: 100%;
  display: block;
}
.search-input-item {
  border: none;

  margin-left: 20px;
}
.search-input-item:focus {
  outline: none;
}
.header-left .my-course:hover {
  cursor: pointer;
}
.header-left .my-infor:hover {
  cursor: pointer;
}
.my-infor {
  margin-left: 40px;
}
.dropdownmenu li {
  display: block;
}
.dropdownmenu li a {
  text-decoration: none;
  color: black;
}
#submenu {
  /* left: 0; */
  opacity: 0;
  position: absolute;
  top: 0px;
  visibility: hidden;
  z-index: 1;
}
.dropdownmenu li:hover ul#submenu {
  opacity: 1;
  top: 40px;
  visibility: visible;
}
.type-menu {
  position: absolute;
}
.hover-course-me {
  padding: 10px;
  border: 1px solid rgb(196, 196, 196);
  margin-top: 24px;
  width: 300px;
  border-radius: 3px;
  display: none;
  color: black;
  z-index: 6;
  background: white;
  box-shadow: 1px 1px 4px 1px rgb(205, 205, 205);
}
.hover-teaching {
  padding: 10px;
  border: 1px solid rgb(196, 196, 196);
  margin-top: 24px;
  width: 300px;
  border-radius: 3px;
  color: black;
  display: none;
  z-index: 6;
  background: white;
  box-shadow: 1px 1px 4px 1px rgb(205, 205, 205);
}
.teaching-header:hover .hover-teaching {
  display: block;
}
.teaching-header:hover {
  color: blueviolet;
}
.teaching-header {
  position: absolute;
}
.course-me:hover {
  color: blueviolet;
}
.course-me:hover .hover-course-me {
  display: block;
}
.course-me {
  position: absolute;
}
.cart-header {
  position: absolute;
}
.hover-cart {
  padding: 10px;
  border: 1px solid rgb(196, 196, 196);
  margin-top: 12px;
  width: 300px;
  border-radius: 3px;
  left: 0;
  color: black;
  display: none;
  z-index: 6;
  background: white;
  box-shadow: 1px 1px 4px 1px rgb(205, 205, 205);
}
.cart-header:hover {
  color: blueviolet;
}
.cart-header:hover .hover-cart {
  display: block;
}
.text-type-link {
  text-decoration: none;
  color: black;
}
.text-type-link:hover {
  color: blueviolet;
}
.header-content-user-link {
  text-decoration: none;
  color: black;
}
.header-content-user-link:hover {
  color: blueviolet;
}
</style>
