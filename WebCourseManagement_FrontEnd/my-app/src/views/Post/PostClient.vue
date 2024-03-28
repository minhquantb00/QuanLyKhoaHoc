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
                    :prepend-avatar="this.listPost.nguoiTaoBaiViet.anhDaiDien"
                    :title="this.listPost.nguoiTaoBaiViet.hoVaTen"
                    subtitle="Tác giả bài viết"
                  >
                  </v-list-item>
                </div>
                <hr />
                <v-row>
                  <v-col>
                    <v-icon
                      color="red"
                      :icon="likeIcon"
                      variant="text"
                      @click="clickLike(this.listPost.id)"
                    ></v-icon>
                    <span class="ml-2">
                      {{ this.likeCount }}
                    </span>
                  </v-col>
                  <v-col>
                    <v-dialog max-width="800">
                      <template v-slot:activator="{ props: activatorProps }">
                        <v-icon
                          v-bind="activatorProps"
                          icon="mdi-chat-outline"
                          hover
                          variant="text"
                          @click="clickComment"
                        ></v-icon>
                        <span class="ml-2">
                          {{ this.listPost.soLuotBinhLuan }}
                        </span>
                      </template>

                      <template v-slot:default="{}">
                        <div style="background: white" class="pa-4">
                          <v-card
                            class="overflow-y-auto bg-blue-lighten-5 mb-6 pa-2"
                            height="700"
                            v-scroll.self="onScroll"
                          >
                            <v-row>
                              <v-col cols="6">
                                <!-- <div class="comment-user-post">
                                  <v-card
                                    color="light-blue-lighten-4"
                                    class="mt-6 rounded-shaped"
                                    :prepend-avatar="p.nguoiBinhLuan.anhDaiDien"
                                    width="350"
                                    v-for="p in listCommentByIdPost"
                                    :key="p"
                                  >
                                    <template v-slot:title>
                                      {{ p.nguoiBinhLuan.hoVaTen }}
                                    </template>

                                    <v-card-text>
                                      {{ p.noiDungBinhLuan }}
                                    </v-card-text>
                                  </v-card>
                                </div> -->
                                <a-comment>
                                  <template #actions>
                                    <span key="comment-basic-like">
                                      <a-tooltip title="Like">
                                        <template v-if="action === 'liked'">
                                          <LikeFilled @click="like" />
                                        </template>
                                        <template v-else>
                                          <LikeOutlined @click="like" />
                                        </template>
                                      </a-tooltip>
                                      <span
                                        style="padding-left: 8px; cursor: auto"
                                      >
                                        {{ likes }}
                                      </span>
                                    </span>
                                    <span key="comment-basic-dislike">
                                      <a-tooltip title="Dislike">
                                        <template v-if="action === 'disliked'">
                                          <DislikeFilled @click="dislike" />
                                        </template>
                                        <template v-else>
                                          <DislikeOutlined @click="dislike" />
                                        </template>
                                      </a-tooltip>
                                      <span
                                        style="padding-left: 8px; cursor: auto"
                                      >
                                        {{ dislikes }}
                                      </span>
                                    </span>
                                    <span key="comment-basic-reply-to"
                                      >Reply to</span
                                    >
                                  </template>
                                  <template #author><a>Han Solo</a></template>
                                  <template #avatar>
                                    <a-avatar
                                      src="https://joeschmoe.io/api/v1/random"
                                      alt="Han Solo"
                                    />
                                  </template>
                                  <template #content>
                                    <p>
                                      We supply a series of design principles,
                                      practical patterns and high quality design
                                      resources (Sketch and Axure), to help
                                      people create their product prototypes
                                      beautifully and efficiently.
                                    </p>
                                  </template>
                                  <template #datetime>
                                    <a-tooltip
                                      :title="
                                        dayjs().format('YYYY-MM-DD HH:mm:ss')
                                      "
                                    >
                                      <span>{{ dayjs().fromNow() }}</span>
                                    </a-tooltip>
                                  </template>
                                </a-comment>
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
                                      color="light-blue-lighten-4"
                                      class="rounded-shaped"
                                      height="200px"
                                      v-for="i in listComments"
                                      :key="i"
                                    >
                                      <v-toolbar color="light-blue-lighten-4">
                                        <div class="comment-user-post">
                                          <v-card
                                            color="light-blue-lighten-5"
                                            class="rounded-shaped"
                                            :prepend-avatar="
                                              i.nguoiBinhLuan.anhDaiDien
                                            "
                                            width="350"
                                          >
                                            <template v-slot:title>
                                              {{ i.nguoiBinhLuan.hoVaTen }}
                                            </template>
                                          </v-card>
                                        </div>

                                        <avatar
                                          color="grey-lighten-4"
                                          class="rounded-shaped"
                                          prepend-avatar="https://cdn.vuetifyjs.com/images/john.jpg"
                                          width="350"
                                        >
                                          <!-- <template v-slot:title>Trần Văn Dương</template> -->
                                        </avatar>
                                        <v-spacer></v-spacer>
                                        <v-menu
                                          v-model="menu"
                                          :close-on-content-click="false"
                                          location="end"
                                        >
                                          {{ i.noiDungBinhLuan }}
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
                                <!-- <div
                                  class="bg-secondary rounded-circle d-inline-block"
                                > -->
                                <v-img
                                  class="rounded-circle"
                                  :src="this.userInfo.Image"
                                ></v-img>
                                <!-- </div> -->
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
                                        v-model="noiDungBinhLuan"
                                      />
                                    </v-col>
                                    <v-col cols="2">
                                      <v-btn
                                        color="purple"
                                        variant="text"
                                        icon=" mdi-send-outline"
                                        @click="createComments"
                                        :disabled="!noiDungBinhLuan.trim()"
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
                  {{ this.listPost.tieuDe }}
                </h1>
              </div>
              <div v-if="loadingPost" class="mt-10">
                <v-skeleton-loader type="card"></v-skeleton-loader>
                <v-skeleton-loader type="article"></v-skeleton-loader>
                <v-skeleton-loader type="article"></v-skeleton-loader>
                <v-skeleton-loader type="article"></v-skeleton-loader>
                <v-skeleton-loader type="article"></v-skeleton-loader>
              </div>
              <div v-else class="card-post mt-10">
                <div class="mx-auto" max-width="400">
                  <v-img
                    class="align-end text-white"
                    height="400"
                    :src="this.listPost.anhBaiViet"
                    cover
                  >
                    <v-card-title style="color: #e0e0e0">{{
                      this.listPost.tieuDe
                    }}</v-card-title>
                  </v-img>

                  <v-card-subtitle class="pt-4">
                    <!-- {{ item.date }} -->
                  </v-card-subtitle>

                  <div v-html="this.listPost.moTa"></div>
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
<script setup>
import dayjs from 'dayjs';
import { ref } from 'vue';
import relativeTime from 'dayjs/plugin/relativeTime';
dayjs.extend(relativeTime);
const likes = ref(0);
const dislikes = ref(0);
const action = ref();
const like = () => {
  likes.value = 1;
  dislikes.value = 0;
  action.value = 'liked';
};
const dislike = () => {
  likes.value = 0;
  dislikes.value = 1;
  action.value = 'disliked';
};
</script>
<script>
import HeaderItem from "../Header/HeaderItem.vue";
import FooterItem from "../Header/FooterItem.vue";
import { postApi } from "../../apis/Post/postApi";
import { useRouter } from "vue-router";

