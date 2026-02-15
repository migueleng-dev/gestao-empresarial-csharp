# Sistema de Gestão de Funcionários e Controle de Ponto

Sistema completo de gerenciamento de funcionários com controle de ponto eletrônico, desenvolvido em C# com .NET 7 seguindo Clean Architecture.

## Tecnologias

- .NET 7.0
- ASP.NET Core Web API
- Entity Framework Core 7
- SQL Server
- JWT Authentication
- Swagger/OpenAPI

## Funcionalidades

### Gestão de Funcionários
- Cadastro completo de funcionários
- Edição e desativação
- Vinculação com departamentos
- Gestão de cargos e salários
- Controle de admissão e demissão
- Busca por CPF, nome ou departamento

### Controle de Ponto
- Registro de entrada e saída
- Controle de intervalos
- Geolocalização do registro
- Ajuste manual com auditoria
- Relatório de horas trabalhadas
- Cálculo de banco de horas

### Departamentos
- Gestão de departamentos
- Associação de funcionários
- Relatórios por departamento

### Autenticação
- Login com JWT
- Níveis de acesso (Funcionário, Gestor, RH, Admin)
- Auditoria de acessos

## Arquitetura

```
GestaoEmpresarial/
├── Domain/               # Entidades e interfaces
│   ├── Entities/
│   └── Interfaces/
├── Application/          # Lógica de negócio
│   ├── DTOs/
│   ├── Services/
│   └── Validators/
├── Infrastructure/       # Acesso a dados
│   ├── Data/
│   └── Repositories/
└── API/                  # Controllers e configurações
    ├── Controllers/
    └── Program.cs
```

## Como Executar

### Pré-requisitos

- .NET 7 SDK
- SQL Server

### Configuração

1. Configure a connection string em `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GestaoEmpresarial;Trusted_Connection=True;"
  }
}
```

2. Execute as migrations:

```bash
dotnet ef database update --project GestaoEmpresarial.Infrastructure
```

3. Execute a aplicação:

```bash
dotnet run --project GestaoEmpresarial.API
```

A aplicação estará disponível em `https://localhost:5001`

## Endpoints Principais

### Autenticação
- `POST /api/auth/login` - Login
- `POST /api/auth/refresh` - Refresh token

### Funcionários
- `GET /api/funcionarios` - Listar todos
- `GET /api/funcionarios/{id}` - Buscar por ID
- `POST /api/funcionarios` - Cadastrar
- `PUT /api/funcionarios/{id}` - Atualizar
- `DELETE /api/funcionarios/{id}` - Desativar
- `GET /api/funcionarios/cpf/{cpf}` - Buscar por CPF

### Controle de Ponto
- `POST /api/ponto/entrada` - Registrar entrada
- `POST /api/ponto/saida` - Registrar saída
- `POST /api/ponto/intervalo-inicio` - Iniciar intervalo
- `POST /api/ponto/intervalo-fim` - Finalizar intervalo
- `GET /api/ponto/funcionario/{id}` - Histórico
- `GET /api/ponto/relatorio` - Relatório de horas

### Departamentos
- `GET /api/departamentos` - Listar todos
- `POST /api/departamentos` - Criar
- `PUT /api/departamentos/{id}` - Atualizar
- `GET /api/departamentos/{id}/funcionarios` - Funcionários do departamento

## Documentação

- Swagger UI: `https://localhost:5001/swagger`

## Modelo de Dados

### Funcionario
- Nome, CPF, Email
- Data de Nascimento
- Cargo, Salário
- Departamento
- Data de Admissão/Demissão
- Status (Ativo/Inativo)

### RegistroPonto
- Funcionário
- Data/Hora
- Tipo (Entrada, Saída, Intervalo)
- Localização (Lat/Long)
- Observações

### Departamento
- Nome, Código
- Descrição
- Gestor

### Usuario
- Username, Email
- Senha (hash)
- Role (Funcionário, Gestor, RH, Admin)

## Exemplo de Uso

### Login

```bash
curl -X POST https://localhost:5001/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "username": "admin",
    "password": "admin123"
  }'
```

### Cadastrar Funcionário

```bash
curl -X POST https://localhost:5001/api/funcionarios \
  -H "Authorization: Bearer {token}" \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "João Silva",
    "cpf": "12345678900",
    "email": "joao@empresa.com",
    "cargo": "Desenvolvedor",
    "salario": 5000.00,
    "departamentoId": 1
  }'
```

### Registrar Ponto

```bash
curl -X POST https://localhost:5001/api/ponto/entrada \
  -H "Authorization: Bearer {token}" \
  -H "Content-Type: application/json" \
  -d '{
    "funcionarioId": 1,
    "latitude": -23.5505,
    "longitude": -46.6333
  }'
```

## Licença

MIT
