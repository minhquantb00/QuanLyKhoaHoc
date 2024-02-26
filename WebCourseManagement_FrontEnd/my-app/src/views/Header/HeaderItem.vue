<template>
  <v-card id="header-course" class="d-flex align-items-center">
    <div class="logo-header">
      <a class="d-block" href="#">
        <img
          src="https://www.udemy.com/staticx/udemy/images/v7/logo-udemy.svg"
          width="91px"
          height="34px"
        />
      </a>
    </div>
    <div class="my-infor d-flex align-items-center">
      <div class="type-menu">
        <a href="">Thể loại</a>
      </div>
      <!-- <h6 style="margin: 0 20px 0 0">Trần Minh Quân</h6>
        <div class="my-image">
          <img
            style="width: 40px; height: 40px; border-radius: 50%"
            src="https://scontent.fhan3-4.fna.fbcdn.net/v/t39.30808-6/272894760_1441962499598505_5790021692436032782_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=dd5e9f&_nc_eui2=AeHlx9qKoY3vv048CbrD4wwY_noQivS61cD-ehCK9LrVwAxlMcE3rqD_qxf0kBuV_c6t_qEEegNKc3txL7JETFCw&_nc_ohc=kOeA-vjyHGQAX8LDXdZ&_nc_ht=scontent.fhan3-4.fna&oh=00_AfDX-bRgs_gOUQGSX4epzNK2txIp5gHJdGvsAKk6eZYLDQ&oe=65B3B8B2"
            href="#"
          /> -->

      <!-- </div>  -->
    </div>
    <div class="search-header d-flex align-items-center">
      <div class="search-icon">
       <font-awesome-icon icon="fa-solid fa-magnifying-glass"></font-awesome-icon>
      </div>
      <div class="search-input">
        <input
          class="search-input-item"
          type="text"
          placeholder="Tìm kiếm từ khóa"
        />
      </div>
    </div>

    <div class="header-left d-flex">
      <div class="my-course d-flex align-items-center">
        <font-awesome-icon
          icon="fa-solid fa-book"
        ></font-awesome-icon>
        <nav class="dropdownmenu ma-2">
          <li>
            <a href=""> <p style="margin: 0">Khóa học của tôi</p></a>
            <ul id="submenu">
              <li>
                <v-card
                  class="mx-auto my-8"
                  max-width="344"
                  title="Hover and click me"
                  subtitle="Same looks, no anchor"
                  link
                  >Dương</v-card
                >
              </li>
            </ul>
          </li>
        </nav>
      </div>
      <div class="my-course d-flex align-items-center">
        <font-awesome-icon
          icon="fa-solid fa-school"
          class="ma-2"
        ></font-awesome-icon>
        <nav class="dropdownmenu">
          <li>
            <a href=""> <p style="margin: 0">Giảng dạy trên udemy</p></a>
            <ul id="submenu">
              <li>
                <v-card
                  class="mx-auto my-8"
                  max-width="344"
                  title="Hover and click me"
                  subtitle="Same looks, no anchor"
                  link
                  >Dương</v-card
                >
              </li>
            </ul>
          </li>
        </nav>
      </div>
      <div class="my-infor d-flex align-items-center">
        <font-awesome-icon icon="fa-solid fa-cart-shopping" />
      </div>
      <!-- <div> -->

      <!-- </div> -->
      <div class="my-infor d-flex align-items-center">
        <!-- <h6 style="margin: 0 20px 0 0">Trần Minh Quân</h6>
        <div class="my-image">
          <img
            style="width: 40px; height: 40px; border-radius: 50%"
            src="https://scontent.fhan3-4.fna.fbcdn.net/v/t39.30808-6/272894760_1441962499598505_5790021692436032782_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=dd5e9f&_nc_eui2=AeHlx9qKoY3vv048CbrD4wwY_noQivS61cD-ehCK9LrVwAxlMcE3rqD_qxf0kBuV_c6t_qEEegNKc3txL7JETFCw&_nc_ohc=kOeA-vjyHGQAX8LDXdZ&_nc_ht=scontent.fhan3-4.fna&oh=00_AfDX-bRgs_gOUQGSX4epzNK2txIp5gHJdGvsAKk6eZYLDQ&oe=65B3B8B2"
            href="#"
          /> -->

        <v-btn
          variant="outlined"
          class="ma-4"
          @click="
            () => {
              router.push({ path: '/login' });
            }
          "
          >Đăng nhập</v-btn
        >

        <v-btn
          @click="
            () => {
              router.push({ path: '/register' });
            }
          "
        >
          Đăng kí
        </v-btn>
        <!-- </div>  -->
      </div>
    </div>
  </v-card>
</template>

<script>
import { useRouter } from "vue-router";
import { authApi } from "../../apis/Auth/authApi";
import useEmitter from "../../helpers/useEmitter";
// import icon form './'
export default {
  data() {
    return {
      router: useRouter(),
      // authenticateApi: authApi(),
      // useEmitter : useEmitter(),
    };
  },
  methods: {},
};
</script>

<style scoped>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
#header-course {
  height: 72px;
  background-color: rgb(226, 226, 226);
  box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px,
    rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
  padding: 0 40px;
  position: fixed;
  width: 100%;
  z-index: 2;
}
.logo-header {
  line-height: 72px;
  background-color: rgb(226, 226, 226);
  border: none;
}
.search-header {
  padding-left: 20px;

  border: 1px rgb(61, 60, 60) solid;
  margin: 0 40px;
  border-radius: 40px;
  line-height: 45px;
}
.search-header input {
  width: 780px;
}
.search-input-item {
  border: none;

  margin-left: 20px;
}
.search-input-item:focus {
  outline: none;
}
.header-left .my-course:hover {
  cursor: pointer;
}
.header-left .my-infor:hover {
  cursor: pointer;
}
.my-infor {
  margin-left: 40px;
}
.dropdownmenu li {
  display: block;
}
.dropdownmenu li a {
  text-decoration: none;
  color: black;
}
#submenu {
  /* left: 0; */
  opacity: 0;
  position: absolute;
  top: 0px;
  visibility: hidden;
  z-index: 1;
}
.dropdownmenu li:hover ul#submenu {
  opacity: 1;
  top: 40px;
  visibility: visible;
}
.type-menu a {
  text-decoration: none;
  color: black;
}
</style>
