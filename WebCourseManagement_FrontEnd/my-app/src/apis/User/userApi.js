import axios from "axios";
import { defineStore } from "pinia";

// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7046/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const userApi = defineStore("user", {
  actions: {
   
    getUserId(id) {
      return new Promise((resolve, reject) => {
        axios
          .get(`/user/GetNguoiDungById/${id}`)
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
    },getAllUser() {
      return new Promise((resolve, reject) => {
        axios
          .get("/user/GetAllsNguoiDung")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
            }else{
              reject(error)
            }
          })
          .catch((error) => reject(error));
      });     
    },
  },
});
