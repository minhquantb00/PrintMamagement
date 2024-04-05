/* eslint-disable import/order */
import '@/@fake-db/db'
import '@/@iconify/icons-bundle'
import App from '@/App.vue'
import ability from '@/plugins/casl/ability'
import i18n from '@/plugins/i18n'
import layoutsPlugin from '@/plugins/layouts'
import vuetify from '@/plugins/vuetify'
import { loadFonts } from '@/plugins/webfontloader'
import router from '@/router'
import { abilitiesPlugin } from '@casl/vue'
import '@core/scss/template/index.scss'
import '@styles/styles.scss'
import { createPinia } from 'pinia'
import { createApp } from 'vue'
import {DatePicker} from'ant-design-vue'
import {Select} from'ant-design-vue'
import {Button} from'ant-design-vue'
import {Layout} from'ant-design-vue'
import {Divider} from'ant-design-vue'
import {Flex} from'ant-design-vue'
import {Grid} from'ant-design-vue'
import {Segmented} from'ant-design-vue'
import {Statistic} from'ant-design-vue'
import {Table} from'ant-design-vue'
import {Tabs} from'ant-design-vue'



loadFonts()


// Create vue app
const app = createApp(App)


// Use plugins
app.use(vuetify)
app.use(createPinia())
app.use(router)
app.use(DatePicker)
app.use(Button)
app.use(Layout)
app.use(Divider)
app.use(Flex)
app.use(Grid)
app.use(Segmented)
app.use(Statistic)
app.use(Table)
app.use(Tabs)
app.use(Select)
app.use(i18n)
app.use(abilitiesPlugin, ability, {
  useGlobalProperties: true,
})

// Mount vue app
app.mount('#app')
