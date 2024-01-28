import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import { createPinia } from 'pinia'
import mitt from 'mitt'
import { loadFonts } from "./plugins/webfontloader";

loadFonts();
const emitter = mitt()
createApp(App).use(router).use(store).use(vuetify).use(createPinia()).mount("#app");
