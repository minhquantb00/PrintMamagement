<template>
  <v-row class="mb-1">
    <v-col>
      <v-text-field
        v-model="search"
        label="Search"
        prepend-inner-icon="mdi-magnify"
        variant="outlined"
        hide-details
        single-line
      ></v-text-field>
    </v-col>
    <v-col class="text-right">
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
            <v-row class="mb-4">
              <v-col>
                <span class="obligatory">(*)</span>

                <v-text-field
                  v-model="inputAddCustomer.fullName"
                  label="Họ và tên"
                  variant="outlined"
                ></v-text-field>
              </v-col>
              <v-col>
                <span class="obligatory">(*)</span>
                <v-text-field
                  label="Số diện thoại"
                  variant="outlined"
                  v-model="inputAddCustomer.phoneNumber"
                ></v-text-field>
              </v-col>
            </v-row>
            <span class="obligatory">(*)</span>

            <v-textarea
              label="Địa chỉ"
              variant="outlined"
              no-resize
              v-model="inputAddCustomer.address"
              class="mb-4"
            ></v-textarea>
            <v-card-actions>
              <v-spacer></v-spacer>

              <v-btn
                text="Thêm mới"
                variant="flat"
                :loading="loading"
                @click="addCustomer"
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
      <tr v-for="item in dataCustomers" :key="item">
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
                color="info"
                style="font-size: 20px"
                density="comfortable"
                icon="mdi-pencil-outline"
                class="mr-4"
              ></v-btn>
            </template>

            <template v-slot:default="{ isActive }">
              <v-card class="pa-4">
                <div class="text-center mb-4"><h2>Cập nhật khách hàng</h2></div>
                <v-row class="mb-4">
                  <v-col>
                    <span class="obligatory">(*)</span>

                    <v-text-field
                      label="Họ và tên"
                      variant="outlined"
                    ></v-text-field>
                  </v-col>
                  <v-col>
                    <span class="obligatory">(*)</span>
                    <v-text-field
                      label="Số diện thoại"
                      variant="outlined"
                    ></v-text-field>
                  </v-col>
                </v-row>
                <span class="obligatory">(*)</span>

                <v-textarea
                  label="Địa chỉ"
                  variant="outlined"
                  no-resize
                  class="mb-4"
                ></v-textarea>
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
                      :loading="loading"
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
    <v-pagination v-model="page" :length="4" rounded="circle"></v-pagination>
  </div>
  <v-snackbar v-model="snackbar" color="blue-grey" rounded="pill" class="mb-5">
    {{ text }}
    <template v-slot:actions>
      <v-btn color="green" variant="text" @click="snackbar = false">
        Đóng
      </v-btn>
    </template>
    <!-- <template v-slot:activator="{ props }">
        <v-btn class="ma-2" color="blue-grey" rounded="pill" v-bind="props">open</v-btn>
      </template> -->
  </v-snackbar>
</template>
<script>
import { customerApi } from "../../../../../api/customer/customerApi";
export default {
  data() {
    return {
      customerApi: customerApi(),
      dataCustomers: [],
      page: 1,
      loading: false,
      text: "",
      snackbar: false,
      customerApi: customerApi(),
      inputAddCustomer: {
        fullName: "",
        phoneNumber: "",
        address: "",
      },
    };
  },
  async mounted() {
    const dataCustomers = await this.customerApi.getAllCustomer();
    this.dataCustomers = dataCustomers.data;
    console.log(this.dataCustomers);
  },
  methods: {
    async addCustomer() {
      const res = await this.customerApi.addCustomer(
        this.inputAddCustomer,
        (this.loading = true)
      );
      if (res) {
        setTimeout(() => {
          this.reloadPage();
          this.text = res.daata;
          this.snackbar = true;
        }, 4500);
      } else {
        this.text = res.data;
        this.snackbar = true;
      }
    },
    async deleteCustomer(id) {
      const res = await this.customerApi.deleteCustomer(
        id,
        (this.loading = true)
      );
      console.log(res);

      if (res) {
        setTimeout(() => {
          this.reloadPage();
          this.text = res.data;
          this.snackbar = true;
        }, 4500);
      } else {
        this.text = res.status;
        this.snackbar = true;
      }
    },
    reloadPage() {
      location.reload();
    },
  },
};
</script>
<style scoped>
.obligatory {
  color: rgb(255, 96, 96);
}
</style>
