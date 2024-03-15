<template>
  <div class="course-product">
    <link
      rel="stylesheet"
      type="text/css"
      href="https://npmcdn.com/flatpickr/dist/themes/dark.css"
    />
    <v-row>
      <v-col cols="1">
        <HeaderDashboardVue class="header"></HeaderDashboardVue>
      </v-col>
      <v-col cols="11">
        <a-layout-content
          class="ant-content"
          style="margin: 150px 10px 0px 0px"
        >
          <div class="container">
            <div class="content-course mb-7">
              <h2>Khóa học của bạn</h2>
            </div>
            <div class="table-course">
              <v-card flat>
                <v-card-title class="d-flex align-center pe-2">
                  <v-spacer></v-spacer>
                  <v-btn
                    :disabled="loading"
                    class="text-none"
                    color="#9933FF"
                    size="x-large"
                    variant="flat"
                    style="color: #ffffff"
                  >
                    Tạo khóa học mới

                    <v-dialog persistent activator="parent" max-width="1000">
                      <template v-slot:default="{ isActive }">
                        <v-card class="pa-5">
                          <div>
                            <AppSingleImage
                              v-model="inputCreateCourse.anhKhoaHoc[0]"
                              :imageUrl="imageUrl"
                              @update:imageUrl="handleImageUrlUpdate"
                            ></AppSingleImage>
                          </div>
                          <label>
                            <span class="obligatory mr-2">*</span>
                            Tiêu đề
                          </label>
                          <v-text-field
                            class="mt-3"
                            :rules="requireFieldRule"
                            color="purple-accent-4"
                            variant="outlined"
                            placeholder="Tiêu đề khóa học"
                            v-model="inputCreateCourse.tieuDeKhoaHoc"
                          ></v-text-field>
                          <label>
                            <span class="obligatory mr-2">*</span>
                            Giá khóa học
                          </label>
                          <v-text-field
                            class="mt-3"
                            :rules="requireFieldRule"
                            color="purple-accent-4"
                            variant="outlined"
                            placeholder="Giá khóa học"
                            v-model="inputCreateCourse.giaKhoaHoc"
                          ></v-text-field>

                          <label>
                            <span class="obligatory mr-2">*</span>
                            Loại khóa học
                          </label>
                          <v-select
                            class="mt-3"
                            clearable
                            v-model="inputCreateCourse.loaiKhoaHocId"
                            color="purple-accent-4"
                            label="Loại khóa học"
                            item-value="id"
                            item-title="tenLoaiKhoaHoc"
                            :items="listCourseType"
                            variant="outlined"
                          ></v-select>

                          <!-- <v-file-input
                            class="mt-3"
                            label="Ảnh khóa học"
                            counter
                            color="purple-accent-4"
                            multiple
                            show-size
                          > -->
                          <!-- <div>
                            <AppSingleImage
                              :class="$attrs.class"
                              :defaultImgUrl="defaultImgUrl"
                              v-model:value="inputCreateCourse.anhKhoaHoc"
                              :label="label"
                            />
                          </div> -->
                          <!-- </v-file-input> -->
                          <v-lable class="mb-3">Mô tả</v-lable>
                          <ckeditor
                            :editor="editor"
                            :config="editorConfig"
                            aria-placeholder="Mô tả"
                            v-model="inputCreateCourse.moTaKhoaHoc"
                            v-html="inputCreateCourse.moTaKhoaHoc"
                          ></ckeditor>

                          <v-btn
                            class="text-none mt-4"
                            color="#9933FF"
                            variant="flat"
                            size="x-large"
                            :loading="loading"
                            style="color: #ffffff"
                            @click="createCourse"
                            >Thêm mới</v-btn
                          >
                          <v-btn
                            class="text-none mt-4"
                            color="black"
                            variant="outlined"
                            size="x-large"
                            style="color: #000"
                            @click="isActive.value = false"
                          >
                            Hủy
                          </v-btn>
                        </v-card>
                      </template>
                    </v-dialog>
                  </v-btn>
                </v-card-title>

                <v-divider></v-divider>
                <a-table :data-source="this.listCourse" :columns="columns">
                  <template #headerCell="{ column }">
                    <template v-if="column.key === 'AnhKhoaHoc'">
                      <span style="color: #1890ff">Ảnh khóa học</span>
                    </template>
                  </template>
                  <template
                    #customFilterDropdown="{
                      setSelectedKeys,
                      selectedKeys,
                      confirm,
                      clearFilters,
                      column,
                    }"
                  >
                    <div style="padding: 8px">
                      <a-input
                        ref="searchInput"
                        :placeholder="`Search ${column.dataIndex}`"
                        :value="selectedKeys[0]"
                        style="width: 188px; margin-bottom: 8px; display: block"
                        @change="
                          (e) =>
                            setSelectedKeys(
                              e.target.value ? [e.target.value] : []
                            )
                        "
                        @pressEnter="
                          handleSearch(selectedKeys, confirm, column.dataIndex)
                        "
                      />
                      <a-button
                        type="primary"
                        size="small"
                        style="width: 90px; margin-right: 8px"
                        @click="
                          handleSearch(selectedKeys, confirm, column.dataIndex)
                        "
                      >
                        <template #icon><SearchOutlined /></template>
                        Search
                      </a-button>
                      <a-button
                        size="small"
                        style="width: 90px"
                        @click="handleReset(clearFilters)"
                      >
                        Reset
                      </a-button>
                    </div>
                  </template>
                  <template #customFilterIcon="{ filtered }">
                    <font-awesome-icon
                      icon="fa-solid fa-magnifying-glass"
                      :style="{ color: filtered ? '#108ee9' : undefined }"
                    />
                  </template>
                  <template #bodyCell="{ column, listCourse }">
                    <span
                      v-if="
                        state.searchText &&
                        state.searchedColumn === column.dataIndex
                      "
                    >
                      <template
                        v-for="(i, fragment) in listCourse
                          .toString()
                          .split(
                            new RegExp(
                              `(?<=${state.searchText})|(?=${state.searchText})`,
                              'i'
                            )
                          )"
                      >
                        <mark
                          v-if="
                            fragment.toLowerCase() ===
                            state.searchText.toLowerCase()
                          "
                          :key="i"
                          class="highlight"
                        >
                          {{ fragment }}
                        </mark>

                        <template>{{ fragment }}</template>
                      </template>
                    </span>

                    <template v-if="column.key === 'operation'">
                      <div class="text-end">
                        <v-btn icon class="mr-3">
                          <font-awesome-icon
                            icon="fa-solid fa-plus"
                          ></font-awesome-icon>
                          <v-dialog
                            persistent
                            activator="parent"
                            max-width="1000"
                          >
                            <template v-slot:default="{ isActive }">
                              <v-card class="pa-5">
                                <label>
                                  <span class="obligatory mr-2">*</span>
                                  Tên chương học
                                </label>
                                <v-text-field
                                  class="mt-3"
                                  :rules="rules"
                                  color="purple-accent-4"
                                  variant="outlined"
                                  placeholder="Tên chương học"
                                ></v-text-field>

                                <label>
                                  <span class="obligatory mr-2">*</span>
                                  Ảnh chương học
                                </label>
                                <v-file-input
                                  class="mt-3"
                                  label="Ảnh chương học"
                                  counter
                                  color="purple-accent-4"
                                  multiple
                                  show-size
                                ></v-file-input>
                                <v-btn
                                  class="text-none mt-4"
                                  color="#9933FF"
                                  variant="flat"
                                  size="x-large"
                                  style="color: #ffffff"
                                  @click="isActive.value = false"
                                  >Thêm chương học</v-btn
                                >
                                <v-btn
                                  class="text-none mt-4"
                                  color="black"
                                  variant="outlined"
                                  size="x-large"
                                  style="color: #000"
                                  @click="isActive.value = false"
                                >
                                  Hủy
                                </v-btn>
                              </v-card>
                            </template>
                          </v-dialog>
                        </v-btn>
                        <v-btn icon class="mr-3">
                          <font-awesome-icon
                            icon="fa-solid fa-pen"
                          ></font-awesome-icon>
                          <v-dialog
                            persistent
                            activator="parent"
                            max-width="1000"
                          >
                            <template v-slot:default="{ isActive }">
                              <v-card class="pa-5">
                                <label>
                                  <span class="obligatory mr-2">*</span>
                                  Tiêu đề
                                </label>
                                <v-text-field
                                  class="mt-3"
                                  :rules="rules"
                                  color="purple-accent-4"
                                  variant="outlined"
                                  placeholder="Tiêu đề khóa học"
                                ></v-text-field>
                                <label>
                                  <span class="obligatory mr-2">*</span>
                                  Giá khóa học
                                </label>
                                <v-text-field
                                  class="mt-3"
                                  :rules="rules"
                                  color="purple-accent-4"
                                  variant="outlined"
                                  placeholder="Giá khóa học"
                                ></v-text-field>
                                <label>
                                  <span class="obligatory mr-2">*</span>
                                  Loại khóa học
                                </label>
                                <v-select
                                  class="mt-3"
                                  clearable
                                  color="purple-accent-4"
                                  label="Loại khóa học"
                                  :items="[
                                    'California',
                                    'Colorado',
                                    'Florida',
                                    'Georgia',
                                    'Texas',
                                    'Wyoming',
                                  ]"
                                  variant="outlined"
                                ></v-select>
                                <label>
                                  <span class="obligatory mr-2">*</span>
                                  Ảnh khóa học
                                </label>
                                <v-file-input
                                  class="mt-3"
                                  label="Ảnh khóa học"
                                  counter
                                  color="purple-accent-4"
                                  multiple
                                  show-size
                                ></v-file-input>
                                <v-lable class="mb-3">Mô tả</v-lable>
                                <ckeditor
                                  :editor="editor"
                                  v-model="updateDescription"
                                  :config="editorConfig"
                                  aria-placeholder="Mô tả"
                                ></ckeditor>

                                <v-btn
                                  class="text-none mt-4"
                                  color="#9933FF"
                                  variant="flat"
                                  size="x-large"
                                  style="color: #ffffff"
                                  @click="isActive.value = false"
                                  >Sửa khóa học</v-btn
                                >
                                <v-btn
                                  class="text-none mt-4"
                                  color="black"
                                  variant="outlined"
                                  size="x-large"
                                  style="color: #000"
                                  @click="isActive.value = false"
                                >
                                  Hủy
                                </v-btn>
                              </v-card>
                            </template>
                          </v-dialog>
                        </v-btn>
                        <router-link
                          to="/study-chapter"
                          class="study-chapter-link"
                        >
                          <v-btn icon class="mr-3">
                            <font-awesome-icon
                              icon="fa-solid fa-eye"
                            ></font-awesome-icon>
                          </v-btn>
                        </router-link>
                        <v-btn icon>
                          <font-awesome-icon
                            icon="fa-regular fa-trash-can"
                          ></font-awesome-icon>
                        </v-btn>
                      </div>
                    </template>
                  </template>
                </a-table>
              </v-card>
            </div>
            <p class="ma-14 text-center" style="font-size: 18px">
              Dựa trên trải nghiệm của bạn, chúng tôi nghĩ rằng những tài nguyên
              này sẽ hữu ích.
            </p>
            <div class="content-middle">
              <div class="content-item">
                <v-container>
                  <div class="content-item-middle">
                    <v-row no-gutters>
                      <v-col cols="4">
                        <v-sheet>
                          <div>
                            <img
                              src="../../assets/image/engaging-course.jpg"
                              width="210"
                            />
                          </div>
                        </v-sheet>
                      </v-col>

                      <v-col cols="8">
                        <v-sheet class="mt-3">
                          <p style="font-size: 24px">Tạo khóa học thu hút</p>
                          <p class="mt-4" style="font-size: 16px">
                            Dù đã giảng dạy nhiều năm hay mới dạy lần đầu, bạn
                            vẫn có thể tạo nên một khóa học hấp dẫn. Chúng tôi
                            đã biên soạn các tài nguyên và phương pháp hay nhất
                            để giúp bạn tiến bộ, bất kể vạch xuất phát của bạn ở
                            đâu.
                          </p>
                          <router-link
                            to="/create-engaging-courses"
                            class="link-item-middle"
                          >
                            <p>Bắt đầu</p>
                          </router-link>
                        </v-sheet>
                      </v-col>
                    </v-row>
                  </div>
                </v-container>
              </div>
              <v-row class="mt-3 mb-3">
                <v-col>
                  <div class="content-item-row">
                    <v-container>
                      <v-row no-gutters>
                        <v-col cols="5">
                          <v-sheet class="pa-2">
                            <img
                              src="../../assets/image/video-creation.jpg"
                              width="210"
                              alt=""
                            />
                          </v-sheet>
                        </v-col>

                        <v-col cols="7">
                          <v-sheet class="pa-2">
                            <p style="font-size: 21px" class="mb-4">
                              Bắt đầu tạo video
                            </p>
                            <p class="mb-6" style="font-size: 16px">
                              Bài giảng video chất lượng có thể giúp khóa học
                              của bạn trở nên khác biệt. Hãy sử dụng tài nguyên
                              của chúng tôi để tìm hiểu thông tin cơ bản.
                            </p>
                            <router-link
                              to="/start-creating-videos"
                              class="link-item-middle"
                            >
                              <p>Bắt đầu</p>
                            </router-link>
                          </v-sheet>
                        </v-col>
                      </v-row>
                    </v-container>
                  </div>
                </v-col>
                <v-col>
                  <div class="content-item-row">
                    <v-container>
                      <v-row no-gutters>
                        <v-col cols="5">
                          <v-sheet class="pa-2">
                            <img
                              src="../../assets/image/build-audience.jpg"
                              width="210"
                              alt=""
                            />
                          </v-sheet>
                        </v-col>

                        <v-col cols="7">
                          <v-sheet class="pa-2">
                            <p style="font-size: 21px" class="mb-4">
                              Xây dựng đội ngũ học viên của bạn
                            </p>
                            <p class="mb-6" style="font-size: 16px">
                              Mang lại thành công cho khóa học của bạn bằng cách
                              xây dựng đội ngũ học viên.
                            </p>
                            <router-link
                              to="/build-a-team-of-students"
                              class="link-item-middle"
                            >
                              <p>Bắt đầu</p>
                            </router-link>
                          </v-sheet>
                        </v-col>
                      </v-row>
                    </v-container>
                  </div>
                </v-col>
              </v-row>
              <div class="content-item">
                <v-container>
                  <div class="content-item-middle">
                    <v-row no-gutters>
                      <v-col cols="4">
                        <v-sheet>
                          <div>
                            <img
                              src="../../assets/image/newcomer-challenge.jpg"
                              width="210"
                            />
                          </div>
                        </v-sheet>
                      </v-col>

                      <v-col cols="8">
                        <v-sheet class="mt-3">
                          <p style="font-size: 24px">
                            Tham gia Thử thách giảng viên mới!
                          </p>
                          <p class="mt-4" style="font-size: 16px">
                            Tham khảo các bí quyết và tài nguyên dành riêng cho
                            bạn, được thiết kế để giúp bạn ra mắt khóa học đầu
                            tiên nhanh hơn! Những giảng viên đủ điều kiện xuất
                            bản khóa học đầu tiên đúng thời hạn sẽ nhận được lời
                            chúc mừng là một phần thưởng đặc biệt. Hãy bắt đầu
                            ngay hôm nay!
                          </p>
                          <router-link to="/" class="link-item-middle">
                            <p>Bắt đầu</p>
                          </router-link>
                        </v-sheet>
                      </v-col>
                    </v-row>
                  </div>
                </v-container>
              </div>
            </div>
            <p class="ma-14 text-center" style="font-size: 18px">
              Bạn có câu hỏi? Sau đây là các tài nguyên hướng dẫn phổ biến nhất
              của chúng tôi.
            </p>
            <div class="content-bottom">
              <v-container>
                <v-row class="mb-6" no-gutters>
                  <v-col>
                    <v-sheet class="pa-2 ma-2 text-center">
                      <font-awesome-icon
                        style="font-size: 40px"
                        icon="fa-solid fa-tv"
                      ></font-awesome-icon>
                      <div class="content-item-bottom">
                        <router-link to="/#" class="link-content-item-bottom">
                          <h6 class="text-center mt-3">Video thử nghiệm</h6>
                          <p class="mt-5">
                            Gửi cho chúng tôi video mẫu và nhận ý kiến phản hồi
                            từ chuyên gia.
                          </p>
                        </router-link>
                      </div>
                    </v-sheet>
                  </v-col>

                  <v-col>
                    <v-sheet class="pa-2 ma-2 text-center">
                      <font-awesome-icon
                        icon="fa-regular fa-comments"
                        style="font-size: 40px"
                      ></font-awesome-icon>
                      <div class="content-item-bottom">
                        <router-link to="/#" class="link-content-item-bottom">
                          <h6 class="text-center mt-3">Cộng đồng giảng viên</h6>
                          <p class="mt-5">
                            Kết nối với những giảng viên giàu kinh nghiệm. Đặt
                            câu hỏi, duyệt qua thảo luận và hơn thế nữa.
                          </p>
                        </router-link>
                      </div>
                    </v-sheet>
                  </v-col>

                  <v-col>
                    <v-sheet class="pa-2 ma-2 text-center">
                      <font-awesome-icon
                        style="font-size: 40px"
                        icon="fa-solid fa-person-chalkboard"
                      ></font-awesome-icon>
                      <div class="content-item-bottom">
                        <router-link to="/#" class="link-content-item-bottom">
                          <h6 class="text-center mt-3">Teaching Center</h6>
                          <p class="mt-5">
                            Tìm hiểu về các phương pháp giảng dạy hay nhất trên
                            Udemy.
                          </p>
                        </router-link>
                      </div>
                    </v-sheet>
                  </v-col>
                  <v-col>
                    <v-sheet class="pa-2 ma-2 text-center">
                      <font-awesome-icon
                        style="font-size: 40px"
                        icon="fa-solid fa-chart-line"
                      ></font-awesome-icon>
                      <div class="content-item-bottom">
                        <router-link to="/#" class="link-content-item-bottom">
                          <h6 class="text-center mt-3">
                            Thông tin chi tiết về thị trường
                          </h6>
                          <p class="mt-5">
                            Xác định chủ đề khóa học của bạn bằng cách khám phá
                            lượng cung và cầu trên thị trường Udemy.
                          </p>
                        </router-link>
                      </div>
                    </v-sheet>
                  </v-col>
                  <v-col>
                    <v-sheet class="pa-2 ma-2 text-center">
                      <font-awesome-icon
                        style="font-size: 40px"
                        icon="fa-solid fa-circle-question"
                      ></font-awesome-icon>
                      <div class="content-item-bottom">
                        <router-link to="/#" class="link-content-item-bottom">
                          <h6 class="text-center mt-3">Trợ giúp và hỗ trợ</h6>
                          <p class="mt-5">
                            Duyệt qua Trung tâm trợ giúp hoặc liên hệ với nhóm
                            Hỗ trợ của chúng tôi.
                          </p>
                        </router-link>
                      </div>
                    </v-sheet>
                  </v-col>
                </v-row>
              </v-container>
            </div>
          </div>
        </a-layout-content>
      </v-col>
    </v-row>

    <FooterItem style="border-radius: 0%"></FooterItem>
  </div>
