import axios from "axios";
import { defineStore } from "pinia";

// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7046/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const lessonsApi = defineStore("lessons", {
  actions: {
    createLessons(params) {
      return new Promise((resolve, reject) => {
        axios
          .post(
            "/user/ThemBaiHoc",
            { ...params },
            {
              headers: {
                Authorization: `Bearer ${authorization}`,
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getAllLessons() {
      return new Promise((resolve, reject) => {
        axios
          .get("/user/GetAllsBaiHoc")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              console.log(res);
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
    getAllCoursesType() {
      return new Promise((resolve, reject) => {
        axios
          .get("/user/GetAllLKH")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              console.log("Loại khóa học");
              console.log(res);
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
  },
});
