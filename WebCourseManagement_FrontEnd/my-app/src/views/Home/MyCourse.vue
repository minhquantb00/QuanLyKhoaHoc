<template>
  <div>
    <div style="min-height: 72px">
      <HeaderItem></HeaderItem>
    </div>
    <div class="menu-course">
      <div class="container">
        <div class="content-header-item">
          <h2>Khóa học của bạn</h2>
        </div>
        <div>
          <v-tabs v-model="tab" align-tabs="left">
            <v-tab :value="1">Tất cả khóa học</v-tab>
            <v-tab :value="2">Mong muốn</v-tab>
          </v-tabs>
        </div>
      </div>
    </div>
    <div class="container">
      <v-window v-model="tab">
        <v-window-item :value="1">
          <div class="mt-10 mb-13" elevation="8">
            <v-slide-group
              v-model="model"
              class="pa-4"
              selected-class="bg-success"
              show-arrows
            >
              <v-slide-group-item>
                <v-hover
                  v-slot="{ isHovering, props }"
                  v-for="c in listCourseApi"
                  :key="c"
                >
                  <router-link :to="`/video-lessons/${c.id}`" style="text-decoration:none;">
                    <v-card
                      :loading="loading"
                      :class="{ 'on-hover': isHovering }"
                      :elevation="isHovering ? 12 : 2"
                      class="ma-4 image-content"
                      v-bind="props"
                      width="260"
                    >
                      <template v-slot:loader="{ isActive }">
                        <v-progress-linear
                          :active="isActive"
                          color="deep-purple"
                          height="4"
                          indeterminate
                        ></v-progress-linear>
                      </template>

                      <v-img :src="c.anhKhoaHoc" height="160" cover>
                        <div class="hover-image text-center">
                          <v-btn
                            icon="mdi-play"
                            color="white"
                            size="x-large"
                            variant="flat"
                            class="icon-image"
                          ></v-btn>
                        </div>
                      </v-img>

                      <v-card-item>
                        <v-card-title>{{ c.tieuDeKhoaHoc }}</v-card-title>

                        <v-card-subtitle>
                          <span class="me-1">{{ c.nguoiTao.hoVaTen }}</span>
                          <v-progress-linear
                            v-model="c.skill"
                            striped
                            color="blue"
                            height="10"
                            class="mt-3"
                          >
                            <strong>{{ c.skill }}%</strong>
                          </v-progress-linear>
                          <v-icon
                            color="error"
                            icon="mdi-fire-circle"
                            size="small"
                          ></v-icon>
                        </v-card-subtitle>
                      </v-card-item>

                      <v-card-text class="mb-5">
                        <v-row align="center" class="mx-0">
                          <v-dialog max-width="500">
                            <template
                              v-slot:activator="{ props: activatorProps }"
                            >
                              <v-btn variant="text" v-bind="activatorProps">
                                <v-rating
                                  :model-value="4.5"
                                  color="amber"
                                  density="compact"
                                  size="small"
                                  half-increments
                                  readonly
                                ></v-rating
                              ></v-btn>
                            </template>

                            <template v-slot:default="{ isActive }">
                              <v-card title="Đánh giá cá nhân">
                                <v-card-text>
                                  <v-rating
                                    v-model="rating"
                                    active-color="orange"
                                    color="orange-lighten-1"
                                    half-increments
                                    hover
                                  ></v-rating>
                                </v-card-text>

                                <v-card-actions>
                                  <v-spacer></v-spacer>

                                  <v-btn
                                    text="Gửi"
                                    @click="isActive.value = false"
                                  ></v-btn>
                                </v-card-actions>
                              </v-card>
                            </template>
                          </v-dialog>

                          <div class="text-grey ms-4">4.5 (413)</div>
                        </v-row>
                      </v-card-text>
                    </v-card>
                  </router-link>
                </v-hover>
              </v-slide-group-item>
            </v-slide-group>
          </div>
        </v-window-item>
        <v-window-item :value="2">
          <div class="desire text-center mt-16">
            <router-link to="/">
              <v-btn
                :disabled="loading"
                :loading="loading"
                class="text-none mb-4"
                color="black"
                size="x-large"
                variant="flat"
                @click="loading = !loading"
              >
                Xem ngay các khóa học
              </v-btn>
            </router-link>
          </div>
        </v-window-item>
      </v-window>
    </div>
    <div class="teaching">
      <v-row>
        <v-col>
          <div class="content-teaching mt-1 ml-14">
            <h3>Giảng dạy online cho cả thế giới</h3>
            <p>
              Tạo một khóa học video online, tiếp cận học viên trên toàn cầu và
              kiếm tiền
            </p>
          </div>
        </v-col>
        <v-col>
          <div class="button-teaching text-right">
            <router-link to="/course-product">
              <v-btn
                :disabled="loading"
                :loading="loading"
                class="text-none mb-4 mt-3 mr-14"
                color="white"
                size="x-large"
                variant="outlined"
                @click="loading = !loading"
              >
                Giảng dạy trên MyBugs
              </v-btn>
            </router-link>
          </div>
        </v-col>
      </v-row>
    </div>
    <div>
      <FooterItem class="footer"></FooterItem>
    </div>
  </div>
