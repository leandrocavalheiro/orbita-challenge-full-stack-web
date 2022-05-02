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
        slot="progress"
    >
        <v-progress-linear 
            color="grey darken-2" 
            height="10" 
            indeterminate 
        />
    </template>

    <v-card-title>
        Editar Aluno
    </v-card-title>

      <v-card-text>      
        <v-form id="edit-student">
          <v-container>
            <v-row>
              <v-col cols="4" xs="12" >
                <v-text-field v-model="student.code" label="Código" required disabled />
              </v-col>

              <v-col cols="4" xs="12" >
                <v-text-field v-model="student.ra" label="R.A." required disabled />
              </v-col>   

              <v-col cols="4" xs="12" >                                
                <v-text-field v-model="student.cpf" label="C.P.F."  return-masked-value mask="'(###) ###-####'" required disabled />                
              </v-col>

              <v-col cols="12">
                <v-text-field v-model="student.name" label="Nome" required autofocus/>
              </v-col>
              
              <v-col cols="12">
                <v-text-field v-model="student.email" label="Email" required />
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
  import student_service from '@/services/student'
  import common_service from '@/services/common'

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
        const response = await student_service.put(this.student.id, JSON.stringify(this.student));
        const message = common_service.get_message_from_response(response, 'Aluno', 'atualizado');
        this.show_message(response.status, message)
        this.close()
      },

      show_message(status, message){
        if(status == 200 || status == 201)
          this.$show_alert('success', message)
        else
          this.$show_alert('error', message)          
      }
    },
    async created() {      
      this.student = (await student_service.get_by_id(this.$route.params.id)).data;
    },    
  }
</script>