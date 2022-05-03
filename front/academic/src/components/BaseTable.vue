<template>
    <div>
        <v-data-table 
            :headers="headerList" 
            :items="dataList" 
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
                        @keypress.enter="loadData(1, search, sortBy, sortDesc)"
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
                <v-icon 
                    small 
                    class="mr-2"
                    @click="editEntity(item)"
                > 
                    mdi-pencil 
                </v-icon>
                <v-icon 
                    small 
                    @click="deleteEntity(item)"
                > 
                    mdi-delete
                </v-icon>
            </template>
            <template slot="no-data">
                <p>Nenhum {{title}} cadastrado.</p>
            </template>             
        </v-data-table>
        <br>
        <div style="display: flex; justify-content: right">          
            <v-pagination 
                v-model="currentPage" 
                :length="totalPage" 
                @change="loadData" 
                color="grey darken-2"
                circle
            />
        </div>
        <v-alert
            dismissible
            shaped
            :type="$store.getters.typeAlert"
            :value="$store.getters.alert"
            transition="scale-transition"
        >
            {{$store.getters.messageAlert}}
        </v-alert>          
    </div>
</template>

<script>  
    import commonService from '@/services/common'
    export default {
        data: () => ({                                    
            loading: false,
            options: {},
            entityName: "",
            currentPage: 1,
            totalPage: 1,
            itensPerPage: 2,      
            dataList: [],
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
            }            
        }),

        props: {
            headerList: {
                type: Array,
                required: true
            },
            service: {
                type: Object,
                required: true
            },
            commonService: {
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

            getOrderBy(){
                var orderBy =  this.options.sortBy;
                if(orderBy == null || orderBy.length === 0)
                    orderBy = this.sortBy
                return orderBy
            },

            getOrderDesc(){
                var orderDesc =  this.options.sortDesc;
                if(orderDesc == null || orderDesc.length === 0)
                    orderDesc = !this.sortDesc
                return orderDesc
            },

            async initialize() {
                await this.loadData(this.currentPage, this.search)
                this.entityName = this.entity                
            },

            async loadData(page, filter = "") {                                
                this.loading = true
                const response = await this.service.getAll(page, this.itensPerPage, filter,  this.getOrderBy(), this.getOrderDesc())
                if(response.status == 200){
                    response.data.items.forEach(element => {
                        element.cpf =  commonService.formatCpf(element.cpf)
                    });
                    this.totalPage = response.data.totalPages
                    this.dataList = response.data.items
                }
                else {
                    this.totalPage = 1
                    this.dataList = []
                    let message = this.commonService.getMessageFromResponse(response, this.title, 'listado')
                    if(message.length > 0)
                        this.$showAlert('error',  this.commonService.getMessageFromResponse(response, this.title, 'listado'))
                }                
                this.loading = false
            },
            editEntity(item) {  
                this.service.callRoute(this.$router, 'edit', item.id)
            },

            addEntity() {
               this.service.callRoute(this.$router, 'add')
            },

            deleteEntity(item) {
                this.editedItem = item;
                this.dialogDelete = true;
            },

            async deleteEntityConfirm() {                
                var response = await this.service.delete(this.editedItem.id)                
                this.showMessage(response.status, commonService.getMessageFromResponse(response, this.title, 'deletado'))
                this.closeDelete(response.status)
            },

            async closeDelete(status) {
                this.dialogDelete = false;
                if(status == 204)
                    await this.initialize();
            },
            showMessage(status, message){
                if(status == 200 || status == 201 || status == 204)
                    this.$showAlert('success', message)
                else                    
                    this.$showAlert('error', message)
            }                    
        },

        watch: {
            options(){
                this.loadData(this.currentPage);
            },

            currentPage(page){
                this.loadData(page, this.search);
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