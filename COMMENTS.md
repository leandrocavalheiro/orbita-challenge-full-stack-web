# Como executar o projeto Academic

## 1. Clonei o projeto e por onde eu começo?

### 1.1. Pré-requisitos
#### 1.1.1 Backend
- .Net Core 6
- Docker
- Docker-Compose
- Ef Core Tools
	- `dotnet tool install --global dotnet-ef`
#### 1.1.2 Frontend
- NodeJS ( >= 14.19.1)
- Vue 2

### 1.2. Inicializando o backend
#### 1.2.1 Inicializando o banco de dados
O Academic utiliza o Postgresql como banco de dados, portanto vamos roda-lo em um container docker.

Executar o comando `docker-compose up -d` na raiz do projeto.

Se o comando for executado com sucesso deve subir o Postgresql (postgres:14.2-alpine) na porta 7432.
- Configura completa em Solutions Items > docker-compose.yml

***O projeto backend fica dentro da pasta 'back'

#### 1.2.2 Executando as migrações do projeto
- Caso não possua o(s) arquivo(s) de migração(ões) em: 'GrupoA.Academic.Infra.Data/Migrations'. Em um terminal digite:
  - `$ dotnet ef migrations add Initial --output-dir Migrations/PgSql/ --project GrupoA.Academic.Infra.Data`
- Após criar o arquivo de migração ou caso já exista o(s) arquivo(s) de migração(ões), vamos executa-la(s) para criar o banco e as tabelas. Em um terminal digite:
  - `$ dotnet ef database update --project GrupoA.Academic.Infra.Data`

#### 1.2.3 Executando o backend
Em um terminal, na pasta 'GrupoA.Academic.Api', executamos o seguinte comando:
- `$ dotnet run`

Para acessar a API, basta copiar o link abaixo e colar no navegador de sua preferência:
`http://localhost:5226/swagger` ou `https://localhost:7226/swagger`

### 1.3. Inicializando o frontend

***O projeto frontend fica dentro da pasta 'front'

#### 1.3.1 Executando o frontend
Em um terminal, na pasta 'academic', executamos o seguinte comando:
- `$ npm run serve`

Para acessar o Academic, basta copiar o link abaixo e colar no navegador de sua preferência:
`http://localhost:8080/`

# Especificações Técnicas

## 1. Backend
A escolha dos patterns da API ( DDD, CQRS, Repository, Unit of Work ) se deu por: além de serem amplamente utilizados na stack .net, também adicionam facilidades no desenvolvimento.
- Com DDD conseguimos isolar nosso domínio, definindo na camada 'domain' nossas entidades e nossas interfaces.
- Com CQRS separamos responsabilidades de leitura e gravação. Como tudo está separados em 'command', cada um tem uma resposabilidade bem definida, facilitando localização/correção de bugs.
Também por essa responsabilidade bem definida, facilita a implementação de eventos para processos que não se tem a necessidade de aguardar um retorno imediato.
- Com o Repository, escrevemos menos código e já temos o CRUD básico definido pelo repositório genérico. Assim temos que escrever apenas os métodos específicos de cada repositório, agilizando  a criação de CRUDS básicos.
- Com o Unit of Work, conseguimos injetar facilmente os repositórios nas outras camadas da aplicação. Em casos da aplicação crescer, podemos até criar "unidades de trabalho" por contexto, assim injetamos apenas os repositórios pertinentes ao contexto.

### 1.1 Pontos de Melhoria
- O filtro da entidade, pode ser melhorado para ficar mais performático.
- Algumas configurações em GrupoA.Academic.Api/Configurations, ficaram hard-code.
- As migrations, podem estar em um projeto, dentro da solution, assim conseguimos melhorar o versionamento das mesmas.
- Adicionar testes unitários

### 1.2 Bibliotecas de Terceiros
- Mediatr
- FluentValidtion
- Npgsql
- AutoMapper
- Swashbuckle ( Swagger )

## 2. Frontend
Com front, tem sido uma das minhas primeiras experiências, para a stack pedida escolhi o Vue 2 pela compatibilidade com o Vuetify.

### 1.1 Pontos de Melhoria
- Parti da ideia de componentizar algumas coisas, por tanto criei um componente BaseTable, para reuso, mas pode ser melhorado:
  - Melhorar como é renderizado, deixando as colunas sempre do mesmo tamanho quando mudamos a página.
- Os alerts, utilizei 'Store' para controlar a exibição e são exibidos em dois lugares: Na BaseTable e nos componentes de Add e Edit
  - Os em todos os lugares usam a mesma variável de controle, pode ser melhorado usando uma variável para cada tipo, assim se mostrar o alert dos componentes de Add/Edit ao fechar a tela antes do alert sumir, ele não ficará visível na tela de listagem.
- Ainda sobre os alerts, o backend, pode retornar várias mensagens de erro de uma vez, por exemplo na validação dos campos ao incluir um aluno, mas no front está exibindo apenas a primeira. Então poderia ser feito um tratamento melhor para exibir todas essas mensagens.
- Pode ser criado um service genérico para o Http ( Axios ), para a aplicação ficar mais limpa
- As configurações que estão hard-code, pode ser jogadas em variáveis na Store ou em algum outro serviço conforme necessidade de uso das mesmas.

### 1.1 Bibliotecas de Terceiros
- Axios
- Vuetify