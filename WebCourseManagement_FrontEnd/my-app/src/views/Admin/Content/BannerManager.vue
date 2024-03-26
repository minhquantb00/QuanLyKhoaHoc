<template>
  <v-card class="mx-auto">
    <div class="text-right mb-3">
      <v-dialog max-width="500">
        <template v-slot:activator="{ props: activatorProps }">
          <v-btn
            v-bind="activatorProps"
            color="purple-accent-4"
            text="Thêm mới"
            variant="flat"
            class="ma-4"
          ></v-btn>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card title="Thêm banner mới">
            <v-card-text>
              <v-file-input
                label="File input"
                @change="hanldeImageChange"
                v-model="inputAddBanner.anhBanner"
                show-size
              ></v-file-input>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>

              <v-btn
                color="purple-accent-4"
                variant="flat"
                :loading="loading"
                text="Thêm mới"
                @click="addBanner"
              ></v-btn>
              <v-btn
                text="Hủy"
                color="black  "
                variant="outlined"
                @click="isActive.value = false"
              ></v-btn>
            </v-card-actions>
          </v-card>
        </template>
      </v-dialog>
    </div>
    <v-container fluid>
      <v-row dense>
        <v-col cols="4" v-for="card in listBanner" :key="card">
          <v-card>
            <v-img
              :src="card.anhBanner"
              class="align-end"
              gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
              height="200px"
              cover
            >
            </v-img>

            <v-card-actions>
              <v-spacer></v-spacer>

              <v-btn
                color="red"
                icon="mdi-share-variant"
                size="small"
                variant="text"
                ><font-awesome-icon
                  style="font-size: 25px"
                  icon="fa-regular fa-trash-can"
                ></font-awesome-icon
              ></v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
    <div class="text-center">
      <v-container>
        <v-row justify="center">
          <v-col cols="4">
            <v-container>
              <v-pagination
                v-model="page"
                :length="15"
                class="my-4"
              ></v-pagination>
            </v-container>
          </v-col>
        </v-row>
      </v-container>
    </div>
  </v-card>
  <v-snackbar v-model="snackbar">
    {{ text }}
    <template v-slot:actions>
      <v-btn color="green" variant="text" @click="snackbar = false">
        Đóng
      </v-btn>
    </template>
  </v-snackbar>
</template>
<script>
import { bannerApi } from "../../../apis/Banner/bannerApi";
export default {
  data() {
    return {
      bannerApi: bannerApi(),
      page: 1,
      loading:false,
      inputAddBanner: {
        anhBanner: null,
      },
      listBanner:[],
      cards: [
        {
          title: "Pre-fab homes",
          src: "https://cdn.vuetifyjs.com/images/cards/house.jpg",
          flex: 6,
        },
        {
          title: "Pre-fab homes",
          src: "https://cdn.vuetifyjs.com/images/cards/docks.jpg",
          flex: 6,
        },
        {
          title: "Favorite road trips",
          src: "https://cdn.vuetifyjs.com/images/cards/road.jpg",
          flex: 6,
        },
        {
          title: "Best airlines",
          src: "https://cdn.vuetifyjs.com/docs/images/cards/purple-flowers.jpg",
          flex: 6,
        },
      ],
    };
  },
  async mounted() {
   try{
     const res = await this.bannerApi.getAllBanner();
    this.listBanner = res
   }catch(e) {e}
  },
  methods: {
    hanldeImageChange(event) {
      const file = event.target.files[0];
      const maxSizeInBytes = 2 * 1024 * 1024; // 2MB
      const allowedExtensions = [".jpg", ".jpeg", ".png"];
      if (!file) {
        return;
      }
      const fileName = file.name;
      if (file.size > maxSizeInBytes) {
        this.text = "Kích thước ảnh không được vượt quá 2MB";
        this.snackbar = true;
        return;
      }
      const fileExtension = fileName.split(".").pop();
      if (!allowedExtensions.includes("." + fileExtension.toLowerCase())) {
        this.text = "Hệ thống chỉ hỗ trợ file ảnh dạng: jpg, png, jpeg";
        this.snackbar = true;
        return;
      }
      this.imageFile = fileName;
      this.inputAddBanner.anhBanner = file;
    },
    async addBanner() {
      const result = await this.bannerApi.createBanner(
        this.inputAddBanner,
        (this.loading = true)
      );
      if (result) {
        this.text = "Thêm banner thành công";
        this.snackbar = true;
        setTimeout(() => {
          this.loadingPage();
        }, 2000);
      } else {
        this.text = "Thêm banner thất bại";
        this.snackbar = true;
        setTimeout(() => {
          this.loadingPage();
        }, 2000);
      }
    },
    loadingPage() {
      location.reload();
    },
  },
};
</script>
