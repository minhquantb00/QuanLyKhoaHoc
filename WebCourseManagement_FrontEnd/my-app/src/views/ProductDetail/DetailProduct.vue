<template>
  <div class="detai-product">
    <div style="height: 72px">
      <HeaderItem></HeaderItem>
    </div>
    <div class="banner" v-for="lc in listCourse" :key="lc.id">
      <div class="container">
        <v-container>
          <v-row>
            <v-col cols="8">
              <v-title class="pa-2 ma-2">
                <h1>{{ lc.courseTitle }}</h1>
                <h5 class="my-4">{{ lc.description }}</h5>
                <h5 class="my-4">
                  Số lượng học viên: {{ lc.numberOfPeopleEnrolled }}
                  <font-awesome-icon
                    class="mx-1"
                    icon="fa-solid fa-user-group"
                  ></font-awesome-icon>
                </h5>
                <h6>Được tạo bởi: {{ lc.teacherCourse }}</h6>
                <p>Ngày cập nhật gần nhất: {{ lc.dateTimeUpdate }}</p>

                <div class="text-left">
                  <v-rating
                    color="orange-lighten-1"
                    active-color="orange"
                  ></v-rating>
                </div>
              </v-title>
            </v-col>

            <v-col
              cols="4"
              class="fixed-element"
              ref="fixedElement"
              id="detail-course"
            >
              <v-card class="mx-auto ma-8 fixed-card" max-width="390">
                <!-- <v-img
                    class="align-end text-white"
                    height="200"
                    src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
                    cover
                  > -->
                <iframe
                  :src="lc.linkVideo"
                  frameborder="0"
                  style="height: 230px; width: 390px"
                ></iframe>
                <v-card-title>
                  <span>đ</span
                  ><span style="font-size: 30px">{{
                    lc.pricepriceHasDecreased
                  }}</span>
                  <span
                    style="text-decoration-line: line-through; font-size: 16px"
                    class="ma-6"
                    >{{ lc.price }}</span
                  >
                </v-card-title>
                <!-- </v-img> -->

                <v-card-subtitle
                  class="pt-4"
                  style="color: red; font-weight: bold"
                  v-for="t in timer"
                  :key="t.id"
                >
                  <font-awesome-icon
                    icon="fa-regular fa-clock"
                  ></font-awesome-icon>
                  <span style="margin-left: 5px">{{ t.time }}</span> giờ còn lại
                  với mức giá này !
                </v-card-subtitle>

                <v-card-title>
                  <v-btn
                    :disabled="loading"
                    :loading="loading"
                    block
                    class="text-none mb-4"
                    color="#9900FF"
                    size="x-large"
                    style="color: #fff"
                    variant="flat"
                    @click="loading = !loading"
                  >
                    Thêm vào giỏ hàng
                  </v-btn>

                  <div>
                    <v-btn
                      :disabled="load"
                      :loading="load"
                      block
                      class="text-none mb-4"
                      color="#000000"
                      size="x-large"
                      style="color: #000000"
                      variant="outlined"
                      @click="load = !load"
                    >
                      Mua ngay
                    </v-btn>
                  </div>
                </v-card-title>
                <!-- <v-card-text> -->
                <v-card-title>
                  <h6>Khóa học này bao gồm:</h6>
                  <ul v-for="c in courseContent" :key="c.id">
                    <li style="font-size: 14px">{{ c.course }}</li>
                  </ul>
                </v-card-title>
                <!-- </v-card-text> -->
              </v-card>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </div>
    <div class="container" id="content-course">
      <div class="body-detail-product">
        <v-container>
          <v-title>
            <h3 class="my-5">Nội dung khóa học</h3>
            <p>
              {{ listEvalute.length }} <span>phần</span> ❤️
              <span>{{ listEvalute.length }} bài giảng</span>
            </p>
          </v-title>
          <v-row>
            <v-col cols="8">
              <!--  -->
              <div>
                <v-expansion-panels
                  v-model="panel"
                  :disabled="disabled"
                  multiple
                  v-for="c in courseContent"
                  :key="c.id"
                >
                  <v-expansion-panel>
                    <v-expansion-panel-title>{{
                      c.course
                    }}</v-expansion-panel-title>
                    <v-expansion-panel-text>
                      <div class="list-lesson">
                        <ul v-for="ls in listLesson" :key="ls.id">
                          <li>
                            <font-awesome-icon
                              icon="fa-solid fa-tv"
                            ></font-awesome-icon>
                            <a :href="ls.linkVideo">{{ ls.nameLesson }}</a>
                          </li>
                        </ul>
                      </div>
                    </v-expansion-panel-text>
                  </v-expansion-panel>
                </v-expansion-panels>
              </div>
              <!--  -->
              <!-- <v-sheet class="pa-2 ma-2">
                <v-card
                  @click="c.show = !c.show"
                  v-for="c in courseContent"
                  :key="c.id"
                >
                  <v-text-field
                    style="border: none"
                    :append-inner-icon="
                      c.show ? 'mdi-chevron-up' : 'mdi-chevron-down'
                    "
                  >
                    <v-title>{{ c.course }}</v-title>
                  </v-text-field>

                  <v-expand-transition>
                    <div v-show="c.show">
                      <div class="list-lesson">
                        <ul v-for="ls in listLesson" :key="ls.id">
                          <li>
                            <font-awesome-icon
                              icon="fa-solid fa-tv"
                            ></font-awesome-icon>
                            <a :href="ls.linkVideo">{{ ls.nameLesson }}</a>
                          </li>
                        </ul>
                      </div>
                    </div>
                  </v-expand-transition>
                </v-card>
              </v-sheet> -->
            </v-col>
          </v-row>
        </v-container>
        <v-container>
          <div class="request">
            <v-row>
              <v-col cols="8">
                <h3 class="my-4">Yêu cầu</h3>
                <div class="title-request">
                  <ul>
                    <li>
                      No need to much experience in the BA position, welcome
                      other domains, you don't need have to have knowledge in IT
                      field.
                    </li>
                  </ul>
                </div>
              </v-col>
            </v-row>
          </div>
          <div class="description">
            <v-row>
              <v-col cols="8">
                <h3 class="my-4">Mô tả</h3>
                <v-title v-for="lc in listCourse" :key="lc.id">
                  {{ lc.description }}
                </v-title>
              </v-col>
            </v-row>
          </div>
        </v-container>
        <v-container>
          <div class="table-course-propose">
            <v-row>
              <v-col cols="8">
                <h3 class="my-6">Học viên cũng mua</h3>
                <div
                  class="data-table"
                  v-for="lc in listCourePropose"
                  :key="lc.id"
                >
                  <v-row>
                    <v-col cols="1">
                      <a href="#">
                        <img
                          :src="lc.imageCourse"
                          alt=""
                          width="70"
                          height="60"
                        />
                      </a>
                    </v-col>
                    <v-col cols="7">
                      <h6 class="mx-2">
                        <a href="#" class="name-table">{{ lc.courseTitle }}</a>
                      </h6>
                      <h6 class="mx-2" style="color: #003000">
                        Tổng số {{ lc.numberOfStudentsWhoHaveCompleted }} giờ
                      </h6>
                    </v-col>
                    <v-col cols="2">
                      <font-awesome-icon
                        icon="fa-solid fa-users"
                      ></font-awesome-icon>
                      {{ lc.numberOfPeopleEnrolled }}
                    </v-col>
                    <v-col cols="2">
                      <p>{{ lc.pricepriceHasDecreased }} đ</p>
                      <p class="price-table">{{ lc.price }} đ</p>
                    </v-col>
                  </v-row>
                  <hr />
                </div>
                <div
                  class="teacher-profile"
                  v-for="t in teacherProfile"
                  :key="t.id"
                >
                  <h3 class="my-4">Giảng viên</h3>
                  <h4 class="name-teacher">
                    <router-link to="/user-profile" > {{ t.nameTeacher }}</router-link>
                  </h4>
                  <h5 class="nick-name-teacher">
                    {{ t.nickName }}
                  </h5>
                  <div class="teacher">
                    <v-row>
                      <v-col cols="2">
                        <v-avatar
                          :image="t.imageTeacher"
                          size="130"
                          class="my-6"
                        ></v-avatar>
                      </v-col>
                      <v-col cols="10">
                        <div class="my-12">
                          <div class="my-2">
                            <v-title>
                              <font-awesome-icon
                                icon="fa-solid fa-medal"
                              ></font-awesome-icon>
                              {{ t.evaluate }} <span>đánh giá</span>
                            </v-title>
                          </div>
                          <div>
                            <v-title>
                              <font-awesome-icon
                                icon="fa-solid fa-user-group"
                              ></font-awesome-icon>
                              {{ t.student }} <span>học viên</span>
                            </v-title>
                          </div>
                          <div class="my-2">
                            <v-title>
                              <font-awesome-icon
                                icon="fa-solid fa-circle-play"
                              ></font-awesome-icon>
                              {{ t.course }} <span>khóa học</span>
                            </v-title>
                          </div>
                        </div>
                      </v-col>
                    </v-row>
                    <div>
                      <p>
                        {{ t.description }}
                      </p>
                    </div>
                  </div>
                </div>

                <div class="evalute">
                  <div class="my-7" v-for="e in teacherProfile" :key="e.id">
                    <h3>Đánh giá: {{ e.evaluate }} xếp hạng</h3>
                  </div>

                  <div class="comment">
                    <v-textarea
                      label="Đánh giá khóa học này"
                      class="text-h4"
                      variant="outlined"
                    ></v-textarea>
                    <v-row>
                      <v-col>
                        <div class="text-left" style="margin-bottom: 20px">
                          <v-btn
                            :loading="loading1"
                            @click="loading1 = !loading1"
                          >
                            Gửi
                            <template v-slot:loader>
                              <v-progress-linear
                                indeterminate
                              ></v-progress-linear>
                            </template>
                          </v-btn>
                        </div>
                      </v-col>
                      <v-col>
                        <div class="text-right">
                          <v-rating
                            v-model="rating"
                            color="orange-lighten-1"
                            active-color="orange"
                          ></v-rating>
                        </div>
                      </v-col>
                    </v-row>
                  </div>
                  <div class="evalute-table">
                    <v-row>
                      <v-col
                        cols="6"
                        v-for="(e, index) in limitedList"
                        :key="index"
                      >
                        <v-card
                          color="grey-lighten-4"
                          flat
                          height="200px"
                          rounded="0"
                        >
                          <v-toolbar>
                            <v-avatar
                              :image="e.image"
                              size="55"
                              class="mx-1"
                            ></v-avatar>
                            <v-row>
                              <v-col>
                                <p class="assessor-evalute">{{ e.assessor }}</p>
                                <p>
                                  <v-rating
                                    size="x-small"
                                    color="orange-lighten-1"
                                    active-color="orange"
                                  ></v-rating>
                                </p>
                              </v-col>
                            </v-row>
                            <v-spacer></v-spacer>
                            <v-menu>
                              <template v-slot:activator="{ props }">
                                <v-btn
                                  icon="mdi-dots-vertical"
                                  v-bind="props"
                                ></v-btn>
                              </template>
                              <form action="">
                                <v-list>
                                  <v-list-item>
                                    <v-list-item-title>
                                      <v-row justify="space-around">
                                        <v-col cols="12" md="6">
                                          <v-dialog
                                            transition="dialog-top-transition"
                                            width="600px"
                                          >
                                            <template
                                              v-slot:activator="{
                                                props: activatorProps,
                                              }"
                                            >
                                              <v-btn
                                                v-bind="activatorProps"
                                                block
                                                >Báo cáo</v-btn
                                              >
                                            </template>
                                            <template
                                              v-slot:default="{ isActive }"
                                            >
                                              <v-card>
                                                <v-toolbar
                                                  title="Báo cáo lạm dụng"
                                                ></v-toolbar>

                                                <v-card-text
                                                  class="text-p px-8"
                                                >
                                                  Nhân viên Udemy sẽ xem xét nội
                                                  dung bị gắn cờ để xác định xem
                                                  nội dung đó có vi phạm Điều
                                                  khoản dịch vụ hoặc Nguyên tắc
                                                  cộng đồng hay không. Nếu bạn
                                                  có câu hỏi hoặc gặp vấn đề kỹ
                                                  thuật, vui lòng liên hệ với
                                                  <a href="#"
                                                    >nhóm Hỗ trợ tại đây.</a
                                                  >
                                                </v-card-text>
                                                <v-card-text
                                                  class="px-9 text-h6"
                                                >
                                                  Loại vấn đề
                                                </v-card-text>
                                                <v-select
                                                  label="Chọn vấn đề"
                                                  :items="[
                                                    'California',
                                                    'Colorado',
                                                    'Florida',
                                                    'Georgia',
                                                    'Texas',
                                                    'Wyoming',
                                                  ]"
                                                  variant="outlined"
                                                  class="px-8"
                                                ></v-select>
                                                <v-card-text
                                                  class="text-h6 px-9"
                                                >
                                                  Thông tin về vấn đề
                                                </v-card-text>
                                                <v-textarea
                                                  label="Label"
                                                  variant="outlined"
                                                  class="px-8"
                                                ></v-textarea>
                                                <v-card-actions
                                                  class="justify-end"
                                                >
                                                  <v-btn
                                                    text="Hủy"
                                                    @click="
                                                      isActive.value = false
                                                    "
                                                    size="x-large"
                                                    variant="outlined"
                                                    class="text-none mb-4"
                                                  >
                                                  </v-btn>

                                                  <v-btn
                                                    :disabled="l"
                                                    :loading="l"
                                                    class="text-none mb-4"
                                                    color="black"
                                                    size="x-large"
                                                    variant="flat"
                                                    @click="l = !l"
                                                    type="submit"
                                                  >
                                                    Gửi
                                                  </v-btn>
                                                </v-card-actions>
                                              </v-card>
                                            </template>
                                          </v-dialog>
                                        </v-col>
                                      </v-row>
                                    </v-list-item-title>
                                  </v-list-item>
                                </v-list>
                              </form>
                            </v-menu>
                          </v-toolbar>
                          <div class="article-container" ref="articleContainer">
                            <div class="article-content">
                              <!-- Đoạn văn bản của bài viết -->
                              <div
                                id="scroll-target"
                                style="max-height: 138px"
                                class="overflow-y-auto"
                              >
                                <p
                                  class="ma-2"
                                  v-scroll:#scroll-target="onScroll"
                                  style="height: 1000px"
                                >
                                  {{ e.evaluate }}
                                </p>
                              </div>

                              <!-- Biểu tượng yêu thích -->
                              <div class="favorite-icon">
                                <v-btn
                                  :icon="
                                    e.isSelected
                                      ? 'mdi-heart'
                                      : 'mdi-heart-outline'
                                  "
                                  @click="e.isSelected = !e.isSelected"
                                  class="love-like"
                                ></v-btn>
                              </div>
                            </div>
                          </div>
                        </v-card>
                      </v-col>
                    </v-row>
                  </div>
                </div>
                <div class="detail-all-evalute">
                  <div class="my-4 text-left">
                    <v-dialog max-width="900">
                      <template v-slot:activator="{ props: activatorProps }">
                        <v-btn
                          v-bind="activatorProps"
                          class="text-none"
                          variant="outlined"
                          text="Hiển thị tất cả đánh giá"
                        ></v-btn>
                      </template>

                      <template v-slot:default="{ isActive }">
                        <v-card>
                          <template v-slot:text>
                            <v-row>
                              <v-col>
                                <v-title class="text-h5"
                                  >Tất cả đánh giá</v-title
                                >
                              </v-col>
                              <v-col>
                                <v-text-field
                                  color="purple"
                                  loading
                                  placeholder="Tìm kiếm đánh giá"
                                ></v-text-field>
                              </v-col>
                            </v-row>
                            <v-row>
                              <v-col
                                cols="6"
                                v-for="e in listEvalute"
                                :key="e.id"
                              >
                                <v-card
                                  color="grey-lighten-4"
                                  flat
                                  height="200px"
                                  rounded="0"
                                >
                                  <v-toolbar>
                                    <v-avatar
                                      :image="e.image"
                                      size="55"
                                      class="mx-1"
                                    ></v-avatar>
                                    <v-row>
                                      <v-col>
                                        <p class="assessor-evalute">
                                          {{ e.assessor }}
                                        </p>
                                        <p>
                                          <v-rating
                                            size="x-small"
                                            color="orange-lighten-1"
                                            active-color="orange"
                                          ></v-rating>
                                        </p>
                                      </v-col>
                                    </v-row>
                                    <v-spacer></v-spacer>
                                    <v-menu>
                                      <template v-slot:activator="{ props }">
                                        <v-btn
                                          icon="mdi-dots-vertical"
                                          v-bind="props"
                                        ></v-btn>
                                      </template>
                                      <form action="">
                                        <v-list>
                                          <v-list-item>
                                            <v-list-item-title>
                                              <v-row justify="space-around">
                                                <v-col cols="12" md="6">
                                                  <v-dialog
                                                    transition="dialog-top-transition"
                                                    width="600px"
                                                  >
                                                    <template
                                                      v-slot:activator="{
                                                        props: activatorProps,
                                                      }"
                                                    >
                                                      <v-btn
                                                        v-bind="activatorProps"
                                                        block
                                                        >Báo cáo</v-btn
                                                      >
                                                    </template>
                                                    <template
                                                      v-slot:default="{
                                                        isActive,
                                                      }"
                                                    >
                                                      <v-card>
                                                        <v-toolbar
                                                          title="Báo cáo lạm dụng"
                                                        ></v-toolbar>

                                                        <v-card-text
                                                          class="text-p px-8"
                                                        >
                                                          Nhân viên Udemy sẽ xem
                                                          xét nội dung bị gắn cờ
                                                          để xác định xem nội
                                                          dung đó có vi phạm
                                                          Điều khoản dịch vụ
                                                          hoặc Nguyên tắc cộng
                                                          đồng hay không. Nếu
                                                          bạn có câu hỏi hoặc
                                                          gặp vấn đề kỹ thuật,
                                                          vui lòng liên hệ với
                                                          <a href="#"
                                                            >nhóm Hỗ trợ tại
                                                            đây.</a
                                                          >
                                                        </v-card-text>
                                                        <v-card-text
                                                          class="px-9 text-h6"
                                                        >
                                                          Loại vấn đề
                                                        </v-card-text>
                                                        <v-select
                                                          label="Chọn vấn đề"
                                                          :items="[
                                                            'California',
                                                            'Colorado',
                                                            'Florida',
                                                            'Georgia',
                                                            'Texas',
                                                            'Wyoming',
                                                          ]"
                                                          variant="outlined"
                                                          class="px-8"
                                                        ></v-select>
                                                        <v-card-text
                                                          class="text-h6 px-9"
                                                        >
                                                          Thông tin về vấn đề
                                                        </v-card-text>
                                                        <v-textarea
                                                          label="Label"
                                                          variant="outlined"
                                                          class="px-8"
                                                        ></v-textarea>
                                                        <v-card-actions
                                                          class="justify-end"
                                                        >
                                                          <v-btn
                                                            text="Hủy"
                                                            @click="
                                                              isActive.value = false
                                                            "
                                                            size="x-large"
                                                            variant="outlined"
                                                            class="text-none mb-4"
                                                          >
                                                          </v-btn>

                                                          <v-btn
                                                            :disabled="l"
                                                            :loading="l"
                                                            class="text-none mb-4"
                                                            color="black"
                                                            size="x-large"
                                                            variant="flat"
                                                            @click="l = !l"
                                                            type="submit"
                                                          >
                                                            Gửi
                                                          </v-btn>
                                                        </v-card-actions>
                                                      </v-card>
                                                    </template>
                                                  </v-dialog>
                                                </v-col>
                                              </v-row>
                                            </v-list-item-title>
                                          </v-list-item>
                                        </v-list>
                                      </form>
                                    </v-menu>
                                  </v-toolbar>
                                  <div
                                    class="article-container"
                                    ref="articleContainer"
                                  >
                                    <!-- Nội dung bài viết -->
                                    <div class="article-content">
                                      <!-- Đoạn văn bản của bài viết -->
                                      <div
                                        id="scroll-target"
                                        style="max-height: 138px"
                                        class="overflow-y-auto"
                                      >
                                        <p
                                          class="ma-2"
                                          v-scroll:#scroll-target="onScroll"
                                          style="height: 1000px"
                                        >
                                          {{ e.evaluate }}
                                        </p>
                                      </div>
                                      <!-- Biểu tượng yêu thích -->
                                      <div class="favorite-icon">
                                        <v-btn
                                          :icon="
                                            e.isSelected
                                              ? 'mdi-heart'
                                              : 'mdi-heart-outline'
                                          "
                                          @click="e.isSelected = !e.isSelected"
                                          class="love-like"
                                        ></v-btn>
                                      </div>

                                      <!-- Đoạn văn bản tiếp theo của bài viết -->

                                      <!-- và cetera -->
                                    </div>
                                  </div>
                                </v-card>
                              </v-col>
                            </v-row>
                          </template>

                          <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn
                              color="surface-variant"
                              text="Ok"
                              variant="flat"
                              @click="isActive.value = false"
                            ></v-btn>
                          </v-card-actions>
                        </v-card>
                      </template>
                    </v-dialog>
                  </div>
                </div>
                <hr />
                <v-list>
                  <v-list-item>
                    <v-list-item-title>
                      <v-row justify="space-around">
                        <v-col cols="12" md="6">
                          <v-dialog
                            transition="dialog-top-transition"
                            width="600px"
                          >
                            <template
                              v-slot:activator="{ props: activatorProps }"
                            >
                              <v-btn
                                v-bind="activatorProps"
                                block
                                class="text-none mb-4"
                                color="black"
                                size="x-large"
                                variant="outlined"
                                >Báo cáo lạm dụng</v-btn
                              >
                            </template>
                            <template v-slot:default="{ isActive }">
                              <v-card>
                                <v-toolbar title="Báo cáo lạm dụng"></v-toolbar>

                                <v-card-text class="text-p px-8">
                                  Nhân viên Udemy sẽ xem xét nội dung bị gắn cờ
                                  để xác định xem nội dung đó có vi phạm Điều
                                  khoản dịch vụ hoặc Nguyên tắc cộng đồng hay
                                  không. Nếu bạn có câu hỏi hoặc gặp vấn đề kỹ
                                  thuật, vui lòng liên hệ với
                                  <a href="#">nhóm Hỗ trợ tại đây.</a>
                                </v-card-text>
                                <v-card-text class="px-9 text-h6">
                                  Loại vấn đề
                                </v-card-text>
                                <v-select
                                  label="Chọn vấn đề"
                                  :items="[
                                    'California',
                                    'Colorado',
                                    'Florida',
                                    'Georgia',
                                    'Texas',
                                    'Wyoming',
                                  ]"
                                  variant="outlined"
                                  class="px-8"
                                ></v-select>
                                <v-card-text class="text-h6 px-9">
                                  Thông tin về vấn đề
                                </v-card-text>
                                <v-textarea
                                  label="Label"
                                  variant="outlined"
                                  class="px-8"
                                ></v-textarea>
                                <v-card-actions class="justify-end">
                                  <v-btn
                                    text="Hủy"
                                    @click="isActive.value = false"
                                    size="x-large"
                                    variant="outlined"
                                    class="text-none mb-4"
                                  >
                                  </v-btn>

                                  <v-btn
                                    :disabled="l"
                                    :loading="l"
                                    class="text-none mb-4"
                                    color="black"
                                    size="x-large"
                                    variant="flat"
                                    @click="l = !l"
                                    type="submit"
                                  >
                                    Gửi
                                  </v-btn>
                                </v-card-actions>
                              </v-card>
                            </template>
                          </v-dialog>
                        </v-col>
                      </v-row>
                    </v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-col>
            </v-row>
          </div>
        </v-container>
      </div>
    </div>
    <div class="footer">
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
      panel: [0, 1],
      disabled: false,
      loading: false,
      load: false,
      loading1: false,
      position: "fixed",
      top: "50px",
      left: "50px",
      dialog: false,
      rating: 3,
      maxLength: 100,
      showLess: true,
      router: useRouter(),
      l: false,
      // show: false,
      listCourse: [
        {
          id: 1,
          description: "C# là một ngôn ngữ thuần hướng đối tượng,...",
          courseTitle: "Khóa học C# .Net Core",
          imageCourse:
            "https://tuhoclaptrinh.edu.vn/upload/post/2023/04/19/gioi-thieu-ngon-ngu-c-20230419090719-567750.jpg",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          percentDecrease: 82,
          discountPeriod: 7,

          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          teacherCourse: "Trần Minh Quân",
          dateTimeUpdate: "02/12/2024",
          linkVideo:
            "https://www.youtube.com/embed/9kohr6pMwag?list=PL33lvabfss1wUj15ea6W0A-TtDOrWWSRK",
        },
      ],
      courseContent: [
        {
          id: 1,
          course: "C# Basic",
          show: false,
        },

        {
          id: 2,
          course: "Winform",
          show: false,
        },

        {
          id: 3,
          course: ".Net",
          show: false,
        },
        {
          id: 3,
          course: "Database",
          show: false,
        },
        {
          id: 3,
          course: "Truy vấn database cơ bản",
          show: false,
        },
      ],
      timer: [
        {
          id: 1,
          time: 10,
        },
      ],
      listLesson: [
        {
          idLesson: 1,
          nameLesson: "C# Basic",
          linkVideo:
            "https://www.youtube.com/embed/9kohr6pMwag?list=PL33lvabfss1wUj15ea6W0A-TtDOrWWSRK",
        },
        {
          idLesson: 2,
          nameLesson: "Java Basic",
          linkVideo:
            "https://www.youtube.com/embed/9kohr6pMwag?list=PL33lvabfss1wUj15ea6W0A-TtDOrWWSRK",
        },
        {
          idLesson: 3,
          nameLesson: "SQL Server Basic",
          linkVideo:
            "https://www.youtube.com/embed/9kohr6pMwag?list=PL33lvabfss1wUj15ea6W0A-TtDOrWWSRK",
        },
        {
          idLesson: 4,
          nameLesson: "Truy vấn SQL Server Basic",
          linkVideo:
            "https://www.youtube.com/embed/9kohr6pMwag?list=PL33lvabfss1wUj15ea6W0A-TtDOrWWSRK",
        },
      ],
      listCourePropose: [
        {
          id: 1,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học BA",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 2,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học truy vấn SQL Server",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 3,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học Angular",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 4,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle:
            "Business Analyst (BA) for Practitioners (BA thực chiến)",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 5,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học Java",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
        {
          id: 6,
          description:
            "Java là một ngôn ngữ lập trình thuần hướng đối tượng,...",
          courseTitle: "Khóa học Java",
          imageCourse:
            "https://appmaster.io/api/_files/hRaLG2N4DVjRZJQzCpN2zJ/download/",
          numberOfLessons: 15,
          chapterNumber: 3,
          totalStudyTime: 90,
          numberOfPeopleEnrolled: 123,
          pricepriceHasDecreased: "299.000",
          price: "1.690.000",
          numberOfStudentsWhoHaveCompleted: 100,
          courseStatus: 1,
          typeCourse: 1,
          linkVideo:
            "https://www.youtube.com/embed/3gtOAlcovoQ?list=PL33lvabfss1yGrOutFR03OZoqm91TSsvs",
        },
      ],
      teacherProfile: [
        {
          id: 1,
          nameTeacher: "Nguyễn Khánh Huyền",
          description:
            "- Hơn 10 năm kinh nghiệm làm việc tại các vị trí quản lý bộ phận kinh doanh, tiếp thị, chăm sóc khách hàng trong những tập đoàn quốc tế hàng đầu thuộc các lĩnh vực khách sạn, giải trí và bất động sản cao cấp như SwanCity, Diageo, AB Inbev, Six Senses Côn Đảo Resort...",
          evaluate: 19,
          student: 332,
          course: 1,
          nickName: "Huyền Baby",
          imageTeacher:
            "https://1.bp.blogspot.com/-mRj1x9CyrcA/Xm3No2S5lTI/AAAAAAAAYaI/FgJeZaiaPWYDAaXq8rhd6WnvTW1ukOmpACLcBGAsYHQ/s1600/Anh-gai-xinh-toc-ngan-deo-kinh%2B%25284%2529.jpg",
        },
      ],
      listEvalute: [
        {
          id: 1,
          assessor: "Nguyễn Khánh Huyền",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://haycafe.vn/wp-content/uploads/2023/06/Hinh-Anh-gai-xinh-de-thuong-dep-nhat-Viet-Nam.jpg",
        },
        {
          id: 2,
          assessor: "Nguyễn Ngọc Linh",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://khoinguonsangtao.vn/wp-content/uploads/2022/08/hinh-nen-gai-xinh.jpg",
        },
        {
          id: 3,
          assessor: "Nguyễn Gia Hân",
          evaluate:
            "Lorem, ipsum dolor sit amet consel! Maxime ipsa fugit sint perferendis, sunt quae distinctio quibusdam quam repudiandae?",
          isSelected: false,
          image:
            "https://gcs.tripi.vn/public-tripi/tripi-feed/img/474015QSt/anh-gai-xinh-1.jpg",
        },
        {
          id: 4,
          assessor: "Trần Ánh Dương",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
        {
          id: 5,
          assessor: "Trần Ánh Dương",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
        {
          id: 6,
          assessor: "Trần Ánh Dương",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
        {
          id: 7,
          assessor: "Trần Ánh Dương",
          evaluate:
            "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Deleniti officiis temporibus possimus eveniet? Ea iure tenetur aliquam ab vel! Maxime ipsa fugit sint perferendis, sunt quae distinctio quibusdam quam repudiandae?",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
        {
          id: 8,
          assessor: "Trần Ánh Dương",
          evaluate: "Bài học này rất tốt",
          isSelected: false,
          image:
            "https://cdn.vn.alongwalk.info/vn/wp-content/uploads/2023/02/15170250/image-top-100-anh-gai-xinh-tik-tok-cute-dang-yeu-thoi-thuong-cuc-hot-167643017042558.jpg",
        },
      ],
      limit: 4,
      offsetTop: 0,
    };
  },
  computed: {
    limitedList() {
      // Trả về một mảng con của listEvalute chứa không quá 'limit' phần tử
      return this.listEvalute.slice(0, this.limit);
    },
  },
  methods: {
    toggleText() {
      this.showLess = !this.showLess;
    },
    onScroll(e) {
      this.offsetTop = e.target.scrollTop;
    },
  },
};
</script>

<style scoped>
.fixed-card{
position: sticky;
  top: 70px;
  left: 1080px; /* Vị trí left bạn mong muốn */
  /* bottom: 400px; */
  /* align-self: flex-end; */
  /* padding: 10px; */
  z-index: 1;
}
.article-container {
  min-height: 100vh;
  position: relative;
}
.favorite-icon {
  position: sticky;
  top: 36px; /* Thay đổi giá trị tùy theo vị trí mong muốn */
  right: 20px; /* Thay đổi giá trị tùy theo vị trí mong muốn */
  z-index: 9; /* Đảm bảo nó hiển thị trên nền bài viết */
}
.banner {
  background-color: #2d2f31;
  width: 100%;
  height: 300px;
  color: white;
}
.list-lesson ul li {
  display: block;
}
.name-teacher a {
  color: blueviolet;
  font-weight: bold;
}
.nick-name-teacher {
  color: rgb(114, 114, 114);
}
.list-lesson ul li a {
  color: blueviolet;
  margin-left: 20px;
}
.price-table {
  font-size: 14px;
  text-decoration-line: line-through;
  margin-top: -20px;
}
.name-table {
  text-decoration: none;
  color: black;
}
.name-table:hover {
  color: blueviolet;
}
.fixed-element {
  height: 2970px;
}
.footer {
  height: 200px; /* Chiều cao của footer */
  background-color: #333;
  color: #fff;
}
.detail-course {
  height: 1000px;
}
.detail-product {
  height: 2000px;
}
.assessor-evalute {
  margin: 25px 0px -3px 8px;
}
.favorite-icon {
  margin: 40px 0px 0px 8px;
  /* position: -webkit-sticky; */
  position: absolute;
  /* position: fixed; */
}
</style>