</template>
<script setup>
import { reactive, ref } from "vue";
import { message } from "ant-design-vue";
const state = reactive({
  searchText: "",
  searchedColumn: "",
});
// const listCourse= this.listCourse;
const searchInput = ref();
const columns = [
  {
    title: "Ảnh khóa học",
    dataIndex: "AnhKhoaHoc",
    key: "AnhKhoaHoc",
  },
  {
    title: "Khóa học",
    dataIndex: "TieuDeKhoaHoc",
    key: "TieuDeKhoaHoc",
    customFilterDropdown: true,
    onFilter: (value, record) =>
      record.username.toString().toLowerCase().includes(value.toLowerCase()),
    onFilterDropdownOpenChange: (visible) => {
      if (visible) {
        setTimeout(() => {
          searchInput.value.focus();
        }, 100);
      }
    },
  },
  {
    title: "Ngày tạo",
    dataIndex: "NgayTao",
    key: "NgayTao",
  },
  {
    title: "Giá khóa học ",
    dataIndex: "GiaKhoaHoc",
    key: "GiaKhoaHoc",
    sorter: {
      compare: (a, b) => a.GiaKhoaHoc - b.GiaKhoaHoc,
      multiple: 1,
    },
  },
  {
    title: "Thao tác",
    key: "operation",
    width: 280,
  },
];
const handleSearch = (selectedKeys, confirm, dataIndex) => {
  confirm();
  state.searchText = selectedKeys[0];
  state.searchedColumn = dataIndex;
};
const handleReset = (clearFilters) => {
  clearFilters({
    confirm: true,
  });
  state.searchText = "";
};
// function getBase64(img, callback) {
//   const reader = new FileReader();
//   reader.addEventListener("load", () => callback(reader.result));
//   reader.readAsDataURL(img);
// }
const imageUrl = ref("");

