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
          <v-data-table
            :headers="headers"
            :items="listLessons"
            :search="search"
            v-model:search="search"
            item-value="name"
          >
            <template v-slot:top>
              <v-row class="mt-4 mb-7">
                <v-col cols="6">
                  <v-text-field
                    v-model="search"
                    density="compact"
                    label="Tìm kiếm bài học"
                    prepend-inner-icon="mdi-magnify"
                    variant="solo-filled"
                    flat
                    hide-details
                    single-line
                  ></v-text-field>
                </v-col>
                <v-col cols="6" class="text-right">
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
                </v-col>
              </v-row>
            </template>
          </v-data-table>
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
    search: "",
    headers: [
      {
        title: "#",
        align: "start",
        key: "idLesson",
      },
      {
        title: "Tên bài học",
        align: "end",
        key: "nameLesson",
      },
      {
        title: "Thời gian tạo",
        align: "end",
        key: "timeLStart",
      },
      {
        title: "Thời gian cập nhật",
        align: "end",
        key: "timeUpdate",
      },
      {
        title: "Trạng thái bài học",
        align: "end",
        key: "getStatus",
      },
    ],
    listLessons: [
      {
        idLesson: 1,
        nameLesson: "Bài 1",
        timeLStart: "28/07/2003",
        timeUpdate: "28/07/2023",
        status: true,
      },
      {
        idLesson: 2,
        nameLesson: "Bài 2",
        timeLStart: "28/07/2003",
        timeUpdate: "28/07/2023",
        status: true,
      },
      {
        idLesson: 3,
        nameLesson: "Bài 3",
        timeLStart: "28/07/2003",
        timeUpdate: "28/07/2023",
        status: true,
      },
      {
        idLesson: 4,
        nameLesson: "Bài 4",
        timeLStart: "28/07/2003",
        timeUpdate: "28/07/2023",
        status: true,
      },
    ],
  }),
  methods: {
    filterNumeric(event) {
      // Lọc ký tự không phải số
      this.numericValue = event.target.value.replace(/\D/g, "");
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
