import axios from "axios";
import { defineStore } from "pinia";

// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7046/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const courseApi = defineStore("course", {
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
    updateCourse(params) {
      return new Promise((resolve, reject) => {
        // Đối với hàm updateCourse, bạn cần truyền ID của khóa học cần cập nhật
        axios
          .put(
            "/user/SuaThongTinKhoaHoc/",
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
    searchCourses(params) {
      return new Promise((resolve, reject) => {
        axios
          .get("/user/getkhoahoc", { ...params })
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
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
    getAllCoursesByUserId(id) {
      return new Promise((resolve, reject) => {
        axios
          .get(`/user/GetAllKhoaHocTheoNguoiTao/${id}`)
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              s;
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
    deleteCourses(khoaHocId) {
      return new Promise((resolve, reject) => {
        axios
          .delete(`/user/XoaKhoaHoc/${khoaHocId}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => {
            if (res.status === 200) {
              // Sửa từ response thành res
              resolve(res.data);
            } else {
              reject(res); // Sử dụng res thay vì error
            }
          })
          .catch((error) => reject(error));
      });
    },
    getCourseId(id) {
      return new Promise((resolve, reject) => {
        axios
          .get(`/user/GetKhoaHocById/${id}`)
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
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
