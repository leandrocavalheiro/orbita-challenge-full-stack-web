<template>
     <div style="margin-top:35px;">
        <BaseTable 
            :header_list="headers" 
            :service="service"
            :common_service="common_service" 
            :title="title" 
            :entity="entity"
        /> 
    </div>
</template>
<script>
    import BaseTable from '../../components/BaseTable.vue'
    import student_service from '@/services/student';
    import common_service from '@/services/common';
    export default {
        components: {
            BaseTable
        },
        data() {
            return {    
                service: student_service,
                common_service: common_service,
                title: 'Alunos',
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