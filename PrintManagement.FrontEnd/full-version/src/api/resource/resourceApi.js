import axios from "axios";
import { defineStore } from "pinia";
// Định nghĩa baseURL cho axios
axios.defaults.baseURL = "https://localhost:7070/api";
const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const resourceApi = defineStore("resource", {
  actions: {
    getAllsResource() {
      return new Promise((resolve, reject) => {
        axios
          .get("/Admin/GetAll")
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    createResouce(params) {
      return new Promise((resolve, reject) => {
        axios
          .post(
            "/Admin/CreateResourceInformation",
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
    updateResouce(id, param) {
      return new Promise((resolve, reject) => {
        axios
          .put(
            "/Admin/UpdateResourceInformation",
            { ...param },
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
    deleteResource(id) {
      console.log(id);
      return new Promise((resolve, reject) => {
        axios
          .delete(`/Admin/DeleteResource/${id}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getByIdResource(id) {
      console.log(id);
      return new Promise((resolve, reject) => {
        axios
          .get(`/Admin/GetById/${id}`, {
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
          .get("/Admin/GetAll", {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
            params: {
              resourceName: param.name,
            },
          })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
  },
});
