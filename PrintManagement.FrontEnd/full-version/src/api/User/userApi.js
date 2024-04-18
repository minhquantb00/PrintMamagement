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
