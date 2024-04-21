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

const checkoutAddressDataLocal = ref(props.checkoutData);

const deliveryOptions = [
  {
    icon: { icon: "tabler-user" },
    title: "Standard",
    desc: "Get your product in 1 Week.",
    value: "free",
  },
  {
    icon: { icon: "tabler-crown" },
    title: "Express",
    desc: "Get your product in 3-4 days.",
    value: "express",
  },
  {
    icon: { icon: "tabler-rocket" },
    title: "Overnight",
    desc: "Get your product in 1 day.",
    value: "overnight",
  },
];

const resolveAddressBadgeColor = {
  home: "primary",
  office: "success",
};

const resolveDeliveryBadgeData = {
  free: {
    color: "success",
    price: "Free",
  },
  express: {
    color: "secondary",
    price: 10,
  },
  overnight: {
    color: "secondary",
    price: 15,
  },
};

const totalPriceWithDeliveryCharges = computed(() => {
  checkoutAddressDataLocal.value.deliveryCharges = 0;
  if (checkoutAddressDataLocal.value.deliverySpeed !== "free")
    checkoutAddressDataLocal.value.deliveryCharges =
      resolveDeliveryBadgeData[
        checkoutAddressDataLocal.value.deliverySpeed
      ].price;

  return (
    checkoutAddressDataLocal.value.orderAmount +
    checkoutAddressDataLocal.value.deliveryCharges
  );
});

const updateAddressData = () => {
  emit("update:checkout-data", checkoutAddressDataLocal.value);
};

const nextStep = () => {
  updateAddressData();
  emit("update:currentStep", props.currentStep ? props.currentStep + 1 : 1);
};

watch(() => props.currentStep, updateAddressData);
</script>

<template>
  <VRow>
    <VCol cols="12" md="8">
      <!-- 👉 Address custom input -->
      <CustomRadios
        v-model:selected-radio="checkoutAddressDataLocal.deliveryAddress"
        :radio-content="checkoutAddressDataLocal.thietKe"
        :grid-column="{ cols: '12', sm: '6' }"
      >
      </CustomRadios>

      <!-- 👉 Add New Address -->
      <VBtn variant="tonal" class="mt-5 mb-8">
        <v-icon
          icon="mdi-folder-upload-outline"
          style="font-size: 25px"
          class="mr-2"
        ></v-icon>
        Tải file
      </VBtn>
    </VCol>

    <VCol cols="12" md="4">
      <VCard flat variant="outlined">
        <!-- 👉 Delivery estimate date -->
        <VCardText >
          <h6 class="text-base font-weight-medium mb-5">Thông tin dự án</h6>

          <VList class="card-list bg-var-theme-background rounded pa-5">
            <VListItem
              v-for="product in checkoutAddressDataLocal.thietKe"
              :key="product.value"
            >
              <VListItemSubtitle class="text-h6 mb-4"
                >Khách hàng {{ product.khachHang }}</VListItemSubtitle
              >
              <span>Mô tả: </span>
              <span class="font-weight-medium text-sm">
                {{ product.moTa }}
              </span>
            </VListItem>
          </VList>
        </VCardText>
      </VCard>

      <VBtn block class="mt-4" @click="nextStep">
        In ấn <v-icon icon=" mdi-arrow-right" class="ml-3"></v-icon>
      </VBtn>
      <VBtn block variant="outlined" class="mt-4" @click="nextStep">
        Không phê duyệt
      </VBtn>
    </VCol>
  </VRow>
</template>
