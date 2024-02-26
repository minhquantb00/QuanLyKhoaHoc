import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import { createPinia } from 'pinia'
import mitt from 'mitt'
import { loadFonts } from "./plugins/webfontloader";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faHouse ,faHouseMedicalCircleExclamation, faCartShopping, faBook, faEye, faEyeSlash, faSchool, faMagnifyingGlass} from "@fortawesome/free-solid-svg-icons";
import { faGoogle} from "@fortawesome/free-brands-svg-icons";

loadFonts();
library.add(faHouse,faHouseMedicalCircleExclamation, faGoogle, faCartShopping, faBook, faEye, faEyeSlash, faSchool, faMagnifyingGlass);
// library.add()
const emitter = mitt()
createApp(App)
.component('font-awesome-icon',FontAwesomeIcon)
.use(router).use(store).use(vuetify).use(createPinia()).mount("#app");
