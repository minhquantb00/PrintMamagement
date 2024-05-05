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
import AddressContent from "@/views/wizard-examples/checkout/Address.vue";
import CartContent from "@/views/wizard-examples/checkout/Cart.vue";
import ConfirmationContent from "@/views/wizard-examples/checkout/Confirmation.vue";
import PaymentContent from "@/views/wizard-examples/checkout/Payment.vue";

const avatars = [avatar1, avatar2, avatar3, avatar4];
const checkoutSteps = [
  {
    title: "Dự án",
    icon: "custom-trending",
  },
  {
    title: "Thiết kế",
    icon: "custom-address",
  },
  {
    title: "In ấn",
    icon: "custom-payment",
  },
  {
    title: "Giao hàng",
    icon: "custom-cart",
  },
];
const dataProjectCheckout = ref(null);
const getDataProjects = async (id) => {
  try {
    const res = await projectApi.getByIdProject(id); // Đảm bảo projectApi đã được khai báo trước
    dataProjectCheckout.value = res.data;
  } catch (e) {
    console.error("error fetching data", e);
  }
};
const checkoutData = ref({
  thietKe: [
    {
      src: "https://cms.vietnamreport.net/source/BaoCao/sach_trang_kinh_te_vietnam_2024/files/mobile/1.jpg?240117171048",
      user: "Nguyễn Bá Quang Huy",
      time: "29-03-2024",
      khachHang: "Nguyễn Khánh Huyền",
      status: "Chờ duyệtdd",
      moTa: " In báo cáo thường niên cho năm tài chính 2024, bao gồm các báo cáo tài chính và phân tích hoạt động.",
      value: 1,
    },
    {
      src: "https://thuthuatnhanh.com/wp-content/uploads/2019/06/anh-anime-girl-xinh-dep-cute-439x580.jpg",
      user: "Trần Văn Dương",
      time: "21-04-2024",
      khachHang: "Thắm Nguyễn",
      moTa: "In báo cáo thường niên cho năm tài chính 2024, bao gồm các báo cáo tài chính và phân tích hoạt động",
      status: "Chờ duyệt",
      value: 2,
    },
  ],
  dataProjectCheckout: [],
});
console.log(dataProjectCheckout);
const currentStep = ref(0);
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
              <v-form ref="refVForm" @submit.prevent="onSubmit">
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
                        :rules="[requiredValidator]"
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
                        :rules="[requiredValidator]"
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
                        :rules="[requiredValidator]"
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
                        :rules="[requiredValidator]"
                        item-title="fullName"
                        label="Khách hàng"
                        :items="dataCustomer"
                        variant="outlined"
                      ></v-select>
                    </v-col>
                    <v-col cols="6">
                      <div class="mb-3">
                        <span class="red">(*)</span> <span>Giá dự án</span>
                      </div>

                      <v-text-field
                        label="Giá dự án"
                        :rules="[requiredValidator]"
                        v-model="inputAddProject.startingPrice"
                        type="number"
                        variant="outlined"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="6">
                      <div class="mb-3">
                        <span class="red">(*)</span>
                        <span>Phần trăm hoa hồng</span>
                      </div>

                      <v-text-field
                        label="Phần trăm hoa hồng nhân viên"
                        :rules="[requiredValidator]"
                        v-model="inputAddProject.commissionPercentage"
                        variant="outlined"
                      ></v-text-field>
                    </v-col>
                  </v-row>
                  <div class="mb-3">
                    <span class="red">(*)</span> <span>Yêu cầu khách hàng</span>
                  </div>
                  <v-textarea
                    label="Yêu cầu khách hàng"
                    v-model="inputAddProject.requestDescriptionFromCustomer"
                    :rules="[requiredValidator]"
                    variant="outlined"
                    class="mb-5"
                  ></v-textarea>
                  <div class="mb-3">
                    <span class="red">(*)</span> <span>Mô tả dự án</span>
                  </div>
                  <v-textarea
                    v-model="inputAddProject.description"
                    label="Mô tả"
                    :rules="[requiredValidator]"
                    variant="outlined"
                  ></v-textarea>
                </div>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn
                    variant="flat"
                    text="Thêm mới"
                    type="submit"
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
        v-for="(project, index) in paginatedData"
        :key="index"
      >
        <VCard>
          <VImg :src="project.imageDescription" cover height="25em" />

          <VCardItem>
            <VCardTitle>{{ project.projectName }}</VCardTitle>
          </VCardItem>
          <VCardText> Trưởng nhóm: {{ project.leader }} </VCardText>
          <v-card-text>
            Ngày tạo: {{ formatDate(project.actualEndDate) }}
          </v-card-text>
          <v-card-text>
            <label
              >Tiến độ:
              <strong style="font-size: 15px; color: #00ff0a"
                >{{ Math.ceil(project.progress) }}%</strong
              ></label
            >
            <v-progress-linear
              class="mt-2"
              color="light-blue"
              height="10"
              :model-value="project.progress"
              striped
            >
            </v-progress-linear>
          </v-card-text>
          <v-card-text>
            <v-dialog
              v-model="dialog"
              transition="dialog-bottom-transition"
              fullscreen
            >
              <template v-slot:activator="{ props: activatorProps }">
                <v-btn
                  icon
                  color="info"
                  style="font-size: 18px"
                  v-bind="activatorProps"
                  density="comfortable"
                  @click="getDataProjects(project.id)"
                >
                  <v-icon icon="mdi-eye-outline"></v-icon>
                  <v-tooltip activator="parent" location="top">
                    Xem tiến độ dự án
                  </v-tooltip>
                </v-btn>
              </template>

              <v-card>
                <v-toolbar>
                  <v-toolbar-title>{{ project }}</v-toolbar-title>

                  <v-spacer></v-spacer>
                  <v-btn icon="mdi-close" @click="dialog = false"></v-btn>
                </v-toolbar>

                <VCard>
                  <VCardText>
                    <!-- 👉 Stepper -->
                    <AppStepper
                      v-model:current-step="currentStep"
                      class="checkout-stepper"
                      :items="checkoutSteps"
                      :direction="
                        $vuetify.display.smAndUp ? 'horizontal' : 'vertical'
                      "
                    />
                  </VCardText>

                  <VDivider />

                  <VCardText>
                    <!-- 👉 stepper content -->
                    <VWindow
                      v-model="currentStep"
                      class="disable-tab-transition"
                    >
                      <VWindowItem>
                        <CartContent
                          v-model:current-step="currentStep"
                          v-model:checkout-data="checkoutData"
                        />
                      </VWindowItem>

                      <VWindowItem>
                        <AddressContent
                          v-model:current-step="currentStep"
                          v-model:checkout-data="checkoutData"
                        />
                      </VWindowItem>

                      <VWindowItem>
                        <PaymentContent
                          v-model:current-step="currentStep"
                          v-model:checkout-data="checkoutData"
                        />
                      </VWindowItem>

                      <VWindowItem>
                        <ConfirmationContent
                          v-model:checkout-data="checkoutData"
                        />
                      </VWindowItem>
                    </VWindow>
                  </VCardText>
                </VCard>
              </v-card>
            </v-dialog>
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
      <v-pagination
        v-model="currentPage"
        :length="totalPages"
        rounded="circle"
      ></v-pagination>
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
import {
  alphaDashValidator,
  emailValidator,
  requiredValidator,
  phoneNumberValidator,
  usernameValidator,
} from "@validators";
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
      dialog: false,
      notifications: false,
      sound: true,
      widgets: false,
      loading: false,
      perPage: 8,
      refVForm: "",
      currentPage: 1,
      text: "",
      knowledge: null,
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
        startingPrice: "",
        commissionPercentage: "",
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
    // async getByIdProjects(id) {
    //   const res = await this.projectApi.getByIdProject(id);
    // },

    async saveProject() {
      const res = await this.projectApi.addProject(this.inputAddProject);
      console.log(res);
      if (res.data.status === 200) {
        this.text = res.data.message;
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      } else {
        this.text = res.data.message;
        this.snackbar = true;
      }
    },
    async deleteProjects(id) {
      try {
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
      } catch (e) {
        console.error(e);
        this.text = "Bạn không phải Admin";
        this.loading = false;
        this.snackbar = true;
      }
    },
    onSubmit() {
      refVForm.value?.validate().then(({ valid: isValid }) => {
        if (isValid) register();
      });
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
    paginatedData() {
      const start = (this.currentPage - 1) * this.perPage;
      const end = start + this.perPage;
      return this.dataProject.slice(start, end);
    },
    totalPages() {
      return Math.ceil(this.dataProject.length / this.perPage);
    },
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
.checkout-stepper {
  .stepper-icon-step {
    .step-wrapper + svg {
      margin-inline: 3.5rem !important;
    }
  }
}
.v-btn {
  transform: none;
}
</style>
