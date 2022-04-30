import {http} from '../services/config'
const headers = { 
    "content-type": "application/json",
    "Accept": "application/json"
}
const endpointName = 'students'

export default{
    async getAll(page, pageSize, filter, sortBy = "code", sortDesc = false) {
        if(filter === null)
            filter = ""
        return await http.get('/' + endpointName + '?page=' + page + '&pageSize=' + pageSize + '&filter=' + filter + '&sortBy' + sortBy + '&sortDesc=' + sortDesc)
    },

    async getById(id) {
        return await http.get('/' + endpointName + '/' + id)
    },
    
    async post (data) {                
        return await await http.post('/' + endpointName, data, {headers})
    },

    async put(id, data) {        
        return await http.put( '/' + endpointName + '/' + id, data, {headers});
    },

    async delete(id) {                
        return await http.delete('/' + endpointName + '/' + id);
    },
    
    async get_message(response) {                
        return response.data.error.message;
    },    
}