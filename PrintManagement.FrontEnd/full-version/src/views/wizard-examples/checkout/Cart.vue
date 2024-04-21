<script setup>
const props = defineProps({
  currentStep: {
    type: Number,
    required: false,
  },
  checkoutData: {
    type: null,
    required: true,
  },
});

const emit = defineEmits(["update:currentStep", "update:checkout-data"]);

const checkoutCartDataLocal = ref(props.checkoutData);

const removeItem = (item) => {
  checkoutCartDataLocal.value.cartItems =
    checkoutCartDataLocal.value.cartItems.filter((i) => i.id !== item.id);
  console.log(checkoutCartDataLocal.value.cartItems);
};

//  cart total
const totalCost = computed(() => {
  return (checkoutCartDataLocal.value.orderAmount =
    checkoutCartDataLocal.value.cartItems.reduce((acc, item) => {
      return acc + item.price * item.quantity;
    }, 0));
});

const updateCartData = () => {
  emit("update:checkout-data", checkoutCartDataLocal.value);
};

const nextStep = () => {
  updateCartData();
  emit("update:currentStep", props.currentStep ? props.currentStep + 1 : 1);
};

watch(() => props.currentStep, updateCartData);
</script>

<template>
  <VRow v-if="checkoutCartDataLocal">
    <VCol cols="12" md="8">
      <VCard hover>
        <div>
          <v-row>
            <v-col cols="5">
              <div class="ma-auto pa-5">
                <VImg
                  src="https://cms.vietnamreport.net/source/BaoCao/sach_trang_kinh_te_vietnam_2024/files/mobile/1.jpg?240117171048"
                />
              </div>
            </v-col>

            <VDivider :vertical="$vuetify.display.mdAndUp" />
            <v-col
              ><div>
                <VCardItem>
                  <VCardTitle class="text-h3"
                    >In Báo Cáo Thường Niên 2024</VCardTitle
                  >
                </VCardItem>
                <VCardText class="text-subtitle-1">
                  <span>Ngày tạo: </span>
                  <span class="font-weight-medium">28-05-2024</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span>Ngày dự kiến: </span>
                  <span class="font-weight-medium">30-05-2024</span>
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span style="font-weight: bold"
                    >Yêu cầu của khách hàng:
                  </span>
                  <span class="font-weight-medium"
                    >In 1000 cuốn báo cáo, bìa cứng, dập nổi logo công ty, 120
                    trang mỗi cuốn, giấy chất lượng cao, đen trắng ngoại trừ
                    trang bìa màu.</span
                  >
                </VCardText>
                <VCardText class="text-subtitle-1">
                  <span style="font-weight: bold">Mô tả: </span>
                  <span class="font-weight-medium"
                    >In báo cáo thường niên cho năm tài chính 2024, bao gồm các
                    báo cáo tài chính và phân tích hoạt động.</span
                  >
                </VCardText>
              </div></v-col
            >
          </v-row>
        </div>
      </VCard>
    </VCol>

    <VCol cols="12" md="4">
      <VCard flat variant="outlined">
        <!-- 👉 payment offer -->
        <VCardText>
          <h4 class="text-h4 font-weight-medium mb-3">Thông tin dự án</h4>

          <div class="d-flex align-center gap-4"></div>

          <!-- 👉 Gift wrap banner -->
          <div class="bg-var-theme-background rounded pa-5 mt-4">
            <h6 class="text-base font-weight-medium mb-5">
              Người phụ trách: Nguyễn Bá Quang Huy
            </h6>
            <p>Số điện thoại: 0385888833</p>
            <p>Email: quanghuy@gmail.com</p>
          </div>
          <div class="bg-var-theme-background rounded pa-5 mt-4">
            <h6 class="text-base font-weight-medium mb-5">
              Khách hàng: Trần Văn Dương
            </h6>
            <p>Số điện thoại: 0388033007</p>
            <p>Địa chỉ: Lý Nhân, Vĩnh Tường, Vĩnh Phúc</p>
          </div>
        </VCardText>

        <VDivider />

        <VCardText class="d-flex justify-space-between py-4">
          <h6 class="text-base font-weight-medium">Giá dự án</h6>
          <h6 class="text-base font-weight-medium">200,000 vnđ</h6>
        </VCardText>
      </VCard>

      <VBtn block class="mt-4" @click="nextStep">
        Thiết kế <v-icon icon="mdi-arrow-right" class="ml-2"></v-icon>
      </VBtn>
    </VCol>
  </VRow>
</template>

<style lang="scss" scoped>
.checkout-item-remove-btn {
  position: absolute;
  inset-block-start: 10px;
  inset-inline-end: 10px;
}
</style>
