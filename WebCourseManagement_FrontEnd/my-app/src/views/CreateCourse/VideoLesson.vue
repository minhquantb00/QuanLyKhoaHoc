<template>
  <div class="content-video-lessons">
    <div class="header">
      <div>
        <v-toolbar color="grey-darken-3">
          <router-link to="/">
            <img
              class="ml-3"
              src="../../assets/image/logo2.png"
              alt=""
              width="120"
            />
          </router-link>

          <v-spacer></v-spacer>

          <v-progress-circular
            color="grey-lighten-4"
            size="large"
            model-value="45"
          >
            <font-awesome-icon icon="fa-solid fa-trophy"></font-awesome-icon>
          </v-progress-circular>
          <v-btn id="menu-activator" class="ml-3" vaniants="plain">
            Tiến độ của bạn
            <font-awesome-icon
              class="ml-2"
              icon="fa-solid fa-chevron-down"
            ></font-awesome-icon>
          </v-btn>

          <v-menu activator="#menu-activator">
            <v-list>
              <v-list-item>
                <v-list-item-title>
                  {{ this.tienDo }}/{{ this.baiHoc }} đã hoàn thành
                </v-list-item-title>
              </v-list-item>
            </v-list>
          </v-menu>
          <!--  -->
          <div class="text-center">
            <v-menu
              v-model="menu"
              :close-on-content-click="false"
              location="bottom"
            >
              <template v-slot:activator="{ props }">
                <v-btn icon v-bind="props">
                  <v-icon>mdi-dots-vertical</v-icon></v-btn
                >
              </template>

              <v-card min-width="300">
                <v-list>
                  <v-list-item>
                    <v-title> Thích khóa học này </v-title>
                    <template v-slot:append>
                      <v-btn
                        :class="fav ? 'text-red' : ''"
                        icon="mdi-heart"
                        variant="text"
                        @click="fav = !fav"
                      ></v-btn>
                    </template>
                  </v-list-item>
                  <v-list-item>
                    <v-title> Lưu trữ khóa học này </v-title>
                    <template v-slot:append>
                      <v-btn
                        :class="fav1 ? 'text-purple' : ''"
                        icon="mdi-folder"
                        variant="text"
                        @click="fav1 = !fav1"
                      ></v-btn>
                    </template>
                  </v-list-item>
                </v-list>

                <v-divider></v-divider>

                <v-list>
                  <v-list-item>
                    <v-checkbox
                      v-model="checkbox1"
                      color="purple"
                      label="Email về thông báo mới"
                      value="checkbox1"
                    ></v-checkbox>
                  </v-list-item>

                  <v-list-item>
                    <v-checkbox
                      v-model="checkbox2"
                      color="purple"
                      label="Email quảng cáo"
                      value="checkbox2"
                    ></v-checkbox>
                  </v-list-item>
                </v-list>
              </v-card>
            </v-menu>
          </div>
          <!--  -->
        </v-toolbar>
      </div>
    </div>
    <v-row>
      <v-col cols="8">
        <div class="video-lessons">
          <div class="video" v-if="selectedLesson">
            <iframe
              :src="selectedLesson ? selectedLesson.videoBaiHoc : ''"
              width="100%"
              height="100%"
              frameborder="0"
            ></iframe>
          </div>
          <div class="video-error text-center" v-else>
            <p>Chưa có video bài học nào được chọn.</p>
          </div>
          <div class="menu-video">
            <div style="border-radius: 0px">
              <v-tabs class="ml-3" v-model="tab" bg-color="grey-lighten-5">
                <v-tab value="one">Tổng quan</v-tab>
                <v-tab value="two">Thông báo</v-tab>
                <v-tab value="three">Đánh giá</v-tab>
              </v-tabs>

              <v-card-text>
                <v-window class="mt-5" v-model="tab">
                  <v-window-item value="one">
                    <div>
                      <div class="content-course-introduction ml-4">
                        <h4>Giới thiệu khóa học</h4>
                        <p class="mt-6 mb-4 text-data">
                          {{ this.listCourse.tieuDeKhoaHoc }}
                        </p>
                      </div>
                      <hr />
                      <div class="content-data">
                        <v-row>
                          <v-col cols="2">
                            <v-card-title>Theo số liệu</v-card-title>
                          </v-col>
                          <v-col cols="3">
                            <p class="text-data ml-4 mt-3">
                              Học viên:
                              {{ this.listCourse.soHocVienHocKhoaHoc }}
                              <font-awesome-icon
                                icon="fa-solid fa-user-group"
                              ></font-awesome-icon>
                            </p>
                          </v-col>
                          <v-col cols="3">
                            <p class="text-data mt-3">
                              Bài giảng: {{ this.numberLesson.length }}
                              <font-awesome-icon
                                icon="fa-solid fa-tv"
                              ></font-awesome-icon>
                            </p>
                            <p class="text-data">
                              Video: Tổng số
                              {{ this.listCourse.tongThoiGianKhoaHoc }} giờ
                            </p>
                          </v-col>
                        </v-row>
                      </div>
                      <hr />
                      <div>
                        <v-row>
                          <v-col cols="2">
                            <v-card-title>Mô tả</v-card-title>
                          </v-col>
                          <v-col cols="7">
                            <v-card-text v-mutate="() => onMutate('card1')">
                              <p
                                v-for="n in +content + 1"
                                :key="n"
                                :class="n === +content + 1 && 'mb-0'"
                                class="text-data"
                                v-html="this.listCourse.moTaKhoaHoc"
                              ></p>
                            </v-card-text>
                          </v-col>
                        </v-row>
                      </div>
                      <div class="text-center">
                        <v-btn
                          :disabled="loading"
                          :loading="loading"
                          class="text-none ml-2 mt-3"
                          color="purple-darken-4"
                          variant="text"
                          :text="content ? 'Ẩn bớt' : 'Hiển thị thêm'"
                          @click="content = !content"
                        >
                        </v-btn>
                      </div>
                    </div>
                  </v-window-item>

                  <v-window-item value="two"> Two </v-window-item>

                  <v-window-item value="three">
                    <v-card
                      class="d-flex flex-column mx-auto pa-8"
                      elevation="10"
                      height="500"
                      width="100%"
                    >
                      <div class="d-flex justify-center text-h4">
                        Đánh giá của học viên
                      </div>

                      <div class="d-flex align-center my-auto">
                        <div class="text-h3 mt-3 ml-3">
                          3.5
                          <span class="text-h6 ml-n3">/5</span>
                        </div>

                        <v-rating
                          :model-value="3.5"
                          color="yellow-darken-3"
                          half-increments
                        ></v-rating>
                        <div class="px-3">3,360 đánh giá</div>
                      </div>
                      <v-list bg-color="transparent" density="compact">
                        <v-list-item v-for="(rating, i) in 5" :key="i">
                          <v-progress-linear
                            :model-value="rating * 15"
                            class="mx-n5"
                            color="yellow-darken-3"
                            height="20"
                            rounded
                          ></v-progress-linear>

                          <template v-slot:prepend>
                            <span>{{ rating }}</span>
                            <v-icon class="mx-3" icon="mdi-star"></v-icon>
                          </template>

                          <template v-slot:append>
                            <div class="rating-values">
                              <span>
                                {{ rating * 224 }}
                              </span>
                            </div>
                          </template>
                        </v-list-item>
                      </v-list>
                      <h2 class="ml-3 mt-5">Bình luận</h2>
                    </v-card>
                  </v-window-item>
                </v-window>
              </v-card-text>
            </div>
          </div>
        </div>
      </v-col>
      <v-col cols="4">
        <div class="lessons-content">
          <div class="pt-3 pr-6 sticky-content">
            <div class="content-item text-center pb-4">
              <h2>Nội dung bài học</h2>
            </div>
            <v-expansion-panels
              class="my-3"
              variant="popout"
              v-model="panel"
              multiple
            >
              <v-expansion-panel
                v-for="(l, index) in listStudyChapter"
                :key="index"
                :title="l.tenChuong"
                :value="l.id"
              >
                <v-expansion-panel-text
                  v-for="(c, lessonIndex) in l.baiHocs"
                  :key="lessonIndex"
                >
                  <v-row>
                    <v-col
                      cols="7"
                      class="hover-lessons"
                      @click="selectedId = c.id"
                    >
                      <font-awesome-icon
                        icon="fa-solid fa-tv"
                        class="mr-3"
                      ></font-awesome-icon>
                      {{ c.tenBaiHoc }}
                    </v-col>
                    <v-col cols="4">
                      <div v-if="c.resources == false">
                        <v-menu
                          v-model="c.id"
                          :close-on-content-click="false"
                          location="bottom"
                        >
                          <template v-slot:activator="{ props }">
                            <v-btn
                              variant="outlined"
                              color="black"
                              v-bind="props"
                            >
                              <font-awesome-icon
                                class="mr-3"
                                icon="fa-solid fa-earth-americas"
                              ></font-awesome-icon>
                              Tài nguyên
                              <font-awesome-icon
                                class="ml-2"
                                icon="fa-solid fa-chevron-down"
                              ></font-awesome-icon>
                            </v-btn>
                          </template>

                          <v-card min-width="300">
                            <router-link to="#" class="resources-link">
                              <v-card-actions class="ml-1">
                                <v-icon
                                  icon="mdi-folder-download-outline"
                                ></v-icon>
                                <v-title class="ml-2">{{ c.folder }}</v-title>
                              </v-card-actions>
                            </router-link>
                            <router-link to="#" class="resources-link">
                              <v-card-actions class="ml-2">
                                <font-awesome-icon
                                  icon="fa-solid fa-up-right-from-square"
                                ></font-awesome-icon>
                                <v-title class="ml-3"
                                  >Trung tâm trợ giúp</v-title
                                >
                              </v-card-actions>
                            </router-link>
                            <router-link to="#" class="resources-link">
                              <v-card-actions class="ml-2">
                                <font-awesome-icon
                                  icon="fa-solid fa-up-right-from-square"
                                ></font-awesome-icon>
                                <v-title class="ml-3"
                                  >Cộng đồng giảng viên</v-title
                                >
                              </v-card-actions>
                            </router-link>
                            <router-link to="#" class="resources-link">
                              <v-card-actions class="ml-2">
                                <font-awesome-icon
                                  icon="fa-solid fa-up-right-from-square"
                                ></font-awesome-icon>
                                <v-title class="ml-3">Teaching Center</v-title>
                              </v-card-actions>
                            </router-link>
                          </v-card>
                        </v-menu>
                      </div>
                    </v-col>
                  </v-row>
                </v-expansion-panel-text>
              </v-expansion-panel>
            </v-expansion-panels>
          </div>
        </div>
      </v-col>
    </v-row>
    <div class="body"></div>
    <div>
      <FooterItem class="footer"></FooterItem>
    </div>
  </div>
