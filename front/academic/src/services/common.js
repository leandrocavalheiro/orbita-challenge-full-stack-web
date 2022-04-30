export default{
    get_message_from_response(response, entity_name= 'Registro', action = 'cadastrado') {
        switch (response.status) {
            case 200:
            case 201:
                return entity_name + ' ' +  action + ' com sucesso!'
            case 400:
                return response.data.message
            case 500:
                return 'Erro Interno.'
          }
    },
}