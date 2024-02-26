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
    component: HomeContentVue
  },
  {
    path: "/register",
    name: "register",
    component: () => import('../views/Authenticate/Register.vue')
  },
  {
    path: "/login",
    name: "login",
    component: () => import('../views/Authenticate/Login.vue')
  },
  {
    path: "/forgot-password",
    name: "forgot-password",
    component: () => import('../views/Authenticate/ForgotPassword.vue')
  }
  ,
  {
    path: "/new-forgot-password",
    name: "new-forgot-password",
    component: () => import('../views/Authenticate/NewForgotPassword.vue')
  }
  ,
  {
    path: "/detail-forgot-password",
    name: "detail-forgot-password",
    component: () => import('../views/Authenticate/DetailForgotPassword.vue')
  },
  {
    path: "/detail-product",
    name: "detail-product",
    component: () => import('../views/ProductDetail/DetailProduct.vue')
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
