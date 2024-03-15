<template>
  <div>
    <div style="min-height: 72px">
      <HeaderItem></HeaderItem>
    </div>
    <div class="container">
      <div class="cart-product">
        <h2 class="item-content-cart mt-7">Giỏ hàng</h2>
      </div>
      <div class="item-group mb-15 mt-15">
        <h3 class="mb-6">Bạn cũng có thể thích</h3>
        <v-sheet class="mx-auto" elevation="4">
          <v-slide-group v-model="model" center-active show-arrows>
            <v-slide-group-item
              v-for="n in listCourse"
              :key="n.id"
              v-slot="{ toggle }"
            >
              <div
                class="ma-6 course-item"
                @click="toggle"
                style="width: 250px"
              >
                <v-img :src="n.image" width="250px" height="141px" />
                <h4>{{ n.nameCourse }}</h4>
                <p>{{ n.teacher }}</p>
                <p style="margin: 0">{{ n.description }}</p>
                <v-rating
                  v-model="rating"
                  size
                  class="my-2"
                  active-color="orange"
                  color="orange-lighten-1"
                ></v-rating>
                <p style="margin: 0">{{ n.price }}</p>
              </div>
            </v-slide-group-item>
          </v-slide-group>
        </v-sheet>
      </div>
    </div>
    <div>
      <FooterItem></FooterItem>
    </div>
  </div>
</template>

<script>
import HeaderItem from "../Header/HeaderItem.vue";
import FooterItem from "../Header/FooterItem.vue";
import { useRouter } from "vue-router";
export default {
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      listCourse: [
        {
          id: 1,
          image:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          nameCourse: "Khóa học C# .Net Core",
          description: "C# là một ngôn ngữ thuần hướng đối tượng,...",
          rating: 3,
          teacher: "Trần Văn Dương",
          price: "397.000 VNĐ",
        },
        {
          id: 2,
          image:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          nameCourse: "Khóa học Java",
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          rating: 3,
          teacher: "Nguyễn Khánh Huyền",
          price: "397.000 VNĐ",
        },
        {
          id: 3,
          image:
            "https://code24h.com/pictures/picfullsizes/2018/08/12/vpn1534042332.jpg",
          nameCourse: "Khóa học Vuejs",
          description: "Vuejs là một framework của JavaScript,...",
          teacher: "Trần Minh Quân",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 4,
          image:
            "https://amela.vn/wp-content/uploads/2021/08/reactjs-app-development-500x500-1.jpg",
          nameCourse: "Khóa học ReactJs",
          description: "ReacJs là một thư viện JavaScript mã nguồn mở,...",
          teacher: "Trần Văn Dương",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 5,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Khóa học Python",
          teacher: "Trần Văn Dương",
          description:
            "Python là một ngôn ngữ lập trình bậc cao, đa mục đích,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
      ],

      listCourseHot: [
        {
          id: 1,
          image:
            "https://tenten.vn/tin-tuc/wp-content/uploads/2022/06/Java-Script-4.jpg",
          nameCourse: "Khóa học Javascript",
          description:
            "JavaScript là ngôn ngữ lập trình website phổ biến hiện nay,...",
          rating: 3,
          teacher: "Trần Văn Dương",
          price: "397.000 VNĐ",
        },
        {
          id: 2,
          image:
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSYqtlZ8hRs-1a_Wdsa-x-rSmWNxNNiaJCaA&usqp=CAU",
          nameCourse: "Khóa học NodeJs",
          description: "Node.js là một hệ thống phần mềm,...",
          rating: 3,
          teacher: "Trần Minh Quân",
          price: "397.000 VNĐ",
        },
        {
          id: 3,
          image:
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZ4sRkWyi-2VPwALEpD6a-rzUJ9W3I1gc_dg&usqp=CAU",
          nameCourse: "Khóa học PHP",
          description: "PHP là một ngôn ngữ lập trình kịch bản,...",
          rating: 3,
          teacher: "Nguyễn Khánh Huyền",
          price: "397.000 VNĐ",
        },
        {
          id: 4,
          image:
            "https://amela.vn/wp-content/uploads/2021/08/reactjs-app-development-500x500-1.jpg",
          nameCourse: "Khóa học ReactJs",
          description: "ReacJs là một thư viện JavaScript mã nguồn mở,...",
          rating: 3,
          teacher: "Trần Văn Dương",
          price: "397.000 VNĐ",
        },
        {
          id: 5,
          image:
            "https://cdn.mcivietnam.com/nhanvien/media/Blog/python-trong-marketingjpegbd2kfe.jpeg",
          nameCourse: "Khóa học Python",
          description:
            "Python là một ngôn ngữ lập trình bậc cao, đa mục đích,...",
          rating: 3,
          teacher: "Trần Văn Dương",
          price: "397.000 VNĐ",
        },
      ],
    };
  },
};
</script>

<style scope>
.item-content-cart{
    font-family: initial;
    font-weight: bold;
    font-size: 40px;
}
</style>
