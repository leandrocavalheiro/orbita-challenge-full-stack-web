import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import { VueMaskDirective } from 'v-mask'


Vue.directive('mask', VueMaskDirective);
Vue.config.productionTip = false
Vue.prototype.$show_alert =  function(type_alert, message){  
  this.$store.commit('change', {'alert': true, 'type_alert': type_alert,'message': message})
  this.$hide_alert()
}
Vue.prototype.$hide_alert =  function(){  
  setTimeout(() => {
    this.$store.commit('change', {'alert': false, 'type_alert': 'success', 'message': ''})
  }, 5000)
}

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
},
).$mount('#app')