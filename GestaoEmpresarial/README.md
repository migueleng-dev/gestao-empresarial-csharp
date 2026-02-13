# 🏢 Sistema de Gestão de Funcionários e Controle de Ponto

Sistema completo de gerenciamento de funcionários com controle automatizado de ponto eletrônico, desenvolvido em C# com .NET 7, seguindo arquitetura limpa e boas práticas de desenvolvimento.

## 🚀 Tecnologias Utilizadas

- **.NET 7.0** - Framework principal
- **ASP.NET Core Web API** - API RESTful
- **Entity Framework Core 7** - ORM para acesso a dados
- **SQL Server** - Banco de dados relacional
- **JWT Bearer Authentication** - Autenticação e autorização
- **Swagger/OpenAPI** - Documentação da API
- **Arquitetura Limpa** (Clean Architecture)

## 📋 Funcionalidades

### Gestão de Funcionários
- ✅ Cadastro completo de funcionários
- ✅ Edição e desativação de funcionários
- ✅ Vinculação com departamentos
- ✅ Gestão de cargos e salários
- ✅ Controle de admissão e demissão
- ✅ Busca por CPF, nome ou departamento

### Controle de Ponto
- ✅ Registro de entrada e saída
- ✅ Controle de intervalos (almoço/pausa)
- ✅ Geolocalização do registro
- ✅ Ajuste manual com auditoria
- ✅ Relatório de horas trabalhadas
- ✅ Cálculo automático de banco de horas
- ✅ Histórico completo de registros

### Departamentos
- ✅ Gestão de departamentos
- ✅ Associação de funcionários
- ✅ Relatórios por departamento

### Autenticação e Segurança
- ✅ Login com JWT
- ✅ Níveis de acesso (Funcionário, Gestor, RH, Admin)
- ✅ Auditoria de acessos
- ✅ Senhas criptografadas

## 🏗️ Arquitetura do Projeto

```
GestaoEmpresarial/
├── GestaoEmpresarial.Domain/          # Entidades e interfaces
│   ├── Entities/
│   │   ├── Funcionario.cs
│   │   ├── Departamento.cs
│   │   ├── RegistroPonto.cs
│   │   └── Usuario.cs
│   └── Interfaces/
│       ├── IFuncionarioRepository.cs
│       ├── IRegistroPontoRepository.cs
│       ├── IDepartamentoRepository.cs
│       └── IUsuarioRepository.cs
│
├── GestaoEmpresarial.Application/     # Lógica de negócio
│   ├── DTOs/
│   ├── Services/
│   └── Validators/
│
├── GestaoEmpresarial.Infrastructure/  # Acesso a dados
│   ├── Data/
│   │   └── AppDbContext.cs
│   └── Repositories/
│       ├── FuncionarioRepository.cs
│       └── RegistroPontoRepository.cs
│
└── GestaoEmpresarial.API/             # Controllers e configurações
    ├── Controllers/
    ├── Program.cs
    └── appsettings.json
```

## 📊 Modelo de Dados

### Funcionario
- Dados pessoais (nome, CPF, email, telefone, data de nascimento)
- Dados profissionais (cargo, salário, data de admissão/demissão)
- Vínculo com departamento
- Status ativo/inativo

### RegistroPonto
- Tipo de registro (Entrada, Saída, Início/Fim Intervalo)
- Data e hora
- Geolocalização (opcional)
- Ajuste manual com auditoria

### Departamento
- Nome e descrição
- Lista de funcionários

### Usuario
- Login e senha (hash)
- Tipo (Funcionário, Gestor, RH, Administrador)
- Vínculo com funcionário

## 🔧 Configuração e Instalação

### Pré-requisitos
- .NET 7.0 SDK ou superior
- SQL Server (LocalDB ou Server)
- Visual Studio 2022 ou VS Code

### Passo a Passo

1. **Clone o repositório**
```bash
git clone https://github.com/seu-usuario/gestao-empresarial.git
cd gestao-empresarial/GestaoEmpresarial
```

2. **Configure a string de conexão**

Edite `appsettings.json` no projeto API:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GestaoEmpresarialDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

3. **Execute as migrações**
```bash
cd GestaoEmpresarial.API
dotnet ef migrations add InitialCreate --project ../GestaoEmpresarial.Infrastructure
dotnet ef database update
```

4. **Execute a aplicação**
```bash
dotnet run
```

A API estará disponível em:
- **HTTPS**: https://localhost:7001
- **HTTP**: http://localhost:5001
- **Swagger**: https://localhost:7001/swagger

