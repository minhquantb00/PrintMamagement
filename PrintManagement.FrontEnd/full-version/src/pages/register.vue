<script setup>
import { VForm } from "vuetify/components/VForm";
import authV2RegisterIllustrationBorderedDark from "@images/pages/auth-v2-register-illustration-bordered-dark.png";
import authV2RegisterIllustrationBorderedLight from "@images/pages/auth-v2-register-illustration-bordered-light.png";
import authV2RegisterIllustrationDark from "@images/pages/auth-v2-register-illustration-dark.png";
import authV2RegisterIllustrationLight from "@images/pages/auth-v2-register-illustration-light.png";
import authV2MaskDark from "@images/pages/misc-mask-dark.png";
import authV2MaskLight from "@images/pages/misc-mask-light.png";
import { useAppAbility } from "@/plugins/casl/useAppAbility";
import AuthProvider from "@/views/pages/authentication/AuthProvider.vue";
import axios from "@axios";
import { useGenerateImageVariant } from "@core/composable/useGenerateImageVariant";
import { VNodeRenderer } from "@layouts/components/VNodeRenderer";
import { themeConfig } from "@themeConfig";
import {
  alphaDashValidator,
  emailValidator,
  requiredValidator,
  phoneNumberValidator,
  usernameValidator,
} from "@validators";
import dayjs from "dayjs";
import { ref } from "vue";
const dateFormat = "YYYY-MM-DD";
const weekFormat = "MM/DD";
const monthFormat = "YYYY/MM";
const dateFormatList = ["DD/MM/YYYY", "DD/MM/YY"];
const customWeekStartEndFormat = (value) =>
  `${dayjs(value).startOf("week").format(weekFormat)} ~ ${dayjs(value)
    .endOf("week")
    .format(weekFormat)}`;
const formatDate = ref(dayjs("2003/07/28", dateFormat[0]));
const options = ref([
  {
    value: "jack",
    label: "Jack",
  },
  {
    value: "lucy",
    label: "Lucy",
  },
  {
    value: "tom",
    label: "Tom",
  },
]);
const handleChange = (value) => {
  console.log(`selected ${value}`);
};
const handleBlur = () => {
  console.log("blur");
};
const handleFocus = () => {
  console.log("focus");
};
const filterOption = (input, option) => {
  return option.value.toLowerCase().indexOf(input.toLowerCase()) >= 0;
};
const value = ref(undefined);
const value5 = ref(dayjs("2015/01/01", dateFormat));
const value6 = ref(dayjs());
const customFormat = (value) => `custom format: ${value.format(dateFormat)}`;
const refVForm = ref();
const privacyPolicies = ref(true);

// Router
const route = useRoute();
const router = useRouter();
const onSubmit = () => {
  refVForm.value?.validate().then(({ valid: isValid }) => {
    if (isValid) register();
  });
};
// Ability
const ability = useAppAbility();

// Form Errors
const errors = ref({
  email: undefined,
  password: undefined,
});

const imageVariant = useGenerateImageVariant(
  authV2RegisterIllustrationLight,
  authV2RegisterIllustrationDark,
  authV2RegisterIllustrationBorderedLight,
  authV2RegisterIllustrationBorderedDark,
  true
);
const authThemeMask = useGenerateImageVariant(authV2MaskLight, authV2MaskDark);
const isPasswordVisible = ref(false);
</script>

