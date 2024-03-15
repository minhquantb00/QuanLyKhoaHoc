<template>
  <div class="post">
    <v-row>
      <v-col v-for="item in listPost" :key="item.id">
        <div class="mx-auto" max-width="400">
          <div class="info-user mb-4">
            <v-list-item class="w-100">
              <template v-slot:prepend>
                <v-avatar
                  color="surface-variant"
                  size="60"
                  :image="item.image"
                ></v-avatar>
              </template>

              <v-list-item-title>
                {{ item.user }}
              </v-list-item-title>
            </v-list-item>
          </div>
          <v-img
            class="align-end text-white"
            height="400"
            :src="item.imagePost"
            cover
          >
            <v-card-title style="color: #E0E0E0"
              >Top 10 Australian beaches</v-card-title
            >
          </v-img>

          <v-card-subtitle class="pt-4">{{ item.date }}</v-card-subtitle>

          <v-card
            class="overflow-y-auto"
            max-height="400"
            v-scroll.self="onScroll"
          >
            <v-banner class="justify-center text-h5 font-weight-light" sticky>
              {{item.tieuDe}}
            </v-banner>

            <v-card-text>
              <div v-for="n in 12" :key="n" class="mb-4">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi
                commodi earum tenetur. Asperiores dolorem placeat ab nobis iusto
                culpa, autem molestias molestiae quidem pariatur. Debitis beatae
                expedita nam facere perspiciatis. Lorem ipsum dolor sit amet
                consectetur adipisicing elit. Repellendus ducimus cupiditate
                rerum officiis consequuntur laborum doloremque quaerat ipsa
                voluptates, nobis nam quis nulla ullam at corporis, similique
                ratione quasi illo!
              </div>
            </v-card-text>
          </v-card>

          <v-card-actions class="mt-3">
            <v-btn color="purple-accent-3" variant="flat"> Phê duyệt </v-btn>

            <v-btn color="purple-accent-3" variant="outlined"> Từ chối </v-btn>
          </v-card-actions>
        </div>
      </v-col>
    </v-row>
    <div class="text-center">
      <v-row justify="center">
        <v-col cols="4">
          <v-container class="max-width">
            <v-pagination
              v-model="page"
              :length="16"
              rounded="circle"
            ></v-pagination>
          </v-container>
        </v-col>
      </v-row>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      page: 1,
      scrollInvoked: 0,
      listPost: [
        {
          id: 1,
          user: "Trần Văn Dương",
          image:
            "https://scontent.fhan2-4.fna.fbcdn.net/v/t39.30808-1/371536062_1066526591004110_8607779098701519755_n.jpg?stp=dst-jpg_p160x160&_nc_cat=105&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeH7AHSVdsOCVLKu2rlEXxKzV31Gt4EOCWZXfUa3gQ4JZpPoW-ttXZzQbDEbeLTG2ZcwKVlAh3LOuCzWIxxWBZ8g&_nc_ohc=ENVCfeU51EUAX-x0Swz&_nc_ht=scontent.fhan2-4.fna&oh=00_AfC7pijRwZxay8oDgJ1HdTJ76qtsUOHX8H9zcEonfyBhMw&oe=65F7DC7E",
          imagePost:
            "https://cdn.popsww.com/blog/sites/2/2021/03/doraemon-wiki-1920x1080-1920x1080.jpg",
          tieuDe: "AD không duyệt tao thiến",
          date: "14/03/2024",
        },
        {
          id: 2,
          user: "Nguyễn Thu Hương",
          image:
            "https://scontent.fhan17-1.fna.fbcdn.net/v/t39.30808-6/338975140_172912058951991_4902495190507300213_n.jpg?_nc_cat=106&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeEOo7NH7opMVIED1S-pLfA5fGfQXByJyXF8Z9BcHInJcT9yNXvM16b5ShJlNVQLhTi6P1Z2OjkO-xTO50qjlmH4&_nc_ohc=AG93rWOptU4AX8kqleH&_nc_ht=scontent.fhan17-1.fna&oh=00_AfAN_OqDNOVb71FB84GNmWp7itqORKwsqJuXSO0Zje2kxQ&oe=65F83C63",
          imagePost:
            "https://scontent.fhan17-1.fna.fbcdn.net/v/t39.30808-6/387753961_1813863399073092_2413766650027429219_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeEFXrPbi-7rmjlOmAPErpJdwta8bG6tuxzC1rxsbq27HCCnpwfYgzwDHco_1NvR9hzQz0Q_98Whp2g0rXm9hM0-&_nc_ohc=f5SfjaRYCoUAX8I6hp4&_nc_ht=scontent.fhan17-1.fna&oh=00_AfCxr9U0Plym_g5JZu1L9cyI2Xu_-ghbVPyeXUAmFjv5yA&oe=65F77056",
          tieuDe: "Đang hóng trai, mong AD duyệt",
          date: "14/03/2024",
        },
      ],
    };
  },
  methods: {
    onScroll() {
      this.scrollInvoked++;
    },
  },
};
</script>

<style></style>
