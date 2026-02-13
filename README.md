# Gerenciador de Tarefas - API REST

Sistema de gerenciamento de tarefas desenvolvido com Spring Boot, demonstrando boas práticas de desenvolvimento Java para processos seletivos de estágio em Engenharia de Software.

Tecnologias Utilizadas

- **Java 17**
- **Spring Boot 3.2.0**
- **Spring Data JPA**
- **H2 Database** (banco em memória)
- **Lombok** (redução de código boilerplate)
- **Maven** (gerenciamento de dependências)
- **Swagger/OpenAPI** (documentação da API)
- **JUnit 5 & Mockito** (testes unitários)

Funcionalidades

- CRUD completo de tarefas
- Filtros por status e prioridade
- Busca por palavras-chave
- Validação de dados
- Tratamento global de exceções
- Documentação automática com Swagger
- Testes unitários
- Banco de dados em memória H2

Arquitetura

O projeto segue uma arquitetura em camadas:

```
├── controller/     # Endpoints REST
├── service/        # Regras de negócio
├── repository/     # Acesso a dados (JPA)
├── model/          # Entidades do domínio
├── dto/            # Objetos de transferência de dados
├── exception/      # Tratamento de exceções
└── config/         # Configurações da aplicação
```

Como Executar

### Pré-requisitos
- Java 17 ou superior
- Maven 3.6+

### Executando o projeto

```bash
# Compilar o projeto
mvn clean install

# Executar a aplicação
mvn spring-boot:run
```

A aplicação estará disponível em: `http://localhost:8080`

Documentação da API

Após iniciar a aplicação, acesse:

- **Swagger UI**: http://localhost:8080/swagger-ui.html
- **API Docs**: http://localhost:8080/api-docs
- **Console H2**: http://localhost:8080/h2-console

### Credenciais H2
- **JDBC URL**: `jdbc:h2:mem:tarefasdb`
- **Username**: `sa`
- **Password**: *(deixar em branco)*

Testes

```bash
# Executar todos os testes
mvn test

# Executar testes com relatório de cobertura
mvn test jacoco:report
```

Endpoints Principais

### Tarefas

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/tarefas` | Lista todas as tarefas |
| GET | `/api/tarefas/{id}` | Busca tarefa por ID |
| GET | `/api/tarefas/status/{status}` | Filtra por status |
| GET | `/api/tarefas/prioridade/{prioridade}` | Filtra por prioridade |
| GET | `/api/tarefas/buscar?termo={termo}` | Busca por termo |
| GET | `/api/tarefas/ordenadas` | Lista ordenada por prioridade |
| POST | `/api/tarefas` | Cria nova tarefa |
| PUT | `/api/tarefas/{id}` | Atualiza tarefa completa |
| PATCH | `/api/tarefas/{id}/status?status={status}` | Atualiza apenas o status |
| DELETE | `/api/tarefas/{id}` | Remove tarefa |

Exemplo de Requisição

### Criar Tarefa

```json
POST /api/tarefas
Content-Type: application/json

{
  "titulo": "Implementar nova funcionalidade",
  "descricao": "Desenvolver sistema de notificações",
  "status": "PENDENTE",
  "prioridade": "ALTA"
}
```

### Resposta de Sucesso

```json
{
  "id": 1,
  "titulo": "Implementar nova funcionalidade",
  "descricao": "Desenvolver sistema de notificações",
  "status": "PENDENTE",
  "prioridade": "ALTA",
  "dataCriacao": "2026-02-12T22:57:00",
  "dataAtualizacao": "2026-02-12T22:57:00",
  "dataConclusao": null
}
```

Características do Código

### Boas Práticas Implementadas

-  **Arquitetura em Camadas**: Separação clara de responsabilidades
-  **DTOs**: Separação entre entidades e objetos de transferência
- **Validações**: Bean Validation com anotações
-  **Tratamento de Exceções**: Handler global para erros
- **Testes Unitários**: Cobertura da camada de serviço
-  **Documentação**: Swagger/OpenAPI integrado
-  **Lombok**: Redução de código boilerplate
-  **SOLID**: Princípios aplicados
-  **Clean Code**: Código limpo e legível

Modelo de Dados

### Entidade Tarefa

```java
- id: Long (auto-gerado)
- titulo: String (obrigatório, 3-100 caracteres)
- descricao: String (opcional, max 500 caracteres)
- status: StatusTarefa (PENDENTE, EM_ANDAMENTO, CONCLUIDA, CANCELADA)
- prioridade: Prioridade (BAIXA, MEDIA, ALTA, URGENTE)
- dataCriacao: LocalDateTime (auto-gerado)
- dataAtualizacao: LocalDateTime (atualizado automaticamente)
- dataConclusao: LocalDateTime (preenchido ao concluir)
```

## Conhecimentos Demonstrados

Este projeto demonstra conhecimento em:

- Spring Framework e Spring Boot
- APIs RESTful e padrões HTTP
- JPA/Hibernate e persistência de dados
- Testes automatizados (JUnit, Mockito)
- Documentação de APIs (Swagger/OpenAPI)
- Validação de dados
- Tratamento de exceções
- Arquitetura de software
- Boas práticas de código (SOLID, Clean Code)
- Versionamento com Git

##  Melhorias Futuras

- Implementar autenticação e autorização (Spring Security)
- Adicionar paginação e ordenação
- Implementar cache com Redis
- Adicionar filtros avançados
- Implementar soft delete
- Adicionar logs estruturados
- Integração com banco de dados PostgreSQL
- Deploy em nuvem (AWS, Azure, Heroku)
- Implementar CI/CD
- Adicionar testes de integração

## 👨‍💻 Autor

Desenvolvido por Miguel-Dev💻

---

 Este projeto demonstra habilidades práticas em desenvolvimento Java/Spring Boot e está pronto para ser apresentado!
