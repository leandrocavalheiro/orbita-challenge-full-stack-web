import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'

Vue.config.productionTip = false
Vue.prototype.$showAlert =  function(typeAlert, message){  
  this.$store.commit('change', {'alert': true, 'typeAlert': typeAlert,'message': message})
  this.$hideAlert()
}
Vue.prototype.$hideAlert =  function(){  
  setTimeout(() => {
    this.$store.commit('change', {'alert': false, 'typeAlert': 'success', 'message': ''})
  }, 5000)
}

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
},
).$mount('#app')