export default {
  el: "#scroll",
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      postApi: postApi(),
      router: useRouter(),

      userInfo: localStorage.getItem("userInfo")
        ? JSON.parse(localStorage.getItem("userInfo"))
        : null,
      fav: true,
      menu: false,
      message: false,
      hints: true,
      drawer: null,
      loadingPost: true,
      isLiked: false,
      scrollInvoked: 0,
      bars: [{ class: "" }],
      listPost: [],
      listCommentByIdPost: [],
      likeCount: 0,
      listPostInvoked: [],
      clickLove: {
        baiVietId: null,
      },
      baiVietId: null,
      noiDungBinhLuan: "",
      listLike: [],
      listComments: [],
    };
  },
  watch: {
    "listPost.soLuotThich": function (newVal, oldVal) {
      // Cập nhật giá trị likeCount khi giá trị của listPost.soLuotThich thay đổi
      this.likeCount = newVal;
    },
  },

  async mounted() {
    const id = this.$route.params.id;
    const userInfo = JSON.parse(localStorage.getItem("userInfo"));

    setTimeout(() => {
      this.loadingPost = false;
    }, 2000);
    try {
      const res = await this.postApi.getAllPostId(id);
      this.listPost = res.data;
      console.log(this.listPost);
    } catch (e) {
      console.error("Error Fetching " + e.message);
    }
    try {
      const res = await this.postApi.getAllPostId(id);
      this.listCommentByIdPost = res.data.binhLuanBaiViets;
      console.log(this.listCommentByIdPost);
    } catch (e) {
      console.error("Error Fetching " + e.message);
    }
    try {
      const response = await this.postApi.getAllPostId(id);
      this.listLike = response.data.nguoiDungThichBaiViets;
      for (let i = 0; i < this.listLike.length; i++) {
        const like = this.listLike[i];
        if (like.nguoiDung.id == userInfo.Id) {
          const likeArray = like.daThich;
          this.isLiked = likeArray;
        }
      }
    } catch (e) {
      console.error("Error Fetching " + e.message);
    }
  },
  methods: {
    onScroll() {
      this.scrollInvoked++;
    },
    disableScroll(event) {
      if (!event.currentTarget.contains(event.relatedTarget)) {
        event.preventDefault();
      }
    },
    async clickLike(id) {
      if (this.userInfo == null) {
        console.log("Vào đấy");
        this.router.push({ path: "/login" });
      } else {
        console.log(id);
        this.clickLove.baiVietId = id;
        const result = await this.postApi.likePost(this.clickLove);
        const response = await this.postApi.getAllPostId(id);
        this.likeCount = response.data.soLuotThich;

        this.isLiked = !this.isLiked;
      }
    },

    async clickComment() {
      if (this.userInfo == null) {
        console.log("Vào đấy");
        this.router.push({ path: "/login" });
      }
    },

    async createComments() {
      const id = this.$route.params.id;
      const params = {
        baiVietId: id,
        noiDungBinhLuan: this.noiDungBinhLuan,
      };
      if (!this.noiDungBinhLuan.trim()) {
        return; // Nếu rỗng thì không thực hiện gì cả
      }
      const res = await this.postApi.createComments(params);
      this.noiDungBinhLuan = "";
      const comments = await this.postApi.getAllPostId(id);
      this.listComments = comments.data.binhLuanBaiViets;
    },
  },
  computed: {
    likeIcon() {
      // Xác định biểu tượng nên hiển thị dựa trên trạng thái isLiked
      console.log(this.isLiked);
      return this.isLiked ? "mdi-heart" : "mdi-heart-outline";
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
