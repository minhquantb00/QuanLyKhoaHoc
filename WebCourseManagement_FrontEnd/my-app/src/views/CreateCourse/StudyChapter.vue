<template>
  <div>
    <v-row>
      <v-col cols="1">
        <HeaderDashboardVue></HeaderDashboardVue>
      </v-col>
      <v-col>
        <div class="study-chapter">
          <div class="container">
            <link
              rel="stylesheet"
              type="text/css"
              href="https://npmcdn.com/flatpickr/dist/themes/dark.css"
            />
            <v-row>
              <v-col cols="3" v-for="c in listCourse" :key="c">
                <v-hover v-slot="{ isHovering, props }">
                  <v-card v-bind="props">
                    <v-img
                      :src="c.image"
                      height="200px"
                      :aspect-ratio="16 / 9"
                      cover
                    >
                      <v-card-title
                        class="text-white"
                        v-text="c.nameCourse"
                      ></v-card-title>
                      <v-expand-transition>
                        <div
                          v-if="isHovering"
                          class="d-flex transition-fast-in-fast-out bg-grey-lighten-2 v-card--reveal text-h2"
                          style="height: 100%"
                        >
                          <router-link to="/all-lessons">
                            <v-btn color="black"> Tất cả bài học </v-btn>
                          </router-link>
                        </div>
                      </v-expand-transition>
                    </v-img>

                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-dialog persistent max-width="1000 ">
                        <template v-slot:activator="{ props: activatorProps }">
                          <v-btn
                            v-bind="activatorProps"
                            color="grey-darken-4"
                            variant="tonal"
                            :value="this.id"
                          >
                            Thêm bài học</v-btn
                          >
                        </template>

                        <template v-slot:default="{ isActive }">
                          <div>
                            <v-card :title="c.nameCourse" class="pa-5">
                              <label>
                                <span class="obligatory mr-2">*</span>
                                Tên bài học
                              </label>
                              <v-text-field
                                class="mt-3"
                                :rules="rules"
                                color="purple-accent-4"
                                variant="outlined"
                                placeholder="Tên bài học"
                              ></v-text-field>
                              <label>
                                <span class="obligatory mr-2">*</span>
                                Thời lượng video
                              </label>
                              <v-text-field
                                class="mt-3"
                                :rules="rules"
                                color="purple-accent-4"
                                variant="outlined"
                                placeholder="Thời lượng video"
                              ></v-text-field>
                              <label>
                                <span class="obligatory mr-2">*</span>
                                Ngày tạo
                              </label>
                              <div>
                                <flat-pickr
                                  color="purple-accent-4"
                                  class="date-picker mt-2 mb-4"
                                  v-model="today"
                                />
                              </div>
                              <label>
                                <span class="obligatory mr-2">*</span>
                                Video bài học
                              </label>
                               <v-text-field
                                class="mt-3"
                                :rules="rules"
                                color="purple-accent-4"
                                variant="outlined"
                                placeholder="Nhập url của bài học"
                              ></v-text-field>
                              <label class="mb-3 ml-1"> Mô tả </label>
                              <ckeditor
                                :editor="editor"
                                :config="editorConfig"
                                aria-placeholder="Mô tả"
                              ></ckeditor>

                              <v-card-actions>
                                <v-spacer></v-spacer>

                                <v-btn
                                  :disabled="loading"
                                  :loading="loading"
                                  class="text-none mt-4"
                                  color="#9933FF"
                                  size="x-large"
                                  variant="flat"
                                  @click="isActive.value = false"
                                  >Thêm bài học</v-btn
                                >
                                <v-btn
                                  class="text-none mt-4"
                                  color="#000"
                                  size="x-large"
                                  variant="outlined"
                                  @click="isActive.value = false"
                                  >Hủy</v-btn
                                >
                              </v-card-actions>
                            </v-card>
                          </div>
                        </template>
                      </v-dialog>
                      <v-btn variant="tonal">
                        <font-awesome-icon
                          style="font-size: 22px"
                          icon="fa-regular fa-trash-can"
                        ></font-awesome-icon>
                      </v-btn>
                    </v-card-actions>
                  </v-card>
                </v-hover>
              </v-col>
            </v-row>
            <div class="text-center mt-7">
              <v-pagination
                v-model="page"
                :length="15"
                :total-visible="7"
              ></v-pagination>
            </div>
          </div>
        </div>
      </v-col>
    </v-row>
    <FooterItem class="footer"></FooterItem>
  </div>
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import FooterItem from "../Header/FooterItem.vue";
import HeaderDashboardVue from "./HeaderDashboard.vue";
import flatPickr from "vue-flatpickr-component";
import "flatpickr/dist/flatpickr.css";
export default {
  components: {
    flatPickr,
    FooterItem,
    HeaderDashboardVue,
  },
  data() {
    return {
      btn: null,
      page: 1,
      editor: ClassicEditor,
      today: new Date(),
      cards: [
        {
          title: "Pre-fab homes",
          src: "https://cdn.vuetifyjs.com/images/cards/house.jpg",
          flex: 12,
        },
        {
          title: "Favorite road trips",
          src: "https://cdn.vuetifyjs.com/images/cards/road.jpg",
          flex: 6,
        },
        {
          title: "Best airlines",
          src: "https://cdn.vuetifyjs.com/images/cards/plane.jpg",
          flex: 6,
        },
      ],
      listCourse: [
        {
          id: 1,
          image:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          nameCourse: "Chương 1",
          dateStart: "28/09/2022",
          price: 443.992,
          stock: false,
        },
        {
          id: 2,
          image:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          nameCourse: "Chương 2",
          dateStart: "28/09/2022",
          price: 500.473,
          stock: false,
        },
        {
          id: 3,
          image:
            "https://code24h.com/pictures/picfullsizes/2018/08/12/vpn1534042332.jpg",
          nameCourse: "Chương 3",
          dateStart: "28/09/2022",
          price: 57.784,
          stock: false,
        },
        {
          id: 4,
          image:
            "https://amela.vn/wp-content/uploads/2021/08/reactjs-app-development-500x500-1.jpg",
          nameCourse: "Chương 4",
          dateStart: "28/09/2022",
          price: 784.758,
          stock: false,
        },
        {
          id: 5,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Chương 5",
          dateStart: "28/09/2022",
          price: 900.778,
          stock: false,
        },
        {
          id: 6,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Chương 6",
          dateStart: "28/09/2022",
          price: 900.778,
          stock: false,
        },
        {
          id: 7,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Chương 7",
          dateStart: "28/09/2022",
          price: 900.778,
          stock: false,
        },
        {
          id: 8,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Chương 8",
          dateStart: "28/09/2022",
          price: 900.778,
          stock: false,
        },
        {
          id: 9,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Chương 7",
          dateStart: "28/09/2022",
          price: 900.778,
          stock: false,
        },
      ],
    };
  },
};
</script>

<style scope>
.footer {
  border-radius: 0px;
}
.study-chapter {
  padding-top: 30px;
}
.date-picker {
  height: 55px;
  border-radius: 3px;
  border: 1px solid rgb(175, 175, 175);
  padding: 16px;
  width: 100%;
}
.obligatory {
  color: rgb(255, 0, 0);
}
.v-card--reveal {
  align-items: center;
  bottom: 0;
  justify-content: center;
  opacity: 0.9;
  position: absolute;
  width: 100%;
}
</style>
