# Music API

API REST para gerenciamento de músicas desenvolvida em Java com Spring Boot.

## Tecnologias Utilizadas

- Java 17
- Spring Boot 3.2.0
- Spring Data JPA
- Spring Validation
- H2 Database (banco em memória)
- Lombok
- SpringDoc OpenAPI (Swagger)
- Maven

## Funcionalidades

- CRUD completo de músicas
- Busca por artista, gênero, álbum e ano
- Busca por termo (título, artista ou álbum)
- Busca por período de anos
- Validação de dados
- Tratamento de erros
- Documentação interativa com Swagger
- Console H2 para visualização do banco

## Estrutura do Projeto

```
music-api/
├── src/
│   ├── main/
│   │   ├── java/com/music/api/
│   │   │   ├── config/          # Configurações (Swagger)
│   │   │   ├── controller/      # Controllers REST
│   │   │   ├── dto/             # Data Transfer Objects
│   │   │   ├── exception/       # Tratamento de exceções
│   │   │   ├── model/           # Entidades JPA
│   │   │   ├── repository/      # Repositories
│   │   │   ├── service/         # Camada de serviço
│   │   │   └── MusicApiApplication.java
│   │   └── resources/
│   │       ├── application.properties
│   │       └── data.sql         # Dados iniciais
│   └── test/
└── pom.xml
```

## Como Executar

### Pré-requisitos

- Java 17 ou superior
- Maven 3.6 ou superior

### Passos

1. Clone o repositório e navegue até o diretório do projeto:
```bash
cd music-api
```

2. Compile o projeto:
```bash
mvn clean install
```

3. Execute a aplicação:
```bash
mvn spring-boot:run
```

A aplicação estará disponível em: `http://localhost:8080`

## Endpoints da API

### Músicas

- **GET** `/api/musicas` - Lista todas as músicas
- **GET** `/api/musicas/{id}` - Busca música por ID
- **POST** `/api/musicas` - Cria nova música
- **PUT** `/api/musicas/{id}` - Atualiza música
- **DELETE** `/api/musicas/{id}` - Deleta música
- **GET** `/api/musicas/artista/{artista}` - Busca por artista
- **GET** `/api/musicas/genero/{genero}` - Busca por gênero
- **GET** `/api/musicas/album/{album}` - Busca por álbum
- **GET** `/api/musicas/ano/{ano}` - Busca por ano
- **GET** `/api/musicas/buscar?termo={termo}` - Busca por termo
- **GET** `/api/musicas/periodo?anoInicio={ano}&anoFim={ano}` - Busca por período

## Documentação Swagger

Acesse a documentação interativa em: `http://localhost:8080/swagger-ui.html`

## Console H2

Acesse o console do banco H2 em: `http://localhost:8080/h2-console`

**Configurações de conexão:**
- JDBC URL: `jdbc:h2:mem:musicdb`
- Username: `sa`
- Password: (deixe em branco)

## Gêneros Musicais Disponíveis

- ROCK
- POP
- JAZZ
- BLUES
- ELETRONICA
- CLASSICA
- RAP
- HIPHOP
- REGGAE
- COUNTRY
- SAMBA
- BOSSA_NOVA
- MPB
- FUNK
- SERTANEJO
- FORRO
- AXIE
- PAGODE
- OUTRO

## Exemplo de Requisição

### Criar uma nova música

```bash
curl -X POST http://localhost:8080/api/musicas \
  -H "Content-Type: application/json" \
  -d '{
    "titulo": "Águas de Março",
    "artista": "Tom Jobim",
    "album": "Matita Perê",
    "anoLancamento": 1973,
    "genero": "BOSSA_NOVA",
    "duracaoSegundos": 180,
    "letra": "É pau, é pedra, é o fim do caminho..."
  }'
```

### Buscar músicas por gênero

```bash
curl http://localhost:8080/api/musicas/genero/ROCK
```

### Buscar músicas por termo

```bash
curl http://localhost:8080/api/musicas/buscar?termo=love
```

## Validações

- Título: obrigatório, 1-200 caracteres
- Artista: obrigatório, 1-200 caracteres
- Álbum: opcional, máximo 200 caracteres
- Ano de lançamento: entre 1900 e 2100
- Gênero: obrigatório
- Duração: entre 1 e 7200 segundos
- Letra: opcional

## Dados de Teste

A aplicação já vem com dados de exemplo carregados automaticamente, incluindo músicas clássicas como:
- Bohemian Rhapsody (Queen)
- Imagine (John Lennon)
- Garota de Ipanema (Tom Jobim)
- Hotel California (Eagles)
- E outras...

## Níveis de Habilidade

Esta API foi desenvolvida para nível **Pleno/Júnior** e demonstra:

✅ Arquitetura em camadas (Controller, Service, Repository)
✅ DTOs para separação de responsabilidades
✅ Validações com Bean Validation
✅ Tratamento global de exceções
✅ Documentação com Swagger
✅ Uso de JPA/Hibernate
✅ Queries customizadas
✅ Boas práticas REST
✅ Uso de Lombok
✅ Testes preparados

## Próximos Passos

Para evoluir este projeto:

1. Adicionar testes unitários e de integração
2. Implementar paginação e ordenação
3. Adicionar autenticação e autorização (Spring Security)
4. Migrar para banco de dados persistente (PostgreSQL, MySQL)
5. Adicionar cache (Redis)
6. Implementar upload de arquivos de áudio
7. Criar playlists
8. Adicionar sistema de favoritos
9. Implementar rate limiting
10. Adicionar logs estruturados

## Autor

Desenvolvido como exemplo de API REST em Java/Spring Boot
