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
            <v-label class="input-label">Tài khoản</v-label>
            <v-text-field
              v-model="inputLogin.taiKhoan"
              color="primary"
              placeholder="Tài khoản"
              variant="underlined"
            ></v-text-field>
            <v-label class="input-label">Mật khẩu</v-label>
            <v-text-field
              v-model="inputLogin.matKhau"
              color="primary"
              placeholder="Mật khẩu"
              type="password"
              variant="underlined"
            ></v-text-field>
            <v-checkbox
            v-model="terms"
            color="primary"
            label="Nhớ mật khẩu"
          />
          </v-container>
  
          <v-card-actions class="justify-content-evenly">
            <v-btn color="success">
              Đăng nhập
  
              <v-icon icon="mdi-chevron-right" end></v-icon>
            </v-btn>
          </v-card-actions>
  
          <v-card-text class="text-center">
            <span class="mr-3">Bạn chưa có tài khoản?</span>
            <v-btn color="success" @click="() => {router.push({ path: '/register' })}">Đăng ký</v-btn>
          </v-card-text>
        </v-card>
      </div>
    </div>
  </template>
  
  <script>
  import { useRouter } from 'vue-router'
  export default {
    data() {
      return {
        inputLogin: {
          taiKhoan: "",
          matKhau: "",
        },
        terms: false,
        router: useRouter()
      };
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
  