import axios from "axios";
import { defineStore } from "pinia";
// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7070/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const projectApi = defineStore("project", {
  actions: {
    getAllsProject() {
      return new Promise((resolve, reject) => {
        axios
          .get("/Admin/GetAllProject", {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    addProject(params) {
      return new Promise((resolve, reject) => {
        axios
          .post(
            "/Admin/CreateProject",
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
    deleteProject(id) {
      console.log(id);
      return new Promise((resolve, reject) => {
        axios
          .delete(`/Admin/DeleteProject/${id}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getByIdProject(id) {
      console.log(id);
      return new Promise((resolve, reject) => {
        axios
          .get(`/Admin/GetProjectById/${id}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    fillterData(param) {
      return new Promise((resolve, reject) => {
        axios
          .get("/Admin/GetAllProject", {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
            params: {
              ProjectName: param.projectName,
              StartDate: param.startDate,
              EndDate: param.endDate,
              LeaderId: param.leaderId,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
  },
});
