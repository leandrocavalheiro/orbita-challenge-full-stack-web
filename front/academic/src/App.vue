<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" app>
      <v-list-item>
        <v-list-item-content>
        <v-img
          max-height="150"
          max-width="250"
          src="../src/assets/logo.png"
        ></v-img>          
          <v-list-item-title class="text-h6 text-center" :style="{'align-items':'center'}">
            Módulo Acadêmico
          </v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <v-list dense nav>
        <v-list-item 
            v-for="item in items" 
            :key="item.title" 
            :to="item.to" link>
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
      <v-app-bar-nav-icon 
        @click="drawer = !drawer"
      >
      </v-app-bar-nav-icon>
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
  }
</script>