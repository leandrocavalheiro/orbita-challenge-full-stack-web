import {http} from '../services/config'
const headers = { 
    "content-type": "application/json",
    "Accept": "application/json"
}
const endpointName = 'students'

export default{
    async get_all(page, pageSize, filter, sortBy = "code", sortDesc = false) {

        if(filter === null)
            filter = ""

        let api_response = null
        await http.get('/' + endpointName + '?page=' + page + '&pageSize=' + pageSize + '&filter=' + filter + '&sortBy=' + sortBy + '&sortDesc=' + sortDesc)
        .then(function (response) {
            api_response = response
        })
        .catch(function (error) {
            api_response = error.response
        });      
        return api_response  
    },

    async get_by_id(id) {
        let api_response = null
        await  http.get('/' + endpointName + '/' + id)
        .then(function (response) {
            api_response = response
        })
        .catch(function (error) {
            api_response = error.response
        });      
        return api_response  
    },
    
    async post (data) {
        let api_response = null
        await http.post('/' + endpointName, data, {headers})
        .then(function (response) {
            api_response = response
        })
        .catch(function (error) {
            api_response = error.response
        });    
        console.log(api_response)    
        return api_response
    },

    async put(id, data) {                
        let api_response = null
        await http.put( '/' + endpointName + '/' + id, data, {headers})
        .then(function (response) {
            api_response = response
        })
        .catch(function (error) {
            api_response = error.response
        });      
        return api_response        
    },

    async delete(id) {                
        let api_response = null
        await http.delete('/' + endpointName + '/' + id)
        .then(function (response) {
            api_response = response
        })
        .catch(function (error) {
            api_response = error.response
        });      
        return api_response           
    }      
}