</template>

<script>
import FooterItem from "../Header/FooterItem.vue";
import { courseApi } from "../../apis/Course/courseApi";
import { studyChapter } from "../../apis/StudyChapter/studyChapter";
export default {
  components: {
    FooterItem,
  },
  data() {
    return {
      courseApi: courseApi(),
      studyChapterApi: studyChapter(),
      tienDo: 4,
      baiHoc: 32,
      fav: false,
      fav1: false,
      menu: false,
      menu1: false,
      message: false,
      hints: true,
      panel: [],
      tab: null,
      content: false,
      card1: 0,
      card2: 0,
      listCourse: [
        {
          id: 1,
          image:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          nameCourse: "Khóa học C# .Net Core",
          dateStart: "28/09/2022",
          student: 3353,
          course: 67,
          time: 70,
          price: 443.992,
          stock: false,
        },
      ],
      listStudyChapter: [],
      numberLesson: [],
      lessonsInDesiredChapter: [],
      listLessons: [],
      selectedId: null,
    };
  },
  async mounted() {
    const id = this.$route.params.id;
    try {
      const res = await this.courseApi.getCourseId(id);
      (this.listCourse = res.data), console.log(this.listStudyChapter);
    } catch (e) {
      console.error("Error fetching course" + e.message);
    }
    try {
      const res = await this.courseApi.getCourseId(id);
      (this.listStudyChapter = res.data.chuongHocs),
        console.log(this.listStudyChapter);
    } catch (e) {
      console.error("Error fetching course" + e.message);
    }
    try {
      const res = await this.courseApi.getCourseId(id);
      this.listLessons = res.data.chuongHocs;
      for (let i = 0; i < this.listLessons.length; i++) {
        const chapter = this.listLessons[i];
        console.log("Chương ", i, ":", chapter);
        const lessonArray = chapter.baiHocs;
        console.log("Bài học trong chương ", i, ":", lessonArray);
        for (var j = 0; j < lessonArray.length; j++) {
          if (lessonArray[j] != null) {
            console.log("nó đã vòa đây rồi");
            console.log(lessonArray[j]);
            this.lessonsInDesiredChapter.push(lessonArray[j]);
            console.log("đây nhé");
            console.log(this.lessonsInDesiredChapter);
            this.numberLesson = this.lessonsInDesiredChapter;
          }
        }
      }
    } catch (e) {}
  },
  methods: {
    onMutate(card) {
      this[card]++;
    },
  },
  computed: {
    selectedLesson() {
      return this.lessonsInDesiredChapter.find(
        (lesson) => lesson.id === this.selectedId
      );
    },
  },
};
</script>

<style scope>
.hover-lessons:hover {
  background-color: rgb(240, 240, 240);
  border-radius: 10px;
  color: rgb(204, 0, 255);
}
.resources-link {
  text-decoration: none;
  color: black;
}
.resources-link:hover {
  color: blueviolet;
}
.text-data {
  font-size: 16px;
}
.footer {
  border-radius: 0%;
}
.video {
  height: 700px;
  width: 100%;
}
.video-error {
  height: 700px;
  width: 100%;
  padding-top: 340px;
}
.video-error p {
  font-size: 20px;
}
.content-item h2 {
  font-family: initial;
  font-weight: bold;
  font-size: 40px;
  margin: 10px 0px 10px 0px;
}
.lessons-content {
  height: 1500px;
}
.sticky-content {
  position: sticky;
  top: 0;
}
</style>
