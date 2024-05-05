import axios from "axios";
import { defineStore } from "pinia";
// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7070/api";
function getAccessToken() {
  return localStorage.getItem("accessToken") || "";
}
export const teamApi = defineStore("team", {
  actions: {
    getAllTeams() {
      return new Promise((resolve, reject) => {
        axios
          .get("/Admin/GetAllTeams", {
            headers: {
              Authorization: `Bearer ${getAccessToken()}`,
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
    createTeams(params) {
      return new Promise((resolve, reject) => {
        axios
          .post(
            "/Admin/CreateTeam",
            {
              ...params,
            },
            {
              headers: {
                Authorization: `Bearer ${getAccessToken()}`,
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    deleteTeams(id) {
      return new Promise((resolve, reject) => {
        axios
          .delete(
            "/Admin/DeleteTeam",
            {
              params: id,
            },
            {
              headers: {
                Authorization: `Bearer ${getAccessToken()}`,
              },
            }
          )
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
