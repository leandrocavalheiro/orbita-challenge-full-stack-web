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

      <v-card-title>
        Cadastrar Aluno
      </v-card-title>

      <v-card-text>      
        <v-form id="add-student">
          <v-container>
            <v-row>
              <v-col cols="6" xs="12" >
                <v-text-field 
                  v-model="student.ra" 
                  label="R.A." 
                  required 
                  autofocus
                />
              </v-col>   

              <v-col cols="6" xs="12" >
                <v-text-field 
                  v-model="student.cpf" 
                  label="C.P.F."
                  required
                  maxlength="14"
                  @input="formatCpf"
                />
              </v-col>

              <v-col cols="12">
                <v-text-field 
                  v-model="student.name" 
                  label="Nome" 
                  required                  
                />
              </v-col>

              <v-col cols="12">
                <v-text-field 
                  v-model="student.email" 
                  label="Email"
                />
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
        <v-alert
            dismissible
            shaped
            :type="$store.getters.typeAlert"
            :value="$store.getters.alert"
            transition="scale-transition"
        >
            {{$store.getters.messageAlert}}
        </v-alert>       
    </v-card>
  </v-row>  
</template>

<script>
  import studentService from '@/services/student';
  import commonService from '@/services/common'
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

      formatCpf(){
        this.student.cpf = commonService.formatCpf(this.student.cpf)
      },

      async save () {        
        var response = await studentService.post(JSON.stringify(this.student))                                                        
        const message = commonService.getMessageFromResponse(response, 'Aluno', 'cadastrado');
        this.showMessage(response.status, message)
        if (response.status == 201)
          this.close()
      },

      showMessage(status, message){
        if(status == 200 || status == 201)
          this.$showAlert('success', message)
        else          
          this.$showAlert('error', message)
      }      
    },
  }
</script>