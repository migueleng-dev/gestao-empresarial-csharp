# 🚀 GUIA RÁPIDO - Como Testar a API

## ✅ 1. Verificar se está rodando

Abra o PowerShell e execute:
```powershell
cd C:\Users\migue\OneDrive\Desktop\Documentos\verdent-projects\new-project\GestaoEmpresarial\GestaoEmpresarial.API
dotnet run
```

Você deve ver:
```
Now listening on: http://localhost:5046
Application started. Press Ctrl+C to shut down.
```

---

## 🧪 2. Testar no Navegador

### **Ver Departamentos** (já tem dados pré-cadastrados)
Abra no navegador:
```
http://localhost:5046/api/funcionarios
```

Deve retornar: `[]` (lista vazia - ainda não tem funcionários)

---

## 📝 3. Testar com Postman ou Insomnia

### **A) Baixar uma ferramenta de teste:**
- **Postman**: https://www.postman.com/downloads/
- **Insomnia**: https://insomnia.rest/download

### **B) Criar um Funcionário:**

**Método:** `POST`  
**URL:** `http://localhost:5046/api/funcionarios`  
**Headers:** `Content-Type: application/json`  
**Body (raw JSON):**
```json
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

### **C) Listar Funcionários:**

**Método:** `GET`  
**URL:** `http://localhost:5046/api/funcionarios`

### **D) Registrar Ponto:**

**Método:** `POST`  
**URL:** `http://localhost:5046/api/ponto/registrar`  
**Headers:** `Content-Type: application/json`  
**Body:**
```json
{
  "funcionarioId": 1,
  "tipo": 1,
  "localizacao": "Escritório Central",
  "observacao": "Entrada"
}
```

**Tipos:**
- `1` = Entrada
- `2` = Saída
- `3` = Início Intervalo
- `4` = Fim Intervalo

---

## 🔍 4. Todos os Endpoints Disponíveis

### **Funcionários:**
```
GET    http://localhost:5046/api/funcionarios
GET    http://localhost:5046/api/funcionarios/ativos
GET    http://localhost:5046/api/funcionarios/1
POST   http://localhost:5046/api/funcionarios
PUT    http://localhost:5046/api/funcionarios/1
PATCH  http://localhost:5046/api/funcionarios/1/demitir
DELETE http://localhost:5046/api/funcionarios/1
```

### **Controle de Ponto:**
```
POST   http://localhost:5046/api/ponto/registrar
GET    http://localhost:5046/api/ponto/funcionario/1
GET    http://localhost:5046/api/ponto/funcionario/1/periodo?inicio=2024-01-01&fim=2024-12-31
GET    http://localhost:5046/api/ponto/funcionario/1/ultimo
```

---

## ❌ Problemas Comuns

### **1. Porta já em uso**
Se a porta 5046 estiver ocupada, o .NET escolhe outra automaticamente.  
Verifique qual porta está usando na mensagem:
```
Now listening on: http://localhost:XXXX
```

### **2. Banco de dados não existe**
Se aparecer erro de banco, execute:
```powershell
cd GestaoEmpresarial/GestaoEmpresarial.API
dotnet ef database update
```

### **3. Não compila**
Execute:
```powershell
cd GestaoEmpresarial
dotnet clean
dotnet build
```

---

## 💡 Dica Extra

Use o **VS Code** com a extensão **REST Client**:

1. Instale: `REST Client` (Huachao Mao)
2. Crie um arquivo `test.http`
3. Cole:

```http
### Listar Funcionários
GET http://localhost:5046/api/funcionarios

### Criar Funcionário
POST http://localhost:5046/api/funcionarios
Content-Type: application/json

{
  "nome": "Maria Santos",
  "cpf": "98765432100",
  "email": "maria@empresa.com",
  "telefone": "11912345678",
  "dataNascimento": "1992-08-20",
  "dataAdmissao": "2024-02-01",
  "salario": 4500.00,
  "cargo": "Analista",
  "departamentoId": 2
}

### Registrar Entrada
POST http://localhost:5046/api/ponto/registrar
Content-Type: application/json

{
  "funcionarioId": 1,
  "tipo": 1,
  "localizacao": "Escritório",
  "observacao": "Entrada"
}
```

4. Clique em "Send Request" acima de cada requisição!

---

**Está rodando? Agora é só testar! 🚀**
