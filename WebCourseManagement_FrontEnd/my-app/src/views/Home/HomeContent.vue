<template>
  <div>
    <div style="height: 72px">
        <HeaderItem></HeaderItem>
        
      </div>
      <div>
        <ContentItem></ContentItem>
      </div>
  </div>

</template>

<script>
import HeaderItem from '../Header/HeaderItem.vue'
import ContentItem from '../Header/ContentItem.vue'
export default {
  components: { HeaderItem, ContentItem },

}
</script>

<style>

</style>