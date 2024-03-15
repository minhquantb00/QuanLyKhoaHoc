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
                  @click="isActive.value = false"
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
    <a-table :data-source="data" :columns="columns">
      <template #headerCell="{ column }">
        <template v-if="column.key === 'name'">
          <span style="color: #1890ff">Name</span>
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
            style="width: 90px; margin-right: 8px"
            @click="handleSearch(selectedKeys, confirm, column.dataIndex)"
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
      <template #bodyCell="{ text, column }">
        <span
          v-if="state.searchText && state.searchedColumn === column.dataIndex"
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
            <template v-else>{{ fragment }}</template>
          </template>
        </span>
        <template v-if="column.key === 'operation'">
          <v-row>
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
        </template>
      </template>
    </a-table>
  </div>
</template>
<script setup>
import { reactive, ref } from "vue";
const data = [
  {
    key: "1",
    username: "Trần Văn Dương",
    phoneNumber: "0388049008",
    email: "Duongtv@gmail.com",
    status: "Đang hoạt động",
  },
  {
    key: "2",
    username: "Trần Diệu Linh",
    phoneNumber: "0345200845",
    email: "Linh208200@gmail.com",
    status: "Ngưng hoạt động",
  },
  {
    key: "3",
    username: "Jim Green",
    phoneNumber: "03787748939",
    email: "Duongtv280703@gmail.com",
    status: "Đang hoạt động",
  },
  {
    key: "4",
    username: "Jim Red",
    phoneNumber: "08472828239",
    email: "Duongtv280703@gmail.com",
    status: "Đang hoạt động",
  },
];
const state = reactive({
  searchText: "",
  searchedColumn: "",
});
const searchInput = ref();
const columns = [
  {
    title: "Tên thể loại khóa học",
    dataIndex: "username",
    key: "username",
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
    title: "Thao tác",
    key: "operation",
    width: 140,
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
