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
  <div class="mb-4">
    <v-row>
      <v-col cols="7">
        <v-text-field
          v-model="filterUser.name"
          label="Tìm kiếm nhân viên"
          prepend-inner-icon="mdi-magnify"
          variant="outlined"
          hide-details
          single-line
        ></v-text-field>
      </v-col>
      <v-col cols="4">
        <v-select
          clearable
          label="Lọc theo phòng ban"
          v-model="filterUser.teamId"
          item-value="id"
          item-title="name"
          :items="dataTeam"
          variant="outlined"
        >
        </v-select>
      </v-col>
      <v-col cols="1">
        <v-btn @click="filterUsers">Tìm kiếm</v-btn>
      </v-col>
    </v-row>
  </div>
  <VRow>
    <VCol cols="12" sm="3" md="3" v-for="user in dataUser" :key="user">
      <VCard>
        <VImg :src="pages2" />

        <VCardText class="position-relative">
          <!-- User Avatar -->
          <VAvatar size="75" class="avatar-center" :image="user.avatar" />

          <!-- Title, Subtitle & Action Button -->
          <div class="d-flex justify-space-between flex-wrap pt-8">
            <div class="me-2 mb-2">
              <VCardTitle class="pa-0"> {{ user.fullName }} </VCardTitle>
              <VCardTitle class="text-h6 pa-0">
                Email: {{ user.email }}
              </VCardTitle>
              <VCardTitle class="text-h6 pa-0">
                Nhóm: {{ user.teamName }}
              </VCardTitle>
            </div>
          </div>
          <v-dialog max-width="400">
            <template v-slot:activator="{ props: activatorProps }">
              <v-btn
                v-bind="activatorProps"
                style="font-size: 20px"
                density="comfortable"
                @click="findByIdUser(user.id)"
                icon="mdi-pencil-outline"
                class="mr-4"
              ></v-btn>
            </template>

            <template v-slot:default="{ isActive }">
              <v-card class="pa-4">
                <div class="text-center mb-4">
                  <h2>Cập nhật nhân viên</h2>
                </div>
                <VSelect
                  class="mb-6"
                  clearable
                  v-model="selectedRoles"
                  label="Quyền hạn"
                  :items="dataRoles"
                  item-title="roleName"
                  item-value="id"
                  :chips="true"
                  multiple
                  v-if="updateUserRoles.length > 0"
                >
                </VSelect>
                <v-select
                  class="mb-6"
                  clearable
                  label="Phòng ban"
                  :items="dataTeam"
                  v-model="updateUser.teamName"
                  item-title="name"
                  item-value="id"
                  variant="outlined"
                ></v-select>
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
        </VCardText>
      </VCard>
    </VCol>
  </VRow>
</template>
<script>
import { teamApi } from "../../../../../api/Team/teamApi";
import { userApi } from "../../../../../api/User/userApi";
import { authApi } from "../../../../../api/Auth/authApi";
export default {
  data() {
    return {
      userApi: userApi(),
      teamApi: teamApi(),
      authApi: authApi(),
      dataUser: [],
      dataTeam: [],
      selectedRoles: [],
      dataRoles: [],
      updateUser: {},
      updateUserRoles: [],
      searchQuery: "",
      filterUser: {
        email: "",
        teamId: "",
        name: "",
        phoneNumber: "",
      },
    };
  },
  async mounted() {
    const dataUser = await this.userApi.getAllUsers();
    this.dataUser = dataUser.data;
    console.log(this.dataUser);
    const dataTeam = await this.teamApi.getAllTeams();
    this.dataTeam = dataTeam.data;
    console.log(this.dataTeam);
    const dataRoles = await this.authApi.getAllRoles();
    this.dataRoles = dataRoles.data;
    console.log(this.dataRoles);
  },
  methods: {
    async filterUsers() {
      const res = await this.userApi.filterUser(this.filterUser);
      this.dataUser = res.data;
    },
    async findByIdUser(id) {
      try {
        const res = await this.userApi.getUserById(id);
        this.updateUser = res.data;

        const getByRolesUserId = await this.userApi.getRolesByIdUser(id);
        this.updateUserRoles = getByRolesUserId.data;

        // Loop through updateUserRoles to check if each role exists in dataRoles
        this.updateUserRoles.forEach((role) => {
          const foundRole = this.dataRoles.find((item) => item.id === role.id);
          if (foundRole) {
            // If the role exists in dataRoles, add it to selectedRoles
            this.selectedRoles.push(foundRole.id);
          }
        });

        console.log("update");
        console.log(this.updateUserRoles);
      } catch (error) {
        console.error("Error while fetching user data:", error);
      }
    },
  },
  watch: {
    updateUserRoles: {
      handler() {
        this.selectedRoles = this.updateUserRoles;
      },
      immediate: true,
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
.obligatory {
  color: rgb(255, 96, 96);
}
</style>
