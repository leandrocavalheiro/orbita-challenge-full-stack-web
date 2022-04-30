<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" app>
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            Grupo A
          </v-list-item-title>
          <v-list-item-subtitle>
            Módulo Acadêmico
          </v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <v-list dense nav>
        <v-list-item v-for="item in items" :key="item.title" :to="item.to" link>
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>    

    <v-app-bar app>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    </v-app-bar>

    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script>
  export default {
    data: () => ({      
      drawer: null,
      items: [
          { title: 'Alunos', icon: 'mdi-account', to:'/students' },
          { title: 'Sobre', icon: 'mdi-help-box', to:'/about'  },
        ],
    }),
    methods: {
      teste()
      {
        console.log(this.$parent.alert)
      }
    },
    created(){
      this.teste()
    }

  }
</script>