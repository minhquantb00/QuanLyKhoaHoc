<template>
  <div class="efficiency">
    <v-row>
      <v-col cols="1">
        <HeaderDashboardVue class="header"></HeaderDashboardVue>
      </v-col>
      <v-col cols="11">
        <div class="efficiency-content">
          <v-tabs
            v-model="tab"
            align-tabs="center"
            color="deep-purple-accent-4"
          >
            <v-tab :value="1">Tổng quan</v-tab>
            <v-tab :value="2">Học viên</v-tab>
            <v-tab :value="3">Đánh giá</v-tab>
          </v-tabs>
          <v-window v-model="tab">
            <v-window-item v-for="n in 3" :key="n" :value="n">
              <v-container fluid>
                <v-row>
                  <v-col v-for="i in 6" :key="i" cols="12" md="4">
                    <v-img
                      :lazy-src="`https://picsum.photos/10/6?image=${
                        i * n * 5 + 10
                      }`"
                      :src="`https://picsum.photos/500/300?image=${
                        i * n * 5 + 10
                      }`"
                      aspect-ratio="1"
                    ></v-img>
                  </v-col>
                </v-row>
              </v-container>
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
.efficiency {
  /* position: relative; */
  height: 800px;
}
.efficiency-content {
  padding: 10px 90px 0px 0px;
}
</style>
