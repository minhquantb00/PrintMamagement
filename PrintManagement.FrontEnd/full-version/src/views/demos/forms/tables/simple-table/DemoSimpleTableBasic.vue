<template>
  <div v-if="isLoading" class="text-center mt-15">
    <a-space>
      <a-spin size="large" />
    </a-space>
  </div>

  <div v-else>
    <v-row class="mb-1">
      <v-col>
        <v-text-field
          v-model="fillterCustomer.name"
          label="Tìm kiếm theo tên"
          prepend-inner-icon="mdi-magnify"
          variant="outlined"
          hide-details
          single-line
        ></v-text-field>
      </v-col>
      <v-col>
        <v-text-field
          v-model="fillterCustomer.phoneNumber"
          label="Tìm kiếm theo số điện thoại"
          prepend-inner-icon="mdi-magnify"
          variant="outlined"
          hide-details
          single-line
        ></v-text-field>
      </v-col>
      <v-col cols="">
        <v-text-field
          v-model="fillterCustomer.address"
          label="Tìm kiếm theo địa chỉ"
          prepend-inner-icon="mdi-magnify"
          variant="outlined"
          hide-details
          single-line
        ></v-text-field>
      </v-col>
      <v-col cols="1">
        <v-btn @click="findByCustomer">Tìm kiếm</v-btn>
      </v-col>
      <v-col class="text-right" cols="1">
        <v-dialog max-width="600">
          <template v-slot:activator="{ props: activatorProps }">
            <v-btn
              v-bind="activatorProps"
              style="font-size: 20px"
              density="comfortable"
              icon="mdi-plus"
              class="mr-4"
            ></v-btn>
          </template>

          <template v-slot:default="{ isActive }">
            <v-card class="pa-4">
              <div class="text-center mb-4"><h2>Thêm khách hàng</h2></div>
              <v-form ref="refVForm" @submit.prevent="onSubmit">
                <v-row class="mb-1">
                  <v-col>
                    <span class="obligatory">(*)</span>

                    <v-text-field
                      v-model="inputAddCustomer.fullName"
                      label="Họ và tên"
                      :rules="[requiredValidator]"
                      variant="outlined"
                    ></v-text-field>
                  </v-col>
                  <v-col>
                    <span class="obligatory">(*)</span>
                    <v-text-field
                      label="Số điện thoại"
                      variant="outlined"
                      :rules="[requiredValidator, phoneNumberValidator]"
                      v-model="inputAddCustomer.phoneNumber"
                    ></v-text-field>
                  </v-col>
                </v-row>
                <span class="obligatory">(*)</span>
                <v-text-field
                  label="Email"
                  class="mb-4"
                  :rules="[requiredValidator, emailValidator]"
                  variant="outlined"
                  v-model="inputAddCustomer.email"
                ></v-text-field>
                <span class="obligatory">(*)</span>

                <v-textarea
                  label="Địa chỉ"
                  variant="outlined"
                  no-resize
                  :rules="[requiredValidator]"
                  v-model="inputAddCustomer.address"
                  class="mb-4"
                ></v-textarea>
                <v-card-actions>
                  <v-spacer></v-spacer>

                  <v-btn
                    text="Thêm mới"
                    variant="flat"
                    type="submit"
                    @click="addCustomer"
                  ></v-btn>
                  <v-btn
                    text="Thoát"
                    variant="outlined"
                    @click="isActive.value = false"
                  ></v-btn>
                </v-card-actions>
              </v-form>
            </v-card>
          </template>
        </v-dialog>
      </v-col>
    </v-row>
    <VTable class="text-no-wrap">
      <thead>
        <tr>
          <th class="text-uppercase">Họ và tên</th>
          <th class="text-uppercase text-center">Số điện thoại</th>
          <th class="text-uppercase text-center">Địa chỉ</th>
          <th class="text-uppercase text-center">Thao tác</th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="(item, index) in paginatedData" :key="index">
          <td>
            {{ item.fullName }}
          </td>
          <td class="text-center">
            {{ item.phoneNumber }}
          </td>
          <td class="text-center">
            {{ item.address }}
          </td>
          <td class="text-center">
            <v-dialog max-width="600">
              <template v-slot:activator="{ props: activatorProps }">
                <v-btn
                  v-bind="activatorProps"
                  style="font-size: 20px"
                  density="comfortable"
                  icon="mdi-pencil-outline"
                  class="mr-4"
                  @click="getByIdCustomer(item.id)"
                ></v-btn>
              </template>

              <template v-slot:default="{ isActive }">
                <v-card class="pa-4">
                  <div class="text-center mb-7">
                    <h2>Cập nhật khách hàng</h2>
                  </div>

                  <v-form ref="refVForm" @submit.prevent="onSubmit">
                    <v-row class="mb-4">
                      <v-col>
                        <v-text-field
                          v-model="updateKhachHang.fullName"
                          label="Họ và tên"
                          :rules="[requiredValidator]"
                          variant="outlined"
                        ></v-text-field>
                      </v-col>
                      <v-col>
                        <v-text-field
                          label="Số điện thoại"
                          v-model="updateKhachHang.phoneNumber"
                          :rules="[requiredValidator, phoneNumberValidator]"
                          variant="outlined"
                        ></v-text-field>
                      </v-col>
                    </v-row>

                    <v-text-field
                      label="Email"
                      class="mb-8"
                      v-model="updateKhachHang.email"
                      :rules="[requiredValidator, emailValidator]"
                      variant="outlined"
                    ></v-text-field>

                    <v-textarea
                      label="Địa chỉ"
                      variant="outlined"
                      no-resize
                      :rules="[requiredValidator]"
                      v-model="updateKhachHang.address"
                      class="mb-4"
                    ></v-textarea>
                    <v-card-actions>
                      <v-spacer></v-spacer>

                      <v-btn
                        text="Cập nhật"
                        variant="flat"
                        type="submit"
                        @click="updateCustomers(updateKhachHang.id)"
                      ></v-btn>
                      <v-btn
                        text="Thoát"
                        variant="outlined"
                        @click="isActive.value = false"
                      ></v-btn>
                    </v-card-actions>
                  </v-form>
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
                  icon="mdi-delete-outline"
                ></v-btn>
              </template>

              <template v-slot:default="{ isActive }">
                <v-card class="pa-4 text-center">
                  <h2>Bạn có muốn xóa</h2>
                  <v-card-actions class="mt-4">
                    <div>
                      <v-btn
                        text="Xóa"
                        @click="deleteCustomer(item.id)"
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
          </td>
        </tr>
      </tbody>
    </VTable>
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
    </v-snackbar>
  </div>
