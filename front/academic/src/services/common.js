export default{
    getMessageFromResponse(response, entityName='Registro', action='cadastrado') {
        let message = ''
        switch (response.status) {
            case 200:
            case 201:
            case 204:
                message = `${entityName}  ${action} com sucesso!`
                break;
            case 400:
                if(Array.isArray(response.data) || !Array.isArray(response.data.error))
                    message = "Oops algo inesperado aconteceu!"
                else
                    message = response.data.error[0].message
                break;
            case 500:
                message = "Oops algo inesperado aconteceu!"
                break;
          }
          return message;
    },
    formatCpf(value){
        return value.replace(/\D/g,"")
                    .replace(/(\d{3})(\d)/,"$1.$2")        
                    .replace(/(\d{3})(\d)/,"$1.$2")                                                 
                    .replace(/(\d{3})(\d{1,2})$/,"$1-$2")
    }    
}