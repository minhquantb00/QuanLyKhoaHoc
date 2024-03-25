<template>
  <div id="scroll">
    <HeaderItem style="min-height: 72px"></HeaderItem>
    <div>
      <v-layout>
        <div class="container">
          <v-row>
            <v-col cols="3">
              <div v-if="loadingPost" class="mt-10">
                <v-skeleton-loader type="paragraph"></v-skeleton-loader>
              </div>
              <div v-else class="fixel-commet">
                <div class="user">
                  <v-list-item
                    prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
                    subtitle="Founder of Vuetify"
                    title="John Leider"
                  >
                  </v-list-item>
                </div>
                <hr />
                <v-row>
                  <v-col>
                    <v-icon
                      icon="mdi-heart-outline"
                      hover
                      variant="text"
                    ></v-icon>
                    <span class="ml-2">1153</span>
                  </v-col>
                  <v-col>
                    <v-dialog max-width="800">
                      <template v-slot:activator="{ props: activatorProps }">
                        <v-icon
                          v-bind="activatorProps"
                          icon="mdi-chat-outline"
                          hover
                          variant="text"
                        ></v-icon>
                        <span class="ml-2">53</span>
                      </template>

                      <template v-slot:default="{}">
                        <div style="background: white" class="pa-4">
                          <v-card
                            class="overflow-y-auto mb-6 pa-2"
                            height="700"
                            v-scroll.self="onScroll"
                          >
                            <v-row>
                              <v-col cols="6">
                                <div class="comment-user-post">
                                  <v-card
                                    color="grey-lighten-4"
                                    class="mt-6 rounded-shaped"
                                    :prepend-avatar="p.nguoiDung"
                                    width="350"
                                    v-for="p in listComments"
                                    :key="p.id"
                                  >
                                    <template v-slot:title>{{
                                      p.name
                                    }}</template>

                                    <v-card-text>
                                      {{ p.comments }}
                                    </v-card-text>
                                  </v-card>
                                </div>
                              </v-col>
                              <v-col cols="6"> </v-col>
                            </v-row>
                            <v-row>
                              <v-col></v-col>
                              <v-col>
                                <v-row>
                                  <v-col
                                    v-for="(bar, i) in bars"
                                    :key="i"
                                    class="my-4"
                                    cols="12"
                                    md="12"
                                    sm="12"
                                  >
                                    <v-card
                                      color="grey-lighten-4"
                                      class="rounded-shaped"
                                      height="200px"
                                    >
                                      <v-toolbar color="grey-lighten-4">
                                        <div class="comment-user-post">
                                          <v-card
                                            color="purple-accent-2"
                                            class="rounded-shaped"
                                            prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
                                            width="350"
                                          >
                                            <template v-slot:title
                                              >Trần Văn Dương</template
                                            >
                                          </v-card>
                                        </div>

                                        <div
                                          color="grey-lighten-4"
                                          class="rounded-shaped"
                                          prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
                                          width="350"
                                        >
                                          <!-- <template v-slot:title>Trần Văn Dương</template> -->
                                        </div>
                                        <v-spacer></v-spacer>
                                        <v-menu
                                          v-model="menu"
                                          :close-on-content-click="false"
                                          location="end"
                                        >
                                          <template
                                            v-slot:activator="{ props }"
                                          >
                                            <v-btn
                                              color="black"
                                              v-bind="props"
                                              icon
                                              variant="text"
                                            >
                                              <v-icon
                                                icon=" mdi-dots-vertical"
                                              ></v-icon>
                                            </v-btn>
                                          </template>

                                          <v-card width="200">
                                            <v-list>
                                              <v-list-item>
                                                <v-dialog max-width="500">
                                                  <template
                                                    v-slot:activator="{
                                                      props: activatorProps,
                                                    }"
                                                  >
                                                    <v-btn
                                                      v-bind="activatorProps"
                                                      color="surface-variant"
                                                      variant="text"
                                                      class="text-none text-p"
                                                    >
                                                      Chỉnh sửa
                                                    </v-btn>

                                                    <router-link
                                                      to="#"
                                                      style="
                                                        text-decoration: none;
                                                        color: black;
                                                      "
                                                    >
                                                      <v-btn
                                                        v-bind="activatorProps"
                                                        color="surface-variant"
                                                        variant="text"
                                                        class="text-none"
                                                      >
                                                        Xóa
                                                      </v-btn>
                                                    </router-link>
                                                  </template>

                                                  <template
                                                    v-slot:default="{
                                                      isActive,
                                                    }"
                                                  >
                                                    <v-card
                                                      title="Bình luận"
                                                      class="pa-4"
                                                    >
                                                      <v-textarea
                                                        class="mt-4"
                                                        label="Chỉnh sửa bình luận"
                                                        variant="outlined"
                                                      ></v-textarea>
                                                      <v-card-actions>
                                                        <v-spacer></v-spacer>

                                                        <v-btn
                                                          text="Hủy"
                                                          @click="
                                                            isActive.value = false
                                                          "
                                                        ></v-btn>
                                                      </v-card-actions>
                                                    </v-card>
                                                  </template>
                                                </v-dialog>
                                              </v-list-item>
                                            </v-list>
                                          </v-card>
                                        </v-menu>
                                      </v-toolbar>
                                    </v-card>
                                  </v-col>
                                </v-row>
                              </v-col>
                            </v-row>
                          </v-card>
                          <div class="comment">
                            <v-row location="bottom">
                              <v-col cols="1">
                                <v-avatar
                                  color="surface-variant"
                                  image="https://cdn.vuetifyjs.com/images/john.jpg"
                                  size="50"
                                ></v-avatar>
                              </v-col>
                              <v-col cols="11">
                                <!-- <v-text-field class="rounded-pill"></v-text-field> -->
                                <div
                                  class="bg-grey-lighten-3 rounded-pill d-inline-block text-right"
                                  style="width: 100%"
                                >
                                  <v-row>
                                    <v-col cols="10">
                                      <input
                                        type="text"
                                        class="input-content-comment"
                                        placeholder="Bạn đang nghĩ gì"
                                      />
                                    </v-col>
                                    <v-col cols="2">
                                      <v-btn
                                        color="purple"
                                        variant="text"
                                        icon=" mdi-send-outline"
                                      ></v-btn>
                                    </v-col>
                                  </v-row>
                                </div>
                                <!--  -->
                              </v-col>
                            </v-row>
                          </div>
                        </div>
                      </template>
                    </v-dialog>
                  </v-col>
                </v-row>
              </div>
            </v-col>
            <v-col cols="9">
              <div class="post-client">
                <div v-if="loadingPost" class="mt-10">
                  <v-skeleton-loader type="paragraph"></v-skeleton-loader>
                </div>
                <h1 v-else>
                  Tổng hợp các sản phẩm của học viên tại MyBugs 👏👏
                </h1>
                <div v-if="loadingPost" class="mt-10" style="width: 300px">
                  <v-skeleton-loader
                    type="list-item-avatar"
                  ></v-skeleton-loader>
                </div>
                <div v-else class="post">
                  <div class="user-post mt-10">
                    <v-row>
                      <v-col cols="1">
                        <v-avatar
                          color="surface-variant"
                          image="https://cdn.vuetifyjs.com/images/john.jpg"
                          size="70"
                        ></v-avatar>
                      </v-col>
                      <v-col cols="3">
                        <div class="content-name-user mt-6">
                          <h5>Trần Văn Dương</h5>
                        </div>
                      </v-col>
                    </v-row>
                  </div>
                </div>
              </div>
              <div v-if="loadingPost" class="mt-10">
                <v-skeleton-loader type="card"></v-skeleton-loader>
                <v-skeleton-loader type="article"></v-skeleton-loader>
              </div>
              <div v-else class="card-post mt-10">
                <div class="mx-auto" max-width="400">
                  <v-img
                    class="align-end text-white"
                    height="400"
                    src="https://mega.com.vn/media/news/2605_hinh-nen-anime-may-tinh8.jpg"
                    cover
                  >
                    <v-card-title style="color: #e0e0e0"
                      >Top 10 Australian beaches</v-card-title
                    >
                  </v-img>

                  <v-card-subtitle class="pt-4">
                    <!-- {{ item.date }} -->
                  </v-card-subtitle>

                  <div>
                    <div>
                      Lorem ipsum dolor sit amet consectetur adipisicing elit.
                      Modi commodi earum tenetur. Asperiores dolorem placeat ab
                      nobis iusto culpa, autem molestias molestiae quidem
                      pariatur. Debitis beatae expedita nam facere perspiciatis.
                      Lorem ipsum dolor sit amet consectetur adipisicing elit.
                      Repellendus ducimus cupiditate rerum officiis consequuntur
                      laborum doloremque quaerat ipsa voluptates, nobis nam quis
                      nulla ullam at corporis, similique ratione quasi illo!
                      Lorem ipsum dolor sit amet consectetur adipisicing elit.
                      Rem quae autem blanditiis laborum nihil repellat
                      consectetur, minus nostrum aperiam provident perferendis
                      vitae quaerat. Dolorem veritatis sit harum ipsum omnis
                      temporibus? Ducimus possimus necessitatibus aliquid illo,
                      sunt blanditiis voluptatem quisquam repellat laboriosam
                      provident fugiat qui doloremque maiores aliquam maxime
                      quam vel sit adipisci. Eaque saepe aperiam tempora dolorum
                      blanditiis tempore deleniti. Dolorem maxime optio
                      provident delectus. Rerum quas earum tenetur consectetur,
                      architecto sed ab sunt error incidunt odit autem quia
                      optio impedit nesciunt. Magnam maiores numquam temporibus
                      aperiam quasi! Odit, quod. Nulla nostrum eius omnis
                      molestiae veniam illum, veritatis iure eaque sit
                      perferendis quasi, quia commodi officia cupiditate libero
                      eligendi ea accusantium est accusamus voluptatem nemo eos
                      id cum! Similique, explicabo. Laboriosam, rerum repellat?
                      Eveniet facere numquam libero? Inventore nulla ipsum
                      nostrum exercitationem voluptate amet iusto asperiores
                      quis animi rerum. Culpa blanditiis magnam sed et maxime
                      repellat minima ab placeat facere? Atque voluptate,
                      sapiente fugiat dolorum molestiae explicabo debitis
                      quibusdam iusto ipsam ab beatae iste quia ullam. Rerum,
                      architecto ipsam provident, amet autem nobis placeat
                      veritatis doloribus nam officia necessitatibus corporis?
                      At minus in molestias voluptatem quis quasi error mollitia
                      suscipit debitis. Similique, quo quaerat! Assumenda, est
                      expedita officiis cumque debitis magni blanditiis. In enim
                      harum exercitationem atque? Ipsum, ratione ex? Cum
                      expedita facere iste porro, eligendi dolores obcaecati
                      consectetur nemo, adipisci similique et ex. Omnis vel
                      quidem debitis eaque quasi deleniti aspernatur. Aperiam,
                      debitis. Quas eius hic nesciunt atque tempore. Temporibus
                      repudiandae nisi eius consequatur veritatis reprehenderit
                      hic provident neque nobis labore nostrum quis praesentium
                      doloribus ratione error facere maiores inventore, deserunt
                      repellat reiciendis velit nam! Officia, dolores et!
                      Repellat. Dignissimos, necessitatibus quasi aperiam quae
                      minima consequuntur nobis fugiat esse explicabo quaerat
                      ratione ipsa ad iste possimus animi nulla veritatis eaque
                      voluptatem repudiandae. Ea ad quia natus placeat maiores
                      magni. Reiciendis, commodi veniam adipisci illo quaerat
                      officiis debitis qui quod provident beatae incidunt? Ullam
                      quae rerum iure adipisci esse dolorem ab veniam distinctio
                      necessitatibus fugiat. Temporibus nulla recusandae esse
                      corporis. Perspiciatis pariatur quisquam reprehenderit
                      magni enim ratione eos ea, laboriosam sequi vitae,
                      molestiae nisi odit quidem voluptas corporis incidunt
                      autem quaerat saepe animi ex soluta, deserunt iste.
                      Reiciendis, nisi voluptates.
                    </div>
                  </div>
                </div>
              </div>
            </v-col>
          </v-row>
        </div>

        <v-navigation-drawer
          v-model="drawer"
          location="right"
          temporary
          width="800"
          class="pa-6 sticky-navigation"
          style="height: 95vh"
          id="drawer"
        >
        </v-navigation-drawer>
      </v-layout>
    </div>
    <FooterItem class="mt-10"></FooterItem>
  </div>