// Hàm xử lý khi giá trị của hình ảnh thay đổi từ component con
const handleImageUrlUpdate = (newImageUrl) => {
  imageUrl.value = newImageUrl;
};
const requireFieldRule = [
  (value) => {
    if (value) return true;

    return "Trường này không được trống!";
  },
];
</script>
<script>
import FooterItem from "../Header/FooterItem.vue";
import HeaderDashboardVue from "./HeaderDashboard.vue";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { format, parseISO } from "date-fns";
import flatPickr from "vue-flatpickr-component";
import "flatpickr/dist/flatpickr.css";
import { courseApi } from "../../apis/Course/courseApi";
import AppSingleImage from "../../components/AppSingleImage.vue";
export default {
  components: {
    FooterItem,
    HeaderDashboardVue,
    flatPickr,
    AppSingleImage,
  },
  props: {
    defaultImgUrl: String,
    label: String,
  },
  data() {
    return {
      loading: false,
      selectedValue: null,

      // router: useRouter(),
      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null,

      courseApi: courseApi(),
      inputCreateCourse: {
        tieuDeKhoaHoc: "",
        moTaKhoaHoc: "",
        giaKhoaHoc: null,
        phanTramGiamGia: null,
        anhKhoaHoc: "",
        loaiKhoaHocId: null,
      },
      btn: null,
      editor: ClassicEditor,
      date: format(parseISO(new Date().toISOString()), "dd-MM-yyyy"),
      menu1: false,
      menu2: false,
      today: new Date(),
      dialog: false,
      search: "",
      listCourse: [],
      listCourseType: [
      ],
      dataType:[
        "ten khoa 1", "tenkhoa 2"
      ]
    };
  },
  async mounted() {
    try {
      const response = await this.courseApi.getAllCourses();
      console.log(response);
      console.log("ở dây nhé");
      this.listCourse = response;
      // Gắn dữ liệu từ API vào danh sách listCourse
      // for item in this.listCourse:
      // AnhKhoaHoc = item.get("AnhKhoaHoc")
    } catch (error) {
      console.error("Error fetching data:", error);
    }
    try {
      const res = await this.courseApi.getAllCoursesType();
      this.listCourseType = res;
      console.log("đây là thể loại");
      console.log(this.listCourseType);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  },
  created() {
    // console.log(localStorage.getItem("userInfo"));
    const userInfo = localStorage.getItem("userInfo");
    // console.log(userInfo);
    // const user = await getUserById(userInfo.id);
    //   retu
    // }
  },
  methods: {
    async createCourse() {
      const userInfo = JSON.parse(localStorage.getItem("userInfo"));
      console.log(userInfo.Id);
      const params = {
        TieuDeKhoaHoc: this.inputCreateCourse.tieuDeKhoaHoc,
        MoTaKhoaHoc: this.inputCreateCourse.moTaKhoaHoc,
        GiaKhoaHoc: this.inputCreateCourse.giaKhoaHoc,
        PhanTramGiamGia: this.inputCreateCourse.phanTramGiamGia,
        AnhKhoaHoc: this.inputCreateCourse.anhKhoaHoc[0],
        LoaiKhoaHocId: this.inputCreateCourse.loaiKhoaHocId,
      };
      console.log("Vào đây rồi");
      console.log(params.AnhKhoaHoc);
      const result = await this.courseApi.createCourse(this.inputCreateCourse);
      console.log(result);
      this.loading = true;
    },
    handleFileChange(event) {
      const file = event.target.files[0];
      this.inputCreateCourse.anhKhoaHoc = file;
    },
  },
};
</script>

<style scope>
.study-chapter-link {
  color: #141414;
}
.content-course h2 {
  font-family: initial;
  font-weight: bold;
  font-size: 40px;
}
.date-picker {
  height: 55px;
  border-radius: 3px;
  border: 1px solid rgb(175, 175, 175);
  padding: 16px;
}
.date-picker:hover {
  border: 1px solid rgb(0, 0, 0);
}
.obligatory {
  color: rgb(201, 0, 0);
}
.create-course-link {
  text-decoration: none;
}
.course-product {
  height: 2000px;
}
.header {
  z-index: 4;
  position: sticky;
  top: 0;
}
.link-item-middle {
  color: rgb(42, 0, 141);
  text-decoration: none;
  font-size: 16px;
  color: rgb(42, 0, 141);
  text-decoration: underline 1px solid;
}
.footer {
  border-radius: 0%;
  margin-top: 80px;
}
.site-layout .site-layout-background {
  background: #fff;
}
[data-theme="dark"] .site-layout .site-layout-background {
  background: #141414;
}
.text-menu {
  font-size: 18px;
  font-weight: 400;
}
.ant-content {
  margin: 0px 10px;
}
.ant-layout {
  background: #fff;
}
.fa-icon {
  font-size: 22px;
  margin: 0px 40px 0px 40px;
}
.student {
  font-size: 16px;
  /* height: 45px ; */
  /* font-size: 45px; */
  /* width: 45px; */
  display: inline-block;
}
.link-content-item-bottom {
  text-decoration: none;
  /* text-decoration: underline 1px solid rgb(42, 0, 141); */
}
.hover-student {
  background-color: white;
  color: black;
  height: 150px;
  width: 350px;
  display: none;
  position: fixed;
  right: 110px;
  border: 1px solid rgb(216, 216, 216);
  /* box-shadow: 0px 3px 3px 3px rgb(247, 247, 247); */
  top: 63px;

  border-radius: 10px;
}
.hover-avatar {
  background-color: #fff;
  /* height: 500px; */
  width: 315px;
  border-radius: 10px;
  border: 1px solid rgb(216, 216, 216);
  /* box-shadow: 0px 3px 3px 3px rgb(247, 247, 247); */
  display: none;
  position: fixed;
  right: 20px;
  top: 63px;
}
.fixed-menu {
  position: fixed;
}
.student:hover .hover-student {
  /* color: blue; */
  z-index: 4;
  display: block;
}
.student a:hover {
  color: purple;
}
.content-item-middle {
  padding: 0px 90px 0px 90px;
}
.avartar {
  height: 45px;
  font-size: 45px;
  width: 45px;
  display: inline-block;
}
.content-item-bottom h6 {
  color: rgb(42, 0, 141);
  font-size: 17px;
  font-weight: bold;
}
.content-item-bottom p {
  text-decoration: none !important;
  color: gray;
}

.avatar:hover .hover-avatar {
  display: block;
  z-index: 4;
  /* top:-1px; */
}
.link-student {
  text-decoration: none;
  color: black;
}
.user-course {
  text-decoration: none;
  color: black;
}
.user-course:hover {
  color: rgb(82, 0, 158);
}
.custom-user-profile {
  line-height: 0px;
  margin: 26px 0px;
}
.custom-user-profile a {
  text-decoration: none;
  color: black;
}
.custom-user-profile .user-course:hover {
  color: rgb(82, 0, 158);
}
.content-item {
  width: 100%;
  border-radius: 4px;
  border: 1px solid rgb(219, 219, 219);
  /* height: 70px; */
  box-shadow: 1px 1px 10px 1px rgb(238, 238, 238);
  padding: 0px 80px 0px 80px;
}
.content-item-row {
  width: 100%;
  border-radius: 4px;
  border: 1px solid rgb(219, 219, 219);
  /* height: 70px; */
  box-shadow: 1px 1px 10px 1px rgb(238, 238, 238);
}
.menu-item-course {
  color: white;
  text-decoration: none;
}
.content-bottom {
  margin: 0px 80px 0px 80px;
  /* background: blue; */
  width: 88%;
  /* height: 90px; */
}
</style>
