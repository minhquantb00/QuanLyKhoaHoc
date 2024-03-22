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
          src="https://img-c.udemycdn.com/notices/featured_carousel_slide/image/5bf6274c-4a57-42ce-93d6-9775b06730be.jpg"
          cover
        ></v-carousel-item>

        <v-carousel-item
          src="https://img-c.udemycdn.com/notices/featured_carousel_slide/image/450dec77-8a3c-4286-98af-fe252fd26166.jpg"
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
                    >Giá: {{ formatCurrency(n.giaKhoaHoc) }}
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
            <v-slide-group-item
              v-for="n in listCourseHot"
              :key="n.id"
              v-slot="{ toggle }"
            >
              <v-card class="ma-2 course-item" @click="toggle" width="283">
                <v-img :src="n.image" height="200px" cover />
                <h4>{{ n.nameCourse }}</h4>
                <p style="margin: 0">{{ n.description }}</p>
                <v-rating
                  v-model="rating"
                  size
                  class="my-2"
                  active-color="orange"
                  color="orange-lighten-1"
                ></v-rating>
                <p style="margin: 0">{{ n.price }}</p>
              </v-card>
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
            <v-slide-group-item v-for="e in listCourePropose" :key="e.id">
              <div class="pa-4">
                <v-hover v-slot="{ isHovering, props }">
                  <v-card
                    class="mx-auto"
                    color="grey-lighten-5"
                    width="565"
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
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useRouter } from "vue-router";
import { courseApi } from "../../apis/Course/courseApi";
export default {
  data() {
    return {
      router: useRouter(),
      apiCourse: courseApi(),
      loading: true,
      listCourse: [],

      listCourseHot: [
        {
          id: 1,
          image:
            "https://tenten.vn/tin-tuc/wp-content/uploads/2022/06/Java-Script-4.jpg",
          nameCourse: "Khóa học Javascript",
          description:
            "JavaScript là ngôn ngữ lập trình website phổ biến hiện nay,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 2,
          image:
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSYqtlZ8hRs-1a_Wdsa-x-rSmWNxNNiaJCaA&usqp=CAU",
          nameCourse: "Khóa học NodeJs",
          description: "Node.js là một hệ thống phần mềm,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 3,
          image:
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZ4sRkWyi-2VPwALEpD6a-rzUJ9W3I1gc_dg&usqp=CAU",
          nameCourse: "Khóa học PHP",
          description: "PHP là một ngôn ngữ lập trình kịch bản,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 4,
          image:
            "https://amela.vn/wp-content/uploads/2021/08/reactjs-app-development-500x500-1.jpg",
          nameCourse: "Khóa học ReactJs",
          description: "ReacJs là một thư viện JavaScript mã nguồn mở,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 5,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Khóa học Python",
          description:
            "Python là một ngôn ngữ lập trình bậc cao, đa mục đích,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
      ],
      listPostHot: [
        {
          id: 1,
          image:
            "https://tenten.vn/tin-tuc/wp-content/uploads/2022/06/Java-Script-4.jpg",
          nameCourse: "Khóa học Javascript",
          description:
            "JavaScript là ngôn ngữ lập trình website phổ biến hiện nay,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 2,
          image:
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSYqtlZ8hRs-1a_Wdsa-x-rSmWNxNNiaJCaA&usqp=CAU",
          nameCourse: "Khóa học NodeJs",
          description: "Node.js là một hệ thống phần mềm,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 3,
          image:
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZ4sRkWyi-2VPwALEpD6a-rzUJ9W3I1gc_dg&usqp=CAU",
          nameCourse: "Khóa học PHP",
          description: "PHP là một ngôn ngữ lập trình kịch bản,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 4,
          image:
            "https://amela.vn/wp-content/uploads/2021/08/reactjs-app-development-500x500-1.jpg",
          nameCourse: "Khóa học ReactJs",
          description: "ReacJs là một thư viện JavaScript mã nguồn mở,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 5,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Khóa học Python",
          description:
            "Python là một ngôn ngữ lập trình bậc cao, đa mục đích,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
      ],
      listCourePropose: [
        {
          id: 1,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học BA",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 2,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học truy vấn SQL Server",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 3,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học Angular",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 4,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle:
            "Business Analyst (BA) for Practitioners (BA thực chiến)",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 5,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học Java",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 6,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học Java",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
      ],
    };
  },

  async mounted() {
    setTimeout(() => {
      this.loading = false; // Tắt loading khi dữ liệu đã được load
    }, 2500);
    try {
      const result = await this.apiCourse.getAllCourses();
      this.listCourse = result;
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
