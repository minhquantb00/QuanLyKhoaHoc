<template>
  <a-layout style="min-height: 100vh">
    <a-layout-sider style="background: #fff">
      <div class="logo text-center ma-3">
        <img src="../../../assets/image/logo2.png" width="100" alt="" />
      </div>
      <a-menu
        v-model:selectedKeys="selectedKeys"
        mode="inline"
        @click="handleMenuClick"
      >
        <a-sub-menu key="sub1">
          <template #title>
            <span>
              <v-icon icon=" mdi-television" class="mr-2"></v-icon>
              <span>Khóa học</span>
            </span>
          </template>
          <a-menu-item key="1">
            <v-icon icon=" mdi-subtitles-outline" class="mr-2"></v-icon>
            Thể loại</a-menu-item
          >
        </a-sub-menu>
        <a-sub-menu key="sub2">
          <template #title>
            <span>
              <v-icon icon=" mdi-content-paste" class="mr-2"></v-icon>
              <span>Nội dung</span>
            </span>
          </template>
          <a-menu-item key="2"
            ><v-icon icon="mdi-content-save-edit-outline" class="mr-3"></v-icon>
            <span>Báo cáo</span></a-menu-item
          >
          <a-menu-item key="3">
            <v-icon icon=" mdi-post-outline" class="mr-2"></v-icon> Bài
            viết</a-menu-item
          >
           <a-menu-item key="7">
            <v-icon icon=" mdi-post-outline" class="mr-2"></v-icon> Thể loại bài
            viết</a-menu-item
          >
          <a-menu-item key="4"
            ><v-icon icon="mdi-image-outline" class="mr-2"></v-icon>
            Banner</a-menu-item
          >
        </a-sub-menu>
        <a-menu-item key="5">
          <v-icon icon=" mdi-account-edit" class="mr-2"></v-icon>

          Người dùng</a-menu-item
        >
        <a-menu-item key="6">
          <font-awesome-icon
            icon="fa-solid fa-chart-line"
            class="mr-3"
          ></font-awesome-icon>
          <span>Thống kê</span>
        </a-menu-item>
      </a-menu>
    </a-layout-sider>
    <a-layout>
      <a-layout-header class="text-right" style="background: #fff; padding: 0">
        <v-menu
          v-model="menu"
          :close-on-content-click="false"
          location="bottom"
        >
          <template v-slot:activator="{ props }">
            <v-btn
              color="black"
              variant="text"
              size="x-large"
              class="text-none mr-1"
              v-bind="props"
            >
              <v-row>
                <v-col>
                  <v-list-item
                    class="text-left"
                    :prepend-avatar="this.userInfo.Image"
                    :subtitle="this.userInfo.role"
                    :title="this.userInfo.Name"
                  >
                  </v-list-item>
                </v-col>
                <v-col cols="2" class="text-center mt-2">
                  <v-icon icon="mdi mdi-chevron-down"></v-icon>
                </v-col>
              </v-row>
            </v-btn>
          </template>

          <v-card min-width="300">
            <v-list>
              <v-list-item
                :prepend-avatar="this.userInfo.Image"
                :subtitle="this.userInfo.role"
                :title="this.userInfo.Name"
              >
              </v-list-item>
            </v-list>

            <v-divider></v-divider>

            <v-list>
              <v-list-item>
                <router-link to="/admin/setting">
                  <v-title> Cài đặt tài khoản </v-title>
                </router-link>
              </v-list-item>
            </v-list>

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
          </v-card>
        </v-menu>
      </a-layout-header>
      <a-layout-content style="margin: 0 16px">
        <a-breadcrumb style="margin: 16px 0">
          <a-breadcrumb-item>
            <v-icon icon="mdi-home-outline" class="mr-1"></v-icon>/
            {{ breadcrumbAdmin }}</a-breadcrumb-item
          >
          <a-breadcrumb-item>{{ breadcrumbText }}</a-breadcrumb-item>
        </a-breadcrumb>

        <router-view
          :key="selectedKeys[0]"
          :style="{ padding: '24px', background: '#fff', minHeight: '360px' }"
        />
      </a-layout-content>
      <a-layout-footer style="text-align: center">
        Ant Design ©2018 Created by Ant UED
      </a-layout-footer>
    </a-layout>
  </a-layout>
</template>

<script setup>
import { ref } from "vue";
import { useRouter } from "vue-router";
const router = useRouter();
const selectedKeys = ref(["1"]);
const breadcrumbAdmin = ref("Admin");
const breadcrumbText = ref("");
const handleMenuClick = ({ key }) => {
  if (key === "1") {
    breadcrumbText.value = "Thể loại khóa học";
    router.push({ name: "the-loai-khoa-hoc" }); // Chuyển hướng đến route con "nguoi-dung"
  } else if (key === "2") {
    breadcrumbText.value = "Báo cáo";
    router.push({ name: "bao-cao" }); // Tương tự cho các route con khác
  } else if (key === "3") {
    breadcrumbText.value = "Bài viết";
    router.push({ name: "bai-viet" });
  } else if (key === "4") {
    breadcrumbText.value = "Banner";
    router.push({ name: "banner" });
  } else if (key === "5") {
    breadcrumbText.value = "Người dùng";
    router.push({ name: "nguoi-dung" });
  } else if (key === "6") {
    breadcrumbText.value = "Thống kê";
    router.push({ name: "thong-ke" });
  }else if (key === "7") {
    breadcrumbText.value = "Thể lọai bài viết";
    router.push({ name: "the-loai-bai-viet" });
  }  else if (key === "") {
    breadcrumbText.value = "Trang chủ";
    router.push({ name: "admin" });
  }
};
</script>

<script>
import UserManager from "../Content/UserManager.vue";
import Statistic from "../Content/Statistic.vue";

export default {
  components: {
    UserManager,
    Statistic,
  },
  methods: {
    logout() {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
    },
  },
  data() {
    return {
      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null,
      fav: true,
      menu: false,
      message: false,
      hints: true,
      User: {
        id: 1,
        name: "Trần Văn Dương",
        chucVu: "Intern",
        image:
          "https://scontent.xx.fbcdn.net/v/t1.15752-9/423737674_1480040725879365_4588731426501580823_n.png?stp=dst-png_s206x206&_nc_cat=101&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeFtB96HRehVZW40v9vLuFrrKZjnfOEJczUpmOd84QlzNQsxUHuJTXwED7HbfLgXRmCE6dC6DZ0JcARCqce6WxDD&_nc_ohc=9bAlxodIY8YAX_BmygY&_nc_ad=z-m&_nc_cid=0&_nc_ht=scontent.xx&oh=03_AdSOlu0qYZN4kdWVccaAfjFdLLbnqN5LU-OI23XFvX_k9g&oe=6616C5B0",
      },
    };
  },
};
</script>

<style scoped>
#components-layout-demo-side .logo {
  height: 32px;
  margin: 16px;
  background: rgba(255, 255, 255, 0.3);
}

.site-layout .site-layout-background {
  background: #fff;
}
[data-theme="dark"] .site-layout .site-layout-background {
  background: #ffffff;
}
.menu-item {
  background: #fff;
}
</style>
