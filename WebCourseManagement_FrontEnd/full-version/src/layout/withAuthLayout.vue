<template>
  <AuthenticationWrap
    :style="{
      backgroundImage: `url('${require('../static/img/admin-bg-light.png')}')`,
    }"
  >
    <div class="ninjadash-authentication-wrap">
      <div class="ninjadash-authentication-brand d-flex justify-content-center align-items-center">
        <!-- <img :src="require('../static/img/Logo_Dark.svg')" alt="" /> -->
        <img src="https://cdn.vectorstock.com/i/preview-1x/10/76/programmer-mascot-logo-design-vector-46471076.jpg" width="40" alt="#" />
        <h2 style="margin-bottom: 0 !important; margin-left: 10px; color:rgb(201, 75, 194); font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif">MyBugs Course</h2>
      </div>
      <router-view></router-view>
    </div>
  </AuthenticationWrap>
</template>
<script>
import { Aside, Content, AuthenticationWrap } from "./style";

const AuthLayout = {
  name: "AuthLayout",
  components: { Aside, Content, AuthenticationWrap },
};

export default AuthLayout;
</script>
