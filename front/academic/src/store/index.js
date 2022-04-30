import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    alert: false,
    type_alert: 'success',
    message_alert: 'Sucesso'
  },
  mutations: {
    change(state, {alert, type_alert, message}) {
      state.alert = alert
      state.type_alert = type_alert
      state.message_alert = message
    }
  },
  getters: {
    alert: state => state.alert,
    type_alert: state => state.type_alert,
    message_alert: state => state.message_alert
  }
})