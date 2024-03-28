import axios from "axios";
import { defineStore } from "pinia";

// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7046/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const postApi = defineStore("post", {
  actions: {
    createPost(params) {
      return new Promise((resolve, reject) => {
        axios
          .post(
            "/user/TaoBaiViet",
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
    getAllPostNotYetApproved() {
      return new Promise((resolve, reject) => {
        axios
          .get("/admin/GetAllBaiVietChuaDuocDuyet", {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
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
    tuChoiBaiViet(khoaHocId) {
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
    xoaBaiViet(id) {
      return new Promise((resolve, reject) => {
        axios
          .delete(`/user/XoaBaiViet/${id}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
            } else {
              reject(res);
            }
          })
          .catch((error) => reject(error));
      });
    },
    async pheDuyetBaiViet(id) {
      const authToken = `Bearer ${authorization}`;
      console.log(authToken);
      const res = await axios.put(`/admin/DuyetBaiViet/${id}`, null, {
        headers: {
          Authorization: authToken,
        },
      });
      console.log(res);
    },
    getAllPostUser() {
      return new Promise((resolve, reject) => {
        axios
          .get("/user/GetAllsBaiViet")
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
    getAllPostUserId(userId) {
      return new Promise((resolve, reject) => {
        axios
          .get(`/user/GetBaiVietByIdNguoiDung/${userId}`)
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
    getAllPostId(id) {
      return new Promise((resolve, reject) => {
        axios
          .get(`/user/GetBaiVietById/${id}`)
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
    likePost(params){
      return new Promise((resolve, reject) => {
        axios
          .post("/user/LikeBaiViet", {...params},{
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
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
    createComments(params){
      return new Promise((resolve, reject) => {
        axios
          .post("/user/TaoBinhLuanBaiViet", {...params},{
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    }
  },
});
