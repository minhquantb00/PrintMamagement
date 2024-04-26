<script setup>
import avatar1 from "@images/avatars/avatar-1.png";
import avatar2 from "@images/avatars/avatar-2.png";
import avatar3 from "@images/avatars/avatar-3.png";
import avatar4 from "@images/avatars/avatar-4.png";
import eCommerce2 from "@images/eCommerce/2.png";
import pages1 from "@images/pages/1.png";
import pages2 from "@images/pages/2.png";
import pages3 from "@images/pages/3.png";
import pages5 from "@images/pages/5.jpg";
import pages6 from "@images/pages/6.jpg";

const avatars = [avatar1, avatar2, avatar3, avatar4];

const isCardDetailsVisible = ref(false);
</script>

<template>
  <div v-if="isLoading" class="text-center mt-15">
    <a-space>
      <a-spin size="large" />
    </a-space>
  </div>
  <div v-else>
    <v-row>
      <v-col>
        <v-row>
          <v-col cols="3">
            <v-text-field
              clearable
              label="Tìm kiếm project"
              v-model="fillterProject.projectName"
              prepend-inner-icon="mdi-magnify"
              variant="outlined"
              hide-details
              single-line
            ></v-text-field>
          </v-col>
          <v-col cols="3">
            <v-select
              clearable
              label="Lọc leader"
              variant="outlined"
              v-model="fillterProject.leaderId"
              item-value="id"
              item-title="fullName"
              :items="dataUser"
            ></v-select>
          </v-col>
          <v-col cols="2">
            <AppDateTimePicker
              clearable
              :format="dateFormat"
              v-model="fillterProject.startDate"
              placeholder="Ngày bắt đầu"
              prepend-inner-icon="tabler-calendar"
              class="date-picker-input"
            >
            </AppDateTimePicker>
          </v-col>
          <v-col cols="2">
            <AppDateTimePicker
              clearable
              :format="dateFormat"
              v-model="fillterProject.endDate"
              placeholder="Ngày kết thúc"
              class="date-picker-input"
              prepend-inner-icon="tabler-calendar"
            >
            </AppDateTimePicker>
          </v-col>
          <v-col cols="2">
            <v-btn @click="fillter">Tìm kiếm</v-btn>
          </v-col>
        </v-row>
      </v-col>
      <v-col cols="1" class="text-right">
        <v-dialog max-width="700" persistent>
          <template v-slot:activator="{ props: activatorProps }">
            <v-btn
              icon
              v-bind="activatorProps"
              density="comfortable"
              variant="flat"
            >
              <v-icon icon="mdi-plus"></v-icon>
              <v-tooltip activator="parent" location="top">
                Thêm dự án
              </v-tooltip>
            </v-btn>
          </template>

          <template v-slot:default="{ isActive }">
            <v-card>
              <h2 class="text-center mt-3">Thêm dự án</h2>
              <v-form>
                <div class="pa-4">
                  <v-row class="mb-5">
                    <v-col cols="12">
                      <v-file-input
                        clearable
                        v-model="inputAddProject.imageDescription"
                        prepend-icon="mdi-tray-arrow-up"
                        variant="outlined"
                        label="Upload ảnh"
                        @change="hanldeImageChange"
                        show-size
                      ></v-file-input>
                    </v-col>
                    <v-col cols="6">
                      <div class="mb-3">
                        <span class="red">(*)</span> <span>Tên dự án</span>
                      </div>

                      <v-text-field
                        label="Tên dự án"
                        v-model="inputAddProject.projectName"
                        variant="outlined"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="6">
                      <div class="mb-3">
                        <span class="red">(*)</span> <span>Ngày dự kiến</span>
                      </div>
                      <AppDateTimePicker
                        :format="dateFormat"
                        v-model="inputAddProject.expectedEndDate"
                        placeholder="Ngày dự kiến"
                        prepend-inner-icon="tabler-calendar"
                        class="date-picker-input"
                      >
                      </AppDateTimePicker>
                    </v-col>
                    <v-col cols="6">
                      <div class="mb-3">
                        <span class="red">(*)</span>
                        <span>Người nhận dự án</span>
                      </div>
                      <v-select
                        clearable
                        v-model="inputAddProject.leaderId"
                        label="Người nhận dự án"
                        item-value="id"
                        item-title="fullName"
                        :items="dataUser"
                        variant="outlined"
                      ></v-select>
                    </v-col>
                    <v-col cols="6">
                      <div class="mb-3">
                        <span class="red">(*)</span> <span>Khách hàng</span>
                      </div>
                      <v-select
                        clearable
                        v-model="inputAddProject.customerId"
                        item-value="id"
                        item-title="fullName"
                        label="Khách hàng"
                        :items="dataCustomer"
                        variant="outlined"
                      ></v-select>
                    </v-col>
                  </v-row>
                  <div class="mb-3">
                    <span class="red">(*)</span> <span>Yêu cầu khách hàng</span>
                  </div>
                  <v-textarea
                    label="Yêu cầu khách hàng"
                    v-model="inputAddProject.requestDescriptionFromCustomer"
                    variant="outlined"
                    class="mb-5"
                  ></v-textarea>
                  <div class="mb-3">
                    <span class="red">(*)</span> <span>Mô tả dự án</span>
                  </div>
                  <v-textarea
                    v-model="inputAddProject.description"
                    label="Mô tả"
                    variant="outlined"
                  ></v-textarea>
                </div>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn
                    variant="flat"
                    text="Thêm mới"
                    @click="saveProject"
                  ></v-btn>
                  <v-btn
                    variant="outlined"
                    text="Thoát"
                    @click="isActive.value = false"
                  ></v-btn>
                </v-card-actions>
              </v-form>
            </v-card>
          </template>
        </v-dialog>
      </v-col>
    </v-row>
    <VRow>
      <VCol
        cols="12"
        sm="6"
        md="3"
        v-for="project in dataProject"
        :key="project"
      >
        <VCard>
          <VImg :src="pages1" cover />

          <VCardItem>
            <VCardTitle>{{ project.projectName }}</VCardTitle>
          </VCardItem>
          <VCardText> Trưởng nhóm: {{ project.leader.fullName }} </VCardText>
          <v-card-text>
            Ngày tạo: {{ formatDate(project.actualEndDate) }}
          </v-card-text>
          <v-card-text>
            <label
              >Tiến độ:
              <strong style="font-size: 15px; color: #00ff0a"
                >{{ Math.ceil(knowledge) }}%</strong
              ></label
            >
            <v-progress-linear
              class="mt-2"
              color="light-blue"
              height="10"
              :model-value="knowledge"
              striped
            >
            </v-progress-linear>
          </v-card-text>
          <v-card-text>
            <router-link to="/wizard-examples/checkout">
              <v-btn
                icon
                color="info"
                style="font-size: 18px"
                density="comfortable"
              >
                <v-icon icon="mdi-eye-outline"></v-icon>
                <v-tooltip activator="parent" location="top">
                  Xem tiến độ dự án
                </v-tooltip>
              </v-btn>
            </router-link>
            <v-dialog max-width="400">
              <template v-slot:activator="{ props: activatorProps }">
                <v-btn
                  v-bind="activatorProps"
                  style="font-size: 20px"
                  density="comfortable"
                  class="ml-4"
                  icon
                >
                  <v-icon icon="mdi-pencil-outline"></v-icon>
                  <v-tooltip activator="parent" location="top">
                    Cập nhật dự án
                  </v-tooltip>
                </v-btn>
              </template>

              <template v-slot:default="{ isActive }">
                <v-card class="pa-4">
                  <div class="text-center mb-4">
                    <h2>Cập nhật dự án</h2>
                  </div>
                  <h1 class="text-center mb-8">Tính năng đang phát triển</h1>
                  <v-card-actions>
                    <v-spacer></v-spacer>

                    <v-btn
                      text="Cập nhật"
                      variant="flat"
                      @click="isActive.value = false"
                    ></v-btn>
                    <v-btn
                      text="Thoát"
                      variant="outlined"
                      @click="isActive.value = false"
                    ></v-btn>
                  </v-card-actions>
                </v-card>
              </template>
            </v-dialog>
            <v-dialog max-width="300">
              <template v-slot:activator="{ props: activatorProps }">
                <v-btn
                  density="comfortable"
                  style="font-size: 20px"
                  v-bind="activatorProps"
                  color="error"
                  class="ml-4"
                  icon
                >
                 <v-icon icon="mdi-delete-outline"></v-icon>
                <v-tooltip activator="parent" location="top">
                  Xóa dự án
                </v-tooltip>
                </v-btn>
              </template>

              <template v-slot:default="{ isActive }">
                <v-card class="pa-4 text-center">
                  <h2>Bạn có muốn xóa</h2>
                  <v-card-actions class="mt-4">
                    <div>
                      <v-btn
                        text="Xóa"
                        :loading="loading"
                        @click="deleteProjects(project.id)"
                        color="error"
                        variant="flat"
                        class="ml-13"
                      ></v-btn>
                      <v-btn
                        text="Thoát"
                        variant="outlined"
                        @click="isActive.value = false"
                      ></v-btn>
                    </div>
                  </v-card-actions>
                </v-card>
              </template>
            </v-dialog>
          </v-card-text>
        </VCard>
      </VCol>
    </VRow>
    <div class="text-center mt-4">
      <v-pagination v-model="page" :length="4" rounded="circle"></v-pagination>
    </div>
    <v-snackbar
      v-model="snackbar"
      color="blue-grey"
      rounded="pill"
      class="mb-5"
    >
      {{ text }}
      <template v-slot:actions>
        <v-btn color="green" variant="text" @click="snackbar = false">
          Đóng
        </v-btn>
      </template>
      <!-- <template v-slot:activator="{ props }">
        <v-btn class="ma-2" color="blue-grey" rounded="pill" v-bind="props"
          >open</v-btn
        >
      </template> -->
    </v-snackbar>
  </div>
