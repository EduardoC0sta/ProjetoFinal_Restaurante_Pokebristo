# \# PokéBistro - Sistema Integrado de Gestão de Restaurante

# 

# Este repositório contém o ecossistema de software do \*\*PokéBistro\*\*, uma aplicação full-stack projetada para otimizar o atendimento, gerenciamento de cardápios, controle de colaboradores e fluxo de pedidos de um estabelecimento gastronômico temático. 

# 

# O sistema é composto por uma arquitetura robusta no backend baseada em serviços e DTOs, integrada a uma interface responsiva e dinâmica no frontend.

# 

# \---

# 

# \## 1. Documentação Funcional (Regras de Negócio e Escopo)

# 

# \### 1.1. Objetivo do Sistema

# O PokéBistro foi desenvolvido para sanar as dores operacionais de estabelecimentos alimentícios, centralizando o controle gerencial (administração) e a experiência de autoatendimento do usuário final (cliente). O foco principal é a agilidade no tráfego de informações entre o salão, a cozinha e o caixa, eliminando falhas de comunicação humana.

# 

# \### 1.2. Funcionalidades Principais

# \* \*\*Portal do Cliente (Autoatendimento):\*\* \* Consulta digital ao cardápio atualizado em tempo real.

# &#x20; \* Sistema de carrinho de compras persistente localmente.

# &#x20; \* Fluxo de autocadastro e identificação automatizada via CPF.

# &#x20; \* Envio direto de pedidos para a fila de espera da cozinha.

# \* \*\*Painel Administrativo (Gestão Geral):\*\*

# &#x20; \* Controle de acesso restrito via autenticação digital.

# &#x20; \* Gerenciamento completo de produtos (Cardápio).

# &#x20; \* Administração de recursos humanos e folha de pagamento básica (Funcionários).

# &#x20; \* Monitoramento, alteração de status e triagem da esteira de produção (Pedidos).

# 

# \### 1.3. Diretrizes Operacionais e Regras de Negócio

# \* \*\*Segurança de Acesso:\*\* Rotas administrativas de escrita, modificação e exclusão exigem a validação de um token de segurança ativo.

# \* \*\*Consistência de Dados Financeiros:\*\* O sistema impede a inserção de valores monetários negativos tanto para a precificação de pratos quanto para a definição de salários de funcionários.

# \* \*\*Ciclo de Vida do Pedido:\*\* Todo pedido inicia obrigatoriamente com o estado `Pendente`. Ele transiciona de forma linear para `Em preparo`, seguido de `Entregue` ou, em casos excepcionais, `Cancelado`.

# \* \*\*Identificação do Consumidor:\*\* Para finalização de compras, o sistema exige a validação do CPF do cliente. Se o cadastro não constar na base de dados, a interface habilita dinamicamente a captura do nome completo para registro instantâneo.

# 

# \---

# 

# \## 2. Documentação Técnica (Arquitetura e Implementação)

# 

# \### 2.1. Tecnologias Utilizadas

# 

# \#### \*\*Backend (API):\*\*

# \* \*\*Framework Principal:\*\* ASP.NET Core Web API (NET 8.0)

# \* \*\*Persistência de Dados:\*\* Entity Framework Core (Abordagem Code-First / DbContext)

# \* \*\*Driver do Banco de Dados:\*\* Pomelo.EntityFrameworkCore.MySql

# \* \*\*Segurança:\*\* Autenticação e Autorização via tokens JWT (JSON Web Tokens)

# \* \*\*Documentação Interativa:\*\* Swagger UI / OpenAPI

# 

# \#### \*\*Frontend:\*\*

# \* \*\*Estrutura e Estilização:\*\* HTML5, CSS3, Bootstrap 5 (Layout fluido e Componentes de Feedback Visual)

# \* \*\*Iconografia:\*\* Bootstrap Icons

# \* \*\*Lógica e Comunicação As síncrona:\*\* JavaScript (ES6+) utilizando a API nativa `Fetch` para requisições assíncronas (AJAX).

# 

# \---

# 

# \## 3. Endpoints da API (Catálogo de Serviços)

# 

# A API expõe serviços estruturados sob o padrão RESTful. Abaixo constam os principais pontos de acesso mapeados:

# 

# \### Autenticação (`/api/Auth`)

# \* `POST /api/Auth/login` - Valida credenciais administrativas e retorna o token de acesso.

# 

# \### Autenticação do Cliente (`/api/ClienteAuth`)

# \* `POST /api/ClienteAuth/identificar` - Verifica a existência do cliente por CPF ou realiza o registro inicial.

# 

# \### Gestão do Cardápio (`/api/Cardapio`)

# \* `GET /api/Cardapio` - Retorna a listagem de pratos ativos (Acesso público).

# \* `POST /api/Cardapio` - Registra um novo item culinário (Requer Token).

# \* `PUT /api/Cardapio/{id}` - Atualiza as especificações de um prato existente (Requer Token).

# \* `DELETE /api/Cardapio/{id}` - Remove de forma lógica ou física um prato do menu (Requer Token).

# 

# \### Controle de Colaboradores (`/api/Funcionario`)

# \* `GET /api/Funcionario` - Lista todos os funcionários e seus respectivos status de ocupação (Requer Token).

# \* `POST /api/Funcionario` - Registra a contratação de um novo colaborador (Requer Token).

# \* `PUT /api/Funcionario/{id}` - Modifica dados cadastrais, cargos ou salários (Requer Token).

# \* `DELETE /api/Funcionario/{id}` - Realiza o desligamento administrativo do funcionário (Requer Token).

# 

# \### Fluxo de Vendas (`/api/Pedido`)

# \* `GET /api/Pedido` - Exibe o mapa geral de ordens de serviço geradas no estabelecimento (Requer Token).

# \* `POST /api/Pedido` - Cria uma nova requisição de consumo vinculando cliente e itens escolhidos.

# \* `PUT /api/Pedido/{id}` - Altera o status evolutivo do pedido na cozinha (Requer Token).

# \* `DELETE /api/Pedido/{id}` - Cancela permanentemente a ordem de serviço informada (Requer Token).

# 

# \---

# 

# \## 4. Instruções de Execução em Ambiente Local

# 

# \### Pré-requisitos

# \* .NET SDK 8.0 instalado.

# \* Servidor MySQL ativo (Local ou via container Docker).

# 

# \### Passos para Configuração

# 1\. \*\*Configuração da Base de Dados:\*\*

# &#x20;  Abra o arquivo `appsettings.json` localizado na raiz do projeto Web API e ajuste a string de conexão informando as credenciais do seu servidor MySQL:

# &#x20;  ```json

# &#x20;  "ConnectionStrings": {

# &#x20;    "DefaultConnection": "Server=localhost;Database=PokebistroDb;Uid=SEU\_USUARIO;Pwd=SUA\_SENHA;"

# &#x20;  }

