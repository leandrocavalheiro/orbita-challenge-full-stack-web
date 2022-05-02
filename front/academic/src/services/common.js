export default{
    get_message_from_response(response, entity_name= 'Registro', action = 'cadastrado') {
        let messages = []
        switch (response.status) {
            case 200:
            case 201:
            case 204:
                messages[messages.length] = entity_name + ' ' +  action + ' com sucesso!'
                break;
            case 400:
                if(Array.isArray(response.data))
                    messages[messages.length] = "Oops algo inesperado aconteceu!"
                else
                    response.data.error.forEach(element => {
                        messages[messages.length] = element.message
                });                
                break;                
            case 500:
                messages[messages.length] = "Oops algo inesperado aconteceu!"
                break;
          }
          return messages;
    },
}