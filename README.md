# CustomerRelationShip.LoadFactor.Admin.Api
Este repositório visa manter a implementação da API administrativa (interna) do sistema, essa API é uma parte dos sistemas distribuídos do LoadFactor.

## Objetivo Geral do Sistema LoadFactor 
O sistema tem como objetivo enviar propostas de mudança de voo para os clientes com base em uma série de regras de elegibilidade, o sistema deverá ofertar um voucher para o cliente e algumas opções de alteração de voo, caso ele aceite trocar de voo, o sistema realizará essa mudança e disponibiliza o voucher para o cliente, assim liberando um assento em um voo que já está com alta demanda para que a Azul possa vender esse assento por uma tarifa maior.

## Comunicações Externas 

- **Banco de dados SQL Server**
    - Utilizado para realizar o CRUD dos lotes e obter os relatórios de propostas enviadas e aceitas.
- **ServiceBus**
    - Serviço de Mensageria que a aplicação utiliza quando é realizada a importação de um novo lote dentro da aplicação.
- **ADFS**
    - Utilizado para realizar a autenticação dos usuários e obter os grupos para efetuar o controle e restrição de acesso na aplicação.

![](docs/diagrams/LoadFactor_v1.0_Admin.Api.jpg)

## Tecnologias Utilizadas

- [ASP.NET Core 3.1](https://github.com/aspnet/Home)
- [Dapper](https://dapper-tutorial.net/dapper) - ORM utilizado para mapear os objetos do banco de dados relacional da aplicação.
- [Azul.Framework.Core.*](https://dev.azure.com/azuldevops/ALM/_wiki/wikis/ALM.wiki?pagePath=%2FHome%2FArquitetura%2FAzul.Framework) - Framework da azul com uma série de facilitadores para utilização de eventos, domínio, infraestrutura, entre outros.
- [Mensageria Service Bus](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview) - Utilizado para se comunicar com os demais serviços distribuidos da aplicação.

## Api Controllers

O sistema está com o Swagger implementado, para ter um fácil acesso às rotas disponibilizadas pelo LoadFactor, basta realizar acesso ao swagger, colocando-o no final da URL onde a API está rodando.
Exemplo: http://localhost/swagger

### Batch

- Obter dados da importação dos lotes de forma paginada  
 /api/v1/batches

- Obter dados da importação de um lote específico  
/api/v1/batches/{id}

- Obter o conteúdo de um lote de forma paginada  
/api/v1/batches/{id}/items

- Realizar a importação de um lote  
/api/v1/batches/upload  
Detalhes: O lote possui um [layout pré definido](#descritivo-dos-campos) e precisa estar no formato csv.  

## Deploy da Aplicação

### Criação da imagem da aplicação  

A aplicação está configurada para ser dockerizada, sendo que possui dois arquivos docker.  

**Dockerfile**: Configurado para apontar para as imagens do *acr* da azul.  
**Dockerfile-dev**: Configurada para apontar para as imagens públicas da Microsoft.

### Subida no Kubernates

A aplicação conta com os arquivos do kubernates configurados para realizar o deploy no kubernates, sendo que possui dois arquivos k8s.

**k8sdeploy.yml**: Configurado para realizar o deploy no ambiente da azul, e com todos valores de ambiente tokenizados.  
**k8sdeploy-dev.yml**: Configurado para realizar o deploy local ou em servidor de desenvolvimento, precisando apenas especificar o caminho da imagem docker e a chave secreta para fazer o download da imagem.

## Glossário

**ADFS**  

Active Directory Federation Services, serviço para realizar a autenticação por meio de um portal web, utilizando as mesmas credenciais do Active Directory (AD) do servidor da empresa.

**Lote**  

Se trata do arquivo que contém as informações do voo que será obtido os passageiros e ofertado a proposta para mudança, abaixo está o layout com um exemplo e também explicação de cada campo. 

```csv
FlightNumber,DepartureDate,DepartureStation,ArrivalStation,OptionalFlightNumber,OptionalDepartureDate,OptionalDepartureStation,OptionalArrivalStation,LimitPassengerInBooking,LimitProposalSent,OfferedVoucherAmount
4173,04/08/2021,VCP,SDU,4041,04/08/2021,VCP,SDU,2,25,130
```  

### Descritivo dos Campos  
  
__FlightNumber__
Número do Voo Original, cujo passageiros receberam as propostas de alteração. Formato: 9999

__DepartureDate__
Data de Partida do Voo Original, cujo passageiros receberam as propostas de alteração. Formato: DD/MM/YYYY

__DepartureStation__
IATA/Aeroporto de partida do Voo Original, cujo passageiros receberam as propostas de alteração. Formato: AAA

__ArrivalStation__
IATA/Aeroporto de chegada do Voo Original, cujo passageiros receberam as propostas de alteração. Formato: BBB

__OptionalFlightNumber__
Número do Voo Opcional, cujo passageiros poderão optar por mudar na proposta de alteração. Formato: 9999

__OptionalDepartureDate__
Data de Partida do Voo Opcional, cujo passageiros poderão optar por mudar na proposta de alteração. Formato: DD/MM/YYYY

__OptionalDepartureStation__
IATA/Aeroporto de partida do Voo Opcional, cujo passageiros poderão optar por mudar na proposta de alteração. Formato: AAA

__OptionalArrivalStation__
IATA/Aeroporto de chegada do Voo Opcional, cujo passageiros poderão optar por mudar na proposta de alteração. Formato: BBB

__LimitPassengerInBooking__
Limite de passageiros que pode ter na reserva do passageiro para ser considerado uma reserva elegível. Formato: 99

__LimitProposalSent__
Limite de propostas de alteração que podem ser enviadas para a opção de voo informada. Formato: 99

__OfferedVoucherAmount__
Valor que será oferecido* ao passageiro caso ele opte alterar pela opção informada
Formato: 999.99 
