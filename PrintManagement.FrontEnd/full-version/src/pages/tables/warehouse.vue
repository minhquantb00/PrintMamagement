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
  <VRow>
    <!-- 👉 Apple iPhone 11 Pro -->
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
    <VCol sm="4" cols="12">
      <VCard>
        <div
          class="d-flex justify-space-between flex-wrap flex-md-nowrap flex-column flex-md-row"
        >
          <div class="ma-auto pa-5">
            <VImg width="137" height="176" :src="eCommerce2" />
          </div>

          <VDivider :vertical="$vuetify.display.mdAndUp" />

          <div>
            <VCardItem>
              <VCardTitle>Apple iPhone 11 Pro</VCardTitle>
            </VCardItem>

            <VCardText>
              Apple iPhone 11 Pro smartphone. Announced Sep 2019. Features 5.8″
              display Apple A13 Bionic
            </VCardText>

            <VCardText class="text-subtitle-1">
              <span>Price :</span> <span class="font-weight-medium">$899</span>
            </VCardText>

            <VCardActions class="justify-space-between">
              <VBtn>
                <VIcon icon="tabler-shopping-cart-plus" />
                <span class="ms-2">Add to cart</span>
              </VBtn>

              <IconBtn color="secondary" icon="tabler-share" />
            </VCardActions>
          </div>
        </div>
      </VCard>
    </VCol>
  </VRow>
</template>

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