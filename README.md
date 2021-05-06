<h1>PetShopAtlantico<h1>
  
  > Status: Developing
  > 

### Projeto criado em Angular 9 no FrontEnd e WepApi .NET CORE 3.1 + EntityFramework SqlServer Code First no Backend, simulando um crud para gerenciar um PetShop

## Funcionalidades desenvolvidas

* Cadastro de Pet -> informações relacionadas ( Dono, Alojamento)
* Update de Pet
* Delete de Pet
* Listar todos os Pets
* Busca de Pet por nome

* Cadastro de Alojamentos
* Listar alojamentos ocupados e livres

## Libs e tecnologias utilizadas

<table>
  <tr>
    <td>C#</td>
    <td>EntityFramework CORE</td>
    <td>XUnit para testes unitários </td>
    <td>Angular 9 - Frontend</td>
    <td>Bootstrap</td>
    <td>WebApi em camadas</td>
    <td>SQL Server</td>
  </tr>
  <tr>
    <td>8.*</td>
    <td>5.0.5</td>
    <td>2.4.1</td>
    <td>9</td>
    <td>4.6</td>
    <td>.NET CORE 3.1</td>
    <td>17</td>
  </tr>
</table>


## passos para rodar o projeto do backend

1) Abrir no Visual studio 2019 - Marcar O projeto <strong>PetshopAtlanticoWebApi</strong> como projeto principal
2) fazer o build
3) verificar a connectionString localizada no AppSettings.json e substituir server e dados de usuario
4) rodar o Update-database apontando pro projeto <strong>PetshopAtlantico.DataBaseAccess.Entity</strong>
5) rodar as seed para popular o banco

## passos para rodar o front end

1) abrir em uma Ide de sua escolha ( foi utilizado o visual studio code na concepção do projeto )
2) abrir uma janela de comando na pasta <strong>PetShopAtlanticoUI</strong>  e dar um npm install para baixar todas as dependências do projeto
3) rodar o comando ng serve --open

## importante

### só é possivel cadastrar um pet se existir um alojamento criado e com status disponivel 

