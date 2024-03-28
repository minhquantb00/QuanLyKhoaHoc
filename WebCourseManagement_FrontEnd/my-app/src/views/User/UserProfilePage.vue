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
              <v-row>
                <v-col cols="5">
                  <v-sheet class="mt-5">
                    <div class="profile-all">
                      <h6>GIẢNG VIÊN</h6>
                      <h2 class="my-3">
                        {{ userInfo.Name }}
                      </h2>
                      <h5 class="nick-name-profile">
                        <!-- {{ p.nickName }} -->
                      </h5>
                      <v-row class="my-4">
                        <v-col col="8">
                          <v-titlte class="text-student">
                            Tổng học viên
                          </v-titlte>
                          <h4>
                            {{ this.listCourePropose.soHocVienHocKhoaHoc }}
                          </h4>
                        </v-col>
                        <v-col cols="4">
                          <v-title class="text-student"> Đánh giá </v-title>
                          <h4>
                            {{ listEvalute.length }}
                          </h4>
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
                </v-col>
                <v-col>
                  <div>
                    <v-card
                      class="mt-6 pl-2 pr-2 rounded-xl"
                      width="450"
                      color="grey-lighten-5"
                    >
                      <v-card-item>
                        <v-row>
                          <v-col cols="2">
                            <v-avatar
                              size="55"
                              class="mx-1 my-4 mr-3"
                              :image="this.userInfo.Image"
                            />
                          </v-col>
                          <v-col>
                            <v-dialog max-width="1000">
                              <template
                                v-slot:activator="{ props: activatorProps }"
                              >
                                <div
                                  v-bind="activatorProps"
                                  class="text-h6 pt-3 pb-3 pl-5 mb-4 mt-3 bg-grey-lighten-3 rounded-pill"
                                >
                                  <span style="color: #bdbdbd">
                                    Bạn đang nghĩ gì</span
                                  >
                                </div>
                              </template>

                              <template v-slot:default="{ isActive }">
                                <v-card class="pa-5">
                                  <label>
                                    <span class="obligatory mr-2">*</span>
                                    Ảnh bài viết
                                  </label>
                                  <v-file-input
                                    :rules="rules"
                                    class="mt-3"
                                    @change="hanldeImageChange"
                                    v-model="inputAddPost.AnhBaiViet"
                                    color="purple-accent-4"
                                    accept="image/png, image/jpeg, image/bmp"
                                    label="Ảnh bài viết"
                                    placeholder="Pick an avatar"
                                    prepend-icon="mdi-camera"
                                  ></v-file-input>
                                  <label>
                                    <span class="obligatory mr-2">*</span>
                                    Tiêu đề bài viết
                                  </label>
                                  <v-text-field
                                    class="mt-3"
                                    :rules="rules"
                                    color="purple-accent-4"
                                    v-model="inputAddPost.TieuDe"
                                    variant="outlined"
                                    placeholder="Tiêu đề bài học"
                                  ></v-text-field>
                                  <label>
                                    <span class="obligatory mr-2">*</span>
                                    Loại bài viết
                                  </label>
                                  <v-select
                                    label="Loại bài viết"
                                    :items="listPostTypes"
                                    item-value="id"
                                    item-title="tenLoaiBaiViet"
                                    variant="outlined"
                                    v-model="inputAddPost.LoaiBaiVietId"
                                  ></v-select>
                                  <label class="mb-3 ml-1">
                                    Nội dung bài viết
                                  </label>
                                  <ckeditor
                                    :editor="editor"
                                    :config="editorConfig"
                                    v-html="inputAddPost.MoTa"
                                    v-model="inputAddPost.MoTa"
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
                                      @click="createPost"
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
                          </v-col>
                        </v-row>
                      </v-card-item>
                    </v-card>
                  </div>
                </v-col>
              </v-row>

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
                    with="70"
                    :disabled="loading"
                    :loading="loading"
                    class="text-h6 text-center rounded-pill"
                    color="white"
                    variant="tonal"
                    @click="loading = !loading"
                    hover
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
            <div class="list-course">
              <div class="" elevation="4">
                <v-slide-group v-model="model" center-active show-arrows>
                  <v-slide-group-item
                    v-for="e in listCourePropose"
                    :key="e"
                    v-if="this.listCourePropose.length > 0"
                  >
                    <router-link
                      :to="`/detail-product/${e.id}`"
                      class="link-detail-product pa-4"
                    >
                      <v-card :loading="loading" width="260" hover>
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
                  <div v-else>
                    <div
                      class="text-h5 pa-4 mt-5"
                      style="color: #e0e0e0; text-align: center"
                    >
                      No data available
                    </div>
                  </div>
                </v-slide-group>
              </div>
            </div>
          </div>
          <div class="card-course-profile mt-10">
            <h5 class="ml-4">
              Các bài viết của tôi ({{ this.listPost.length }})
            </h5>
            <div class="list-course">
              <div class="" elevation="4">
                <v-slide-group v-model="model" center-active show-arrows>
                  <v-slide-group-item
                    v-for="e in listPost"
                    :key="e"
                    v-if="this.listPost.length > 0"
                  >
                    <div class="pa-4">
                      <v-hover v-slot="{ isHovering, props }">
                        <v-card
                          class="mx-auto"
                          color="grey-lighten-5"
                          width="550"
                          v-bind="props"
                        >
                          <v-img height="300" :src="e.anhBaiViet" cover>
                            <v-expand-transition>
                              <div
                                v-if="isHovering"
                                class="d-flex transition-fast-in-fast-out bg-grey-darken-1 v-card--reveal text-h2"
                                style="height: 100%"
                              >
                                <router-link
                                  :to="`/post-client/${e.id}`"
                                  class="link-detail-product"
                                >
                                  <v-btn
                                    class="text-h6 mb-4"
                                    color="blue"
                                    size="x-large"
                                    variant="flat"
                                    icon=" mdi-eye"
                                  ></v-btn>
                                </router-link>

                                <div class="pa-4 text-center">
                                  <v-dialog v-model="dialog" max-width="300">
                                    <template
                                      v-slot:activator="{
                                        props: activatorProps,
                                      }"
                                    >
                                      <v-btn
                                        class="text-h6 mb-4 ml-4"
                                        color="red"
                                        size="x-large"
                                        variant="flat"
                                        icon="mdi-trash-can-outline"
                                        v-bind="activatorProps"
                                      ></v-btn>
                                    </template>

                                    <v-card>
                                      <v-card-text class="mb-4 text-center">
                                        <v-title class="text-h6">
                                          Bạn muốn xóa bài viết
                                        </v-title>
                                        <v-btn
                                          text="Hủy"
                                          color="primary"
                                          variant="tonal"
                                          class="mr-5 mt-4"
                                          @click="dialog = false"
                                        ></v-btn>

                                        <v-btn
                                          color="red"
                                          text="Xóa"
                                          class="mt-4"
                                          variant="tonal"
                                          @click="deletePost(e.id)"
                                        ></v-btn>
                                      </v-card-text>
                                    </v-card>
                                  </v-dialog>
                                </div>
                              </div>
                            </v-expand-transition>
                          </v-img>
                        </v-card>
                      </v-hover>
                    </div>
                  </v-slide-group-item>
                  <div v-else>
                    <div
                      class="text-h5 pa-4 mt-5"
                      style="color: #e0e0e0; text-align: center"
                    >
                      No data available
                    </div>
                  </div>
                </v-slide-group>
              </div>
            </div>
          </div>
        </v-container>
      </div>
    </div>
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
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
import { postApi } from "../../apis/Post/postApi";
import { courseApi } from "../../apis/Course/courseApi";
import { postTypeApi } from "../../apis/Post/postTypeApi";
export default {
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      editor: ClassicEditor,
      text: "",
      snackbar: false,
      dialog: false,
      router: useRouter(),
      postApi: postApi(),
      courseApi: courseApi(),
      postTypeApi: postTypeApi(),
      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null,
      page: 1,
      inputAddPost: {
        TieuDe: "",
        MoTa: "",
        AnhBaiViet: null,
        LoaiBaiVietId: null,
      },
      listPostTypes: [],
      listPost: [],
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
  async mounted() {
    const id = this.$route.params.id;
    console.log(id);
    try {
      const res = await this.courseApi.getAllCoursesByUserId(id);
      console.log(res);
      this.listCourePropose = res;
      console.log(this.listCourePropose);
    } catch (e) {
      console.error("Error fetching failed" + e.message);
    }
    try {
      const res = await this.postTypeApi.getAllPostType();
      this.listPostTypes = res;
      console.log(this.listPostTypes);
    } catch (e) {
      console.error("Error fetching failed" + e.message);
    }
    try {
      const userId = id;
      const res = await this.postApi.getAllPostUserId(userId);
      this.listPost = res;
      console.log(this.listPost);
    } catch (e) {
      console.error("Error fetching failed" + e.message);
    }
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
      // this.inputAddPost.AnhBaiViet = file;
      this.inputAddPost.AnhBaiViet = file;
    },
    logout() {
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      localStorage.removeItem("userInfo");
    },
    async createPost() {
      const result = await this.postApi.createPost(this.inputAddPost);
      if (result) {
        this.text = "Gửi bài viết thành công";
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      } else {
        this.text = "Gửi bài viết thất bại";
        this.snackbar = true;
      }
    },

    async deletePost(idPost) {
      const deleteBaiViet = await this.postApi.xoaBaiViet(idPost);
      if (deleteBaiViet) {
        this.text = "Xóa bài viết thành công";
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      } else {
        this.text = "Xóa bài thất bại";
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      }
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
    reloadPage() {
      location.reload();
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
