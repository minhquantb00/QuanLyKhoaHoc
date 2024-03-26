<template>
  <div>
    <v-row>
      <v-col cols="1">
        <!-- <HeaderDashboardVue></HeaderDashboardVue> -->
      </v-col>
      <v-col>
        <div class="container">
          <div class="text-content-profile">
            <h3>Hồ sơ cá nhân của bạn</h3>
          </div>
          <div class="content-profile">
            <div class="image-user mb-4">
              <v-row>
                <v-col>
                  <div class="clearfix">
                    <a-upload
                      v-model:file-list="fileList"
                      action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                      list-type="picture-card"
                      @preview="handlePreview"
                    >
                      <div v-if="fileList.length < 1">
                        <v-icon icon="mdi-plus"></v-icon>
                        <div style="margin-top: 8px">Upload</div>
                      </div>
                    </a-upload>
                    <a-modal
                      :open="previewVisible"
                      :title="previewTitle"
                      :footer="null"
                      @cancel="handleCancel"
                    >
                      <img
                        alt="example"
                        style="width: 100%"
                        :src="previewImage"
                      />
                    </a-modal>
                  </div>
                </v-col>
                <v-col>
                  <div class="change-password text-right">
                    <v-btn color="purple-accent-3"> Đổi mật khẩu </v-btn>
                  </div>
                </v-col>
              </v-row>
            </div>
            <v-row>
              <v-col>
                <div class="input-profile">
                  <v-lable
                    ><span class="obligatory mr-2">*</span> Họ và tên
                    đệm</v-lable
                  >
                  <a-input
                    v-model:value="value"
                    placeholder="Họ và tên đệm"
                    class="input-ant mt-3 mb-5"
                  />
                  <v-lable class="mt-3"
                    ><span class="obligatory mr-2">*</span>Tên</v-lable
                  >

                  <a-input
                    class="input-ant mt-3 mb-5"
                    v-model:value.lazy="value1"
                    autofocus
                    placeholder="Tên"
                  />
                  <v-lable>Ngày sinh</v-lable>
                  <a-date-picker
                    v-model:value="value1"
                    class="input-ant mt-3 mb-5"
                  />
                  <v-row>
                    <v-col>
                      <v-lable>Tỉnh, thành phố</v-lable>
                      <v-select
                        v-model="selectedTinh"
                        :items="dataTinh"
                        item-title="ten"
                        label="Tỉnh, thành phố"
                        variant="outlined"
                        @change="onTinhChange"
                        class="mt-3"
                      >
                        <template v-slot:item="{ props }">
                          <v-list-item v-bind="props"></v-list-item>
                        </template>
                      </v-select>
                    </v-col>
                    <v-col>
                      <v-lable>Quận, huyện</v-lable>
                      <v-select
                        v-model="selectedHuyen"
                        @change="onHuyenChange"
                        :items="filteredDataHuyen"
                        item-title="ten"
                        :disabled="!selectedTinh"
                        label="Quận, huyện"
                        variant="outlined"
                        class="mt-3"
                      >
                        <template v-slot:item="{ props }">
                          <v-list-item v-bind="props"></v-list-item>
                        </template>
                      </v-select>
                    </v-col>
                  </v-row>
                </div>
              </v-col>
              <v-col>
                <v-lable>Instagram </v-lable>
                <a-input
                  v-model:value="value"
                  placeholder="Link instagram của bạn"
                  class="input-ant mt-3 mb-5"
                />
                <v-lable>Youtube</v-lable>
                <a-input
                  class="input-ant mt-3 mb-5"
                  v-model:value.lazy="value1"
                  autofocus
                  placeholder="Link youtube của bạn"
                />
                <v-lable> Facebook</v-lable>

                <a-input
                  class="input-ant mt-3 mb-5"
                  v-model:value.lazy="value1"
                  autofocus
                  placeholder="Link facebok của bạn"
                />
                <v-lable>Phường, xã</v-lable>
                <v-select
                  v-model="selectedXa"
                  :items="filteredDataXa"
                  item-title="ten"
                  label="Phường, xã"
                  variant="outlined"
                  :disabled="!selectedHuyen"
                  class="mt-3"
                >
                  <template v-slot:item="{ props }">
                    <v-list-item v-bind="props"></v-list-item>
                  </template>
                </v-select>
              </v-col>
            </v-row>
            <div class="descriptions-user mt-5">
              <v-lable class="">Mô tả bản thân</v-lable>
              <ckeditor
                :editor="editor"
                v-model="updateDescription"
                class="mt-3"
                :config="editorConfig"
                aria-placeholder="Mô tả"
              ></ckeditor>
            </div>
          </div>
          <v-btn color="black" class="mt-6">Lưu</v-btn>
        </div></v-col
      >
    </v-row>
    <footer-item></footer-item>
  </div>
