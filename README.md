# 📦 Clientes API — ASP.NET Core

API REST simples para gerenciamento de clientes, desenvolvida em **ASP.NET Core (.NET 8)** com **Entity Framework Core** e **SQLite**.

Projeto criado com foco em **aprendizado prático** e **portfólio**.

---

## 🚀 Funcionalidades

- Criar clientes
- Listar clientes
- Atualizar cliente por ID
- Remover cliente por ID
- Autenticação via JWT
- Controle de acesso com Roles (`Admin` e `User`)
- Testes via Swagger com botão **Authorize**

---

## 🛡 Autenticação e Autorização (JWT)

Implementado sistema de segurança baseado em **JWT (JSON Web Token)**, permitindo proteger endpoints e validar permissões.

### 🔑 Funcionalidades adicionadas:

✔ Configuração do JWT no `Program.cs`  
✔ Login com `POST /auth/login`  
✔ Geração de token com:
- Nome do usuário (`ClaimTypes.Name`)
- Papel (`ClaimTypes.Role`)
- Expiração
- Assinatura com chave simétrica

✔ Perfis de acesso:
- `Admin`
- `User`

✔ Proteção de endpoints via atributo `[Authorize]`  
✔ Integração com Swagger usando botão **Authorize**

---

## 🛠 Tecnologias Utilizadas

- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQLite
- AutoMapper
- JWT Authentication
- Swagger / OpenAPI
- Git & GitHub

---

## 📁 Estrutura do Projeto

ClientesApi
│
├── Controllers # Endpoints da API
├── Models # Entidades do domínio
├── Dtos # Objetos de transferência de dados
├── Data # DbContext e configuração do EF Core
├── Migrations # Migrations do banco de dados
└── Program.cs # Configuração da aplicação


---

## 🧩 Fluxo de Autenticação

1. Enviar `POST /auth/login`
2. Receber token JWT
3. Enviar token no header: Authorization: Bearer <seu_token>
4. Acessar endpoints protegidos por roles
 

📚 Aprendizados

- Durante o desenvolvimento foram estudados e aplicados:
- Criação de APIs REST com ASP.NET Core
- CRUD com Entity Framework Core + SQLite
- Separação de responsabilidades com DTOs
- Versionamento com Git e GitHub
- Autenticação com JWT
- Controle de acesso com Roles
- Integração do JWT ao Swagger


✨ Próximas melhorias

- Validação de dados
- Paginação no GET
- Gestão de usuários no banco
- Refresh token
- Versionamento de API

👩‍💻 Autora

Tainá Alecrim
Desenvolvedora .NET em formação

🔗 GitHub: https://github.com/TainaAlecrim





