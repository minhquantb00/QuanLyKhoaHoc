<template>
  <div id="content-course" class="container">
    <div class="slider">
      <v-carousel show-arrows="hover" hide-delimiters>
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
              <div class="ma-6" @click="toggle" style="width: 250px">
                <v-img :src="n.image" width="250px"/>
                <h4 >{{ n.nameCourse }}</h4>
                <p style="margin: 0;">{{ n.description }}</p>
                <v-rating
                  half-increments
                  hover
                  :length="5"
                  :size="32"
                  :model-value="n.rating"
                  active-color="primary"
                />
                <p style="margin:0">{{ n.price }}</p>
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
          description: "C# là một ngôn ngữ thuần hướng đối tượng",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 2,
          image:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          nameCourse: "Khóa học C# .Net Core",
          description: "C# là một ngôn ngữ thuần hướng đối tượng",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 3,
          image:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          nameCourse: "Khóa học C# .Net Core",
          description: "C# là một ngôn ngữ thuần hướng đối tượng",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 4,
          image:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          nameCourse: "Khóa học C# .Net Core",
          description: "C# là một ngôn ngữ thuần hướng đối tượng",
          rating: 3,
          price: "397.000 VNĐ",
        },
        {
          id: 5,
          image:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          nameCourse: "Khóa học C# .Net Core",
          description: "C# là một ngôn ngữ thuần hướng đối tượng",
          rating: 3,
          price: "397.000 VNĐ",
        },
      ],
    };
  },
};
</script>

<style scoped>
.course-suggest {
  margin-top: 40px;
}
</style>
