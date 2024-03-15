<template>
  <div id="register">
    <div class="background-register"></div>
    <div class="background-opacity"></div>
    <div class="main-register d-flex justify-content-evenly align-items-center">
      <v-card
        class="form-register text-white mx-auto"
        title="Vui lòng nhập mã xác minh"
      >
        <v-container class="set-index">
          <v-label class="input-label">Mã xác minh</v-label>
          <v-text-field
            v-model="inputRegister.email"
            placeholder="Mã xác minh"
            color="blue"
            variant="underlined"
            
          ></v-text-field>
        </v-container>

        <v-card-actions class="justify-content-evenly">
          <v-btn color="white" :loading="loading" @click="() => {router.push({path:'/new-forgot-password'})}">
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
      terms: false,
      router: useRouter(),
      loading: false
    };
  },
   watch: {
      loading (val) {
        if (!val) return

        setTimeout(() => (this.loading = false), 2000)
      },
    }
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