## 📡 Principais Endpoints

### Funcionários
```
GET    /api/funcionarios              # Listar todos
GET    /api/funcionarios/{id}         # Buscar por ID
GET    /api/funcionarios/cpf/{cpf}    # Buscar por CPF
GET    /api/funcionarios/ativos       # Listar ativos
POST   /api/funcionarios              # Cadastrar
PUT    /api/funcionarios/{id}         # Atualizar
DELETE /api/funcionarios/{id}         # Remover
```

### Controle de Ponto
```
GET    /api/ponto/funcionario/{id}                    # Histórico
GET    /api/ponto/funcionario/{id}/periodo?inicio=&fim=  # Por período
POST   /api/ponto/registrar                          # Registrar ponto
GET    /api/ponto/ultimo/{funcionarioId}             # Último registro
GET    /api/ponto/relatorio/{funcionarioId}/mes/{mes}/ano/{ano}  # Relatório mensal
```

### Departamentos
```
GET    /api/departamentos         # Listar todos
GET    /api/departamentos/{id}    # Buscar por ID
POST   /api/departamentos         # Criar
PUT    /api/departamentos/{id}    # Atualizar
DELETE /api/departamentos/{id}    # Remover
```

### Autenticação
```
POST   /api/auth/login           # Login
POST   /api/auth/register        # Registrar usuário
GET    /api/auth/me              # Dados do usuário logado
```

## 💡 Exemplos de Uso

### Cadastrar Funcionário
```json
POST /api/funcionarios
{
  "nome": "João Silva",
  "cpf": "12345678900",
  "email": "joao.silva@empresa.com",
  "telefone": "(11) 98765-4321",
  "dataNascimento": "1990-05-15",
  "dataAdmissao": "2024-01-10",
  "salario": 5500.00,
  "cargo": "Desenvolvedor",
  "departamentoId": 1
}
```

### Registrar Ponto
```json
POST /api/ponto/registrar
{
  "funcionarioId": 1,
  "tipo": 1,
  "localizacao": "Escritório Central",
  "observacao": "Entrada normal"
}
```

**Tipos de Registro:**
- 1 = Entrada
- 2 = Saída
- 3 = Início Intervalo
- 4 = Fim Intervalo

## 🎯 Casos de Uso Empresarial

### 1. Controle de Jornada
- Registro automático de entradas/saídas
- Cálculo de horas trabalhadas
- Identificação de horas extras
- Banco de horas

### 2. Gestão de Equipes
- Visualização de equipes por departamento
- Controle de presença em tempo real
- Relatórios gerenciais

### 3. Conformidade Legal
- Registro auditável de pontos
- Histórico completo de ajustes
- Relatórios para e-Social

### 4. Produtividade
- Análise de padrões de trabalho
- Identificação de atrasos recorrentes
- Métricas de pontualidade

## 🔒 Segurança

- **Autenticação JWT** com tokens de curta duração
- **Senhas criptografadas** usando hash seguro
- **Níveis de acesso** baseados em roles
- **Auditoria** de todas as operações sensíveis
- **Validação** de dados em todas as camadas

## 📈 Melhorias Futuras

- [ ] Aplicativo mobile para registro de ponto
- [ ] Reconhecimento facial
- [ ] Integração com biometria
- [ ] Notificações push
- [ ] Dashboard com gráficos em tempo real
- [ ] Integração com sistemas de folha de pagamento
- [ ] Exportação de relatórios em PDF/Excel
- [ ] API de integração com outros sistemas
- [ ] Geofencing para validação de localização

## 🧪 Testes

```bash
# Executar todos os testes
dotnet test

# Com cobertura de código
dotnet test /p:CollectCoverage=true
```

## 📝 Licença

Este projeto foi desenvolvido para fins educacionais e demonstração de habilidades técnicas.

## 👨‍💻 Autor

Desenvolvido como projeto para processos seletivos de estágio/júnior em Engenharia de Software.

---

## 🌟 Destaques Técnicos

✨ **Arquitetura Limpa** - Separação clara de responsabilidades  
✨ **SOLID Principles** - Código manutenível e escalável  
✨ **Repository Pattern** - Abstração do acesso a dados  
✨ **Dependency Injection** - Baixo acoplamento  
✨ **Async/Await** - Performance otimizada  
✨ **Entity Framework Core** - ORM moderno  
✨ **Swagger** - Documentação interativa  
✨ **JWT** - Autenticação stateless  

---

⭐ **Projeto pronto para demonstração em entrevistas técnicas!**
