<template>
  <div class="post">
    <v-row>
      <v-col cols="6" v-for="item in listPost" :key="item.id">
        <div class="mx-auto" max-width="400">
          <div class="info-user mb-4">
            <v-list-item class="w-100">
              <template v-slot:prepend>
                <v-avatar
                  color="surface-variant"
                  size="60"
                  :image="item.nguoiTaoBaiViet.anhDaiDien"
                ></v-avatar>
              </template>

              <v-list-item-title>
                {{ item.nguoiTaoBaiViet.hoVaTen }}
              </v-list-item-title>
            </v-list-item>
          </div>
          <v-img
            class="align-end text-white"
            height="400"
            :src="item.anhBaiViet"
            cover
          >
            <v-card-title style="color: #e0e0e0">
              {{ item.tieuDe }}</v-card-title
            >
          </v-img>

          <v-card-subtitle class="pt-4">{{
            formatDate(item.thoiGianTao)
          }}</v-card-subtitle>

          <v-card
            class="overflow-y-auto"
            max-height="600"
            v-scroll.self="onScroll"
          >
            <v-banner class="justify-center text-h5 font-weight-light" sticky>
              {{ item.tieuDe }}
            </v-banner>

            <v-card-text v-html="item.moTa"> </v-card-text>
          </v-card>

          <v-card-actions class="mt-3">
            <v-btn color="purple-accent-3" variant="flat" @click="pheDuyetBaiViet(item.id)"> Phê duyệt </v-btn>
            <v-btn color="purple-accent-3" variant="outlined"> Từ chối </v-btn>
          </v-card-actions>
        </div>
      </v-col>
    </v-row>
    <div class="text-center">
      <v-row justify="center">
        <v-col cols="4">
          <v-container class="max-width">
            <v-pagination
              v-model="page"
              :length="16"
              rounded="circle"
            ></v-pagination>
          </v-container>
        </v-col>
      </v-row>
    </div>
      <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import { postApi } from "../../../apis/Post/postApi";
export default {
  data() {
    return {
      postApi: postApi(),
      page: 1,
      scrollInvoked: 0,
      snackbar: false,
      text:"",
      listPost: [],
    };
  },
  async mounted() {
    try {
      const res = await this.postApi.getAllPostNotYetApproved();
      this.listPost = res;
      console.log(this.listPost);
    } catch (e) {
      console.error("Error call fetching" + e.message);
    }
  },
  methods: {
    async pheDuyetBaiViet(id) {
      const result = await this.postApi.pheDuyetBaiViet(id);
      if (result) {
        this.text = "Phê duyệt thất bại";
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      }else{
        this.text = "Phê duyệt thành công";
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      }
    },
    onScroll() {
      this.scrollInvoked++;
    },
    processDescription(description) {
      const doc = new DOMParser().parseFromString(description, "text/html");
      return doc.body.textContent || "";
    },
    formatDate(dateString) {
      const date = new Date(dateString);
      const day = date.getDate();
      const month = date.getMonth() + 1;
      const year = date.getFullYear();
      const formattedDay = day < 10 ? "0" + day : day;
      const formattedMonth = month < 10 ? "0" + month : month;

      return `${formattedDay}/${formattedMonth}/${year}`;
    },
    reloadPage() {
      location.reload();
    },
  },
};
</script>

<style></style>
