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
              :src="selectedLesson ? selectedLesson.linkVideo : ''"
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
                        <p
                          class="mt-6 mb-4 text-data"
                          v-for="c in listCourse"
                          :key="c.id"
                        >
                          {{ c.nameCourse }}
                        </p>
                      </div>
                      <hr />
                      <div
                        class="content-data"
                        v-for="c in listCourse"
                        :key="c.id"
                      >
                        <v-row>
                          <v-col cols="2">
                            <v-card-title>Theo số liệu</v-card-title>
                          </v-col>
                          <v-col cols="3">
                            <p class="text-data ml-4 mt-3">
                              Học viên: {{ c.student }}
                              <font-awesome-icon
                                icon="fa-solid fa-user-group"
                              ></font-awesome-icon>
                            </p>
                          </v-col>
                          <v-col cols="3">
                            <p class="text-data mt-3">
                              Bài giảng: {{ c.course }}
                              <font-awesome-icon
                                icon="fa-solid fa-tv"
                              ></font-awesome-icon>
                            </p>
                            <p class="text-data">
                              Video: Tổng số {{ c.time }} giờ
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
                              >
                                Suspendisse enim turpis, dictum sed, iaculis a,
                                condimentum nec, nisi. Fusce fermentum odio nec
                                arcu. Aenean ut eros et nisl sagittis
                                vestibulum. Nunc interdum lacus sit amet orci.
                                Phasellus nec sem in justo pellentesque
                                facilisis. Lorem, ipsum dolor sit amet
                                consectetur adipisicing elit. Nisi accusantium
                                numquam, laboriosam officia consequuntur
                                consectetur dicta possimus illum obcaecati
                                veniam repudiandae placeat ad recusandae alias
                                non. Eos laudantium blanditiis porro? Lorem
                                ipsum, dolor sit amet consectetur adipisicing
                                elit. Voluptas unde cum, quibusdam perspiciatis
                                expedita rerum alias minus. Similique
                                consequuntur nobis sint non! Perspiciatis quod
                                reprehenderit aliquid voluptate? Sit, architecto
                                tenetur. Libero ab numquam voluptatum laborum
                                placeat minima quibusdam, nulla quis. Debitis
                                officia, perferendis numquam labore consequatur
                                tempora repudiandae suscipit explicabo autem in,
                                voluptas commodi adipisci, dolorem culpa
                                distinctio at illum? Totam enim quisquam
                                eveniet. Incidunt vitae, expedita temporibus
                                dolore possimus ab iusto impedit veniam saepe
                                voluptate necessitatibus? Fugit earum dolor
                                nesciunt, obcaecati numquam velit facilis odio
                                qui unde excepturi maxime! Lorem ipsum dolor sit
                                amet consectetur adipisicing elit. Libero
                                dolores labore deserunt at eligendi itaque,
                                nesciunt dolorum commodi consequuntur, nam ab,
                                reprehenderit assumenda illum voluptates aut ut
                                blanditiis quis debitis! Lorem ipsum dolor sit
                                amet consectetur adipisicing elit. Nostrum
                                facilis pariatur, odio mollitia veritatis amet
                                consequuntur labore distinctio asperiores non
                                fugit excepturi magni unde nisi sapiente ipsam
                                ex reprehenderit ipsum. Necessitatibus, soluta
                                maxime. Error eaque iste at debitis fuga
                                architecto soluta fugit quaerat dolorum
                                accusantium sit odio, illum rerum? Minus ipsum
                                aliquam cumque animi facere obcaecati dolor
                                corrupti officia exercitationem. Magni eos
                                doloremque voluptate ratione placeat rerum
                                asperiores excepturi est aperiam numquam,
                                repellat repudiandae, minima tempore aliquid
                                ipsa suscipit, molestias doloribus quis possimus
                                ducimus amet rem perspiciatis? Quia, voluptate
                                id. Nobis ipsa consequatur in id mollitia
                                veritatis iure quisquam quasi dolorum eaque
                                laborum ab, beatae, maiores reprehenderit ea
                                repellat error perspiciatis ad praesentium vel
                                magni est. Nemo consectetur dignissimos
                                perferendis! Laudantium distinctio dolores odio
                                eum numquam rerum dicta repellat corporis
                                consequuntur praesentium veniam sint, earum
                                neque harum, quae similique est aliquam ratione.
                                Alias exercitationem aut facere quas doloremque
                                totam quis? Amet, dignissimos in similique nam
                                cum soluta sapiente esse, veniam iure ad ea
                                dolore, repellat vero consequatur aspernatur
                                dolores distinctio adipisci placeat facilis
                                pariatur sequi natus? Deserunt repellat sit rem?
                                Architecto deserunt vitae pariatur sed nam
                                laboriosam maxime corporis eos, ipsa labore?
                                Neque atque facilis provident maxime, quod
                                distinctio dolorem laborum natus molestias
                                facere eius aliquid doloremque veritatis
                                praesentium a. Aspernatur, in voluptatem quod
                                quibusdam sapiente quasi sed omnis tempore
                                recusandae harum asperiores nulla reprehenderit
                                fugit, praesentium autem voluptatum architecto
                                excepturi iure. Commodi odio perspiciatis
                                placeat quasi quaerat tenetur ut!
                              </p>
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
              v-for="l in listStudyChapter"
              :key="l.id"
            >
              <v-expansion-panel :title="l.nameLesson" :value="l.idLesson">
                <v-expansion-panel-text v-for="c in listLessons" :key="c.id">
                  <v-row>
                    <v-col
                      cols="7"
                      class="hover-lessons"
                      @click="selectedId = c.idLesson"
                    >
                      <font-awesome-icon
                        icon="fa-solid fa-tv"
                        class="mr-3"
                      ></font-awesome-icon>
                      {{ c.nameLesson }}
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
export default {
  components: {
    FooterItem,
  },
  data() {
    return {
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
        // {
        //   id: 2,
        //   image:
        //     "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
        //   nameCourse: "Khóa học Java",
        //   dateStart: "28/09/2022",
        //   price: 500.473,
        //   stock: false,
        // },
        // {
        //   id: 3,
        //   image:
        //     "https://code24h.com/pictures/picfullsizes/2018/08/12/vpn1534042332.jpg",
        //   nameCourse: "Khóa học Vuejs",
        //   dateStart: "28/09/2022",
        //   price: 57.784,
        //   stock: false,
        // },
        // {
        //   id: 4,
        //   image:
        //     "https://amela.vn/wp-content/uploads/2021/08/reactjs-app-development-500x500-1.jpg",
        //   nameCourse: "Khóa học ReactJs",
        //   dateStart: "28/09/2022",
        //   price: 784.758,
        //   stock: false,
        // },
        // {
        //   id: 5,
        //   image:
        //     "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
        //   nameCourse: "Khóa học Python",
        //   dateStart: "28/09/2022",
        //   price: 900.778,
        //   stock: false,
        // },
        // {
        //   id: 6,
        //   image:
        //     "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
        //   nameCourse: "Khóa học Python",
        //   dateStart: "28/09/2022",
        //   price: 900.778,
        //   stock: false,
        // },
        // {
        //   id: 7,
        //   image:
        //     "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
        //   nameCourse: "Khóa học Python",
        //   dateStart: "28/09/2022",
        //   price: 900.778,
        //   stock: false,
        // },
        // {
        //   id: 8,
        //   image:
        //     "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
        //   nameCourse: "Khóa học Python",
        //   dateStart: "28/09/2022",
        //   price: 900.778,
        //   stock: false,
        // },
        // {
        //   id: 9,
        //   image:
        //     "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
        //   nameCourse: "Khóa học Python",
        //   dateStart: "28/09/2022",
        //   price: 900.778,
        //   stock: false,
        // },
        // {
        //   id: 10,
        //   image:
        //     "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
        //   nameCourse: "Khóa học Python",
        //   dateStart: "28/09/2022",
        //   price: 900.778,
        //   stock: false,
        // },
        // {
        //   id: 11,
        //   image:
        //     "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
        //   nameCourse: "Khóa học Python",
        //   dateStart: "28/09/2022",
        //   price: 900.778,
        //   stock: false,
        // },
        // {
        //   id: 12,
        //   image:
        //     "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
        //   nameCourse: "Khóa học Python",
        //   dateStart: "28/09/2022",
        //   price: 900.778,
        //   stock: false,
        // },
      ],
      listStudyChapter: [
        {
          idLesson: 1,
          nameLesson: "C# Basic",
        },
        {
          idLesson: 2,
          nameLesson: "Java Basic",
        },
        {
          idLesson: 3,
          nameLesson: "SQL Server Basic",
        },
        {
          idLesson: 4,
          nameLesson: "Truy vấn SQL Server Basic",
        },
      ],
      listLessons: [
        {
          idLesson: 1,
          nameLesson: "Bài 1",
          linkVideo: "https://www.youtube.com/embed/Ug4-1eLb29Y",
          resources: false,
          folder: "download tài nguyên",
        },
        {
          idLesson: 2,
          nameLesson: "Bài 2",
          linkVideo: "https://www.youtube.com/embed/jWmaXCuCZbk",
        },
        {
          idLesson: 3,
          nameLesson: "Bài 3",
          linkVideo: "https://www.youtube.com/embed/9_60Fl6g9xE",
          resources: false,
          folder: "download tài nguyên",
        },
        {
          idLesson: 4,
          nameLesson: "Bài 4",
          linkVideo: "https://www.youtube.com/embed/4r8Cgnbk7fs",
        },
      ],
      selectedId: null,
    };
  },
  methods: {
    onMutate(card) {
      this[card]++;
    },
  },
  computed: {
    selectedLesson() {
      return this.listLessons.find(
        (lesson) => lesson.idLesson === this.selectedId
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
.video-error p{
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
