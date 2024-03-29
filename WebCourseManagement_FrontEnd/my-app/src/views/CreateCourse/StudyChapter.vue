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
                      :src="c.anhChuongHoc"
                      height="200px"
                      :aspect-ratio="16 / 9"
                      cover
                    >
                      <v-card-title
                        class="text-white"
                        v-text="c.tenChuong"
                      ></v-card-title>
                      <v-expand-transition>
                        <div
                          v-if="isHovering"
                          class="d-flex transition-fast-in-fast-out bg-grey-lighten-2 v-card--reveal text-h2"
                          style="height: 100%"
                        >
                          <router-link :to="`/all-lessons/${c.id}`">
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
                            @click="inputAddLesson.chuongHocId = c.id"
                          >
                            Thêm bài học</v-btn
                          >
                        </template>

                        <template v-slot:default="{ isActive }">
                          <div>
                            <v-card :title="c.nameCourse" class="pa-5">
                              <input
                              type="hidden"
                                v-model="inputAddLesson.chuongHocId"
                              />
                              <label>
                                <span class="obligatory mr-2">*</span>
                                Tên bài học
                              </label>
                              <v-text-field
                                class="mt-3"
                                :rules="rules"
                                v-model="inputAddLesson.tenBaiHoc"
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
                                v-model="inputAddLesson.thoiLuongVideo"
                                :rules="rules"
                                color="purple-accent-4"
                                variant="outlined"
                                placeholder="Thời lượng video"
                              ></v-text-field>
                              <label>
                                <span class="obligatory mr-2">*</span>
                                Video bài học
                              </label>
                              <v-text-field
                                class="mt-3"
                                :rules="rules"
                                v-model="inputAddLesson.videoBaiHoc"
                                color="purple-accent-4"
                                variant="outlined"
                                placeholder="Nhập url của bài học"
                              ></v-text-field>
                              <label class="mb-3 ml-1"> Mô tả </label>
                              <ckeditor
                                :editor="editor"
                                :config="editorConfig"
                                v-model="inputAddLesson.moTaBaiHoc"
                                v-html="inputAddLesson.moTaBaiHoc"
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
                                  @click="createLesson"
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
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
    <FooterItem class="footer"></FooterItem>
  </div>
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import FooterItem from "../Header/FooterItem.vue";
import HeaderDashboardVue from "./HeaderDashboard.vue";
import flatPickr from "vue-flatpickr-component";
import "flatpickr/dist/flatpickr.css";
import { courseApi } from "../../apis/Course/courseApi";
import { lessonsApi } from "../../apis/Lessons/lessonsApi";
export default {
  components: {
    flatPickr,
    FooterItem,
    HeaderDashboardVue,
  },
  data() {
    return {
      courseApi: courseApi(),
      lessonsApi: lessonsApi(),
      btn: null,
      page: 1,
      text: "",
      snackbar: false,
      editor: ClassicEditor,
      today: new Date(),
      loading: false,
      inputAddLesson: {
        tenBaiHoc: "",
        moTaBaiHoc: "",
        chuongHocId: null,
        videoBaiHoc: "",
        thoiLuongVideo: null,
      },
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
      listCourse: [],
    };
  },
  async mounted() {
    const id = this.$route.params.id;
    try {
      const res = await this.courseApi.getCourseId(id);
      this.listCourse = res.data.chuongHocs;
      console.log("đây là chương học");
      console.log(this.listCourse);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  },
  methods: {
    async createLesson() {
      try {
        const userInfo = JSON.parse(localStorage.getItem("userInfo"));
        const result = await this.lessonsApi.createLessons(
          this.inputAddLesson,
          (this.loading = true)
        );

        if (result) {
          this.text = "Thêm bài học thành công";
          this.snackbar = true;
          setTimeout(() => {
            this.reloadPage();
          }, 2000);
        } else {
          this.text = "Thêm bài học thất bại";
          this.snackbar = true;
        }
      } catch (error) {
        console.error("Đã xảy ra lỗi:", error);
      }
    },
    reloadPage() {
      location.reload();
    },
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
