<template>
  <div id="register">
    <div class="background-register"></div>
    <div class="background-opacity"></div>
    <div class="main-register d-flex justify-content-evenly align-items-center">
      <v-card
        class="form-register text-white mx-auto"
        title="Cập nhật mật khẩu mới"
      >
        <v-container class="set-index">
          <v-label class="input-label">Mật khẩu mới</v-label>
          <!-- <font-awesome-icon icon="fa-solid fa-eye"></font-awesome-icon> -->

          <v-text-field
            v-model="inputRegister.matKhau"
            placeholder="Mật khẩu mới"
            color="blue"
            :append-inner-icon="visitble ? 'mdi-eye-off' : 'mdi-eye'"
            :type="visitble ? 'text' : 'password'"
            variant="underlined"
            @click:append-inner="visitble = !visitble"
          ></v-text-field>
           <v-label class="input-label">Nhập lại mật khẩu</v-label>
          <v-text-field
            v-model="inputRegister.matKhauMoi"
            placeholder="Nhập lại mật khẩu"
            :append-inner-icon="confirmPass ?'mdi-eye-off' : 'mdi-eye'"
            :type="confirmPass ? 'text' : 'password'"
            color="blue"
            variant="underlined"
            @click:append-inner="confirmPass = !confirmPass"
          ></v-text-field>
        </v-container>

        <v-card-actions class="justify-content-evenly">
          <v-btn color="white" :loading="loading"  :disabled="loading">
            Xác nhận

            <v-icon icon="mdi-chevron-right" end></v-icon>
          </v-btn>
        </v-card-actions>
      </v-card>
    </div>
  </div>
</template>

<script>
import { useRouter } from 'vue-router'
export default {
  data() {
    return {
      inputRegister: {
        taiKhoan: "",
        hoVaTen: "",
        email: "",
        soDienThoai: "",
        matKhau: "",
        gioiTinh: null,
        ngaySinh: new Date(),
      },
      visitble:false,
      confirmPass: false,
      terms: false,
      router: useRouter(),
      loading:false
    };
  },
   watch: {
      loading (val) {
        if (!val) return

        setTimeout(() => (this.loading = false), 2000)
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
  background-image: url(https://png.pngtree.com/background/20210711/original/pngtree-speed-abstract-vector-technology-background-picture-image_1161315.jpg);
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
  background: -webkit-linear-gradient(to right, #0949a8, #0732a8);
  background: linear-gradient(to right, #3e73c4, #001b91);

  box-shadow: 0px 0px 10px 4px rgba(255, 255, 255, 0.5);
}
.set-index {
}
</style>
