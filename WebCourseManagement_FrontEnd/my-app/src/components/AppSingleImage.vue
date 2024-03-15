<template>
  <div class="clearfix text-center">
    <a-upload
      v-model:file-list="fileList"
      list-type="picture-card"

      @preview="handlePreview"
    >
      <div v-if="fileList.length < 1">
        <v-icon icon="mdi-plus"></v-icon>
        <div style="margin-top: 8px">Ảnh khóa học</div>
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
</template>

<script setup>
import { ref, computed } from "vue";

const fileList = ref([]);
const previewVisible = ref(false);
const previewTitle = ref("");
const previewImage = ref("");

const handlePreview = async file => {
  previewImage.value = file.url || file.thumbUrl;
  previewVisible.value = true;
};

const handleCancel = () => {
  previewVisible.value = false;
};

const inputCreateCourse = ref({
  anhKhoaHoc: ""
});

const onFileChange = (e) => {
  const file = e.currentTarget.files[0];
  console.log(file);
  console.log('nó chạy vô đấy rồi');
  if (!file) {
    return;
  }
  // Gọi hàm để xử lý và hiển thị hình ảnh
  createImage(file);
};

// Hàm xử lý chọn tệp hình ảnh
const createImage = (file) => {
  const reader = new FileReader();
  reader.onload = () => {
    // Gán URL của hình ảnh đã chọn vào previewImage
    previewImage.value = reader.result;
  };
  reader.readAsDataURL(file);
};
</script>

<style lang="scss" scoped>
</style>
