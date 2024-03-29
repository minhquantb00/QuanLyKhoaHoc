import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import { createPinia } from "pinia";
import mitt from "mitt";
import { loadFonts } from "./plugins/webfontloader";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { DatePicker } from "ant-design-vue";
// import { Icon } from "@ant-design/icons-vue";
import { Layout } from "ant-design-vue";
import { Spin } from "ant-design-vue";
import { Table } from "ant-design-vue";
import { Comment } from "ant-design-vue";
import { Menu } from "ant-design-vue";
import { Select } from "ant-design-vue";
import { Modal } from "ant-design-vue";
import { Input } from "ant-design-vue";
import { Tooltip } from "ant-design-vue";
import { Upload } from "ant-design-vue";
import { Form } from "ant-design-vue";
// import{Icon} from "@ant-design/icons-vue";
import { Checkbox } from "ant-design-vue";
// import {echart} from "echarts";
// import {monacoEditor} from "monaco-editor"
import * as echarts from 'echarts';
import { Button } from "ant-design-vue";
import { Breadcrumb } from "ant-design-vue";
import CKEditor from "@ckeditor/ckeditor5-vue";
import VueDatePicker from "vue3-datepicker";
import {
  faHouse,
  faHouseMedicalCircleExclamation,
  faCartShopping,
  faBook,
  faEye,
  faEyeSlash,
  faSchool,
  faMagnifyingGlass,
  faTv,
  faUser,
  faUsers,
  faMedal,
  faUserGroup,
  faCirclePlay,
  faLink,
  faPenNib,
  faChartColumn,
  faWrench,
  faEarthAmerica,
  faPersonChalkboard,
  faChartLine,
  faCircleQuestion,
  faTag,
  faPen,
  faPlus,
  faChevronDown,
  faFolder,
  faTrophy,
  faUpRightFromSquare,
  faRightFromBracket,
  faLock,
  faLockOpen
} from "@fortawesome/free-solid-svg-icons";
import {
  faGoogle,
  faTwitch,
  faFacebook,
  faYoutube,
} from "@fortawesome/free-brands-svg-icons";
import {
  faClock,
  faComments,
  faBell,
  faTrashCan,
  faPaperPlane
} from "@fortawesome/free-regular-svg-icons";
import { use } from "echarts";

loadFonts();
library.add(
  faPaperPlane,
  faUpRightFromSquare,
  faRightFromBracket,
  faTrophy,
  faFolder,
  faTrashCan,
  faWrench,
  faHouse,
  faHouseMedicalCircleExclamation,
  faGoogle,
  faCartShopping,
  faBook,
  faEye,
  faEyeSlash,
  faSchool,
  faMagnifyingGlass,
  faClock,
  faTv,
  faUser,
  faUsers,
  faMedal,
  faUserGroup,
  faCirclePlay,
  faChevronDown,
  faLink,
  faFacebook,
  faYoutube,
  faPenNib,
  faTwitch,
  faChartColumn,
  faEarthAmerica,
  faComments,
  faBell,
  faPersonChalkboard,
  faChartLine,
  faCircleQuestion,
  faTag,
  faPen,
  faPlus,
  faLock,
  faLockOpen
);
// library.add()
const emitter = mitt();
createApp(App)
  .component("font-awesome-icon", FontAwesomeIcon)
  .use(router)
  .use(store)
  .use(DatePicker)
  .use(Layout)
  // .use(Icon)
  .use(vuetify)
  .use(Breadcrumb)
  .use(Modal)
  .use(Menu)
  .use(Comment)
  .use(Form)
  .use(Tooltip)
  .use(Checkbox)
  .use(Upload)
  .use(echarts)
  .use(CKEditor)
  .use(Spin)
  .use(Select)
  // .use(monacoEditor)
  .use(Table)
  .use(Input)
  .use(Button)
  .use(createPinia())
  .component("VueDatePicker", VueDatePicker)
  .mount("#app");
