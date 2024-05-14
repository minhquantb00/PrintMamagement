<script setup>
import { ref, onMounted } from "vue";
import { VDataTableServer } from "vuetify/labs/VDataTable";
import { paginationMeta } from "@/@fake-db/utils";
import AddNewUserDrawer from "@/views/apps/user/list/AddNewUserDrawer.vue";
import { useUserListStore } from "@/views/apps/user/useUserListStore";
import { avatarText } from "@core/utils/formatters";
import { giaoHangApi } from "@/api/giaoHang/giaoHangApi";
const userListStore = useUserListStore();
const searchQuery = ref("");
const selectedRole = ref();
const selectedPlan = ref();
const selectedStatus = ref();
const totalUsers = ref(0);
const dataGiaoHang = ref([]);
const giaoHangResApi = giaoHangApi();
const options = ref({
  page: 1,
  itemsPerPage: 10,
  sortBy: [],
  groupBy: [],
  search: undefined,
});

const headers = [
  {
    title: "Mã đơn hàng",
    key: "projectName",
  },
  {
    title: "Tên đơn hàng",
    key: "test",
  },
  {
    title: "Khách hàng",
    key: "role",
  },
  {
    title: "Số điện thoại",
    key: "plan",
  },
  {
    title: "Giá đơn hàng",
    key: "billing",
  },
  {
    title: "Trạng thái",
    key: "shippingMethodName",
  },
  {
    title: "PTVN",
    key: "status",
  },
  {
    title: "Vận chuyển",
    key: "actions",
    sortable: false,
  },
];

const fetchProjects = async () => {
  try {
    const res = await giaoHangResApi.getAllGiaoHang();
    dataGiaoHang.value = res.data;
    console.log("Fetched projects:", dataGiaoHang.value);
  } catch (error) {
    console.error("Error fetching projects:", error);
  }
};

onMounted(() => {
  fetchProjects();
});

const isAddNewUserDrawerVisible = ref(false);
</script>

<template>
  <div class="table-giao-hang">
    <v-table>
      <thead>
        <tr>
          <th class="text-left">tên đơn hàng</th>
          <th class="text-left">Khách hàng</th>
          <th class="text-left">Địa chỉ</th>
          <th class="text-left">ptvc</th>
          <th class="text-left">Vận chuyển</th>
          <th class="text-left">Trạng thái</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in dataGiaoHang" :key="item">
          <td>{{ item.project.projectName }}</td>
          <td>{{ item.project.customer }}</td>
          <td>{{ item.deliveryAddress }}</td>
          <td>{{ item.shippingMethodName }}</td>
          <td>{{ item.deliver.fullName }}</td>
          <td>
            {{ item.deliveryStatus }}
            <v-menu>
              <template v-slot:activator="{ props }">
                <v-btn
                  icon="mdi-dots-vertical"
                  density="comfortable"
                  variant="text"
                  v-bind="props"
                ></v-btn>
              </template>

              <v-list>
                <v-dialog max-width="500">
                  <template v-slot:activator="{ props: activatorProps }">
                    <v-btn v-bind="activatorProps" variant="text"
                      >Xem chi tiết</v-btn
                    >
                  </template>

                  <template v-slot:default="{ isActive }">
                    <v-card>
                      <div class="text-center mt-3">
                        <h2>Chi tiết đơn hàng</h2>
                      </div>
                      <div class="pa-4">
                        <v-list lines="one" class="text-h6">
                          <v-list-item>
                            Mã đơn hàng: {{ item.id }}
                          </v-list-item>
                          <v-list-item>
                            Tên đơn hàng: {{ item.project.projectName }}
                          </v-list-item>
                          <v-list-item>
                            Khách hàng: {{ item.customer.fullName }}
                          </v-list-item>
                          <v-list-item>
                            Số điện thoại: {{ item.customer.phoneNumber }}
                          </v-list-item>
                          <v-list-item>
                            Địa chỉ giao hàng: {{ item.deliveryAddress }}
                          </v-list-item>
                          <v-list-item>
                            Phương thức vận chuyển:
                            {{ item.shippingMethodName }}
                          </v-list-item>
                          <v-list-item>
                            Người vẫn chuyển: {{ item.deliver.fullName }}
                          </v-list-item>
                          <v-list-item>
                            Trạng thái đơn hàng: {{ item.deliveryStatus }}
                          </v-list-item>
                        </v-list>
                      </div>

                      <v-card-actions>
                        <v-spacer></v-spacer>

                        <v-btn
                          text="Thoát"
                          @click="isActive.value = false"
                        ></v-btn>
                      </v-card-actions>
                    </v-card>
                  </template>
                </v-dialog>
              </v-list>
            </v-menu>
          </td>
        </tr>
      </tbody>
    </v-table>
  </div>
</template>
<script>
export default {
  data() {
    return {
      items: [
        { title: "Click Me" },
        { title: "Click Me" },
        { title: "Click Me" },
        { title: "Click Me 2" },
      ],
    };
  },
};
</script>
<style lang="scss">
.text-capitalize {
  text-transform: capitalize;
}

.user-list-name:not(:hover) {
  color: rgba(var(--v-theme-on-background), var(--v-medium-emphasis-opacity));
}
</style>