</template>
<script setup>
import { ref } from "vue";
import { message } from "ant-design-vue";
function getBase64(img, callback) {
  const reader = new FileReader();
  reader.addEventListener("load", () => callback(reader.result));
  reader.readAsDataURL(img);
}
const fileList = ref([]);
const loading = ref(false);
const imageUrl = ref("");
const handleChange = (info) => {
  if (info.file.status === "uploading") {
    loading.value = true;
    return;
  }
  if (info.file.status === "done") {
    // Get this url from response in real world.
    getBase64(info.file.originFileObj, (base64Url) => {
      imageUrl.value = base64Url;
      loading.value = false;
    });
  }
  if (info.file.status === "error") {
    loading.value = false;
    message.error("upload error");
  }
};
const beforeUpload = (file) => {
  const isJpgOrPng = file.type === "image/jpeg" || file.type === "image/png";
  if (!isJpgOrPng) {
    message.error("You can only upload JPG file!");
  }
  const isLt2M = file.size / 1024 / 1024 < 2;
  if (!isLt2M) {
    message.error("Image must smaller than 2MB!");
  }
  return isJpgOrPng && isLt2M;
};
</script>
<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import FooterItem from "../Header/FooterItem.vue";
import HeaderDashboardVue from "../CreateCourse/HeaderDashboard.vue";
export default {
  components: {
    FooterItem,
    HeaderDashboardVue,
  },
  data() {
    return {
      editor: ClassicEditor,
      dataTinh: [
        { id: 1, ten: "Tỉnh Vĩnh Phúc" },
        { id: 2, ten: "Tỉnh Thái Bình" },
        // Thêm các tỉnh khác vào đây
      ],
      dataHuyen: [
        { tinhId: 1, id: 1, ten: "Huyện Vĩnh Tường" },
        { tinhId: 2, id: 2, ten: "Huyện Đông Hưng" },
        // Thêm các huyện khác vào đây
      ],
      dataXa: [
        { huyenId: 1, id: 1, ten: "Xã Lý Nhân" },
        { huyenId: 2, id: 2, ten: "Xã Hồng Bạch" },
        // Thêm các xã khác vào đây
      ],
      selectedTinh: null,
      selectedHuyen: null,
      selectedXa: null,
    };
  },
  computed: {
    filteredDataHuyen() {
      if (!this.selectedTinh) {
        return [];
        console.log(this.selectedTinh);
      } else {
        return this.dataHuyen.filter(
          (huyen) => huyen.tinhId === this.selectedTinh.id
        );
      }
    },
    filteredDataXa() {
      if (!this.selectedHuyen) return [];
      return this.dataXa.filter((xa) => xa.huyenId === this.selectedHuyen.id);
    },
  },
  methods: {
    onTinhChange() {
      this.selectedHuyen = null;
      this.selectedXa = null;
    },
    onHuyenChange() {
      this.selectedXa = null;
    },
  },
};
</script>

<style scoped>
.avatar-uploader > .ant-upload {
  width: 128px;
  height: 128px;
}
.ant-upload-select-picture-card i {
  font-size: 32px;
  color: #999;
}

.ant-upload-select-picture-card .ant-upload-text {
  margin-top: 8px;
  color: #666;
}
.ant-upload-list-item-container {
  height: 200px;
  width: 200px;
}
.ant-upload .ant-upload-select .ant-upload-select-picture-card {
  height: 200px;
  width: 200px;
}
.input-ant {
  height: 60px;
  font-size: 18px;
  width: 100%;
}
.ck-editor__editable {
  height: 500px;
}
.obligatory {
  color: red;
}
.text-content-profile {
  margin: 30px 0px 30px 0px;
  font-family: initial;
}
.text-content-profile h3 {
  font-weight: bold;
  font-size: 40px;
}
.container {
  margin-bottom: 70px;
}
</style>
