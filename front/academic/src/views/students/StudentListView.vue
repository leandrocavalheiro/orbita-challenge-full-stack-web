<template>
     <div style="margin-top:35px;">
        <BaseTable 
            :headerList="headers" 
            :service="service"
            :commonService="commonService" 
            :title="title" 
            :entity="entity"
        /> 
    </div>
</template>
<script>
    import BaseTable from '../../components/BaseTable.vue'
    import studentService from '@/services/student';
    import commonService from '@/services/common';
    export default {
        components: {
            BaseTable
        },
        data() {
            return {    
                service: studentService,
                commonService: commonService,
                title: 'Aluno',
                entity: 'student',                        
                headers:[                                    
                            {text: 'Código', align: 'start', sortable: true, value: 'code'},
                            { text: 'Nome', value: 'name', sortable: true},
                            { text: 'E-Mail', value: 'email', sortable: true },
                            { text: 'R.A.', value: 'ra', sortable: true },
                            { text: 'C.P.F', value: 'cpf', sortable: true },
                            { text: 'Ações', value: 'actions', sortable: false }
                        ]
            }
        }        
    }    
</script>