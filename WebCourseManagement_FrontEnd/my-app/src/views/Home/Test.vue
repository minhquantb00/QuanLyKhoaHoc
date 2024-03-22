<template>
    <div style="width: 500px; height: 500px;">
        <div ref="editor" style="width: 500px; height: 500px;"></div>
  </div>
</template>

<script>
import * as monaco from 'monaco-editor';

export default {
  name: 'app',
  async mounted() {
    const el = this.$refs.editor;
    this.editor = monaco.editor.create(el, {
      value: "console.log('hello world');",
      language: 'javascript',
    });
  },
};
</script>