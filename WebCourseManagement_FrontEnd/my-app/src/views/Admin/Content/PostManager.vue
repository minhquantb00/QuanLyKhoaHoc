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
            <v-card-title style="color: #e0e0e0"
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
              {{ item.tieuDe }}
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
import { postApi } from "../../../apis/Post/postApi";
export default {
  data() {
    return {
      postApi: postApi(),
      page: 1,
      scrollInvoked: 0,
      listPost: [],
    };
  },
  async mounted() {
    try {
      const res = await this.postApi.getAllPostNotYetApproved();
      this.listPost = res;
      console.log(this.listPost);
    } catch (e) {
      console.error("Error call fetching" + e.message);
    }
  },
  methods: {
    onScroll() {
      this.scrollInvoked++;
    },
  },
};
</script>

<style></style>
