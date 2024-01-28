<template>
  <div id="register">
    <div class="background-register"></div>
    <div class="background-opacity"></div>
    <div class="main-register d-flex justify-content-evenly align-items-center">
      <v-card
        class="form-register text-white mx-auto"
        title="Vui lòng đăng nhập tại đây!"
      >
        <v-container class="set-index">
          <v-label class="input-label" :rules="taiKhoanRules"
            >Tài khoản</v-label
          >
          <v-text-field
            v-model="inputLogin.taiKhoan"
            color="primary"
            placeholder="Tài khoản"
            variant="underlined"
          ></v-text-field>
          <v-label class="input-label" :rules="passwordRules">Mật khẩu</v-label>
          <v-text-field
            v-model="inputLogin.matKhau"
            color="primary"
            placeholder="Mật khẩu"
            type="password"
            variant="underlined"
          ></v-text-field>
          <v-checkbox v-model="terms" color="primary" label="Nhớ mật khẩu" />
        </v-container>

        <v-card-actions class="justify-content-evenly">
          <v-btn color="success" :loading="loading" @click="login">
            Đăng nhập

            <v-icon icon="mdi-chevron-right" end></v-icon>
          </v-btn>
        </v-card-actions>

        <v-card-text class="text-center">
          <span class="mr-3">Bạn chưa có tài khoản?</span>
          <v-btn
            color="success"
            @click="
              () => {
                router.push({ path: '/register' });
              }
            "
            >Đăng ký</v-btn
          >
        </v-card-text>
      </v-card>
    </div>
  </div>
</template>

<script>
import { useRouter } from "vue-router";
import { authApi  } from '../../apis/Auth/authApi'
import   useEmitter   from '../../helpers/useEmitter'
export default {
  data() {
    return {
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
  methods: {
    async login(){
      this.loading = true
      const result = (await this.authenticateApi.login(this.inputLogin)).data
      if(result.status === 200){
        this.emitter.emit('showAlert', {
          type: 'success',
          content: result.message
        })
        if(!localStorage.getItem('accessToken')){
          localStorage.setItem('accessToken', result.data.accessToken)
          localStorage.setItem('refreshToken', result.data.refreshToken)

          const accessToken = localStorage.getItem('accessToken')
          var decoded = parseJwt(accessToken)
          localStorage.setItem('userInfo', JSON.stringify(decoded))
        }
        this.router.push({path: '/'})
      }
      else{
        const alert = {
          type: 'error',
          content: result.message
        }
        this.emitter.emit('showAlert', alert)
      }
      this.loading = false
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
  },
};
</script>

<style scoped>
#register {
  width: 100%;
  height: 100%;
}
.background-register {
  background-image: url(https://www.freecodecamp.org/news/content/images/2022/09/jonatan-pie-3l3RwQdHRHg-unsplash.jpg);
  background-size: cover;
  background-repeat: no-repeat;
  width: 100%;
  height: 100%;
  position: relative;
  z-index: 1;
}
.background-opacity {
  background-color: black;
  width: 100%;
  height: 100%;
  opacity: 0.8;
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
  background-color: rgba(0, 0, 0, 0.75);
  box-shadow: 0 0 10px rgba(255, 255, 255, 0.5);
}
</style>
