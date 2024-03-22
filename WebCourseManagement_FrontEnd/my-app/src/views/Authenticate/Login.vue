<template>
  <div id="register">
    <div class="background-register"></div>
    <div class="background-opacity"></div>
    <div class="main-register d-flex justify-content-evenly align-items-center">
      <div class="layout">
        <div class="form-login">
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
            <a-form-item name="username" :rules="taiKhoanRules">
              <a-input
                v-model:value="inputLogin.taiKhoan"
                placeholder="Username"
                class="input-content"
              >
              </a-input>
            </a-form-item>

            <a-form-item name="password" :rules="passwordRules">
              <a-input-password
                v-model:value="inputLogin.matKhau"
                placeholder="Password"
                class="input-content"
              >
              </a-input-password>
            </a-form-item>

            <a-form-item>
              <router-link to="/forgot-password" class="login-form-forgot"
                >Quên mật khẩu?</router-link
              >
            </a-form-item>
            <a-form-item class="text-center">
              <a-button
                type="primary"
                html-type="submit"
                class="login-form-button"
                @click="login"
                :loading="loading"
                :disabled="disabled"
              >
                Đăng nhập
              </a-button>
            </a-form-item>
            <a-form-item class="text-center">
              <p style="font-size: 18px">Hoặc đăng nhập với</p>
              <a href="#" class="mr-2">
                <v-btn icon>
                  <img src="../../assets/logo/google.png" width="30" alt="" />
                </v-btn>
              </a>
              <a href="#" class="ml-2">
                <v-btn icon>
                  <img src="../../assets/logo/facebook.png" width="30" alt="" />
                </v-btn>
              </a>
            </a-form-item>
            <a-form-item class="text-center">
              <span style="font-size: 17px">Chưa có tài khoản?</span>
              <router-link to="/register" class="ml-2 content-register-link"
                >Đăng kí</router-link
              >
            </a-form-item>
          </a-form>
        </div>
      </div>
    </div>
    <v-snackbar v-model="snackbar">
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
    </v-snackbar>
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

</script>
<script>
import { useRouter } from "vue-router";
import { authApi } from "../../apis/Auth/authApi";
import useEmitter from "../../helpers/useEmitter";
export default {
  data() {
    return {
      text: "",
      snackbar: false,
      inputLogin: {
        taiKhoan: "",
        matKhau: "",
      },
      terms: false,
      authenticateApi: authApi(),
      router: useRouter(),
      emitter: useEmitter(),
      loading: false,
      taiKhoanRules: [
        (value) => {
          if (value) return true;
          return "Bạn phải điền tên tài khoản";
        },
      ],
      visible: false,
      passwordRules: [
        (value) => {
          if (value) return true;

          return "Mật khẩu là bắt buộc!";
        },
        (value) => {
          if (
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/.test(
              value
            )
          )
            return true;

          return "Mật khẩu phải có ít nhất 8 ký tự, ít nhất 1 ký tự in hoa, ít nhất 1 ký tự in thường, ít nhất 1 số và 1 ký tự đặc biệt!";
        },
      ],
    };
  },
  computed: {
    disabled() {
      return !(this.inputLogin.taiKhoan && this.inputLogin.matKhau);
    }
  },
  methods: {
    async login() {
      try {
        this.loading = true;
        console.log(this.inputLogin);
        const dataLogin = this.inputLogin;
        console.log(dataLogin);

        const result = (await this.authenticateApi.login(dataLogin)).data;
        console.log(result);
        if (result.status === 200) {
          if (!localStorage.getItem("accessToken")) {
            localStorage.setItem("accessToken", result.data.accessToken);
            localStorage.setItem("refreshToken", result.data.refreshToken);
            const accessToken = localStorage.getItem("accessToken");
            var decoded = this.parseJwt(accessToken); // Fix lỗi parseJwt không được định nghĩa
            localStorage.setItem("userInfo", JSON.stringify(decoded));
          }

          const userInfo = JSON.parse(localStorage.getItem("userInfo")); // Lấy userInfo từ localStorage và parse thành đối tượng JSON

          console.log(userInfo);
          console.log("user");
          if (userInfo.role === "Admin") {
            this.router.push({ path: "/admin" });
            this.text = "Đăng nhập thành công";
            this.snackbar = true;
            setTimeout(() => {
              this.reloadPage();
            }, 2000);
          } else {
            this.text = "Đăng nhập thành công";
            this.snackbar = true;
            setTimeout(() => {
              this.reloadPage();
            }, 2000);
            this.router.push({ path: "/" });
          }
        } else {
          const alert = {
            type: "error",
            content: result.message,
          };
          this.emitter.emit("showAlert", alert);
          this.snackbar = true;
        }
      } catch (error) {
        // Xử lý lỗi khi gọi API đăng nhập
        console.error("Error logging in:", error);
        this.text = "Bạn đã nhập sai tài khoản hoặc mật khẩu!";

        this.snackbar = true;
        const alert = {
          type: "error",
          content: result.message,
        };
        this.emitter.emit("showAlert", alert);
        // this.text = "Lỗi hệ thống không đăng nhập được";
        // this.snackbar = true;
      } finally {
        this.loading = false;
      }
    },
    parseJwt(token) {
      var base64Url = token.split(".")[1];
      var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      var jsonPayload = decodeURIComponent(
        window
          .atob(base64)
          .split("")
          .map(function (c) {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );

      return JSON.parse(jsonPayload);
    },
    reloadPage() {
      location.reload();
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
  width: 410px;
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
.form-register {
  width: 30%;
  border-radius: 40px;
  padding: 20px;
  background: #5d5be9;
  background: -webkit-linear-gradient(to right, #ffffff, #ffffff);
  background: linear-gradient(to right, #ffffff, #ffffff);

  box-shadow: 0px 0px 10px 4px rgba(255, 255, 255, 0.5);
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
