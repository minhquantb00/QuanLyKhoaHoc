<template>
  <div>
    <v-row>
      <v-col cols="1">
        <div class="header">
          <HeaderDashboardVue></HeaderDashboardVue>
        </div>
      </v-col>
      <v-col>
        <div class="container">
          <div class="text-right mt-10 mb-5">
            <v-dialog persistent max-width="1000 ">
              <template v-slot:activator="{ props: activatorProps }">
                <v-btn
                  v-bind="activatorProps"
                  variant="flat"
                  color="purple-accent-4"
                  class="text-none"
                >
                  Thêm bài học</v-btn
                >
              </template>

              <template v-slot:default="{ isActive }">
                <div>
                  <v-card class="pa-5">
                    <label>
                      <span class="obligatory mr-2">*</span>
                      Tên bài học
                    </label>
                    <v-text-field
                      class="mt-3"
                      :rules="rules"
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
                      v-model="numericValue"
                      :rules="number"
                      color="purple-accent-4"
                      variant="outlined"
                      placeholder="Thời lượng video"
                    ></v-text-field>
                    <label>
                      <span class="obligatory mr-2">*</span>
                      Ngày tạo
                    </label>
                    <div>
                      <flat-pickr
                        color="purple-accent-4"
                        class="date-picker mt-2 mb-4"
                        v-model="today"
                      />
                    </div>
                    <label>
                      <span class="obligatory mr-2">*</span>
                      Video bài học
                    </label>
                    <v-text-field
                      class="mt-3"
                      :rules="rules"
                      color="purple-accent-4"
                      variant="outlined"
                      placeholder="Nhập url của bài học"
                    ></v-text-field>
                    <label class="mb-3 ml-1"> Mô tả </label>
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
          </div>
          <v-table height="300px" fixed-header>
            <thead>
              <tr>
                <th class="text-left">Tên bài học</th>
                <th class="text-left">Thời gian tạo</th>
                <th class="text-left">Thời gian cập nhật</th>
                <th class="text-left">Thời lượng video</th>
                <th class="text-left">Thao tác</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in listLessons" :key="item">
                <td>{{ item.tenBaiHoc }}</td>
                <td>{{ formatDate(item.thoiGianTao) }}</td>
                <td>{{ formatDate(item.thoiGianCapNhat) }}</td>
                <td>{{ item.thoiLuongVideo }}</td>
                <td class="mt-4">
                  <router-link to="#">
                    <v-btn
                      icon
                      class="mr-3 btn-update"
                      @click="handleClickCourseId(n.id)"
                    >
                      <font-awesome-icon
                        icon="fa-solid fa-pen"
                      ></font-awesome-icon>
                      <v-dialog persistent activator="parent" max-width="1000">
                        <template v-slot:default="{ isActive }">
                          <v-card class="pa-5">
                            <input v-model="khoaHocId" type="hidden" />
                            <label>
                              <span class="obligatory mr-2">*</span>
                              Tên bài học
                            </label>
                            <v-text-field
                              class="mt-3"
                              :rules="rules"
                              v-model="tieuDeKhoaHoc"
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
                              :rules="rules"
                              v-model="phanTramGiamGia"
                              color="purple-accent-4"
                              variant="outlined"
                              placeholder="Thời lượng video"
                            ></v-text-field>
                            <v-lable class="mb-3">Mô tả</v-lable>
                            <ckeditor
                              :editor="editor"
                              v-model="moTaKhoaHoc"
                              :config="editorConfig"
                              aria-placeholder="Mô tả"
                            ></ckeditor>

                            <v-btn
                              class="text-none mt-4"
                              color="#9933FF"
                              variant="flat"
                              size="x-large"
                              style="color: #ffffff"
                              :loading="loading"
                              @click="updateCourse"
                              >Sửa bài học</v-btn
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
                  </router-link>
                  <router-link to="#">
                    <v-btn icon class="btn-delete" @click="deleteCoure(n.id)">
                      <font-awesome-icon
                        icon="fa-regular fa-trash-can"
                      ></font-awesome-icon>
                    </v-btn>
                  </router-link>
                </td>
              </tr>
            </tbody>
          </v-table>
        </div>
      </v-col>
    </v-row>
    <FooterItem></FooterItem>
  </div>
</template>
<script>
import HeaderDashboardVue from "./HeaderDashboard.vue";
import flatPickr from "vue-flatpickr-component";
import "flatpickr/dist/flatpickr.css";
import FooterItem from "../Header/FooterItem.vue";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { lessonsApi } from "../../apis/Lessons/lessonsApi";
import { studyChapter } from "../../apis/StudyChapter/studyChapter";
export default {
  components: {
    flatPickr,
    HeaderDashboardVue,
    FooterItem,
  },
  data: () => ({
    numericValue: "",
    editor: ClassicEditor,
    today: new Date(),
    lessonsApi: lessonsApi(),
    studyChapter: studyChapter(),
    search: "",
    listLessons: [],
  }),
  async mounted() {
    const id = this.$route.params.id;
    try {
      const res = await this.studyChapter.getStudyChapterById(id);
      this.listLessons = res.data.baiHocs;
      console.log(this.listLessons);
    } catch (e) {
      console.error("Error Fetching Lessons" + e.message);
    }
  },
  methods: {
    filterNumeric(event) {
      // Lọc ký tự không phải số
      this.numericValue = event.target.value.replace(/\D/g, "");
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
  },
  computed: {
    getStatus() {
      return this.status ? "Đang hoạt động" : "Ngưng hoạt động";
    },
    computedDataObject() {
      // Trả về một đối tượng mới bằng cách kết hợp dữ liệu ban đầu với trường key
      return {
        ...this.headers,
        key: "status '" + this.getStatus,
      };
    },
    number() {
      return [(value) => /^\d*$/.test(value) || "Chỉ được nhập số"];
    },
  },
};
</script>
<style scoped>
.btn-update {
  color: black;
}
.btn-update:hover {
  color: rgb(255, 234, 0);
}
.btn-delete {
  color: black;
}
.btn-delete:hover {
  color: red;
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
</style>
