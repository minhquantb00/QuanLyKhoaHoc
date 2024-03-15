<template>
  <div class="container">
    <div class="title-post">
      <v-text-field label="Tiêu đề"></v-text-field>
    </div>
    <div class="uploadImage">
      <v-file-input
        :rules="rules"
        accept="image/png, image/jpeg, image/bmp"
        label="Avatar"
        placeholder="Pick an avatar"
        prepend-icon="mdi-camera"
      ></v-file-input>
    </div>
    <ckeditor
      :editor="editor"
      v-model="updateDescription"
      :config="editorConfig"
      aria-placeholder="Mô tả"
      style="height:500px"
    ></ckeditor>
  </div>
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
export default {
  data() {
    return {
      editor: ClassicEditor,
    };
  },
};
</script>

<style scoped>
.ck-editor__editable {
    height: 500px;
}
</style>