<template>
  <a-space direction="vertical" :size="12"> </a-space>
  <VRow no-gutters class="auth-wrapper bg-surface">
    <VCol lg="8" class="d-none d-lg-flex">
      <div class="position-relative bg-background rounded-lg w-100 ma-8 me-0">
        <div class="d-flex align-center justify-center w-100 h-100">
          <VImg
            max-width="441"
            :src="imageVariant"
            class="auth-illustration mt-16 mb-2"
          />
        </div>

        <VImg class="auth-footer-mask" :src="authThemeMask" />
      </div>
    </VCol>

    <VCol cols="12" lg="4" class="d-flex align-center justify-center">
      <VCard flat :max-width="500" class="mt-12 mt-sm-0 pa-4">
        <VCardText>
          <VRow>
            <VCol cols="1">
              <VNodeRenderer :nodes="themeConfig.app.logo" class="mb-6" />
            </VCol>
            <VCol>
              <h5 class="text-h5 mb-1 ml-2">Print Manager</h5>
            </VCol>
          </VRow>
        </VCardText>

        <VCardText>
          <VForm ref="refVForm" @submit.prevent="onSubmit">
            <VRow>
              <!-- Username -->
              <VCol cols="12">
                <AppTextField
                  v-model="inputRegister.Username"
                  autofocus
                  :rules="[requiredValidator, usernameValidator]"
                  label="Username"
                />
              </VCol>
              <VCol cols="12">
                <a-label class="label-date-birth">Date of birth</a-label>
                <!-- <AppDatePicKer v-model="hgsdhdhd"></AppDatePicKer> -->
                <AppDateTimePicker
                  v-model="inputRegister.DateOfBirth"
                  :rules="[requiredValidator]"
                  :format="dateFormat"
                  class="date-picker-input"
                />
              </VCol>

              <!-- email -->
              <VCol cols="12">
                <AppTextField
                  v-model="inputRegister.Email"
                  :rules="[requiredValidator, emailValidator]"
                  label="Email"
                  type="email"
                />
              </VCol>
              <VCol cols="12">
                <AppTextField
                  v-model="inputRegister.FullName"
                  :rules="[requiredValidator]"
                  label="Full Name"
                  type="text"
                />
              </VCol>
              <VCol cols="12">
                <AppTextField
                  v-model="inputRegister.PhoneNumber"
                  :rules="[requiredValidator, phoneNumberValidator]"
                  label="Phone number"
                  type="text"
                />
              </VCol>
              <!-- password -->
              <VCol cols="12">
                <AppTextField
                  class="mb-5"
                  v-model="inputRegister.Password"
                  :rules="[requiredValidator]"
                  label="Password"
                  :type="isPasswordVisible ? 'text' : 'password'"
                  :append-inner-icon="
                    isPasswordVisible ? 'tabler-eye-off' : 'tabler-eye'
                  "
                  @click:append-inner="isPasswordVisible = !isPasswordVisible"
                />
                <a-label class="sex"> Gender </a-label>
                <v-select
                  class="select-ant"
                  ref="select"
                  :rules="[requiredValidator]"
                  v-model="inputRegister.Gender"
                  :items="items"
                >
                </v-select>
                <div class="d-flex align-center mt-2 mb-4">
                  <VCheckbox
                    id="privacy-policy"
                    v-model="privacyPolicies"
                    :rules="[requiredValidator]"
                    inline
                  >
                    <template #label>
                      <span class="me-1">
                        I agree to
                        <a href="javascript:void(0)" class="text-primary"
                          >privacy policy & terms of Print Manage</a
                        >
                      </span>
                    </template>
                  </VCheckbox>
                </div>

                <VBtn block type="submit" @click="Register"> Sign up </VBtn>
              </VCol>

              <!-- create account -->
              <VCol cols="12" class="text-center text-base">
                <span>Already have an account?</span>
                <RouterLink class="text-primary ms-2" :to="{ name: 'login' }">
                  Sign in instead
                </RouterLink>
              </VCol>

              <VCol cols="12" class="d-flex align-center">
                <VDivider />
                <span class="mx-4">or</span>
                <VDivider />
              </VCol>

              <!-- auth providers -->
              <VCol cols="12" class="text-center">
                <AuthProvider />
              </VCol>
            </VRow>
          </VForm>
        </VCardText>
      </VCard>
    </VCol>
  </VRow>
  <v-snackbar v-model="snackbar" color="blue-grey" rounded="pill" class="mb-5">
    {{ text }}
    <template v-slot:actions>
      <v-btn color="green" variant="text" @click="snackbar = false">
        Đóng
      </v-btn>
    </template>
    <!-- <template v-slot:activator="{ props }">
        <v-btn class="ma-2" color="blue-grey" rounded="pill" v-bind="props">open</v-btn>
      </template> -->
  </v-snackbar>
</template>
<script>
import { authApi } from "../api/Auth/authApi";
import { format } from "date-fns";
import { useRouter } from "vue-router";
export default {
  data() {
    return {
      authApi: authApi(),
      router: useRouter(),
      text: "",
      snackbar: false,
      items: ["Male", "Female", "UnKnown"],
      inputRegister: {
        Username: "",
        Email: "",
        Password: "",
        FullName: "",
        PhoneNumber: "",
        DateOfBirth: "",
        Gender: "",
      },
    };
  },
  computed: {
    dateFormat: "yyyy-MM-dd",
  },
  methods: {
    async Register() {
      const result = await this.authApi.register(this.inputRegister);
      // this.router.push();
      console.log("Vào đây rồi nhe");
      console.log(result);
      console.log(result.data.status);
      console.log(result.data.message);
      if (result && result.data.status === 200) {
        this.text = result.data.message;
        this.snackbar = true;
        setTimeout(() => {
          this.reloadPage();
        }, 1500);
        this.router.push();
      } else if (result && result.data.status === 400) {
        this.text = result.data.message;
        this.snackbar = true;
      } else {
        this.text = "Registration failed";
        this.snackbar = true;
      }
    },
    reloadPage() {
      location.reload();
    },
  },
};
</script>
<style lang="scss" scoped>
@use "@core/scss/template/pages/page-auth.scss";
.date-picker-input {
  width: 100%;
  background-color: rgb(47, 51, 73);
  border: 1px solid rgb(87 90 115);

  height: 40px;
}
.date-picker-input input {
  color: white;
}
.label-date-birth {
  // margin: 10px 0px px 0px;
  font-size: 13px;
}
.select-ant {
  width: 100% !important;
  background-color: rgb(47, 51, 73) !important;
  margin: 5px 0px 0px 0px;
  height: 40px;
}
.sex {
  font-size: 13px;
}
.ant-select-selector {
  background-color: rgb(47, 51, 73);
}
.ant-picker-input {
  color: #8d8ca8;
}
.ant-picker-suffix {
  color: #8d8ca8 !important;
}
</style>
<route lang="yaml">
meta:
  layout: blank
  action: read
  subject: Auth
  redirectIfLoggedIn: true
</route>
