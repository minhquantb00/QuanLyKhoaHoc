<template>
  <div class="detail-teacher">
    <div style="height: 72px">
      <HeaderItem></HeaderItem>
    </div>
    <div class="container">
      <div class="content">
        <v-container>
          <v-row class="bg-white">
            <v-col cols="9">
              <v-sheet class="mt-4">
                <div class="profile-all">
                  <h6>GIẢNG VIÊN</h6>
                  <h2 class="my-3">
                    {{ this.teacherProfile.hoVaTen }}
                  </h2>
                  <h5 class="nick-name-profile">
                    <!-- {{ p.nickName }} -->
                  </h5>
                  <v-row class="my-4">
                    <v-col cols="5">
                      <v-row>
                        <v-col col="7">
                          <v-titlte class="text-student">
                            Tổng học viên
                          </v-titlte>
                          <h4>
                            <!-- {{ p.student }} -->
                          </h4>
                        </v-col>
                        <v-col cols="5">
                          <v-title class="text-student"> Đánh giá </v-title>
                          <h4>
                            {{ listEvalute.length }}
                          </h4>
                        </v-col>
                      </v-row>
                    </v-col>
                  </v-row>
                  <div class="introduce-profile">
                    <h5>Giới thiệu về tôi</h5>
                    <p>
                      <!-- {{ p.description }} -->
                    </p>
                  </div>
                  <div class="certification-profile">
                    <h6>| Chứng nhận |</h6>
                    <!-- {{p.certifications}} -->
                    <p class="my-3 mb-7">
                      <font-awesome-icon
                        icon="fa-solid fa-pen-nib"
                        class="mx-3"
                      ></font-awesome-icon>
                      <!-- {{ p.certifications }} -->
                    </p>
                  </div>
                </div>
              </v-sheet>
              <div class="description-user">
                <h5>Mô tả</h5>
                <p>
                  Lorem ipsum dolor sit amet consectetur adipisicing elit.
                  Voluptatibus aliquid ut est, autem quod modi natus incidunt
                  debitis iste nihil quisquam perferendis, vitae eveniet optio
                  enim, dolores repellat culpa repellendus. Lorem, ipsum dolor
                  sit amet consectetur adipisicing elit. Non, perferendis ea,
                  exercitationem ullam ipsa voluptatum pariatur vel soluta
                  corrupti placeat modi culpa facilis iure! Architecto et eius
                  ullam quisquam maxime! Lorem ipsum dolor sit amet consectetur
                  adipisicing elit. Praesentium voluptatum ad eos nobis modi
                  magnam nemo numquam? Laboriosam ea, neque dicta sunt
                  dignissimos harum perferendis velit vitae quisquam, nemo odit?
                </p>
              </div>
            </v-col>

            <v-col cols="3">
              <v-sheet class="ma-2 text-center">
                <v-avatar
                  size="200"
                  class="mx-1 my-4"
                  :image="this.teacherProfile.anhDaiDien"
                ></v-avatar>
              </v-sheet>
              <v-sheet>
                <a :href="this.teacherProfile.hoVaTen" class="link-teacher">
                  <v-card
                    class="text-h6 text-center rounded-pill"
                    color="white"
                    variant="tonal"
                    hover
                    @click="loading = !loading"
                  >
                    <v-avatar
                      size="40"
                      rounded="0"
                      class="mx-1 my-4 mr-3"
                      image="https://2235233.fs1.hubspotusercontent-na1.net/hubfs/2235233/blog-import/2022/07-22-Jul/every-social-media-logo-and-icon-in-one-handy-place-instagram.png"
                    ></v-avatar>

                    <span style="color: black">Instagram</span>
                  </v-card>
                </a>
                <a :href="this.teacherProfile.hoVaTen" class="link-teacher">
                  <v-card
                    class="text-h6 text-center rounded-pill"
                    color="white"
                    variant="tonal"
                    hover
                    @click="loading = !loading"
                  >
                    <v-avatar
                      size="40"
                      class="mx-1 my-4 mr-3"
                      image="https://upload.wikimedia.org/wikipedia/commons/thumb/b/b8/2021_Facebook_icon.svg/2048px-2021_Facebook_icon.svg.png"
                    ></v-avatar>
                    <span style="color: black">Facebook</span>
                  </v-card>
                </a>
                <a :href="this.teacherProfile.hoVaTen" class="link-teacher">
                  <v-card
                    class="text-h6 text-center rounded-pill"
                    color="white"
                    variant="tonal"
                    hover
                    @click="loading = !loading"
                  >
                    <v-avatar
                      size="40"
                      rounded="0"
                      class="mx-1 my-4 mr-3"
                      image="https://cdn-icons-png.flaticon.com/256/1384/1384060.png"
                    ></v-avatar
                    ><span style="color: black">Youtube</span>
                  </v-card>
                </a>
              </v-sheet>
            </v-col>
          </v-row>
          <div class="card-course-profile">
            <h5 class="ml-4">
              Các khóa học của tôi ({{ this.listCourePropose.length }})
            </h5>
            <div v-if="loadingCard">
              <v-row>
                <v-col md="3">
                  <v-skeleton-loader
                    class="mx-auto border"
                    max-width="300"
                    type="image, article"
                  ></v-skeleton-loader>
                </v-col>
                <v-col md="3">
                  <v-skeleton-loader
                    class="mx-auto border"
                    max-width="300"
                    type="image, article"
                  ></v-skeleton-loader>
                </v-col>
                <v-col md="3">
                  <v-skeleton-loader
                    class="mx-auto border"
                    max-width="300"
                    type="image, article"
                  ></v-skeleton-loader>
                </v-col>
                <v-col md="3">
                  <v-skeleton-loader
                    class="mx-auto border"
                    max-width="300"
                    type="image, article"
                  ></v-skeleton-loader>
                </v-col>
              </v-row>
            </div>
            <div v-else class="list-course">
              <v-sheet class="" elevation="4">
                <v-slide-group v-model="model" center-active show-arrows>
                  <v-slide-group-item v-for="e in listCourePropose" :key="e">
                    <router-link
                      :to="`/detail-product${e.id}`"
                      class="link-detail-product pa-4"
                    >
                      <v-card :loading="loading" width="260">
                        <template v-slot:loader="{ isActive }">
                          <v-progress-linear
                            :active="isActive"
                            color="deep-purple"
                            height="4"
                            indeterminate
                          ></v-progress-linear>
                        </template>

                        <v-img height="189" :src="e.anhKhoaHoc" cover></v-img>

                        <v-card-item>
                          <v-card-title style="font-size: 17px">{{
                            e.tieuDeKhoaHoc
                          }}</v-card-title>

                          <v-card-subtitle>
                            <span class="me-3"
                              >{{ e.chuongHocs.length }} chương * Tất cả trình
                              độ</span
                            >

                            <v-icon
                              color="error"
                              icon="mdi-fire-circle"
                              size="small"
                            ></v-icon>
                          </v-card-subtitle>
                        </v-card-item>

                        <v-card-text>
                          <v-row>
                            <v-rating
                              v-model="rating"
                              active-color="orange"
                              size="small"
                              color="orange-lighten-1"
                            ></v-rating>
                          </v-row>

                          <div style="margin-top: 30px" class="text-subtitle-2">
                            <h5>{{ formatCurrency(e.giaKhoaHoc) }}</h5>
                          </div>
                        </v-card-text>
                      </v-card>
                    </router-link>
                  </v-slide-group-item>
                </v-slide-group>
              </v-sheet>
            </div>
          </div>
          <div class="card-course-profile mt-10">
            <h5 class="ml-4">
              Các bài viết của tôi ({{ listCourePropose.length }})
            </h5>
            <div v-if="loadingCard">
              <v-row>
                <v-col>
                  <v-skeleton-loader type="article"></v-skeleton-loader>
                </v-col>
                <v-col>
                  <v-skeleton-loader type="article"></v-skeleton-loader>
                </v-col>
              </v-row>
            </div>
            <div v-else class="list-course">
              <v-sheet class="" elevation="4">
                <v-slide-group v-model="model" center-active show-arrows>
                  <v-slide-group-item v-for="e in listCourePropose" :key="e.id">
                    <div class="pa-4">
                      <v-hover v-slot="{ isHovering, props }">
                        <v-card
                          class="mx-auto"
                          color="grey-lighten-5"
                          width="550"
                          v-bind="props"
                        >
                          <v-img
                            height="300"
                            src="https://tuhoclaptrinh.edu.vn/upload/post/15/95/81/tu-hoc-lap-trinh-ruby-534086.jpg"
                            cover
                          >
                            <v-expand-transition>
                              <div
                                v-if="isHovering"
                                class="d-flex transition-fast-in-fast-out bg-grey-darken-1 v-card--reveal text-h2"
                                style="height: 100%"
                              >
                                <router-link
                                  to="/detail-product"
                                  class="link-detail-product"
                                >
                                  <v-btn
                                    class="text-h6 mb-4"
                                    color="grey-lighten-5"
                                    size="x-large"
                                    variant="flat"
                                    >Xem bài viết</v-btn
                                  >
                                </router-link>
                              </div>
                            </v-expand-transition>
                          </v-img>
                        </v-card>
                      </v-hover>
                    </div>
                  </v-slide-group-item>
                </v-slide-group>
              </v-sheet>
            </div>
          </div>
        </v-container>
      </div>
    </div>
    <div style="margin-top: 40px">
      <FooterItem></FooterItem>
    </div>
  </div>
