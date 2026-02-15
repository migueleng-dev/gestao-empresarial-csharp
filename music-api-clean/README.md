# Music API

API REST para gerenciamento de músicas desenvolvida em Java com Spring Boot.

## Tecnologias

- Java 17
- Spring Boot 3.2.0
- Spring Data JPA
- H2 Database
- Maven
- Swagger/OpenAPI

## Funcionalidades

- CRUD completo de músicas
- Busca por artista, gênero, álbum e ano
- Busca por termo (título, artista ou álbum)
- Validação de dados
- Documentação interativa com Swagger

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

### Músicas

- `GET /api/musicas` - Listar todas
- `GET /api/musicas/{id}` - Buscar por ID
- `POST /api/musicas` - Criar música
- `PUT /api/musicas/{id}` - Atualizar
- `DELETE /api/musicas/{id}` - Deletar
- `GET /api/musicas/artista/{artista}` - Buscar por artista
- `GET /api/musicas/genero/{genero}` - Buscar por gênero
- `GET /api/musicas/buscar?termo={termo}` - Busca geral

## Documentação

- Swagger UI: `http://localhost:8080/swagger-ui.html`
- Console H2: `http://localhost:8080/h2-console`

### Conexão H2

- JDBC URL: `jdbc:h2:mem:musicdb`
- Username: `sa`
- Password: (vazio)

## Estrutura do Projeto

```
music-api/
├── src/main/java/com/music/api/
│   ├── config/          # Configurações
│   ├── controller/      # Controllers REST
│   ├── dto/             # DTOs
│   ├── exception/       # Tratamento de exceções
│   ├── model/           # Entidades JPA
│   ├── repository/      # Repositories
│   └── service/         # Camada de serviço
└── pom.xml
```

## Exemplo de Uso

### Criar música

```bash
curl -X POST http://localhost:8080/api/musicas \
  -H "Content-Type: application/json" \
  -d '{
    "titulo": "Águas de Março",
    "artista": "Tom Jobim",
    "album": "Matita Perê",
    "anoLancamento": 1973,
    "genero": "BOSSA_NOVA",
    "duracaoSegundos": 180
  }'
```

## Licença

MIT
