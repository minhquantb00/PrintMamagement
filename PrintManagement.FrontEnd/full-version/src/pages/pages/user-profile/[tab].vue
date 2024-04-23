<script setup>
import { useRoute } from "vue-router";
import UserConnections from "@/views/pages/user-profile/connections/index.vue";
import UserProfile from "@/views/pages/user-profile/profile/index.vue";
import UserProjects from "@/views/pages/user-profile/projects/index.vue";
import UserTeam from "@/views/pages/user-profile/team/index.vue";
import UserProfileHeader from "@/views/pages/user-profile/UserProfileHeader.vue";
import ChartJsBarChart from "@/views/charts/chartjs/ChartJsBarChart.vue";
import ChartJsBubbleChart from "@/views/charts/chartjs/ChartJsBubbleChart.vue";
import ChartJsHorizontalBarChart from "@/views/charts/chartjs/ChartJsHorizontalBarChart.vue";
import ChartJsLineAreaChart from "@/views/charts/chartjs/ChartJsLineAreaChart.vue";
import ChartJsLineChart from "@/views/charts/chartjs/ChartJsLineChart.vue";
import ChartJsPolarAreaChart from "@/views/charts/chartjs/ChartJsPolarAreaChart.vue";
import ChartJsRadarChart from "@/views/charts/chartjs/ChartJsRadarChart.vue";
import ChartJsScatterChart from "@/views/charts/chartjs/ChartJsScatterChart.vue";

const chartJsCustomColors = {
  white: "#fff",
  yellow: "#ffe802",
  primary: "#836af9",
  areaChartBlue: "#2c9aff",
  barChartYellow: "#ffcf5c",
  polarChartGrey: "#4f5d70",
  polarChartInfo: "#299aff",
  lineChartYellow: "#d4e157",
  polarChartGreen: "#28dac6",
  lineChartPrimary: "#9e69fd",
  lineChartWarning: "#ff9800",
  horizontalBarInfo: "#26c6da",
  polarChartWarning: "#ff8131",
  scatterChartGreen: "#28c76f",
  warningShade: "#ffbd1f",
  areaChartBlueLight: "#84d0ff",
  areaChartGreyLight: "#edf1f4",
  scatterChartWarning: "#ff9f43",
};
const route = useRoute();
const activeTab = ref(route.params.tab);
</script>

<template>
  <div>
    <UserProfileHeader class="mb-5" />
    <VRow id="chartjs-wrapper">
      <!-- 👉 Statistics Line Chart  -->
      <VCol cols="12">
        <VCard>
          <v-row>
            <v-col>
              <v-card-title class="text-h3 mt-5">
                Thống kê lương hoa hồng
              </v-card-title>
            </v-col>
            <v-col class="d-flex justify-end mt-5">
              <div class="date-picker-wrapper mr-2">
                <AppDateTimePicker
                  style="width: 220px"
                  placeholder="Ngày bắt đầu"
                  prepend-inner-icon="tabler-calendar"
                  density="compact"
                  :config="{ position: 'auto right' }"
                />
              </div>

              <div class="date-picker-wrapper mr-2">
                <AppDateTimePicker
                  style="width: 220px"
                  placeholder="Ngày kết thúc"
                  prepend-inner-icon="tabler-calendar"
                  density="compact"
                  :config="{ position: 'auto right' }"
                />
              </div>
              <v-btn class="mr-2">Thống kê</v-btn>
            </v-col>
          </v-row>

          <VCardText>
            <ChartJsLineChart :colors="chartJsCustomColors" />
          </VCardText>
        </VCard>
      </VCol>

      <!-- 👉 Latest Statistics -->
      <VCol cols="12" md="12">
        <VCard>
          <v-row>
            <v-col>
              <v-card-title class="text-h3 mt-5">
                Thống kê doanh thu
              </v-card-title>
            </v-col>
            <v-col class="d-flex justify-end mt-5">
              <div class="date-picker-wrapper mr-2">
                <AppDateTimePicker
                  style="width: 220px"
                  placeholder="Ngày bắt đầu"
                  prepend-inner-icon="tabler-calendar"
                  density="compact"
                  :config="{ position: 'auto right' }"
                />
              </div>

              <div class="date-picker-wrapper mr-2">
                <AppDateTimePicker
                  style="width: 220px"
                  placeholder="Ngày kết thúc"
                  prepend-inner-icon="tabler-calendar"
                  density="compact"
                  :config="{ position: 'auto right' }"
                />
              </div>
              <v-btn class="mr-2">Thống kê</v-btn>
            </v-col>
          </v-row>

          <VCardText>
            <ChartJsBarChart :colors="chartJsCustomColors" />
          </VCardText>
        </VCard>
      </VCol>
    </VRow>
  </div>
</template>

<route lang="yaml">
meta:
  navActiveLink: pages-user-profile-tab
</route>
