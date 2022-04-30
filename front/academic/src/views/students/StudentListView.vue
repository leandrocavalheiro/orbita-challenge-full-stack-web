<template>
     <div style="margin-top:35px;">
        <BaseTable 
            :header_list="headers" 
            :service="service" 
            :title="title" 
            :entity="entity"
        /> 
    </div>
</template>
<script>
    import BaseTable from '../../components/BaseTable.vue'
    import StudentService from '@/services/student';
    export default {
        components: {
            BaseTable
        },
        data() {
            return {    
                alert: true,
                type_alert: "success",
                message_alert: "",
                service: StudentService,
                title: 'Alunos',
                entity: 'student',                        
                headers:[                                    
                            {text: 'Código', align: 'start', sortable: true, value: 'code'},
                            { text: 'Nome', value: 'name', sortable: true},
                            { text: 'E-Mail', value: 'email', sortable: false },
                            { text: 'R.A.', value: 'ra', sortable: false },
                            { text: 'C.P.F', value: 'cpf', sortable: false },
                            { text: 'Ações', value: 'actions', sortable: false }
                        ]
            }
        },
        methods: {
          show_alert(type, message){
            this.alert = true
            this.type_alert = type
            this.message_alert = message
          }
        },
        watch: {
          alert(new_val){
            if(new_val){
              setTimeout(()=>{this.alert=false},3000)
            }
          }  
        }
        
    }    
</script>