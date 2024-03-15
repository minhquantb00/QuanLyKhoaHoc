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
                    <!-- {{ userInfo.Name }} -->
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
              <v-sheet
                class="ma-2 text-center"
                v-for="e in teacherProfile"
                :key="e.id"
              >
                <v-avatar
                  size="200"
                  class="mx-1 my-4"
                  image="https://scontent.xx.fbcdn.net/v/t1.15752-9/423737674_1480040725879365_4588731426501580823_n.png?stp=dst-png_s206x206&_nc_cat=101&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeFtB96HRehVZW40v9vLuFrrKZjnfOEJczUpmOd84QlzNQsxUHuJTXwED7HbfLgXRmCE6dC6DZ0JcARCqce6WxDD&_nc_ohc=WbjwVgTX7eEAX_jdvUS&_nc_ad=z-m&_nc_cid=0&_nc_ht=scontent.xx&oh=03_AdTknmTmzgFqFVToBlZuS3x-fwUriw_X3DBIhgjbpyhbqA&oe=661A81F0"
                ></v-avatar>
              </v-sheet>
              <v-sheet v-for="p in teacherProfile" :key="p.id">
                <v-dialog max-width="1000">
                  <template v-slot:activator="{ props: activatorProps }">
                    <v-btn
                      v-bind="activatorProps"
                      :disabled="loading"
                      :loading="loading"
                      class="text-h6 mb-4"
                      color="black"
                      size="x-large"
                      variant="outlined"
                      block
                      ><v-icon
                        icon=" mdi-subtitles-outline"
                        class="mr-2"
                      ></v-icon>
                      Đăng bài viết</v-btn
                    >
                  </template>

                  <template v-slot:default="{ isActive }">
                    <v-card class="pa-5">
                      <label>
                        <span class="obligatory mr-2">*</span>
                        Tiêu đề bài viết
                      </label>
                      <v-text-field
                        class="mt-3"
                        :rules="rules"
                        color="purple-accent-4"
                        variant="outlined"
                        placeholder="Tiêu đề bài học"
                      ></v-text-field>
                      <label>
                        <span class="obligatory mr-2">*</span>
                        Ảnh bài viết
                      </label>
                      <v-file-input
                        :rules="rules"
                        class="mt-3"
                        color="purple-accent-4"
                        accept="image/png, image/jpeg, image/bmp"
                        label="Ảnh bài viết"
                        placeholder="Pick an avatar"
                        prepend-icon="mdi-camera"
                      ></v-file-input>
                      <label class="mb-3 ml-1"> Nội dung bài viết </label>
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
                        >
                          Gửi
                          <font-awesome-icon
                            icon="fa-regular fa-paper-plane"
                            class="ml-2 mr-2"
                          ></font-awesome-icon>
                        </v-btn>
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
                  </template>
                </v-dialog>
                <a :href="p.webTeacher" class="link-teacher">
                  <v-btn
                    :disabled="loading"
                    :loading="loading"
                    class="text-h6 mb-4"
                    color="black"
                    size="x-large"
                    variant="outlined"
                    block
                    @click="loading = !loading"
                  >
                    <font-awesome-icon
                      icon="fa-solid fa-link"
                      class="mx-2"
                    ></font-awesome-icon
                    >Trang web
                  </v-btn>
                </a>
                <a :href="p.facebookTeacher" class="link-teacher">
                  <v-btn
                    :disabled="loading"
                    :loading="loading"
                    class="text-h6 mb-4"
                    color="black"
                    size="x-large"
                    variant="outlined"
                    block
                    @click="loading = !loading"
                  >
                    <font-awesome-icon
                      icon="fa-brands fa-facebook"
                      class="mx-2"
                    ></font-awesome-icon
                    >Facebook
                  </v-btn>
                </a>
                <a :href="p.youtubeTeacher" class="link-teacher">
                  <v-btn
                    :disabled="loading"
                    :loading="loading"
                    class="text-h6 mb-4"
                    color="black"
                    size="x-large"
                    variant="outlined"
                    block
                    @click="loading = !loading"
                  >
                    <font-awesome-icon
                      icon="fa-brands fa-youtube"
                      class="mx-2"
                    ></font-awesome-icon
                    >Youtube
                  </v-btn>
                </a>
              </v-sheet>
            </v-col>
          </v-row>
          <div class="card-course-profile">
            <h5 class="ml-4">
              Các khóa học của tôi ({{ listCourePropose.length }})
            </h5>
            <div class="list-course">
              <v-sheet class="" elevation="4">
                <v-slide-group v-model="model" center-active show-arrows>
                  <v-slide-group-item v-for="e in listCourePropose" :key="e.id">
                    <router-link
                      to="/detail-product"
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

                        <v-img height="189" :src="e.imageCourse" cover></v-img>

                        <v-card-item>
                          <v-card-title style="font-size: 17px">{{
                            e.courseTitle
                          }}</v-card-title>

                          <v-card-subtitle>
                            <span class="me-3"
                              >{{ listCourePropose.length }} chương * Tất cả
                              trình độ</span
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

                            <div class="text-grey ms-4">
                              4.5 ({{ listEvalute.length }})
                            </div>
                          </v-row>

                          <div style="margin-top: 30px" class="text-subtitle-2">
                            <h5>{{ e.price }} vnđ</h5>
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
            <div class="list-course">
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
import { authApi } from "../../apis/Auth/authApi";
export default {
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      editor: ClassicEditor,
      router: useRouter(),
      // userInfo: localStorage.getItem("userInfo")
      //   ? JSON.parse(localStorage.getItem("userInfo"))
      //   : null, // Thông tin người dùng
      page: 1,

      // listCertification:[
      //   {
      //       id:1,
      //       nameCertification:"Resilience Practitioner",
      //       dateCertification: 2021,
      //   },
      //   {
      //       id:2,
      //       nameCertification:"EQ Practitioner",
      //       dateCertification: 2023,
      //   },
      //   {
      //       id:3,
      //       nameCertification:"Sofware Developer engineer",
      //       dateCertification: 2024,
      //   },
      //   {
      //       id:4,
      //       nameCertification:"Font-end Developer Engineer",
      //       dateCertification: 2020,
      //   },

      // ],
      teacherProfile: [
        {
          id: 1,
          nameTeacher: "Nguyễn Khánh Huyền",
          description:
            "- Hơn 10 năm kinh nghiệm làm việc tại các vị trí quản lý bộ phận kinh doanh, tiếp thị, chăm sóc khách hàng trong những tập đoàn quốc tế hàng đầu thuộc các lĩnh vực khách sạn, giải trí và bất động sản cao cấp như SwanCity, Diageo, AB Inbev, Six Senses Côn Đảo Resort...",
          evaluate: 19,
          student: 332,
          certifications: "Font-end Developer Engineer từ 2020",
          course: 1,
          webTeacher: "https://www.facebook.com/profile.php?id=100029403376571",
          youtubeTeacher:
            "https://www.youtube.com/channel/UC3CVoJo3JI7LWjD1-ezBWBA",
          facebookTeacher:
            "https://www.facebook.com/profile.php?id=100029403376571",
          nickName: "Huyền Baby",
          imageTeacher:
            "https://1.bp.blogspot.com/-mRj1x9CyrcA/Xm3No2S5lTI/AAAAAAAAYaI/FgJeZaiaPWYDAaXq8rhd6WnvTW1ukOmpACLcBGAsYHQ/s1600/Anh-gai-xinh-toc-ngan-deo-kinh%2B%25284%2529.jpg",
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
  created() {
    console.log(localStorage.getItem("userInfo"));
    const userInfo = localStorage.getItem("userInfo");
    // const user = await getUserById(userInfo.id);
    //   retu
    // }
  },
  async mounted() {
    // await this.checkAndDecodeToken();
  },
  methods: {
    logout() {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
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
