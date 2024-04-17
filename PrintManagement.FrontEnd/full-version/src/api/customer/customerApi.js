import axios from "axios";
import { defineStore } from "pinia";
// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7070/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const customerApi = defineStore("customer", {
  actions: {
    getAllCustomer() {
      return new Promise((resolve, reject) => {
        axios
          .get("/Admin/GetAllCustomers", {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    addCustomer(params) {
      return new Promise((resolve, reject) => {
        axios
          .post(
            "/Admin/CreateCustomer",
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

    deleteCustomer(id) {
      console.log(id);
      return new Promise((resolve, reject) => {
        axios
          .delete(`/Admin/DeleteCustomer/${id}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    confirmCreateNewPassword(params) {
      return new Promise((resolve, reject) => {
        axios
          .put("/Auth/ConfirmCreateNewPassword", { ...params })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
  },
});
