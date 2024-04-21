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
    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://product.hstatic.net/1000230347/product/new26_227dafd725ce4ff3a1f65de31d4f2a4f.jpg"
                />
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

    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://lh3.googleusercontent.com/proxy/G9IX6lzFCHq2HMsZcWerqdMRFxZ-wYr0juhgWeZU5fz096zobAsPuNd86cWRyM285L8dvjJFdUTg_q-2MuwywbaxLKcLQ2_IBHjKUDH1-UQpynyqe_z4GQDdrYUBZn-1nDV__WNNvu9q"
                />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle
                    >Máy in đa năng trắng đen A4 OKI MB472dnw</VCardTitle
                  >
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Giá :</span>
                  <span class="font-weight-medium">10,831,000 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng:</span>
                  <span class="font-weight-medium">10</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Loại sản phẩm:</span>
                  <span class="font-weight-medium">Máy in</span>
                </VCardText>
              </div>
            </div>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">
              Máy in đa năng trắng đen A4 OKI MB472dnw
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
    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://bizweb.dktcdn.net/100/334/874/products/3486-2.jpg?v=1592189578323"
                />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle
                    >Giấy thủ công Hồng Hà 12 màu (195x295mm) - 3486</VCardTitle
                  >
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Giá :</span>
                  <span class="font-weight-medium">8.935 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng:</span>
                  <span class="font-weight-medium">500</span>
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
              Giấy thủ công Hồng Hà 12 màu (195x295mm) - 3486
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
    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://hoangminhoffice.com/wp-content/uploads/2021/02/canon-gi70.jpg"
                />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle
                    >Bộ mực in Canon GI-70 – Cho máy G5070/ G6070</VCardTitle
                  >
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Price :</span>
                  <span class="font-weight-medium">1.150.000 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng tồn:</span>
                  <span class="font-weight-medium">50</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Loại sản phẩm: </span>
                  <span class="font-weight-medium">Mực in</span>
                </VCardText>
              </div>
            </div>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">
              Bộ mực in Canon GI-70 – Cho máy G5070/ G6070
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
    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://vietbis.vn/Image/Picture/HP/Scan_hp/L2737A.png"
                />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle>Máy Scan HP Scanjet Pro 3000s2 (90%)</VCardTitle>
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Giá: </span>
                  <span class="font-weight-medium">3,900,000 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng:</span>
                  <span class="font-weight-medium">10</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Loại sản phẩm: </span>
                  <span class="font-weight-medium">Máy in</span>
                </VCardText>
              </div>
            </div>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">
              Máy Scan HP Scanjet Pro 3000s2 (90%)
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
    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://cf.shopee.vn/file/35c2e9e1716bee36257c0eb5bc2ac25a"
                />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle>Bàn Cắt Giấy 500 tờ Khổ A3</VCardTitle>
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Giá :</span>
                  <span class="font-weight-medium">2,700,000 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng: </span>
                  <span class="font-weight-medium">5</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Loại sản phẩm:</span>
                  <span class="font-weight-medium">Máy in</span>
                </VCardText>
              </div>
            </div>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">Bàn Cắt Giấy 500 tờ Khổ A3</h2>
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
    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://salt.tikicdn.com/ts/product/1c/ac/5d/74d956770d19e33e30468cc1b268db8f.png"
                />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle
                    >Dập ghim loại lớn 100 trang, dụng cụ văn phòng phẩm tặng 1
                    hộp ghim DG 9001</VCardTitle
                  >
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Giá :</span>
                  <span class="font-weight-medium">200,000 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng: </span>
                  <span class="font-weight-medium">5</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Loại sản phẩm:</span>
                  <span class="font-weight-medium">Đồ văn phòng</span>
                </VCardText>
              </div>
            </div>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">
              Dập ghim loại lớn 100 trang, dụng cụ văn phòng phẩm tặng 1 hộp
              ghim DG 9001
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
    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://vanphongphamsieure.vn/wp-content/uploads/2017/06/Ghim-k%E1%BA%B9p-gi%E1%BA%A5y-C32.jpg"
                />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle>Ghim kẹp giấy C32</VCardTitle>
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Giá :</span>
                  <span class="font-weight-medium">30,000 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng: </span>
                  <span class="font-weight-medium">100</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Loại sản phẩm:</span>
                  <span class="font-weight-medium">Đồ văn phòng</span>
                </VCardText>
              </div>
            </div>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">Ghim kẹp giấy C32</h2>
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
    <VCol sm="4" cols="12">
      <v-dialog max-width="700">
        <template v-slot:activator="{ props: activatorProps }">
          <VCard v-bind="activatorProps">
            <div
              class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
            >
              <div class="ma-auto pa-5">
                <VImg
                  width="137"
                  height="176"
                  src="https://intmt.vn/wp-content/uploads/2022/03/mo-hinh-may-in-offset.jpg"
                />
              </div>

              <VDivider :vertical="$vuetify.display.mdAndUp" />

              <div>
                <VCardItem>
                  <VCardTitle>Máy in Offset</VCardTitle>
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Giá :</span>
                  <span class="font-weight-medium">21,700,000 VND</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Số lượng: </span>
                  <span class="font-weight-medium">1</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Loại sản phẩm:</span>
                  <span class="font-weight-medium">Máy in</span>
                </VCardText>
              </div>
            </div>
          </VCard>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card class="pa-4">
            <h2 class="mb-4 text-center">Máy in Offset</h2>
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
export default {
  data() {
    return {
      page: 1,
    };
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
