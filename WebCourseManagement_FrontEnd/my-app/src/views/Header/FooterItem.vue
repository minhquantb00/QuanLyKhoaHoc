<template>
  <v-card id="footer-course">
    <div class="container infor-course">
        <h3 class="text-center text-white mb-5">
            <v-img src="https://www.udemy.com/staticx/udemy/images/v7/logo-udemy-inverted.svg" style="padding-left:10px" width="200px" />
            <div class="title-footer">
                Thông tin về <span style="color:violet">MyBugs Course</span>
            </div>
        </h3>
        <v-table fixed-header>
            <tbody style="background-color: rgb(24, 21, 21);">
                <tr v-for="item in listWork" :key="item.id">
                    <td class="text-white">{{ item.lienHe }}</td>
                    <td class="text-white"><a href="#">{{ item.gioiThieu }}</a></td>
                    <td class="text-white"><a href="#">{{ item.sanPham }}</a></td>
                    <td class="text-white"><a href="#">{{ item.congCu }}</a></td>
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
.text-white a{
    text-decoration: none;
    color: white;
}
.text-white a:hover{
    box-shadow: 0 0.5px rgb(255, 255, 255);
    transition: box-shadow 0.3s;
}
.title-footer{
    margin: -50px 0px 40px 90px;
}
</style>