</template>
<script>
import HeaderItem from "../Header/HeaderItem.vue";
import FooterItem from "../Header/FooterItem.vue";

export default {
  el: "#scroll",
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      fav: true,
      menu: false,
      message: false,
      hints: true,
      drawer: null,
      loadingPost: true,
      scrollInvoked: 0,
      bars: [{ class: "" }],
      listComments: [
        {
          id: 1,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 2,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 3,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 3,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 3,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 3,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 3,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 3,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
      ],
    };
  },
  async mounted() {
    setTimeout(() => {
      this.loadingPost = false;
    }, 2000);
  },
  methods: {
    onScroll() {
      this.scrollInvoked++;
    },
    disableScroll(event) {
      // Kiểm tra xem con trỏ có di chuyển ra khỏi vùng của drawer không
      if (!event.currentTarget.contains(event.relatedTarget)) {
        event.preventDefault();
      }
    },
  },
};
</script>
<style scoped>
.fixel-commet {
  position: fixed;
  margin: 50px 0px 0px 0px;
}
.input-comment-custom {
  background: rgb(213, 213, 213);
  width: 100%;
  height: 50px;
  border-radius: 50px;
}
.input-comment-custom input {
  height: 50px;
  width: 100%;
  border-radius: 50px;
  border: none;
  outline: none;
  padding-left: 20px;
}
.post-client {
  margin: 40px 0px 0px 0px;
}
.input-content-comment {
  width: 100%;
  height: 50px;
  border-radius: 50px;
  outline: none;
  border: none;
  padding-left: 30px;
}
.user-post-item {
  margin-top: 30px;
}
.sticky-navigation {
  height: 100vh;
}
</style>
