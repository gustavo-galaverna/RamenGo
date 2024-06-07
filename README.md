# RamenGo

 RamenGo Api foi feita com o intuito de demonstrar minhas habilidades técnicas para a vaga de Software Engineer da Red Ventures.
 
 Para a construção escolhi usar .NET 8, em conjunto com as seguintes bibliotecas: 
 ```
 Microsoft.AspNetCore.Mvc.NewtonsoftJson
 Microsoft.EntityFrameworkCore.Design
 Microsoft.EntityFrameworkCore.Sqlite
 Microsoft.EntityFrameworkCore.Tools
 Swashbuckle.AspNetCore
 Microsoft.VisualStudio.Azure.Containers.Tools.Targets
```
 A solução é dividida em 4 camadas: 
 * **API:** Projeto destinado à execução da API propriamente.
 * **Application:** Regra de negócios com a implementações das interfaces.
 * **Data:** Onde são definidas as entidades, junto com o contexto para o banco de dados SQLite.
 * **Domain:** Projeto responsável por definir as interfaces e as classes DTO.

 Foi utilizado Docker para facilitar a distribuição da aplicação.

Detalhes da API: 
----------------------------------------------------------------------------------------------------------
Link da API hospedada: https://ramengo-c5c51aa6b5c5.herokuapp.com/

Autenticação: para fazer qualquer requisição é necessário enviar no header da requisição:
```
X-API-Key: ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf
```
### Endpoints: 
<code>GET: /broths - Lista as opções disponíveis de caldos</code>

Content type de retorno: application/json

Possíveis status retornados: 

201: É exibido uma lista de 
```
Broth:
{
       id	        : string
       imageInactive 	: string
       imageActive      : string
       name             : string
       description	: string
       price            : double
}
```
Exemplo: 
```
[
    {
        "id": "1",
        "imageInactive": "https://tech.redventures.com.br/icons/salt/inactive.svg",
        "imageActive": "https://tech.redventures.com.br/icons/salt/active.svg",
        "name": "Salt",
        "description": "Simple like the seawater, nothing more",
        "price": 10.0
    }
]
```
403: Retorna um ErrorResponse: 
```
ErrorResponse:
{
  error : string
}
```
Exemplo: 
```
{
  "error": "x-api-key header missing"
}
```
----------------------------------------------------------------------------------------------------------
<code>GET: /proteins - Lista as opções disponíveis de proteínas</code>

Content type de retorno: application/json

Possíveis status retornados: 

201: É exibido uma lista de 
```
Protein: {
       id	        : string
       imageInactive 	: string
       imageActive      : string
       name             : string
       description	: string
       price            : double
}
```
Exemplo: 
```
[
    {
        "id": "1",
        "imageInactive": "https://tech.redventures.com.br/icons/pork/inactive.svg",
        "imageActive": "https://tech.redventures.com.br/icons/pork/active.svg",
        "name": "Chasu",
        "description": "A sliced flavourful pork meat with a selection of season vegetables.",
        "price": 10.0
    }
]
```
403: Retorna um ErrorResponse: 
```
ErrorResponse: {
       error:	string
}
```
Exemplo: 
```
{
  "error": "x-api-key header missing"
}
```
----------------------------------------------------------------------------------------------------------
<code>POST: /order - realiza um pedido.</code>
> [!NOTE]
>1. Este endpoint foi feito diferente da documentação pois a aplicação client-side faz uma requisição para esta rota.
>2. O código deste endpoint teve de ser adaptado para receber requisições sem o content-type: application/json no header, seguindo a requisição feita no lado do cliente.
Corpo experado:
```
OrderRequest
{
  "brothId"   : string,
  "proteinId" : string
}
```
Content type de retorno: application/json
Possíveis status retornados:
201: Retorna um OrderResponse
```
OrderResponse:
{
  "id": "string",
  "description": "string",
  "image": "string"
}
```
Exemplo: 
```
{
  "id": "12345",
  "description": "Salt and Chasu Ramen",
  "image": "https://tech.redventures.com.br/icons/ramen/ramenChasu.png"
}
```

400: Retorna um ErrorResponse
```
ErrorResponse:
{
       error:	string
}
```
Exemplo: 
```
{
  "error": "both brothId and proteinId are required"
}
```
403: Retorna um ErrorResponse: 
```
ErrorResponse:
{
       error:	string
}
```
Exemplo: 
```
{
  "error": "x-api-key header missing"
}
```

500: Retorna um ErrorResponse: 
```
ErrorResponse:
{
       error:	string
}
```
Exemplo: 
```
{
  "error": "could not place order"
}
```
