import axios from "axios";
import { defineStore } from "pinia";
// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7070/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const userApi = defineStore("user", {
  actions: {
    getAllUsers() {
      return new Promise((resolve, reject) => {
        axios
          .get("/User/GetAllUsers")
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    updateUserAccount(id, params) {
      return new Promise((resolve, reject) => {
        console.log(params);
        axios
          .put(
            "/User/UpdateUser",
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

    filterUser(param) {
      console.log(param);
      return new Promise((resolve, reject) => {
        // https://localhost:7070/api/User/GetAllUsers?Name=D%C6%B0%C6%A1ng&Email=duongtv280703%40gmail.com&PhoneNumber=0388049008
        axios
          .get("/User/GetAllUsers", {
            params: {
              email: param.email,
              name: param.name,
              phoneNumber: param.phoneNumber,
              teamId: param.teamId,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getUserById(id) {
      console.log(id);
      return new Promise((resolve, reject) => {
        axios
          .get(`/User/GetUserById/${id}`)
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getRolesByIdUser(id) {
      console.log(id);
      return new Promise((resolve, reject) => {
        axios
          .get(`/Admin/GetRolesByUserId/${id}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getAllUserContainsLeaderRole() {
      return new Promise((resolve, reject) => {
        axios
          .get("/User/GetAllUserContainsLeaderRole")
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
  },
});
