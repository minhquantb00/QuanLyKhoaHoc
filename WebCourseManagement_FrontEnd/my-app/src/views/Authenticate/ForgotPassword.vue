<template>
  <div id="register">
    <div class="background-register"></div>
    <div class="background-opacity"></div>
    <div class="main-register d-flex justify-content-evenly align-items-center">
      <div class="layout">
        <div v-if="!isConfirm" class="form-login">
          <div class="logo text-center mb-6">
            <img src="../../assets/image/logo2.png" width="130" alt="" />
          </div>
          <a-form
            :model="formState"
            name="normal_login"
            class="login-form"
            @finish="onFinish"
            @finishFailed="onFinishFailed"
          >
            <div class="content-fogot-password text-center">
              <h3>Lấy lại mật khẩu</h3>
              <p style="font-size: 16px" class="text-center">
                Nhập email hoặc số điện thoại để nhận mã xác thực lấy lại mật
                khẩu
              </p>
            </div>
            <a-form-item name="username" :rules="taiKhoanRules">
              <a-input
                v-model:value="inputForgotPass.email"
                placeholder="Email"
                class="input-content"
              >
              </a-input>
            </a-form-item>

            <a-form-item class="text-center">
              <a-button
                type="primary"
                html-type="submit"
                class="login-form-button"
                @click="forgotPassword"
                :loading="loading"
              >
                Lấy lại mật khẩu
              </a-button>
            </a-form-item>
            <a-form-item>
              <v-row>
                <v-col>
                  <router-link to="/login" class="content-register-link">
                    Quay lại đăng nhập</router-link
                  >
                </v-col>
                <v-col class="text-right">
                  <router-link to="/register" class="content-register-link"
                    >Trợ giúp</router-link
                  >
                </v-col>
              </v-row>
            </a-form-item>
          </a-form>
        </div>
        <!-- Nhập mã xác minh -->
        <!-- <div v-else-if="null" class="form-login">
          <div class="logo text-center mb-6">
            <img src="../../assets/image/logo2.png" width="130" alt="" />
            <h3>Nhập mã xác nhận</h3>
            <p>Mã đã được gửi vào email của bạn, vui lòng kiểm tra</p>
          </div>
          <a-form
            :model="formState"
            name="normal_login"
            class="login-form"
            @finish="onFinish"
            @finishFailed="onFinishFailed"
          >
            <a-form-item name="verification" :rules="passwordRules">
              <a-input
                placeholder="Mã xác nhận"
                v-model:value="maXacNhan"
                class="input-content"
              >
              </a-input>
            </a-form-item>
            <a-form-item class="text-center">
              <a-button
                type="primary"
                html-type="submit"
                class="login-form-button"
                @click="onConfirm"
                :loading="loading1"
              >
                Xác nhận
              </a-button>
            </a-form-item>
          </a-form>
        </div> -->
        <!-- Nhập lại password -->
        <div v-else class="form-login">
          <div class="logo text-center mb-6">
            <img src="../../assets/image/logo2.png" width="130" alt="" />
            <h3>Nhập mật khẩu mới</h3>
            <p>
              Vui lòng nhập mã xác đã được gửi trong email để lấy lại mật khẩu
              của bạn
            </p>
          </div>
          <a-form
            :model="formState"
            name="normal_login"
            class="login-form"
            @finish="onFinish"
            @finishFailed="onFinishFailed"
          >
            <a-form-item name="verification" :rules="passwordRules">
              <a-input
                placeholder="Mã xác nhận"
                v-model:value="inputXacNhanMatKhau.maXacNhan"
                class="input-content"
              >
              </a-input>
            </a-form-item>
            <a-form-item name="verification" :rules="passwordRules">
              <a-input-password
                placeholder="Mật khẩu mới"
                v-model:value="inputXacNhanMatKhau.matKhauMoi"
                class="input-content"
              >
              </a-input-password>
            </a-form-item>
            <a-form-item name="verification" :rules="passwordRules">
              <a-input-password
                placeholder="Nhập lại mật khẩu"
                v-model:value="inputXacNhanMatKhau.xacNhanMatKhau"
                class="input-content"
              >
              </a-input-password>
            </a-form-item>
            <a-form-item class="text-center">
              <a-button
                type="primary"
                html-type="submit"
                class="login-form-button"
                @click="updatePassword"
                :loading="loading"
              >
                Lấy lại mật khẩu
              </a-button>
            </a-form-item>
          </a-form>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
import { reactive, computed } from "vue";
const onFinish = (values) => {
  console.log("Success:", values);
};
const onFinishFailed = (errorInfo) => {
  console.log("Failed:", errorInfo);
};
const disabled = computed(() => {
  return !(formState.username && formState.password);
});
</script>
<script>
import { useRouter } from "vue-router";
import { authApi } from "../../apis/Auth/authApi";
import useEmitter from "../../helpers/useEmitter";
export default {
  data() {
    return {
      isConfirm: false,
      inputXacNhanMatKhau: {
        maXacNhan: "",
        matKhauMoi: "",
        xacNhanMatKhau: "",
      },
      inputForgotPass: {
        email: "",
      },
      terms: false,
      authenticateApi: authApi(),
      router: useRouter(),
      emitter: useEmitter(),
      loading: false,
    };
  },
  methods: {
    async forgotPassword() {
      this.loading = true;
      const result = (
        await this.authenticateApi.forgotPassword(this.inputForgotPass)
      ).data;
      this.isConfirm = true;
      this.loading = false;
    },
    async updatePassword() {
      this.loading = true;
      const params = {
        maXacNhan: this.inputXacNhanMatKhau.maXacNhan,
        matKhauMoi: this.inputXacNhanMatKhau.matKhauMoi,
        xacNhanMatKhauMoi: this.inputXacNhanMatKhau.xacNhanMatKhau,
      };
      await this.authenticateApi.updatePassword(params);
      this.router.push({ path: "/" });
    },
  },
};
</script>

<style scoped>
.content-register-link {
  text-decoration: none;
  font-size: 17px;
}
.login-form-button {
  width: 100%;
  height: 60px;
  font-size: 20px;
  color: #ffffff;
}
.site-form-item-icon {
  font-size: 20px;
}
.login-form-forgot {
  text-decoration: none;
  font-size: 17px;
}
.form-login {
  background: #ffffff;
  padding: 20px 40px 20px 40px;
  border-radius: 10px;
}
.input-content {
  width: 100%;
  height: 60px;
  font-size: 18px;
}
#register {
  width: 100%;
  height: 100%;
}
.background-register {
  background-image: url(https://thaihoanghd.com/wp-content/uploads/2021/07/triangle-stage-with-smoke-purple-neon-light-scaled.jpg);
  background-size: cover;
  background-repeat: no-repeat;
  width: 100%;
  height: 100%;
  position: relative;
  z-index: 1;
}
.background-opacity {
  background-color: rgb(1, 3, 32);
  width: 100%;
  height: 100%;
  opacity: 0.2;
  position: absolute;
  top: 0;
  z-index: 2;
}
.main-register {
  width: 100%;
  height: 100%;
  z-index: 3;
  position: absolute;
  top: 0;
}

.or-login {
  text-align: center;
  margin-bottom: 10px;
}
.forgot-password {
  margin-left: 90px;
}
.forgot-password a:hover {
  color: rgb(65, 185, 255);
}
#components-form-demo-normal-login .login-form {
  max-width: 300px;
}
#components-form-demo-normal-login .login-form-forgot {
  float: right;
}
#components-form-demo-normal-login .login-form-button {
  width: 100%;
}
</style>