</template>
<script>
import { projectApi } from "../../../api/Project/projectApi";
import { customerApi } from "../../../api/customer/customerApi";
import { userApi } from "../../../api/User/userApi";
export default {
  data() {
    return {
      page: 1,
      projectApi: projectApi(),
      customerApi: customerApi(),
      userApi: userApi(),
      dataCustomer: [],
      dataProject: [],
      dataUser: [],
      snackbar: false,
      loading: false,
      text: "",
      knowledge: 75,
      fillterProject: {
        projectName: "",
        startDate: "",
        endDate: "",
        leaderId: "",
      },
      inputAddProject: {
        projectName: "",
        description: "",
        requestDescriptionFromCustomer: "",
        leaderId: "",
        expectedEndDate: "",
        customerId: "",
        imageDescription: "",
      },
      isLoading: true,
    };
  },
  async mounted() {
    const resDataCustomer = await this.customerApi.getAllCustomer();
    this.dataCustomer = resDataCustomer.data;
    const resUser = await this.userApi.getAllUserContainsLeaderRole();
    this.dataUser = resUser.data;
  },
  methods: {
    async saveProject() {
      const res = await this.projectApi.addProject(this.inputAddProject);
      console.log(res);
      if (res.data.status === 200) {
        this.text = res.data.message;
        this.snackbar = true;
        // setTimeout(() => {
        //   this.reloadPage();
        // }, 2000);
      } else {
        this.text = res.message;
        this.snackbar = true;
      }
    },
    async deleteProjects(id) {
      const res = await this.projectApi.deleteProject(
        id,
        (this.loading = true)
      );
      console.log(res);
      if (res.status === 200) {
        this.text = res.data;
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      } else {
        this.text = res.data.message;
        this.snackbar = true;
      }
    },
    reloadPage() {
      location.reload();
    },
    hanldeImageChange(event) {
      const file = event.target.files[0];
      const maxSizeInBytes = 2 * 1024 * 1024; // 2MB
      const allowedExtensions = [".jpg", ".jpeg", ".png"];
      if (!file) {
        return;
      }
      const fileName = file.name;
      if (file.size > maxSizeInBytes) {
        this.text = "Kích thước ảnh không được vượt quá 2MB";
        this.snackbar = true;
        return;
      }
      const fileExtension = fileName.split(".").pop();
      if (!allowedExtensions.includes("." + fileExtension.toLowerCase())) {
        this.text = "Hệ thống chỉ hỗ trợ file ảnh dạng: jpg, png, jpeg";
        this.snackbar = true;
        return;
      }
      this.imageFile = fileName;
      this.inputAddProject.imageDescription = file;
    },
    async fillter() {
      const res = await this.projectApi.fillterData(this.fillterProject);
      this.dataProject = res.data;
    },
    formatDate(dateString) {
      const date = new Date(dateString);
      const day = date.getDate();
      const month = date.getMonth() + 1;
      const year = date.getFullYear();
      const hours = date.getHours();
      const minutes = date.getMinutes();
      const seconds = date.getSeconds();
      const formattedDay = day < 10 ? "0" + day : day;
      const formattedMonth = month < 10 ? "0" + month : month;
      const formattedHours = hours < 10 ? "0" + hours : hours;
      const formattedMinutes = minutes < 10 ? "0" + minutes : minutes;
      const formattedSeconds = seconds < 10 ? "0" + seconds : seconds;

      return `${formattedDay}/${formattedMonth}/${year}`;
    },
    async getDataProjects() {
      this.isLoading = true;
      try {
        const res = await this.projectApi.getAllsProject();
        this.dataProject = res.data;
      } catch (e) {
        console.error("error fetching data", e);
      } finally {
        this.isLoading = false;
      }
    },
  },
  created() {
    this.getDataProjects();
  },
  computed: {
    dateFormat: "yyyy-MM-dd",
  },
};
</script>
<style lang="scss" scoped>
.avatar-center {
  position: absolute;
  border: 3px solid rgb(var(--v-theme-surface));
  inset-block-start: -2rem;
  inset-inline-start: 1rem;
}
.red {
  color: rgb(255, 72, 72);
}
// membership pricing
.member-pricing-bg {
  position: relative;
  background-color: rgba(var(--v-theme-on-surface), var(--v-hover-opacity));
}

.membership-pricing {
  sup {
    inset-block-start: 9px;
  }
}

.v-btn {
  transform: none;
}
</style>
