<script setup>
import RoleCards from "@/views/apps/roles/RoleCards.vue";
import UserList from "@/views/apps/roles/UserList.vue";
</script>

<template>
  <VRow>
    <!-- <VCol cols="12">
      <h4 class="text-h4 mb-6">
        Quản lí giao hàng
      </h4>
      <p class="mb-0">
        A role provided access to predefined menus and features so that depending on assigned role an administrator can have access to what he need
      </p>
    </VCol> -->

    <!-- 👉 Roles Cards -->
    <!-- <VCol cols="12">
      <RoleCards />
    </VCol> -->

    <VCol cols="12">
      <!-- 👉 User List  -->
      <UserList />
    </VCol>
  </VRow>
</template>