</template>
<script setup>
import {
  alphaDashValidator,
  emailValidator,
  requiredValidator,
  phoneNumberValidator,
  usernameValidator,
} from "@validators";
const refVForm = ref();
</script>
<script>
import { customerApi } from "../../../../../api/customer/customerApi";

export default {
  data() {
    return {
      customerApi: customerApi(),
      dataCustomers: [],
      page: 1,
      isLoading: true,
      loading: false,
      text: "",
      perPage: 10, // Number of items per page (fixed)
      currentPage: 1, // Current page
      snackbar: false,
      updateKhachHang: {},
      customerApi: customerApi(),
      inputAddCustomer: {
        fullName: "",
        phoneNumber: "",
        address: "",
        email: "",
      },
      fillterCustomer: {
        name: "",
        phoneNumber: "",
        address: "",
      },
    };
  },
  methods: {
    async findByCustomer() {
      const res = await this.customerApi.filterCustomer(this.fillterCustomer);
      this.dataCustomers = res.data;
    },
    async getByIdCustomer(id) {
      const getByIdCustomer = await this.customerApi.getByIdCustomer(id);
      this.updateKhachHang = getByIdCustomer.data;
    },
    async addCustomer() {
      const res = await this.customerApi.addCustomer(
        this.inputAddCustomer,
        (this.loading = true)
      );
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
    async updateCustomers(id) {
      const res = await this.customerApi.updateCustomer(
        id,
        this.updateKhachHang
      );
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
      console.log(res);
    },
    async deleteCustomer(id) {
      const res = await this.customerApi.deleteCustomer(id);
      console.log(res);

      if (res.status === 200) {
        this.text = res.data;
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 2000);
      } else {
        this.text = res.status;
        this.snackbar = true;
      }
    },
    reloadPage() {
      location.reload();
    },
    onSubmit() {
      refVForm.value?.validate().then(({ valid: isValid }) => {
        if (isValid) register();
      });
    },
    async getDataCustomer() {
      this.isLoading = true;
      try {
        const dataCustomers = await this.customerApi.getAllCustomer();
        this.dataCustomers = dataCustomers.data;
      } catch (e) {
        console.error("fetching error:", e);
      } finally {
        this.isLoading = false;
      }
    },
  },
  created() {
    this.getDataCustomer();
  },
  computed: {
    paginatedData() {
      const start = (this.currentPage - 1) * this.perPage;
      const end = start + this.perPage;
      return this.dataCustomers.slice(start, end);
    },
    totalPages() {
      return Math.ceil(this.dataCustomers.length / this.perPage);
    },
  },
};
</script>
<style scoped>
.obligatory {
  color: rgb(255, 96, 96);
}
</style>
