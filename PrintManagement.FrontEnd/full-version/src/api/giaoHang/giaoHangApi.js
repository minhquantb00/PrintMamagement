import axios from "axios";
import { defineStore } from "pinia";
// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7070/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const giaoHangApi = defineStore("giaoHang", {
  actions: {
    getAllGiaoHang() {
      return new Promise((resolve, reject) => {
        axios
          .post("/User/GetAllDelivery")
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },

    updateSeenNotification(id) {
      return new Promise((resolve, reject) => {
        axios
          .put(`/User/ConfirmIsSeenNotification/${id}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    updateCustomer(id, params) {
      return new Promise((resolve, reject) => {
        console.log(params);
        axios
          .put(
            "/Admin/UpdateCustomer",
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
    filterCustomer(param) {
      return new Promise((resolve, reject) => {
        axios
          .get(`/Admin/GetAllCustomers`, {
            params: {
              Name: param.name,
              PhoneNumber: param.phoneNumber,
              Address: param.address,
            },
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
  },
});
