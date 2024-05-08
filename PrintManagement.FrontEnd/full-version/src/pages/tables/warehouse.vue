<script setup>
import { ref } from "vue";
function getBase64(file) {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = (error) => reject(error);
  });
}
const previewVisible = ref(false);
const previewImage = ref("");
const previewTitle = ref("");
const fileList = ref([]);
const handleCancel = () => {
  previewVisible.value = false;
  previewTitle.value = "";
};
const handlePreview = async (file) => {
  if (!file.url && !file.preview) {
    file.preview = await getBase64(file.originFileObj);
  }
  previewImage.value = file.url || file.preview;
  previewVisible.value = true;
  previewTitle.value =
    file.name || file.url.substring(file.url.lastIndexOf("/") + 1);
};
</script>
<template>
  <v-row>
    <v-col>
      <v-text-field
        label="Tìm kiếm theo tên"
        prepend-inner-icon="mdi-magnify"
        variant="outlined"
        hide-details
        single-line
      ></v-text-field>
    </v-col>
    <v-col class="text-right">
      <v-dialog max-width="500">
        <template v-slot:activator="{ props: activatorProps }">
          <v-btn
            icon="mdi-plus"
            active
            v-bind="activatorProps"
            density="comfortable"
          ></v-btn>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">Thêm sản phẩm</h2>
            <div class="clearfix mb-4 text-center">
              <a-upload
                v-model:file-list="fileList"
                action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                list-type="picture-card"
                @preview="handlePreview"
              >
                <div v-if="fileList.length < 1">
                  <plus-outlined />
                  <div style="margin-top: 8px; color: grey">
                    <v-icon
                      style="font-size: 20px"
                      icon="mdi-tray-arrow-up"
                    ></v-icon>
                    <p class="mt-1">Tải ảnh lên</p>
                  </div>
                </div>
              </a-upload>
              <a-modal
                :open="previewVisible"
                :title="previewTitle"
                :footer="null"
                @cancel="handleCancel"
              >
              </a-modal>
            </div>
            <v-row class="mb-4">
              <v-col cols="12">
                <v-text-field
                  label="Tên sản phẩm"
                  variant="outlined"
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-select
                  clearable
                  label="Thể loại kho"
                  :items="dataResourceType"
                  item-value="id"
                  item-title="nameOfResourceType"
                  variant="outlined"
                ></v-select>
              </v-col>
            </v-row>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                text="Thêm mới"
                variant="flat"
                @click="isActive.value = false"
              ></v-btn>
              <v-btn
                variant="outlined"
                text="Thoát"
                @click="isActive.value = false"
              ></v-btn>
            </v-card-actions>
          </v-card>
        </template>
      </v-dialog>
    </v-col>
  </v-row>
  <VRow>
    <!-- 👉 Apple iPhone 11 Pro -->
    <VCol sm="4" cols="12" v-for="item in dataResource" :key="item">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg width="137" height="176" :src="item" />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle
                    >Ream giấy A4 70 gsm IK Copy (500 tờ) - Hàng nhập khẩu
                    Indonesia</VCardTitle
                  >
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Giá: </span>
                  <span class="font-weight-medium">78,300 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng tồn:</span>
                  <span class="font-weight-medium">100</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Loại sản phẩm:</span>
                  <span class="font-weight-medium">Giấy</span>
                </VCardText>
              </div>
            </div>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">
              Ream giấy A4 70 gsm IK Copy (500 tờ) - Hàng nhập khẩu Indonesia
            </h2>
            <div class="clearfix mb-4 text-center"></div>
            <v-row class="mb-4">
              <v-col cols="6">
                <span class="red">(*)</span>
                <v-text-field
                  label="Số lượng"
                  variant="outlined"
                ></v-text-field>
              </v-col>
              <v-col cols="6">
                <span class="red">(*)</span>
                <v-text-field
                  label="Giá sản phẩm"
                  variant="outlined"
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <span class="red">(*)</span>
                <v-select
                  label="Phân loại"
                  :items="['Máy móc', 'Đồ văn phòng', 'Giấy']"
                  variant="outlined"
                ></v-select>
              </v-col>
            </v-row>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                text="Thêm mới"
                variant="flat"
                @click="isActive.value = false"
              ></v-btn>
              <v-btn
                variant="outlined"
                text="Thoát"
                @click="isActive.value = false"
              ></v-btn>
            </v-card-actions>
          </v-card>
        </template>
      </v-dialog>
    </VCol>
  </VRow>
  <div class="text-center mt-6">
    <v-pagination v-model="page" :length="4" rounded="circle"></v-pagination>
  </div>
</template>
>
<script>
import { resourceTypeApi } from "../../api/resource/resourceTypeApi";
import { resourceApi } from "../../api/resource/resourceApi";
export default {
  data() {
    return {
      resourceTypeApi: resourceTypeApi(),
      resourceApi: resourceApi(),
      dataResourceType: [],
      dataResource: [],
      page: 1,
    };
  },
  methods: {
    async getAllResourceTypes() {
      const data = await this.resourceTypeApi.getAllsResourceType();
      this.dataResourceType = data.data;
      console.log(this.dataResourceType);
    },
    async getAllsResource() {
      const data = await this.resourceApi.getAllsResource();
      this.dataResource = data.data;
    },
  },
  created() {
    this.getAllResourceTypes();
    this.getAllsResource();
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
.text-width {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 270px;
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
.red {
  color: rgb(253, 75, 75);
}
.v-btn {
  transform: none;
}
.ant-upload-select-picture-card i {
  font-size: 32px;
  color: #999;
}

.ant-upload-select-picture-card .ant-upload-text {
  margin-top: 8px;
  color: #d9d9d9;
}
</style>
