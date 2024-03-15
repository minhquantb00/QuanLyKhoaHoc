<template>
  <div id="register">
    <div class="background-register"></div>
    <div class="background-opacity"></div>
    <div class="main-register d-flex justify-content-evenly align-items-center">
      <div class="layout">
        <div v-if="!isConfirm" class="form-login">
          <div class="logo text-center mb-6">
            <span class="content-register mr-3"
              >Đăng kí tài khoản khách hàng</span
            >
            <img
              src="../../assets/image/logo2.png"
              width="110"
              style="margin-top: -10px"
              alt=""
            />
            <p>
              Bạn đang là khách hàng của MyBugs?
              <router-link to="/login" style="text-decoration: none"
                ><span>Quay lại đăng nhập</span></router-link
              >
            </p>
          </div>
          <a-form
            :model="formState"
            name="normal_login"
            class="login-form"
            @finish="onFinish"
            @finishFailed="onFinishFailed"
          >
            <a-form-item name="username" :rules="taiKhoanRules">
              <a-label style="font-size: 15px"
                ><span class="obligatory mr-2">*</span>Email</a-label
              >
              <a-input
                v-model:value="inputRegister.email"
                placeholder="Email"
                class="input-content-one"
              >
              </a-input>
            </a-form-item>
            <v-row class="mt-6">
              <v-col>
                <a-form-item name="username" :rules="taiKhoanRules">
                  <a-label style="font-size: 15px"
                    ><span class="obligatory mr-2">*</span>Tài khoản</a-label
                  >

                  <a-input
                    v-model:value="inputRegister.taiKhoan"
                    placeholder="Tài khoản"
                    class="input-content"
                  >
                  </a-input>
                </a-form-item>
              </v-col>
              <v-col>
                <a-form-item name="password" :rules="passwordRules">
                  <a-label style="font-size: 15px"
                    ><span class="obligatory mr-2">*</span>Mật khẩu</a-label
                  >

                  <a-input-password
                    v-model:value="inputRegister.matKhau"
                    placeholder="Mật khẩu"
                    class="input-content"
                  >
                  </a-input-password>
                </a-form-item>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <a-form-item name="username" :rules="taiKhoanRules">
                  <a-label style="font-size: 15px"
                    ><span class="obligatory mr-2">*</span>Họ và tên</a-label
                  >

                  <a-input
                    v-model:value="inputRegister.hoVaTen"
                    placeholder="Họ và tên"
                    class="input-content"
                  >
                  </a-input>
                </a-form-item>
              </v-col>
              <v-col>
                <a-form-item name="username" :rules="taiKhoanRules">
                  <a-label style="font-size: 15px"
                    ><span class="obligatory mr-2">*</span>Số điện
                    thoại</a-label
                  >

                  <a-input
                    v-model:value="inputRegister.soDienThoai"
                    placeholder="Số điện thoại"
                    class="input-content"
                  >
                  </a-input>
                </a-form-item>
              </v-col>
            </v-row>
            <a-form-item name="username" :rules="taiKhoanRules">
              <a-label style="font-size: 15px"
                ><span class="obligatory mr-2">*</span>Giới tính</a-label
              >

              <v-select
                label="Giới tính"
                variant="outlined"
                style="height: 60px"
                color="blue-lighten-2"
                v-model:value="inputRegister.gioiTinh"
                :items="items"
              >
              </v-select>
            </a-form-item>
            <a-checkbox
              class="mb-7 mt-3"
              name="type"
              v-model="terms"
              style="font-size: 16px"
              >Tôi đồng ý với các điều khoản về
              <router-link to="#" style="text-decoration: none"
                ><span>Chính sách và quyền riêng tư</span></router-link
              ></a-checkbox
            >
            <a-form-item class="text-center mt-3">
              <a-button
                type="primary"
                html-type="submit"
                class="login-form-button"
                @click="registerAccount"
                :loading="loading"
              >
                Đăng ký tài khoản
              </a-button>
            </a-form-item>
          </a-form>
        </div>
        <div v-else class="form-login">
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
              <a-input placeholder="Mã xác nhận" v-model:value="maXacNhan" class="input-content">
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
      items: ["Nam", "Nữ"],
      isConfirm: false,
      maXacNhan: '',
      inputRegister: {
        email: "",
        taiKhoan: "",
        matKhau: "",
        soDienThoai: "",
        gioiTinh: null,
      },
      term: false,
      // passwordRules: [
      //   { required: true, message: "Vui lòng nhập mật khẩu", trigger: "blur" },
      // ],
      confirmPasswordRules: [
        {
          required: true,
          message: "Vui lòng xác nhận mật khẩu",
          trigger: "blur",
        },
        { validator: this.validateConfirmPassword, trigger: "blur" },
      ],
      terms: false,
      authenticateApi: authApi(),
      router: useRouter(),
      emitter: useEmitter(),
      loading: false,
      loading1: false,
     
    };
  },
  methods: {
    async registerAccount(){
      this.loading = true;
      const result = (await this.authenticateApi.register(this.inputRegister)).data;
      this.isConfirm = true
      this.loading = false
    },

    async onConfirm(){
      const params = {
        maXacNhan: this.maXacNhan
      }
      await this.authenticateApi.confirmAddUser(params)
    this.router.push({path: '/login'})
    },
    validateConfirmPassword(rule, value, callback) {
      if (value !== this.inputRegister.matKhau) {
        callback(new Error("Mật khẩu xác nhận không trùng khớp"));
      } else {
        callback();
      }
    },
  },
};
</script>

<style scoped>
.obligatory {
  color: red;
}
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
  height: 60px;
  font-size: 18px;
}
.input-content-one {
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
.content-register {
  font-size: 30px;
  font-weight: bold;
}
</style>
