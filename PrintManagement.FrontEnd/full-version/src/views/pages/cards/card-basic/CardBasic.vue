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
  <v-row>
    <v-col>
      <v-row>
        <v-col cols="4">
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
            placeholder="Start day"
            class="date-picker-input"
          >
          </AppDateTimePicker>
        </v-col>
        <v-col cols="2">
          <AppDateTimePicker
            clearable
            :format="dateFormat"
            v-model="fillterProject.endDate"
            placeholder="End day"
            class="date-picker-input"
          >
          </AppDateTimePicker>
        </v-col>
        <v-col cols="1">
          <v-btn @click="fillter">Tìm kiếm</v-btn>
        </v-col>
      </v-row>
    </v-col>
  </v-row>

  <VRow>
    <!-- 👉 Influencing The Influencer -->
    <VCol cols="12" sm="6" md="4" v-for="project in dataProject" :key="project">
      <v-dialog max-width="600">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <VImg :src="pages1" cover />

            <VCardItem>
              <VCardTitle>{{ project.projectName }}</VCardTitle>
            </VCardItem>
            <VCardText> Trưởng nhóm: {{ project.leader.fullName }} </VCardText>
            <v-card-text> Ngày tạo: {{ project.actualEndDate }} </v-card-text>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-0">
            <VImg :src="pages1" cover />
            <v-card-text>
              <h2>
                {{ project.projectName }}
              </h2>
            </v-card-text>
            <VCardText
              ><h3>- <b>Trưởng nhóm:</b> {{ project.leader.fullName }}</h3>
            </VCardText>
            <VCardText
              ><h3>- <b>Khách hàng:</b> {{ project.customer.fullName }}</h3>
            </VCardText>
            <VCardText
              ><b>- Ngày tạo:</b> {{ project.actualEndDate }}
            </VCardText>
            <v-card-text class="text-h6">
              <b>- Yêu cầu của khách hàng:</b>
              {{ project.requestDescriptionFromCustomer }}
            </v-card-text>
            <v-card-text class="text-h6">
              <b>- Mô tả:</b>
              {{ project.description }}
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>

              <v-btn
                variant="flat"
                text="Thoát"
                @click="isActive.value = false"
              ></v-btn>
            </v-card-actions>
          </v-card>
        </template>
      </v-dialog>
    </VCol>
  </VRow>
  <div class="text-center mt-4">
    <v-pagination v-model="page" :length="4" rounded="circle"></v-pagination>
  </div>
</template>
<script>
import { projectApi } from "../../../../api/Project/projectApi";
import { userApi } from "../../../../api/User/userApi";
export default {
  data() {
    return {
      page: 1,
      projectApi: projectApi(),
      dataProject: [],
      dataUser: [],
      userApi: userApi(),
      fillterProject: {
        projectName: "",
        startDate: "",
        endDate: "",
        leaderId: "",
      },
    };
  },
  async mounted() {
    const res = await this.projectApi.getAllsProject();
    this.dataProject = res.data;
    const resUser = await this.userApi.getAllUserContainsLeaderRole();
    this.dataUser = resUser.data;
  },
  methods: {
    async fillter() {
      const res = await this.projectApi.fillterData(this.fillterProject);
      this.dataProject = res.data;
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
</style>
