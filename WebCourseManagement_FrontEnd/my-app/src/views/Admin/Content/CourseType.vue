<template>
  <div class="course-type">
    <div class="btn-add-course text-right">
      <v-dialog persistent max-width="600">
        <template v-slot:activator="{ props: activatorProps }">
          <v-btn
            color="purple-accent-4"
            size="small"
            variant="flat"
            text="Thêm mới"
            v-bind="activatorProps"
            class="mb-6"
          >
          </v-btn>
        </template>

        <template v-slot:default="{ isActive }">
          <div>
            <v-card class="pa-5">
              <label>
                <span class="obligatory mr-2">*</span>
                Tên thể loại khóa học
              </label>
              <v-text-field
                class="mt-3"
                :rules="rules"
                v-model="inputCreateCourseTypes.tenLoaiKhoaHoc"
                color="purple-accent-4"
                variant="outlined"
                placeholder="Tên thể loại khóa học"
              ></v-text-field>
              <v-card-actions>
                <v-spacer></v-spacer>

                <v-btn
                  :disabled="loading"
                  :loading="loading"
                  class="text-none mt-4"
                  color="purple-accent-4"
                  size="x-large"
                  variant="flat"
                  @click="createCourseType"
                  >Thêm thể loại khóa học</v-btn
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
    <a-table :data-source="this.listCourseTypes" :columns="columns">
      <template #headerCell="{ column }">
        <template v-if="column.key === 'name'">
          <span style="color: #1890ff"></span>
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
              (e) => setSelectedKeys(e.target.value ? [e.target.value] : [])
            "
            @pressEnter="handleSearch(selectedKeys, confirm, column.dataIndex)"
          />
          <a-button
            type="primary"
            size="small"
            style="width: 90px; margin-right: 8px; color: #fff"
            @click="handleSearch(selectedKeys, confirm, column.dataIndex)"
          >
            <v-icon icon="mdi-magnify"></v-icon>
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
      <template #listCourseTypes="{ text }">
        <span
          v-if="state.searchText && state.searchedColumn === 'tenLoaiKhoaHoc'"
        >
          <template
            v-for="(fragment, i) in text
              .toString()
              .split(
                new RegExp(
                  `(?<=${state.searchText})|(?=${state.searchText})`,
                  'i'
                )
              )"
          >
            <mark
              v-if="fragment.toLowerCase() === state.searchText.toLowerCase()"
              :key="i"
              class="highlight"
            >
              {{ fragment }}
            </mark>
            <template v-else>
              {{ fragment }}
            </template>
          </template>
        </span>
      </template>
      <div v-if="column.key === 'operation'" style="z-index: 8">
        <v-row v-for="i in listCourseTypes" :key="i">
          <v-col>
            <v-dialog persistent max-width="600">
              <template v-slot:activator="{ props: activatorProps }">
                <v-btn
                  icon
                  color="black"
                  size="small"
                  variant="outlined"
                  v-bind="activatorProps"
                >
                  <font-awesome-icon
                    icon="fa-solid fa-pen"
                    style="font-size: 16px"
                  ></font-awesome-icon>
                </v-btn>
              </template>

              <template v-slot:default="{ isActive }">
                <div>
                  <v-card class="pa-5">
                    <label>
                      <span class="obligatory mr-2">*</span>
                      Tên thể loại khóa học
                    </label>
                    <v-text-field
                      class="mt-3"
                      :rules="rules"
                      color="purple-accent-4"
                      variant="outlined"
                      placeholder="Tên thể loại khóa học"
                    ></v-text-field>
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
                        >Sửa thể loại khóa học</v-btn
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
          <v-col>
            <v-btn icon color="red" size="small" variant="outlined">
              <font-awesome-icon
                icon="fa-solid fa-lock"
                style="font-size: 16px"
              ></font-awesome-icon>
            </v-btn>
          </v-col>
        </v-row>
      </div>
    </a-table>
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
  </div>
</template>
<script>
import { courseTypeApi } from "../../../apis/Course/courseTypeApi";

export default {
  data() {
    return {
      courseTypeApiInstance: courseTypeApi(),
      listCourseTypes: [],
      inputCreateCourseTypes: {
        tenLoaiKhoaHoc: "",
      },
      text:"",
      snackbar:false,
      columns: [],
      state: [
        {
          searchText: "",
          searchedColumn: "",
        },
      ],
    };
  },
  async mounted() {
    try {
      const res = await this.courseTypeApiInstance.getAllCoursesType();
      console.log(res);
      this.listCourseTypes = res;

      this.columns = [
        {
          title: "Tên thể loại khóa học",
          dataIndex: "tenLoaiKhoaHoc",
          key: "tenLoaiKhoaHoc",
          customFilterDropdown: true,
          onFilter: (value, record) => {
            return record.tenLoaiKhoaHoc
              .toLowerCase()
              .includes(value.toLowerCase());
          },
          onFilterDropdownOpenChange: (visible) => {
            if (visible) {
              setTimeout(() => {
                searchInput.value.focus();
              }, 100);
            }
          },
        },
        {
          title: "Thao tác",
          key: "operation",
          width: 300,
        },
      ];
      console.log(this.listCourseTypes);
    } catch (e) {
      console.error("Error Fetching failed: " + e.message);
    }
  },
  methods: {
    handleSearch(selectedKeys, confirm, dataIndex) {
      confirm();
      state.searchText = selectedKeys[0];
      state.searchedColumn = dataIndex;
    },
    handleReset(clearFilters) {
      clearFilters({
        confirm: true,
      });
      state.searchText = "";
    },
    async createCourseType() {
      const result = await this.courseTypeApiInstance.createCourseTypes(this.inputCreateCourseTypes)
      if (result){
        this.text = "Thêm loại khóa học thành công";
        this.snackbar = true;
          setTimeout(() => {
            this.reloadPage();
          }, 2000)
      }else{
        this.text = "Thêm thể loại khóa học thất bại"
        this.snackbar = true;
      }
      
    },
        reloadPage() {
      location.reload();
    },
  },
};
</script>

<style scoped>
.obligatory {
  color: red;
}
.highlight {
  background-color: rgb(255, 192, 105);
  padding: 0px;
}
</style>
