import { createRouter, createWebHistory } from "vue-router";
// import HeaderItemVue from "@/views/Header/HeaderItem.vue";
import HomeContentVue from "@/views/Home/HomeContent.vue";
import { courseApi } from "@/apis/Course/courseApi";

const routes = [
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
    path: '/detail-product/:id',
    name: 'detail-product',
    component: () => import('../views/ProductDetail/DetailProduct.vue'),
  },
  {
    path: "/user-teacher-profile/:id",
    name: "user-teacher-profile",
    component: () => import("../views/ProductDetail/DetailTeacher.vue"),
  },
  {
    path: "/course-product/:id",
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
    path: "/test-chat",
    name: "test-chat",
    component: () => import("../views/Home/TestChat.vue"),
  },
  {
    path: "/comment",
    name: "comment",
    component: () => import("../views/CreateCourse/CommentsCourse.vue"),
  },
  {
    path: "/study-chapter/:id",
    name: "study-chapter",
    component: () => import("../views/CreateCourse/StudyChapter.vue"),
  },
  {
    path: "/video-lessons/:id",
    name: "video-lessons",
    component: () => import("../views/CreateCourse/VideoLesson.vue"),
  },
  {
    path: "/all-lessons/:id",
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
  }, {
    path: "/public-records/:id",
    name: "public-records",
    component: () => import("../views/User/UserProfilePage.vue"),
  },
  {
    path: "/post-client/:id",
    name: "post-client",
    component: () => import("../views/Post/PostClient.vue"),
  },
  {
    path: "/admin/:id",
    component: () => import("../views/Admin/Header/HeaderAdmin.vue"),
    children: [
      {
        path: "/admin",
        name: "admin",
        component: () => import("../views/Admin/Content/UserManager.vue"),
      },
      {
        path: "/admin/nguoi-dung",
        name: "nguoi-dung",
        component: () => import("../views/Admin/Content/UserManager.vue"),
      },
      {
        path: "/admin/thong-ke",
        name: "thong-ke",
        component: () => import("../views/Admin/Content/Statistic.vue"),
      },
      {
        path: "/admin/banner",
        name: "banner",
        component: () => import("../views/Admin/Content/BannerManager.vue"),
      },
      {
        path: "/admin/bao-cao",
        name: "bao-cao",
        component: () => import("../views/Admin/Content/RepostManager.vue"),
      },
      {
        path: "/admin/bai-viet",
        name: "bai-viet",
        component: () => import("../views/Admin/Content/PostManager.vue"),
      },
      {
        path: "/admin/the-loai-bai-viet",
        name: "the-loai-bai-viet",
        component: () => import("../views/Admin/Content/PostTypeManager.vue"),
      },
      {
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
