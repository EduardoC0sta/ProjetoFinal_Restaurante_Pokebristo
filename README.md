# 🍳 PokéBistro - Sistema Integrado de Gestão de Restaurante

![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge&logo=dotnet)
![MySQL](https://img.shields.io/badge/MySQL-8.4-blue?style=for-the-badge&logo=mysql&logoColor=white)
![Bootstrap 5](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![Render](https://img.shields.io/badge/Render-Hosted-black?style=for-the-badge&logo=render&logoColor=white)
![Vercel](https://img.shields.io/badge/Vercel-Deployed-white?style=for-the-badge&logo=vercel&logoColor=black)

O **PokéBistro** é um ecossistema de software completo (Full-Stack) projetado para otimizar o autoatendimento, gerenciamento de cardápios, controle de colaboradores e fluxo de ordens de serviço de um estabelecimento gastronômico temático.

A arquitetura conta com um backend robusto em C# estruturado com serviços, repositórios e autenticação segura, comunicando-se diretamente com um banco de dados relacional na nuvem e uma interface web fluida e responsiva.

---

## 🚀 Links do Sistema em Produção (Nuvem)

O ecossistema foi totalmente implantado em ambiente de produção e pode ser acessado de forma totalmente online pelos links abaixo:

* **🛒 Portal do Cliente (Frontend):** [https://projeto-final-restaurante-pokebristo.vercel.app/cliente.html](https://projeto-final-restaurante-pokebristo.vercel.app/cliente.html)
* **⚙️ Painel do Administrador (Frontend):** [https://projeto-final-restaurante-pokebristo.vercel.app/index.html](https://projeto-final-restaurante-pokebristo.vercel.app/index.html)
* **💻 Servidor da API Backend (Render):** [https://projetofinal-restaurante-pokebristo.onrender.com](https://projetofinal-restaurante-pokebristo.onrender.com)

---

## 🛠️ 1. Documentação Funcional (Regras de Negócio)

### 1.1. Objetivo
Centralizar o controle gerencial e a experiência de autoatendimento do usuário final, eliminando erros humanos de comunicação entre o salão, a cozinha e a administração financeira.

### 1.2. Regras de Negócio Críticas
* **🔒 Proteção Administrativa:** Rotas de escrita, modificação e exclusão exigem a validação de um token JWT ativo gerado no login.
* **🛡️ Conformidade com a LGPD:** O sistema captura dados sensíveis (CPF e Nome) apenas mediante consentimento explícito do usuário através de um checkbox obrigatório. O envio do pedido é bloqueado pela interface caso os termos não sejam aceitos.
* **📈 Ciclo de Vida do Pedido:** Todo pedido inicia como `Pendente`, progredindo linearmente para `Em preparo`, `Entregue` ou `Cancelado`.
* **💰 Integridade Financeira:** Bloqueio lógico contra a inserção de valores monetários negativos para preços de pratos e salários de colaboradores.

---

## 💻 2. Tecnologias e Arquitetura

### Backend (API)
* **Linguagem & Framework:** C# com ASP.NET Core Web API (.NET 8.0)
* **ORM / Persistência:** Entity Framework Core (Abordagem Code-First)
* **Banco de Dados:** MySQL 8.4 hospedado via Aiven Cloud
* **Segurança:** Autenticação e Autorização via tokens criptografados JWT

### Frontend
* **Interface:** HTML5, CSS3, Bootstrap 5.3 (Componentes fluidos e Toasts dinâmicos)
* **Comunicação As síncrona:** JavaScript (ES6+) utilizando a API nativa `Fetch` para requisições assíncronas (AJAX) com tratamento de políticas de CORS.

---

## 🔌 3. Endpoints da API (Catálogo de Serviços)

| Módulo | Método | Rota | Descrição | Acesso |
| :--- | :--- | :--- | :--- | :--- |
| **Auth** | `POST` | `/api/Auth/login` | Autentica administradores e gera Token JWT | Público |
| **ClienteAuth** | `POST` | `/api/ClienteAuth/identificar` | Identifica cliente por CPF ou faz o cadastro | Público |
| **Cardapio** | `GET` | `/api/Cardapio` | Lista todos os pratos ativos | Público |
| **Cardapio** | `POST` | `/api/Cardapio` | Cria um novo item culinário | Requer Token |
| **Funcionario** | `GET` | `/api/Funcionario` | Lista todos os colaboradores ativos | Requer Token |
| **Funcionario** | `POST` | `/api/Funcionario` | Registra a contratação de um colaborador | Requer Token |
| **Pedido** | `POST` | `/api/Pedido` | Registra uma nova ordem de serviço | Público |
| **Pedido** | `PUT` | `/api/Pedido/{id}` | Altera o status evolutivo na cozinha | Requer Token |

---

## 🛠️ 4. Instruções de Execução em Ambiente Local

Se desejar baixar o projeto e rodar na sua máquina local, siga os passos abaixo:

### Pré-requisitos
* .NET SDK 8.0 instalado.
* Servidor MySQL ativo localmente.

### Passo 1: Clonar o Repositório
```bash
git clone [https://github.com/EduardoC0sta/ProjetoFinal_Restaurante_Pokebristo.git](https://github.com/EduardoC0sta/ProjetoFinal_Restaurante_Pokebristo.git)
cd ProjetoFinal_Restaurante_Pokebristo/Sprint3
