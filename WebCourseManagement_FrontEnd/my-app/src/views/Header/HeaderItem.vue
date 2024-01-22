<template>
  <v-card id="header-course" class="d-flex align-items-center">
    <div class="logo-header">
      <a class="d-block" href="#">
        <img src="https://www.udemy.com/staticx/udemy/images/v7/logo-udemy.svg" width="91px" height="34px" />
      </a>
    </div>

    <div class="search-header d-flex align-items-center">
      <div class="search-icon">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" style="width: 22px"><path d="M416 208c0 45.9-14.9 88.3-40 122.7L502.6 457.4c12.5 12.5 12.5 32.8 0 45.3s-32.8 12.5-45.3 0L330.7 376c-34.4 25.2-76.8 40-122.7 40C93.1 416 0 322.9 0 208S93.1 0 208 0S416 93.1 416 208zM208 352a144 144 0 1 0 0-288 144 144 0 1 0 0 288z"/></svg>
      </div>
      <div class="search-input">
          <input class="search-input-item" type="text" placeholder="Tìm kiếm từ khóa"/>
      </div>
  </div>

  <div class="header-left d-flex">
      <div class="my-course d-flex align-items-center">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" style="width: 22px; margin-right:10px"><path d="M96 0C43 0 0 43 0 96V416c0 53 43 96 96 96H384h32c17.7 0 32-14.3 32-32s-14.3-32-32-32V384c17.7 0 32-14.3 32-32V32c0-17.7-14.3-32-32-32H384 96zm0 384H352v64H96c-17.7 0-32-14.3-32-32s14.3-32 32-32zm32-240c0-8.8 7.2-16 16-16H336c8.8 0 16 7.2 16 16s-7.2 16-16 16H144c-8.8 0-16-7.2-16-16zm16 48H336c8.8 0 16 7.2 16 16s-7.2 16-16 16H144c-8.8 0-16-7.2-16-16s7.2-16 16-16z"/></svg>
          <h6 style="margin: 0;">Khóa học của tôi</h6>
      </div>

      <div class="my-infor d-flex align-items-center">
          <h6 style="margin: 0 20px 0 0;">Trần Minh Quân</h6>
          <div class="my-image">
              <img style="width: 40px; height: 40px; border-radius: 50%;" src="https://scontent.fhan3-4.fna.fbcdn.net/v/t39.30808-6/272894760_1441962499598505_5790021692436032782_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=dd5e9f&_nc_eui2=AeHlx9qKoY3vv048CbrD4wwY_noQivS61cD-ehCK9LrVwAxlMcE3rqD_qxf0kBuV_c6t_qEEegNKc3txL7JETFCw&_nc_ohc=kOeA-vjyHGQAX8LDXdZ&_nc_ht=scontent.fhan3-4.fna&oh=00_AfDX-bRgs_gOUQGSX4epzNK2txIp5gHJdGvsAKk6eZYLDQ&oe=65B3B8B2" href="#" />
          </div>
      </div>
  </div>
  </v-card>
</template>

<script>
export default {

}
</script>

<style scoped>
*{
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
#header-course{
  height: 72px;
  background-color: rgb(226, 226, 226);
  box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px, rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
  padding: 0 40px;
  position: fixed;
  width: 100%;
  z-index: 2;
}
.logo-header{
  line-height: 72px;
  background-color: rgb(226, 226, 226);
  border: none;
}
.search-header{
  padding-left: 20px;
  
  border: 1px rgb(61, 60, 60) solid;
  margin: 0 40px;
  border-radius: 40px;
  line-height: 50px;
}
.search-header input{
  width: 1200px;
}
.search-input-item{
  border: none;
  
  margin-left: 20px;
}
.search-input-item:focus{
  outline: none;
}
.header-left .my-course:hover{
  cursor: pointer;
}
.header-left .my-infor:hover{
  cursor: pointer;
}
.my-infor{
  margin-left: 40px;
}
</style>