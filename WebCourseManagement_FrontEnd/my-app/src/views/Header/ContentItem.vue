<template>
  <div id="content-course" class="container">
    <div class="slider">
      <v-carousel show-arrows="hover" hide-delimiters continuous="true">
        <v-carousel-item
          src="https://img-c.udemycdn.com/notices/featured_carousel_slide/image/5bf6274c-4a57-42ce-93d6-9775b06730be.jpg"
          cover
        ></v-carousel-item>

        <v-carousel-item
          src="https://img-c.udemycdn.com/notices/featured_carousel_slide/image/450dec77-8a3c-4286-98af-fe252fd26166.jpg"
          cover
        ></v-carousel-item>
      </v-carousel>
    </div>

    <div class="course-suggest">
      <h2 style="margin-bottom: 20px">Đề xuất cho bạn</h2>
      <div class="list-course">
        <v-sheet class="mx-auto" elevation="8">
          <v-slide-group v-model="model" center-active show-arrows>
            <v-slide-group-item
              v-for="n in listCourse"
              :key="n.id"
              v-slot="{ toggle }"
            >
              <div class="ma-6 course-item" @click="toggle" style="width: 250px">
                <v-img :src="n.image" width="250px" height="141px" />
                <h4>{{ n.nameCourse }}</h4>
                <p style="margin: 0">{{ n.description }}</p>
                <v-rating
                  half-increments
                  hover
                  :length="5"
                  :size="32"
                  :model-value="n.rating"
                  active-color="primary"
                  @click="changeRating(n.id, $event)"
                />
                <p style="margin: 0">{{ n.price }}</p>
              </div>
            </v-slide-group-item>
          </v-slide-group>
        </v-sheet>
      </div>
    </div>
  </div>
</template>

<script>
export default {
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
          price: "397.000 VNĐ",
        },
        {
          id: 3,
          image:
            "https://code24h.com/pictures/picfullsizes/2018/08/12/vpn1534042332.jpg",
          nameCourse: "Khóa học Vuejs",
          description: "Vuejs là một framework của JavaScript,...",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 4,
          image:
            "https://amela.vn/wp-content/uploads/2021/08/reactjs-app-development-500x500-1.jpg",
          nameCourse: "Khóa học ReactJs",
          description: "ReacJs là một thư viện JavaScript mã nguồn mở,...",
          rating: 3,
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
          price: "397.000 VNĐ",
        },
      ],
    };
  },
  methods: {
    changeRating(courseId, event) {
      const newRating = event.target.value;
      const course = this.listCourse.find(course => course.id === courseId);
      if (course) {
        course.rating = newRating;
      }
      console.log(`Updated rating for course ${courseId}: ${newRating}`);
    },
  },
};
</script>

<style scoped>
.course-suggest {
  margin-top: 40px;
  min-height: 1000px;
}
.course-item:hover{
    cursor: pointer;
}
</style>