</template>

<script>
import HeaderItem from "../Header/HeaderItem.vue";
import FooterItem from "../Header/FooterItem.vue";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { useRouter } from "vue-router";
import { userApi } from "../../apis/User/userApi";
import { courseApi } from "../../apis/Course/courseApi";
export default {
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      loadingCard: true,
      editor: ClassicEditor,
      router: useRouter(),
      userApi: userApi(),
      courseApi: courseApi(),
      page: 1,
      teacherProfile: [],
      listCourePropose: [],
      listEvalute: [
        {
          id: 1,
          assessor: "Nguyễn Khánh Huyền",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://haycafe.vn/wp-content/uploads/2023/06/Hinh-Anh-gai-xinh-de-thuong-dep-nhat-Viet-Nam.jpg",
        },
        {
          id: 2,
          assessor: "Nguyễn Ngọc Linh",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://khoinguonsangtao.vn/wp-content/uploads/2022/08/hinh-nen-gai-xinh.jpg",
        },
        {
          id: 3,
          assessor: "Nguyễn Gia Hân",
          evaluate:
            "Lorem, ipsum dolor sit amet consel! Maxime ipsa fugit sint perferendis, sunt quae distinctio quibusdam quam repudiandae?",
          isSelected: false,
          image:
            "https://gcs.tripi.vn/public-tripi/tripi-feed/img/474015QSt/anh-gai-xinh-1.jpg",
        },
        {
          id: 4,
          assessor: "Trần Ánh Dương",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
        {
          id: 5,
          assessor: "Trần Ánh Dương",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
        {
          id: 6,
          assessor: "Trần Ánh Dương",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
        {
          id: 7,
          assessor: "Trần Ánh Dương",
          evaluate:
            "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Deleniti officiis temporibus possimus eveniet? Ea iure tenetur aliquam ab vel! Maxime ipsa fugit sint perferendis, sunt quae distinctio quibusdam quam repudiandae?",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
        {
          id: 8,
          assessor: "Trần Ánh Dương",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
      ],
    };
  },
  // created() {
  //   console.log(localStorage.getItem("userInfo"));
  //   const userInfo = localStorage.getItem("userInfo");
  //   // const user = await getUserById(userInfo.id);
  //   //   retu
  //   // }
  // },
  async mounted() {
    const id = this.$route.params.id;
    try {
      const res = await this.userApi.getUserId(id);
      this.teacherProfile = res.data;
      console.log("đây là profile");
      console.log(this.teacherProfile);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
    try {
      const res = await this.courseApi.getAllCoursesByUserId(id);
      console.log(res);
      this.listCourePropose = res;
      console.log(this.listCourePropose);
    } catch (e) {
      console.error("Error fetching failed" + e.message);
    }
    setTimeout(() => {
      this.loadingCard = false; // Tắt loading khi dữ liệu đã được load
    }, 1500);
  },
  methods: {
    logout() {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
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
    formatCurrency(value) {
      const intValue = parseInt(value);
      return intValue.toLocaleString("vi-VN", {
        style: "currency",
        currency: "VND",
      });
    },
  },
};
</script>

<style scope>
.v-card--reveal {
  align-items: center;
  bottom: 0;
  justify-content: center;
  opacity: 0.9;
  position: absolute;
  width: 100%;
}
.ck-editor__editable {
  height: 450px;
}
.obligatory {
  color: red;
}
.link-teacher {
  text-decoration: none;
}
.text-student {
  font-weight: bold;
  color: rgb(143, 143, 143);
}
.nick-name-profile {
  color: rgb(126, 126, 126);
}
.certification-profile {
  margin: 10px 0px 10px 0px;
}
.introduce-profile {
  margin-bottom: 30px;
}
.link-detail-product {
  text-decoration: none;
}
</style>
