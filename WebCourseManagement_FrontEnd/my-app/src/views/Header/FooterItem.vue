<template>
  <v-card id="footer-course">
    <div class="container infor-course">
        <h3 class="text-center text-white">
            <v-img src="https://www.udemy.com/staticx/udemy/images/v7/logo-udemy-inverted.svg" style="padding-left:10px" width="200px" />
            Thông tin về MyBugs Course
        </h3>
        <v-table fixed-header>
            <tbody style="background-color: rgb(24, 21, 21);">
                <tr v-for="item in listWork" :key="item.id">
                    <td class="text-white">{{ item.lienHe }}</td>
                    <td class="text-white">{{ item.gioiThieu }}</td>
                    <td class="text-white">{{ item.sanPham }}</td>
                    <td class="text-white">{{ item.congCu }}</td>
                </tr>
            </tbody>
        </v-table>
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
                    congCu: "Tạo CV xin việc"
                },
                {
                    id: 2,
                    lienHe: "Email: minhquantb00@gmail.com",
                    gioiThieu: "Liên hệ",
                    sanPham: "Game CSS Dinner",
                    congCu: "Rút gọn liên kết"
                },
                {
                    id: 3,
                    lienHe: "Địa chỉ: 22 Ao Sen",
                    gioiThieu: "Điều khoản",
                    sanPham: "Game CSS Selectors",
                    congCu: "Clip-path maker"
                }
            ]
        }
    },
}
</script>

<style scoped>
#footer-course{
    width: 100%;
    height: 300px;
    background-color: rgb(24, 21, 21);
    display: flex;
    align-items: center;
    
}
.infor-course{
    background-color:  rgb(24, 21, 21);
}
</style>