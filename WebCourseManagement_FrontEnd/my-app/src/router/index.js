import { createRouter, createWebHistory } from "vue-router";
// import HeaderItemVue from "@/views/Header/HeaderItem.vue";
import HomeContentVue from "@/views/Home/HomeContent.vue";
const routes = [
  // {
  //   path: "/",
  //   name: "home",
  //   component: HomeView,
  // },
  // {
  //   path: "/about",
  //   name: "about",
  //   // route level code-splitting
  //   // this generates a separate chunk (about.[hash].js) for this route
  //   // which is lazy-loaded when the route is visited.
  //   component: () =>
  //     import(/* webpackChunkName: "about" */ "../views/AboutView.vue"),
  // },
  {
    path: "/",
    name: "home",
    component: HomeContentVue,
  },
  {
    path: "/register",
    name: "register",
    component: () => import("../views/Authenticate/Register.vue"),
  },
  {
    path: "/login",
    name: "login",
    component: () => import("../views/Authenticate/Login.vue"),
  },
  {
    path: "/forgot-password",
    name: "forgot-password",
    component: () => import("../views/Authenticate/ForgotPassword.vue"),
  },
  {
    path: "/new-forgot-password",
    name: "new-forgot-password",
    component: () => import("../views/Authenticate/NewForgotPassword.vue"),
  },
  {
    path: "/detail-forgot-password",
    name: "detail-forgot-password",
    component: () => import("../views/Authenticate/DetailForgotPassword.vue"),
  },
  {
    path: "/detail-product",
    name: "detail-product",
    component: () => import("../views/ProductDetail/DetailProduct.vue"),
  },
  {
    path: "/user-profile",
    name: "user-profile",
    component: () => import("../views/ProductDetail/DetailTeacher.vue"),
  },
  {
    path: "/course-product",
    name: "course-product",
    component: () => import("../views/CreateCourse/CourseProduct.vue"),
  },
  {
    path: "/create-engaging-courses",
    name: "create-engaging-courses",
    component: () => import("../views/CreateCourse/CreateEngagingCourses.vue"),
  },
  {
    path: "/build-a-team-of-students",
    name: "build-a-team-of-students",
    component: () => import("../views/CreateCourse/BuildATeamOfStudents.vue"),
  },
  {
    path: "/start-creating-videos",
    name: "start-creating-videos",
    component: () => import("../views/CreateCourse/StartCreatingVideos.vue"),
  },
  {
    path: "/create-course",
    name: "create-course",
    component: () => import("../views/CreateCourse/CreateCouse.vue"),
  },
  {
    path: "/tools-courses",
    name: "tools-courses",
    component: () => import("../views/CreateCourse/ToolsCourse.vue"),
  },
  {
    path: "/resources",
    name: "resources",
    component: () => import("../views/CreateCourse/Resources.vue"),
  },
  {
    path: "/efficiency",
    name: "efficiency",
    component: () => import("../views/CreateCourse/Efficiency.vue"),
  },
  {
    path: "/content-efficiency",
    name: "content-efficiency",
    component: () => import("../views/CreateCourse/ContentEffciencyCourse.vue"),
  },
  {
    path: "/cart-products",
    name: "cart-products",
    component: () => import("../views/ProductDetail/CartProducts.vue"),
  },
  {
    path: "/my-course",
    name: "my-course",
    component: () => import("../views/Home/MyCourse.vue"),
  },
  {
    path: "/test",
    name: "test",
    component: () => import("../views/Home/Test.vue"),
  },
  {
    path: "/comment",
    name: "comment",
    component: () => import("../views/CreateCourse/CommentsCourse.vue"),
  },
  {
    path: "/study-chapter",
    name: "study-chapter",
    component: () => import("../views/CreateCourse/StudyChapter.vue"),
  },
  {
    path: "/video-lessons",
    name: "video-lessons",
    component: () => import("../views/CreateCourse/VideoLesson.vue"),
  },
  {
    path: "/all-lessons",
    name: "all-lessons",
    component: () => import("../views/CreateCourse/AllLesson.vue"),
  },
  {
    path: "/post-user",
    name: "post-user",
    component: () => import("../views/Post/PostManagerUser.vue"),
  }, {
    path: "/profile-user",
    name: "profile-user",
    component: () => import("../views/User/ProfileUser.vue"),
  },
  {
    path: "/admin/:id",
    component: () => import("../views/Admin/Header/HeaderAdmin.vue"),
    children: [
      {
        // UserProfile will be rendered inside User's <router-view>
        // when /user/:id/profile is matched
        path: "/admin",
        name: "admin",
        component: () => import("../views/Admin/Content/UserManager.vue"),
      },
      {
        // UserProfile will be rendered inside User's <router-view>
        // when /user/:id/profile is matched
        path: "/admin/nguoi-dung",
        name: "nguoi-dung",
        component: () => import("../views/Admin/Content/UserManager.vue"),
      },
      {
        // UserProfile will be rendered inside User's <router-view>
        // when /user/:id/profile is matched
        path: "/admin/thong-ke",
        name: "thong-ke",
        component: () => import("../views/Admin/Content/Statistic.vue"),
      },
      {
        // UserProfile will be rendered inside User's <router-view>
        // when /user/:id/profile is matched
        path: "/admin/banner",
        name: "banner",
        component: () => import("../views/Admin/Content/BannerManager.vue"),
      },
      {
        // UserProfile will be rendered inside User's <router-view>
        // when /user/:id/profile is matched
        path: "/admin/bao-cao",
        name: "bao-cao",
        component: () => import("../views/Admin/Content/RepostManager.vue"),
      },
      {
        // UserProfile will be rendered inside User's <router-view>
        // when /user/:id/profile is matched
        path: "/admin/bai-viet",
        name: "bai-viet",
        component: () => import("../views/Admin/Content/PostManager.vue"),
      },
      {
        // UserProfile will be rendered inside User's <router-view>
        // when /user/:id/profile is matched
        path: "/admin/the-loai-khoa-hoc",
        name: "the-loai-khoa-hoc",
        component: () => import("../views/Admin/Content/CourseType.vue"),
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
