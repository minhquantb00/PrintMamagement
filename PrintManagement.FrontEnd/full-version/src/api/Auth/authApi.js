import axios from "axios";
import { defineStore } from "pinia";
// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7070/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const authApi = defineStore("auth", {
  actions: {
    login(params) {
      return new Promise((resolve, reject) => {
        axios
          .post("/Auth/Login", { ...params })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    register(params) {
      return new Promise((resolve, reject) => {
        console.log(params);
        // params.DateOfBirth = format(new Date(params.DateOfBirth), "yyyy-MM-dd");
        axios
          .post(
            "/Auth/Register",
            { ...params },
            {
              headers: {
                "Content-Type": "multipart/form-data",
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },

    async changePassword(params) {
      const authToken = `Bearer ${authorization}`;
      console.log(authToken);
      const res = await axios.put(
        `/Auth/ChangePassword`,
        { ...params },
        {
          headers: {
            Authorization: authToken,
          },
        }
      );
    },
    forgotPassword(params) {
      return new Promise((resolve, reject) => {
        axios
          .post("/auth/XacNhanQuenMatKhau", { ...params })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    updatePassword(params) {
      return new Promise((resolve, reject) => {
        axios
          .put("/auth/TaoMatKhauMoi", { ...params })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
  },
});
