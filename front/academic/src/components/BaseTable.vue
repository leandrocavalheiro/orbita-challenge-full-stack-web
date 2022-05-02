<template>
    <div>
        <v-data-table 
            :headers="header_list" 
            :items="data_list" 
            hide-default-footer
            :sort-desc.sync="sortDesc"
            :sort-by.sync="sortBy"                        
            :options.sync="options"
            :loading="loading"
            loading-text="Carregando dados..."                        
            class="elevation-1" 
        >
            <template v-slot:top>        
                <v-toolbar flat>
                    <v-toolbar-title>{{ title }}</v-toolbar-title>          
                    <v-spacer/>
                    <v-text-field 
                        v-model="search"
                        append-icon="mdi-magnify"
                        label="Pesquisar"
                        @keypress.enter="load_data(1, search, sortBy, sortDesc)"
                        single-line
                        hide-details
                    />
                    <v-spacer/>

                    <v-btn                        
                        text
                        @click="addEntity"
                    >
                        Novo
                    </v-btn>

                    <v-dialog 
                        v-model="dialogDelete" 
                        max-width="800px">
                        <v-card>
                            <v-card-title class="text-h5">
                                Tem certeza que deseja remover o aluno {{editedItem.name}}?
                            </v-card-title>
                            <v-card-actions>
                                <v-spacer/>
                                <v-btn
                                    text
                                    @click="closeDelete"
                                >
                                    Cancelar
                                </v-btn>
                                <v-btn
                                    text
                                    @click="deleteEntityConfirm"
                                >
                                        OK
                                </v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                </v-toolbar>
            </template>

            <template v-slot:[`item.actions`]="{ item }">
                <v-icon small class="mr-2" @click="editEntity(item)"> mdi-pencil </v-icon>
                <v-icon small @click="deleteEntity(item)"> mdi-delete </v-icon>
            </template>
            <template slot="no-data">
                <p>Nenhum {{title}} cadastrado.</p>
            </template>             
        </v-data-table>
        <br>
        <div style="display: flex; justify-content: right">          
            <v-pagination 
                v-model="current_page" 
                :length="total_page" 
                @change="load_data" 
                color="grey darken-2"
                circle
            />
        </div>
        <v-alert
            dismissible
            shaped
            :type="$store.getters.type_alert"
            :value="$store.getters.alert"
            transition="scale-transition"
        >
            {{$store.getters.message_alert}}
        </v-alert>          
    </div>
</template>

<script>  
    import common_service from '@/services/common'
    export default {
        data: () => ({                                    
            loading: false,
            options: {},
            entity_name: "",
            current_page: 1,
            total_page: 1,
            items_per_page: 2,      
            data_list: [],
            dialogDelete: false,        
            search: null,
            sortBy: "code",
            sortDesc: false,
            editedItem: {
                id: null,
                code: 0,
                name: "",
                email: "",
                ra: 0,
                cpf: ""
            },
            defaultItem: {
                id: null,
                code: 0,
                name: "",
                email: "",
                ra: 0,
                cpf: ""
            },
        }),

        props: {
            header_list: {
                type: Array,
                required: true
            },
            service: {
                type: Object,
                required: true
            },
            common_service: {
                type: Object,
                required: true
            },            
            title: {
                type: String,
                required: true
            },
            entity: {
                type: String,
                required: true
            }
        },
                    
        methods: {
            get_orderBy(){
                var orderBy =  this.options.sortBy;                
                if(orderBy == null || orderBy.length === 0)
                    orderBy = this.sortBy
                return orderBy
            },
            get_orderDesc(){
                var orderDesc =  this.options.sortDesc;
                if(orderDesc == null || orderDesc.length === 0)
                    orderDesc = !this.sortDesc
                return orderDesc
            },            
            async initialize() {
                await this.load_data(this.current_page, this.search)
                this.entity_name = this.entity                
            },

            async load_data(page, filter = "") {                                
                this.loading = true
                const response = await this.service.get_all(page, this.items_per_page, filter,  this.get_orderBy(), this.get_orderDesc())                
                if(response.status == 200)
                {
                    this.total_page = response.data.totalPages
                    this.data_list = response.data.items
                } 
                else {
                    this.total_page = 1
                    this.data_list = []
                    this.$show_alert('error',  this.common_service.get_message_from_response(response, 'Aluno', 'listado'))
                }                
                this.loading = false
            },
            editEntity(item) {
                this.$router.push({ name: 'edit-' + this.entity_name, params:{id:item.id}});
            },

            addEntity() {
                this.$router.push({ name: 'add-' + this.entity_name});
            },

            deleteEntity(item) {
                this.editedItem = item;
                this.dialogDelete = true;
            },

            async deleteEntityConfirm() {                
                var response = await this.service.delete(this.editedItem.id)
                const message = common_service.get_message_from_response(response, 'Aluno', 'deletado');
                this.show_message(response.status, message)
                this.closeDelete(response.status)
            },

            async closeDelete(status) {      
                this.dialogDelete = false;
                if(status == 204)
                    await this.initialize();
            },
            show_message(status, message){
                if(status == 200 || status == 201 || status == 204)
                    this.$show_alert('success', message)
                else {
                    
                    this.$show_alert('error', message)          
                }
            }                    
        },

        watch: {
            options(){
                this.load_data(this.current_page);
            },

            current_page(page){
                this.load_data(page, this.search);
            },             
            dialogDelete(val) {
                val || this.closeDelete();
            },
        },
    
        async created() {
            await this.initialize();
        },
    };
</script>