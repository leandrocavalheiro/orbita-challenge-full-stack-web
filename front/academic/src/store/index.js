import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    alert: false,
    typeAlert: 'success',
    messageAlert: 'Sucesso'
  },
  mutations: {
    change(state, {alert, typeAlert, message}) {
      state.alert = alert
      state.typeAlert = typeAlert
      state.messageAlert = message
    }
  },
  getters: {
    alert: state => state.alert,
    typeAlert: state => state.typeAlert,
    messageAlert: state => state.messageAlert
  }
})