# Anime SaaS Platform

Plataforma SaaS para gerenciamento e descoberta de animes com sistema de assinaturas e controle de acesso.

## Tecnologias

- Java 17
- Spring Boot 3.2.0
- Spring Security + JWT
- Spring Data JPA
- H2 Database
- PostgreSQL (produção)
- Maven
- Swagger/OpenAPI

## Funcionalidades

### Sistema de Usuários
- Registro e login com JWT
- Perfis de usuário
- Sistema de roles (USER, PREMIUM, ADMIN)
- Gerenciamento de assinaturas
- Controle de acesso por plano

### Gerenciamento de Animes
- CRUD completo de animes
- Tipos: TV, Movie, OVA, ONA, Special, Music
- Status: Em exibição, Finalizado, Em breve
- 24 gêneros disponíveis
- Sistema de episódios
- Conteúdo premium exclusivo

### Avaliações e Favoritos
- Sistema de avaliações (0-10)
- Comentários e reviews
- Lista de favoritos personalizada

### Buscas Avançadas
- Buscar por título, gênero, estúdio
- Filtrar por status e tipo
- Buscar por nota mínima
- Animes em alta

## Como Executar

### Pré-requisitos

- Java 17+
- Maven 3.6+

### Executar

```bash
mvn clean install
mvn spring-boot:run
```

A aplicação estará disponível em `http://localhost:8080`

## Endpoints Principais

### Autenticação
- `POST /api/auth/register` - Registrar usuário
- `POST /api/auth/login` - Login
- `POST /api/auth/refresh` - Refresh token

### Animes
- `GET /api/animes` - Listar todos
- `GET /api/animes/{id}` - Buscar por ID
- `POST /api/animes` - Criar (ADMIN)
- `PUT /api/animes/{id}` - Atualizar (ADMIN)
- `DELETE /api/animes/{id}` - Deletar (ADMIN)
- `GET /api/animes/genero/{genero}` - Buscar por gênero
- `GET /api/animes/trending` - Animes em alta

### Avaliações
- `POST /api/avaliacoes` - Criar avaliação
- `GET /api/avaliacoes/anime/{animeId}` - Listar por anime
- `PUT /api/avaliacoes/{id}` - Atualizar
- `DELETE /api/avaliacoes/{id}` - Deletar

### Favoritos
- `POST /api/favoritos/{animeId}` - Adicionar favorito
- `GET /api/favoritos` - Listar favoritos
- `DELETE /api/favoritos/{animeId}` - Remover favorito

## Documentação

- Swagger UI: `http://localhost:8080/swagger-ui.html`
- Console H2: `http://localhost:8080/h2-console`

### Conexão H2

- JDBC URL: `jdbc:h2:mem:animesaasdb`
- Username: `sa`
- Password: (vazio)

## Estrutura do Projeto

```
anime-saas/
├── src/main/java/com/anime/saas/
│   ├── config/          # Configurações (Security, JWT, Swagger)
│   ├── controller/      # Controllers REST
│   ├── dto/             # DTOs
│   ├── exception/       # Tratamento de exceções
│   ├── model/           # Entidades JPA
│   ├── repository/      # Repositories
│   ├── security/        # Filtros e utilitários JWT
│   └── service/         # Camada de serviço
└── pom.xml
```

## Planos de Assinatura

### FREE
- Acesso a animes básicos
- Avaliações e favoritos limitados

### PREMIUM
- Acesso a todo conteúdo
- Avaliações e favoritos ilimitados
- Sem anúncios

### ADMIN
- Acesso total
- Gerenciamento de conteúdo

## Exemplo de Uso

### Registrar usuário

```bash
curl -X POST http://localhost:8080/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "usuario",
    "email": "usuario@email.com",
    "password": "senha123",
    "planoAssinatura": "FREE"
  }'
```

### Login

```bash
curl -X POST http://localhost:8080/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "username": "usuario",
    "password": "senha123"
  }'
```

### Buscar animes

```bash
curl http://localhost:8080/api/animes \
  -H "Authorization: Bearer {token}"
```

## Licença

MIT
