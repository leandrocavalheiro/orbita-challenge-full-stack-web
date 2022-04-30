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
                        @keypress.enter="load_data(current_page, search, sortBy, sortDesc)"
                        single-line
                        hide-details
                    />
                    <v-spacer/>

                    <v-btn
                        color="primary"
                        dark class="mb-2"
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
                                    color="blue darken-1"
                                    text
                                    @click="closeDelete"
                                >
                                    Cancelar
                                </v-btn>
                                <v-btn
                                    color="blue darken-1"
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
        <v-alert
            dismissible
            shaped
            :type="$store.getters.type_alert"
            :value="$store.getters.alert"
        >
            {{$store.getters.message_alert}}
        </v-alert>            
            <v-pagination 
                v-model="current_page" 
                :length="total_page" 
                @change="load_data" 
                circle
            />
        </div>
    </div>
</template>

<script>  
    
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
            async initialize() {
                await this.load_data(this.current_page)
                this.entity_name = this.entity
                this.$store.commit('action_change', 'list')                
            },

            async load_data(page, filter = "") {                                
                this.loading = true
                const response = await this.service.getAll(page, this.items_per_page, filter, this.sortBy, this.sortDesc)
                this.total_page = response.data.totalPages
                this.data_list = response.data.items
                this.loading = false
            },

            async custom_sort() {
                await this.load_data(this.current_page, this.search)
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
                this.closeDelete(await this.service.delete(this.editedItem.id));
                this.initialize();
            },

            async closeDelete(status) {      
                this.dialogDelete = false;
                if(status == 204)
                    await this.initialize();
            },        
        },

        watch: {
            options(){
                this.load_data(this.current_page);
            },

            current_page(page){
                this.load_data(page);
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