<template>
  <v-row 
    align="center"
    justify="center"
  >
    <v-card 
      :loading="loading"
      class="my-16"
      max-width="1200"
      elevation="12"
      outlined
      shaped      
    >
      <template 
        slot="progress">
        <v-progress-linear 
          color="deep-purple" 
          height="10" 
          indeterminate 
      />
      </template>

      <v-card-title>Cadastrar Aluno</v-card-title>

      <v-card-text>      
        <v-form id="edit-student">
          <v-container>
            <v-row>
              <v-col cols="4" xs="12" >
                <v-text-field v-model="student.code" label="Código" required disabled />
              </v-col>

              <v-col cols="4" xs="12" >
                <v-text-field v-model="student.ra" label="R.A." required autofocus/>
              </v-col>   

              <v-col cols="4" xs="12" >
                <v-text-field v-model="student.cpf" label="C.P.F." required/>
              </v-col>

              <v-col cols="12">
                <v-text-field v-model="student.name" label="Nome" required />
              </v-col>

              <v-col cols="12">
                <v-text-field v-model="student.email" label="Email"/>
              </v-col>
            </v-row>
          </v-container>
        </v-form>      
      </v-card-text>
        
      <v-card-actions>
        <v-spacer/>
        <v-btn text @click="close">
          Cancelar
        </v-btn>
        <v-btn text @click="save">
          Salvar
        </v-btn>      
      </v-card-actions>
    </v-card>
  </v-row>  
</template>

<script>
  import StudentService from '@/services/student';
  export default {

    data: () => ({
      student: {
        id: null,
        code: 0,
        name: "",
        email: "",
        ra: 0,
        cpf: "",
      },
      loading: false,
      selection: 1,
    }),
    props: ["item"],
    methods: {
      close () {
        this.$router.push({ name: 'students'})
      },
      async save () {
        await StudentService.post(JSON.stringify(this.student));
        this.close()
      },      
    },
  }
</script>