<template>
  <div id="scroll">
    <HeaderItem style="min-height: 72px"></HeaderItem>
    <v-card>
      <v-layout style="height: 100vh">
        <div class="container">
          <v-row>
            <v-col cols="3">
              <div class="fixel-commet">
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
                    <v-icon
                      icon="mdi-chat-outline"
                      hover
                      variant="text"
                      @click.stop="drawer = !drawer"
                    ></v-icon>
                    <span class="ml-2">53</span>
                  </v-col>
                </v-row>
              </div>
            </v-col>
            <v-col cols="9">
              <div class="post-client">
                <h1>Tổng hợp các sản phẩm của học viên tại MyBugs 👏👏</h1>

                <div class="post">
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
              <div v-if="loadingPost">
                <v-skeleton-loader type="paragraph"></v-skeleton-loader>
              </div>
              <div v-else class="card-post">
                <div width="100%" hover>
                  <v-card-item>
                    <v-card-title> Card title </v-card-title>
                    <v-card-subtitle>
                      Card subtitle secondary text
                    </v-card-subtitle>
                  </v-card-item>

                  <v-card-text>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed
                    do eiusmod tempor incididunt ut labore et dolore magna
                    aliqua.
                  </v-card-text>
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
          class="pa-6"
          id="drawer"
          @mouseout="disableScroll"
        >
          <v-card
            class="overflow-y-auto mb-6"
            height="750"
            v-scroll.self="onScroll"
          >
            <v-row>
              <v-col cols="6">
                <div class="comment-user-post">
                  <v-card
                    color="grey-lighten-1"
                    class="mt-6 rounded-shaped"
                    :prepend-avatar="p.nguoiDung"
                    width="350"
                    v-for="p in listComments"
                    :key="p.id"
                  >
                    <template v-slot:title>{{ p.name }}</template>

                    <v-card-text> {{ p.comments }} </v-card-text>
                  </v-card>
                </div>
              </v-col>
              <v-col cols="6">
                <v-toolbar>
                  <div class="comment-user-post">
                    <v-card
                      color="grey-lighten-1"
                      class="mt-6 rounded-shaped"
                      prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
                      width="350"
                    >
                      <template v-slot:title>Trần Văn Dương</template>

                      <v-card-text> alo alo có ai không </v-card-text>
                    </v-card>
                  </div>

                  <div class="text-center">

                  </div>
                </v-toolbar>
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
                      color="grey-lighten-1"
                      class="rounded-shaped"
                      height="200px"
                    >
                      <v-toolbar color="grey-lighten-1">
                        <div
                          color="grey-lighten-1"
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
                      <template v-slot:activator="{ props }">
                        <v-btn
                          color="indigo"
                          v-bind="props"
                          icon
                          variant="text"
                        >
                          <v-icon icon=" mdi-dots-vertical"></v-icon>
                        </v-btn>
                      </template>

                      <v-card min-width="300">
                        <v-list>
                          <v-list-item
                            prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
                            subtitle="Founder of Vuetify"
                            title="John Leider"
                          >
                            <template v-slot:append>
                              <v-btn
                                :class="fav ? 'text-red' : ''"
                                icon="mdi-heart"
                                variant="text"
                                @click="fav = !fav"
                              ></v-btn>
                            </template>
                          </v-list-item>
                        </v-list>

                        <v-divider></v-divider>

                        <v-list>
                          <v-list-item>
                            <v-switch
                              v-model="message"
                              color="purple"
                              label="Enable messages"
                              hide-details
                            ></v-switch>
                          </v-list-item>

                          <v-list-item>
                            <v-switch
                              v-model="hints"
                              color="purple"
                              label="Enable hints"
                              hide-details
                            ></v-switch>
                          </v-list-item>
                        </v-list>

                        <v-card-actions>
                          <v-spacer></v-spacer>

                          <v-btn variant="text" @click="menu = false">
                            Cancel
                          </v-btn>
                          <v-btn
                            color="primary"
                            variant="text"
                            @click="menu = false"
                          >
                            Save
                          </v-btn>
                        </v-card-actions>
                      </v-card>
                    </v-menu>

                      </v-toolbar>
                    </v-card>
                  </v-col>
                </v-row>
              </v-col>
            </v-row>

            <v-card-text> alo alo có ai không </v-card-text>
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
                  class="bg-grey-lighten-1 rounded-pill d-inline-block text-right"
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
        </v-navigation-drawer>
      </v-layout>
    </v-card>
    <FooterItem></FooterItem>
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
      bars: [
        { class: "" },
      ],
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
          id: 4,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 5,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 6,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 7,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 8,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 9,
          comments: "Bài này hay",
          nguoiDung: " https://cdn.vuetifyjs.com/images/john.jpg",
          name: "Trần Văn Dương",
        },
        {
          id: 10,
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
</style>
