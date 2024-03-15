<template>
  <div>
    <div style="height: 72px">
        <HeaderItem></HeaderItem>
        
      </div>
      <div>
        <ContentItem></ContentItem>
      </div>
      <div style="margin-top:40px">
        <FooterItem></FooterItem>
      </div>
      <!-- <link rel="stylesheet" href="https://api.coze.com/adapter/messenger/webhook"> -->
  </div>

</template>

<script>
import HeaderItem from '../Header/HeaderItem.vue'
import ContentItem from '../Header/ContentItem.vue'
import FooterItem from '../Header/FooterItem.vue'
export default {
  components: { HeaderItem, ContentItem, FooterItem },

}
</script>

<style>

</style>