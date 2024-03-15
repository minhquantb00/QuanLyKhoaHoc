<template>
  <div class="comment">
    <v-row>
      <v-col cols="1">
        <HeaderDashboardVue class="header"></HeaderDashboardVue>
      </v-col>
      <v-col cols="11">
        <div class="comment-content">
          <v-tabs
            v-model="tab"
            align-tabs="center"
            color="deep-purple-accent-4"
          >
            <v-tab :value="1">Hỏi đáp</v-tab>
            <v-tab :value="2">Tin nhắn</v-tab>
            <v-tab :value="3">Bài tập</v-tab>
            <v-tab :value="4">Thông báo</v-tab>
          </v-tabs>
          <v-window v-model="tab">
            <v-window-item :value="1">
              <h1>Trang hỏi đáp</h1>
            </v-window-item>
            <v-window-item :value="2">
              <h1>Trang Tin Nhắn</h1>
            </v-window-item>
            <v-window-item :value="3">
              <h1>Trang Bài tập</h1>
            </v-window-item>
            <v-window-item :value="4">
              <h1>Trang Thông báo</h1>
            </v-window-item>
          </v-window>
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
  data() {
    return {
      tab: null,
    };
  },
};
</script>
<style scoped>
.header {
  position: sticky;
  top: 0;
  z-index: 1;
}
.footer {
  border-radius: 0%;
}
.comment {
  /* position: relative; */
  height: 800px;
}
.comment-content {
  padding: 10px 90px 0px 0px;
}
</style>
