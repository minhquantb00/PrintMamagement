import axios from "axios";
import { defineStore } from "pinia";
// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7070/api";
function getAccessToken() {
  return localStorage.getItem("accessToken") || "";
}
const userInfo = JSON.parse(localStorage.getItem("userInfo"));
export const thongkeApi = defineStore("thongke", {
  actions: {
    thongKeLuong() {
      return new Promise((resolve, reject) => {
        axios
          .get("/User/GetstatisticSalary", {
            params: {
              id: userInfo.Id,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getTeamById(id) {
      return new Promise((resolve, reject) => {
        axios
          .get("/Admin/GetTeamById", {
            params: {
              teamId: id,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    updateTeams() {
      return new Promise((resolve, reject) => {
        axios
          .put("/Admin/GetTeamById", {
            params: {
              teamId: id,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
  },
});
