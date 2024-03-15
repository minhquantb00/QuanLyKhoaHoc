<template>
  <v-card id="footer-course">
    <div class="container">
      <v-row>
        <v-col>
          <h3 class="text-white mb-5">
            <img
              src="../../assets/image/logo2.png"
              style="padding-left: 10px"
              width="200px"
            />
          </h3>
          <v-table fixel-header>
            <tbody style="background-color: rgb(24, 21, 21)">
              <tr v-for="item in listWork" :key="item.id">
                <td class="text-white">{{ item.lienHe }}</td>
              </tr>
            </tbody>
          </v-table>
        </v-col>
        <v-col>
          <h2 class="ma-3 mb-11 mt-6" style="color:#fff">
            Thông tin về <span style="color:#e22bcb">MyBugs Course</span>
          </h2>
          <v-table>
            <tbody style="background-color: rgb(24, 21, 21)">
              <tr v-for="item in listWork" :key="item.id">
                <td class="text-white">
                  <a href="#">{{ item.gioiThieu }}</a>
                </td>
                <td class="text-white">
                  <a href="#">{{ item.sanPham }}</a>
                </td>
                <td class="text-white">
                  <a href="#">{{ item.congCu }}</a>
                </td>
              </tr>
            </tbody>
          </v-table></v-col
        >
      </v-row>
    </div>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      listWork: [
        {
          id: 1,
          lienHe: "Điện thoại: 0339245240",
          gioiThieu: "Giới thiệu",
          sanPham: "Game Nester",
          congCu: "Tạo CV xin việc",
        },
        {
          id: 2,
          lienHe: "Email: minhquantb00@gmail.com",
          gioiThieu: "Liên hệ",
          sanPham: "Game CSS Dinner",
          congCu: "Rút gọn liên kết",
        },
        {
          id: 3,
          lienHe: "Địa chỉ: 22 Ao Sen",
          gioiThieu: "Điều khoản",
          sanPham: "Game CSS Selectors",
          congCu: "Clip-path maker",
        },
      ],
    };
  },
};
</script>

<style scoped>
#footer-course {
  width: 100%;
  height: 300px;
  background-color: rgb(24, 21, 21);
  display: flex;
  align-items: center;
}
.infor-course {
  background-color: rgb(24, 21, 21);
}
.text-white a {
  text-decoration: none;
  color: white;
}
.text-white a:hover {
  box-shadow: 0 0.5px rgb(255, 255, 255);
  transition: box-shadow 0.3s;
}
.title-footer {
  margin: -50px 0px 40px 90px;
}
</style>
