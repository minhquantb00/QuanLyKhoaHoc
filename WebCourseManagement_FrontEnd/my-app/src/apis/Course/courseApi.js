import axios from "axios";
import { defineStore } from "pinia";

// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7046/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const courseApi = defineStore("user", {
  actions: {
    createCourse(params) {
      return new Promise((resolve, reject) => {
        axios
          .post(
            "/user/ThemKhoaHoc",
            { ...params },
            {
              headers: {
                "Content-Type": "multipart/form-data",
                Authorization: `Bearer ${authorization}`,
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getAllCourses() {
      return new Promise((resolve, reject) => {
        axios
          .get("/user/getkhoahoc")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              console.log('vào đây rooif nhế');
              console.log(res);
            }else{
              reject(error)
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
              console.log('Loại khóa học');
              console.log(res);
            }else{
              reject(error)
            }
          })
          .catch((error) => reject(error));
      });
      
    },
  },
});
