<template>
  <div id="content-course" class="container">
    <div class="slider">
      <v-carousel
        show-arrows="hover"
        hide-delimiters
        continuous="true"
        cycle
        interval="2000"
      >
        <v-carousel-item
          v-for="b in listBanner"
          :key="b"
          :src="b.anhBanner"
          cover
        ></v-carousel-item>
      </v-carousel>
    </div>

    <div class="course-suggest">
      <h2 class="content-item-text">Đề xuất cho bạn</h2>
      <div v-if="loading" class="text-left mt-6">
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

      <div v-else class="list-course mt-7">
        <div elevation="4">
          <v-slide-group v-model="model" center-active show-arrows>
            <v-slide-group-item v-for="n in listCourse" :key="n.id" class="">
              <router-link
                :to="`/detail-product/${n.id}`"
                @click="handleRouterLinkClick(n.id)"
                style="text-decoration: none"
              >
                <v-card class="mb-5 ma-2" width="283">
                  <v-img height="200" :src="n.anhKhoaHoc" cover></v-img>

                  <v-card-title class="text-h5">{{
                    n.tieuDeKhoaHoc
                  }}</v-card-title>

                  <v-card-subtitle>
                    {{ processDescription(n.moTaKhoaHoc) }}
                  </v-card-subtitle>
                  <v-card-title class="text-p"
                    >Giá: {{ formatCurrency(n.giaKhoaHocThucTe) }}
                    <span
                      style="
                        text-decoration-line: line-through;
                        font-size: 14px;
                        color: grey;
                      "
                    >
                      {{ formatCurrency(n.giaKhoaHoc) }}
                    </span>
                  </v-card-title>
                  <v-card-actions>
                    <v-rating
                      v-model="rating"
                      size
                      class="my-2"
                      active-color="orange"
                      color="orange-lighten-1"
                    ></v-rating>
                  </v-card-actions>
                </v-card>
              </router-link>
            </v-slide-group-item>
          </v-slide-group>
        </div>
      </div>
    </div>

    <div class="course-suggest">
      <h2 class="content-item-text">Khóa học nổi bật</h2>
      <div v-if="loading" class="text-left mt-6">
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
      <div v-else class="list-course mt-7">
        <div elevation="4">
          <v-slide-group v-model="model" center-active show-arrows>
            <v-slide-group-item v-for="n in listCourse" :key="n.id" class="">
              <router-link
                :to="`/detail-product/${n.id}`"
                @click="handleRouterLinkClick(n.id)"
                style="text-decoration: none"
              >
                <v-card class="mb-5 ma-2" width="283">
                  <v-img height="200" :src="n.anhKhoaHoc" cover></v-img>

                  <v-card-title class="text-h5">{{
                    n.tieuDeKhoaHoc
                  }}</v-card-title>

                  <v-card-subtitle>
                    {{ processDescription(n.moTaKhoaHoc) }}
                  </v-card-subtitle>
                  <v-card-title class="text-p"
                    >Giá: {{ formatCurrency(n.giaKhoaHocThucTe) }}
                    <span
                      style="
                        text-decoration-line: line-through;
                        font-size: 14px;
                        color: grey;
                      "
                    >
                      {{ formatCurrency(n.giaKhoaHoc) }}
                    </span>
                  </v-card-title>
                  <v-card-actions>
                    <v-rating
                      v-model="rating"
                      size
                      class="my-2"
                      active-color="orange"
                      color="orange-lighten-1"
                    ></v-rating>
                  </v-card-actions>
                </v-card>
              </router-link>
            </v-slide-group-item>
          </v-slide-group>
        </div>
      </div>
    </div>

    <div class="course-suggest">
      <h2 class="content-item-text">Bài viết nổi bật</h2>
      <div v-if="loading">
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
        <div class="" elevation="4">
          <v-slide-group v-model="model" center-active show-arrows>
            <v-slide-group-item v-for="e in listPost" :key="e">
              <div class="pa-4">
                <v-hover v-slot="{ isHovering, props }">
                  <v-card
                    class="mx-auto"
                    color="grey-lighten-5"
                    width="565"
                    v-bind="props"
                  >
                    <v-img height="300" :src="e.anhBaiViet" cover>
                      <v-expand-transition>
                        <div
                          v-if="isHovering"
                          class="d-flex transition-fast-in-fast-out bg-grey-darken-4 v-card--reveal text-h2"
                          style="height: 100%"
                        >
                          <router-link
                            :to="`/post-client/${e.id}`"
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
                      <v-card-title style="color: #e0e0e0">{{
                        e.tieuDe
                      }}</v-card-title>
                    </v-img>
                  </v-card>
                </v-hover>
              </div>
            </v-slide-group-item>
          </v-slide-group>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useRouter } from "vue-router";
import { courseApi } from "../../apis/Course/courseApi";
import { bannerApi } from "../../apis/Banner/bannerApi";
import { postApi } from "../../apis/Post/postApi";
export default {
  data() {
    return {
      router: useRouter(),
      apiCourse: courseApi(),
      bannerApi: bannerApi(),
      postApi: postApi(),
      loading: true,
      listCourse: [],
      listBanner: [],
      listPost: [],
      listCourseHot: [],
      listCourePropose: [],
    };
  },

  async mounted() {
    setTimeout(() => {
      this.loading = false;
    }, 2500);
    try {
      const result = await this.apiCourse.getAllCourses();
      this.listCourse = result;
    } catch (e) {
      console.error("Fetching faild", e);
    }
    try {
      const result = await this.bannerApi.getAllBanner();
      this.listBanner = result;
    } catch (e) {
      console.error("Fetching faild", e);
    }
    try {
      const result = await this.postApi.getAllPostUser();
      this.listPost = result;
      console.log(this.listPost);
    } catch (e) {
      console.error("Fetching faild", e);
    }
  },
  methods: {
    changeRating(courseId, event) {
      const newRating = event.target.value;
      const course = this.listCourse.find((course) => course.id === courseId);
      if (course) {
        course.rating = newRating;
      }
      console.log(`Updated rating for course ${courseId}: ${newRating}`);
    },
    async handleRouterLinkClick(id) {
      try {
        const response = await this.apiCourse.getCourseId(id);
      } catch (error) {
        console.error("Đã xảy ra lỗi khi gọi API:", error);
        // Xử lý lỗi nếu cần thiết
        this.$router.push("/error"); // Điều hướng đến trang lỗi nếu cần
      }
    },
    formatCurrency(value) {
      // Chuyển đổi giá trị sang kiểu số nguyên
      const intValue = parseInt(value);

      // Sử dụng hàm toLocaleString để định dạng giá tiền theo tiêu chuẩn của quốc gia
      return intValue.toLocaleString("vi-VN", {
        style: "currency",
        currency: "VND",
      });
    },
    processDescription(description) {
      const doc = new DOMParser().parseFromString(description, "text/html");
      return doc.body.textContent || "";
    },
  },
};
</script>

<style scoped>
.course-suggest {
  margin-top: 40px;
}
.course-item:hover {
  cursor: pointer;
}
.content-item-text {
  font-family: initial;
  font-weight: bold;
  font-size: 35px;
  margin-left: 60px;
  margin-top: 80px;
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