</template>

<script>
import HeaderItem from "../Header/HeaderItem.vue";
import FooterItem from "../Header/FooterItem.vue";
import { useRouter } from "vue-router";
import {courseApi} from "../../apis/Course/courseApi"
export default {
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      loading: false,
      selection: 1,
      tab: null,
      model: null,
      rating: 1,
      courseApi: courseApi(),
      listCourseApi: [],
      listCourse: [
        {
          id: 1,
          image:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          nameCourse: "Khóa học C# .Net Core",
          description: "C# là một ngôn ngữ thuần hướng đối tượng,...",
          teacher: "Trần Văn Dương",
          rating: 3,
          skill: 15,
          price: "397.000 VNĐ",
        },
        {
          id: 2,
          image:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          nameCourse: "Khóa học Java",
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          teacher: "Trần Minh Quân",
          rating: 3,
          skill: 55,
          price: "397.000 VNĐ",
        },
        {
          id: 3,
          image:
            "https://code24h.com/pictures/picfullsizes/2018/08/12/vpn1534042332.jpg",
          nameCourse: "Khóa học Vuejs",
          description: "Vuejs là một framework của JavaScript,...",
          teacher: "Trần Văn Dương",
          rating: 3,
          skill: 100,
          price: "397.000 VNĐ",
        },
        {
          id: 4,
          image:
            "https://amela.vn/wp-content/uploads/2021/08/reactjs-app-development-500x500-1.jpg",
          nameCourse: "Khóa học ReactJs",
          description: "ReacJs là một thư viện JavaScript mã nguồn mở,...",
          teacher: "Nguyễn Khánh Toàn",
          rating: 3,
          skill: 85,
          price: "397.000 VNĐ",
        },
        {
          id: 5,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Khóa học Python",
          description:
            "Python là một ngôn ngữ lập trình bậc cao, đa mục đích,...",
          teacher: "Trần Văn Dương",
          rating: 3,
          skill: 25,
          price: "397.000 VNĐ",
        },
      ],
      icons: ["mdi-play"],
      items: [
        {
          title: "New Releases",
          text: `It's New Release Friday`,
          subtext: "Newly released songs.",
          img: "https://cdn.vuetifyjs.com/docs/images/cards/hands.jpg",
        },
        {
          title: "Rock",
          text: "Greatest Rock Hits",
          subtext: "Lose yourself in rock tunes.",
          img: "https://cdn.vuetifyjs.com/docs/images/cards/singer.jpg",
        },
        {
          title: "Mellow Moods",
          text: "Ambient Bass",
          subtext: "Chill beats to mellow you out.",
          img: "https://cdn.vuetifyjs.com/docs/images/cards/concert.jpg",
        },
      ],
      transparent: "rgba(255, 255, 255, 0)",
    };
  },
  async mounted() {
    try{
      const res = await this.courseApi.getAllCourses()
      this.listCourseApi = res
      console.log(this.listCourseApi);
    }catch(e){
      console.error('Error fetching' + e.message);
    }
  },
};

</script>

<style scope>
.icon-image {
  display: block;
  color: rgb(0, 0, 0);
}
.hover-image {
  display: none;

  padding-top: 50px;
  padding-left: 100px;
  /* z-index: 2; */
}
.image-content:hover .hover-image {
  background-color: rgb(0, 0, 0);

  height: 100%;
  opacity: 0.6;
  /* z-index: 2; */
  display: block;
}
/* .show-btns {
  color: rgba(255, 255, 255, 1) !important;
} */
/*  */
.footer {
  border-radius: 0%;
}
.content-header-item {
  font-family: initial;
  padding: 40px 0px 20px 0px;
}
.content-header-item h2 {
  font-size: 40px;
}
.teaching {
  background-color: rgb(24, 21, 21);
  border-bottom: 1px solid rgb(93, 93, 93);
  /* height: 100px; */
}
.content-teaching {
  color: white;
}
.menu-course {
  background-color: rgb(24, 21, 21);
  color: white;
}
.border-content-course {
  box-shadow: 1px 1px 10px 1px rgb(0, 0, 0);
}
.desire {
  height: 404px;
}
</style>
