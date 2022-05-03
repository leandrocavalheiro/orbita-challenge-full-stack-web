import {http} from '../services/config'

const headers = { 
    "content-type": "application/json",
    "Accept": "application/json"
}
const endpointName = 'students'
const entityName = 'student'

export default{
    async getAll(page, pageSize, filter, sortBy = "code", sortDesc = false) {

        if(filter === null)
            filter = ""

        let apiResponse = null
        await http.get('/' + endpointName + '?page=' + page + '&pageSize=' + pageSize + '&filter=' + filter + '&sortBy=' + sortBy + '&sortDesc=' + sortDesc)
                    .then(function (response) {
                        apiResponse = response
                    })
                    .catch(function (error) {
                        apiResponse = error.response
                    });      
        return apiResponse  
    },

    async getById(id) {
        let apiResponse = null
        await  http.get('/' + endpointName + '/' + id)
                    .then(function (response) {
                        apiResponse = response
                    })
                    .catch(function (error) {
                        apiResponse = error.response
                    });      
        return apiResponse  
    },
    
    async post (data) {
        let apiResponse = null
        await http.post('/' + endpointName, data, {headers})
                    .then(function (response) {
                        apiResponse = response
                    })
                    .catch(function (error) {
                        apiResponse = error.response
                    });    
        return apiResponse
    },

    async put(id, data) {                
        let apiResponse = null
        await http.put( '/' + endpointName + '/' + id, data, {headers})
                    .then(function (response) {
                        apiResponse = response
                    })
                    .catch(function (error) {
                        apiResponse = error.response
                    });      
        return apiResponse        
    },

    async delete(id) {                
        let apiResponse = null
        await http.delete('/' + endpointName + '/' + id)
                    .then(function (response) {
                        apiResponse = response
                    })
                    .catch(function (error) {
                        apiResponse = error.response
                    });      
        return apiResponse           
    },
    callRoute(routerObj, action, id) {
        switch(action){
            case 'edit':
                routerObj.push({ name: `edit-${entityName}`, params:{id:id}});
                break;
            case 'add':
                routerObj.push({ name: `add-${entityName}`});
                break;
            default:
                routerObj.push({ name: 'students'});
                break;                
        }
    }

}