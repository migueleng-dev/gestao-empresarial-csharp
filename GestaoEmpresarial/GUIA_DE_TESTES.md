# 🧪 Guia de Testes da API

## 🚀 Como Rodar o Projeto

```powershell
cd GestaoEmpresarial/GestaoEmpresarial.API
dotnet run
```

A API estará disponível em: **http://localhost:5046**

---

## 📡 Endpoints Disponíveis

### **Departamentos**
- GET `/api/departamentos` - Listar todos (já tem 4 seed data)

### **Funcionários**

#### Listar todos
```http
GET http://localhost:5046/api/funcionarios
```

#### Listar apenas ativos
```http
GET http://localhost:5046/api/funcionarios/ativos
```

#### Buscar por ID
```http
GET http://localhost:5046/api/funcionarios/1
```

#### Criar funcionário
```http
POST http://localhost:5046/api/funcionarios
Content-Type: application/json

{
  "nome": "João Silva",
  "cpf": "12345678901",
  "email": "joao.silva@empresa.com",
  "telefone": "(11) 98765-4321",
  "dataNascimento": "1990-05-15",
  "dataAdmissao": "2024-01-10",
  "salario": 5500.00,
  "cargo": "Desenvolvedor",
  "departamentoId": 1
}
```

#### Atualizar funcionário
```http
PUT http://localhost:5046/api/funcionarios/1
Content-Type: application/json

{
  "nome": "João Silva Santos",
  "cpf": "12345678901",
  "email": "joao.silva@empresa.com",
  "telefone": "(11) 98765-4321",
  "dataNascimento": "1990-05-15",
  "dataAdmissao": "2024-01-10",
  "salario": 6000.00,
  "cargo": "Desenvolvedor Sênior",
  "departamentoId": 1
}
```

#### Demitir funcionário
```http
PATCH http://localhost:5046/api/funcionarios/1/demitir
```

#### Deletar funcionário
```http
DELETE http://localhost:5046/api/funcionarios/1
```

---

### **Controle de Ponto**

#### Registrar ponto
```http
POST http://localhost:5046/api/ponto/registrar
Content-Type: application/json

{
  "funcionarioId": 1,
  "tipo": 1,
  "localizacao": "Escritório Central",
  "observacao": "Entrada normal"
}
```

**Tipos de Registro:**
- `1` = Entrada
- `2` = Saída
- `3` = Início Intervalo
- `4` = Fim Intervalo

#### Ver registros de um funcionário
```http
GET http://localhost:5046/api/ponto/funcionario/1
```

#### Ver registros por período
```http
GET http://localhost:5046/api/ponto/funcionario/1/periodo?inicio=2024-01-01&fim=2024-12-31
```

#### Ver último registro
```http
GET http://localhost:5046/api/ponto/funcionario/1/ultimo
```

---

## 🧪 Testando com PowerShell

### Criar um funcionário
```powershell
$funcionario = @{
    nome = "Maria Santos"
    cpf = "98765432100"
    email = "maria.santos@empresa.com"
    telefone = "(11) 91234-5678"
    dataNascimento = "1992-08-20"
    dataAdmissao = "2024-02-01"
    salario = 4500.00
    cargo = "Analista"
    departamentoId = 2
} | ConvertTo-Json

Invoke-RestMethod -Uri "http://localhost:5046/api/funcionarios" `
                   -Method Post `
                   -Body $funcionario `
                   -ContentType "application/json"
```

### Registrar entrada
```powershell
$ponto = @{
    funcionarioId = 1
    tipo = 1
    localizacao = "Escritório"
    observacao = "Entrada"
} | ConvertTo-Json

Invoke-RestMethod -Uri "http://localhost:5046/api/ponto/registrar" `
                   -Method Post `
                   -Body $ponto `
                   -ContentType "application/json"
```

### Listar funcionários
```powershell
Invoke-RestMethod -Uri "http://localhost:5046/api/funcionarios" -Method Get | ConvertTo-Json
```

---

## 📊 Banco de Dados

O banco de dados SQLite está em: `GestaoEmpresarial.API/gestao.db`

Você pode visualizar com ferramentas como:
- **DB Browser for SQLite**: https://sqlitebrowser.org/
- **VS Code Extension**: SQLite Viewer

---

## 🛠️ Comandos Úteis

### Recriar o banco de dados
```powershell
cd GestaoEmpresarial/GestaoEmpresarial.API
Remove-Item gestao.db -ErrorAction SilentlyContinue
dotnet ef database update
```

### Ver logs detalhados
```powershell
dotnet run --verbosity detailed
```

### Compilar sem executar
```powershell
dotnet build
```

---

## ✅ Funcionalidades Implementadas

- ✅ CRUD completo de funcionários
- ✅ Validação de dados (CPF único, Email único)
- ✅ Controle de ponto eletrônico
- ✅ 4 tipos de registro (Entrada, Saída, Intervalos)
- ✅ Consulta por período
- ✅ Geolocalização de registros
- ✅ Departamentos com seed data
- ✅ Soft delete (demitir funcionário)
- ✅ Arquitetura limpa em 4 camadas
- ✅ Repository Pattern
- ✅ DTOs para entrada e saída
- ✅ Tratamento de exceções
- ✅ CORS habilitado

---

## 🎯 Próximas Melhorias Sugeridas

1. Adicionar Swagger UI para documentação interativa
2. Implementar autenticação JWT
3. Adicionar paginação nos endpoints de lista
4. Criar relatórios de horas trabalhadas
5. Adicionar validação de CPF
6. Implementar testes unitários e de integração
7. Adicionar logs estruturados
8. Criar endpoint de estatísticas

---

**O projeto está 100% funcional e pronto para demonstrações!** 🚀
