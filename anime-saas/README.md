# 🎌 Anime SaaS Platform

<div align="center">

![Java](https://img.shields.io/badge/Java-17-orange?style=for-the-badge&logo=java)
![Spring Boot](https://img.shields.io/badge/Spring%20Boot-3.2.0-brightgreen?style=for-the-badge&logo=spring)
![JWT](https://img.shields.io/badge/JWT-Authentication-blue?style=for-the-badge&logo=json-web-tokens)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

**Plataforma SaaS completa para gerenciamento e descoberta de animes**

[Documentação](#documentação) • [Instalação](#como-executar) • [API](#endpoints) • [Features](#funcionalidades)

</div>

---

## 📋 Sobre o Projeto

Anime SaaS é uma plataforma completa de Software como Serviço (SaaS) para gerenciamento, descoberta e avaliação de animes. O sistema implementa autenticação JWT, planos de assinatura, sistema de favoritos e avaliações.

### 🎯 Propósito

Demonstrar a construção de uma aplicação SaaS real com:
- Arquitetura escalável e profissional
- Autenticação e autorização JWT
- Sistema de assinaturas (Free, Basic, Premium, Enterprise)
- Controle de acesso baseado em planos
- API RESTful completa e documentada

---

## ✨ Funcionalidades

### 👤 Sistema de Usuários
- ✅ Registro e login com JWT
- ✅ Perfis de usuário personalizáveis
- ✅ Sistema de roles (USER, PREMIUM, ADMIN)
- ✅ Gerenciamento de assinaturas
- ✅ Controle de acesso baseado em plano

### 🎬 Gerenciamento de Animes
- ✅ CRUD completo de animes
- ✅ Múltiplos tipos (TV, Movie, OVA, ONA, Special, Music)
- ✅ Status de exibição (Em exibição, Finalizado, Em breve)
- ✅ 24 gêneros disponíveis
- ✅ Sistema de episódios
- ✅ Informações detalhadas (sinopse, estúdio, temporada)
- ✅ Conteúdo premium exclusivo

### ⭐ Sistema de Avaliações
- ✅ Avaliação com notas (0-10)
- ✅ Comentários e reviews
- ✅ Cálculo automático de média
- ✅ Uma avaliação por usuário por anime

### ❤️ Favoritos
- ✅ Lista personalizada de favoritos
- ✅ Adicionar/remover favoritos
- ✅ Visualizar todos os favoritos

### 🔍 Buscas Avançadas
- ✅ Buscar por título, gênero, estúdio
- ✅ Filtrar por status e tipo
- ✅ Buscar por nota mínima
- ✅ Ordenação customizada
- ✅ Animes em alta

### 🔐 Autenticação & Segurança
- ✅ JWT (JSON Web Tokens)
- ✅ Senhas criptografadas (BCrypt)
- ✅ Refresh tokens
- ✅ Controle de sessão
- ✅ Proteção de endpoints por plano

---

## 🛠️ Stack Tecnológico

### Backend
- **Java 17** - Linguagem de programação
- **Spring Boot 3.2.0** - Framework principal
- **Spring Security** - Autenticação e autorização
- **Spring Data JPA** - Persistência de dados
- **JWT (jjwt 0.12.3)** - Tokens de autenticação
- **H2 Database** - Banco em memória (desenvolvimento)
- **PostgreSQL** - Banco de dados (produção)
- **Maven** - Gerenciador de dependências
- **Lombok** - Redução de boilerplate
- **Swagger/OpenAPI** - Documentação da API

---

## 📐 Arquitetura

```
┌─────────────────────────────────────────────────────────┐
│                    CLIENT (Frontend)                     │
└──────────────────────┬──────────────────────────────────┘
                       │ HTTP/REST + JWT
┌──────────────────────┴──────────────────────────────────┐
│                  API Layer (Controllers)                 │
│  ┌─────────────┬──────────────┬──────────────────────┐  │
│  │   Auth      │    Anime     │   User & Reviews    │  │
│  └─────────────┴──────────────┴──────────────────────┘  │
└──────────────────────┬──────────────────────────────────┘
                       │
┌──────────────────────┴──────────────────────────────────┐
│                 Service Layer (Business Logic)           │
│  ┌─────────────┬──────────────┬──────────────────────┐  │
│  │ AuthService │ AnimeService │  UserService         │  │
│  └─────────────┴──────────────┴──────────────────────┘  │
└──────────────────────┬──────────────────────────────────┘
                       │
┌──────────────────────┴──────────────────────────────────┐
│              Repository Layer (Data Access)              │
│  ┌─────────────┬──────────────┬──────────────────────┐  │
│  │   Usuario   │    Anime     │    Avaliacao         │  │
│  └─────────────┴──────────────┴──────────────────────┘  │
└──────────────────────┬──────────────────────────────────┘
                       │
┌──────────────────────┴──────────────────────────────────┐
│                    Database (H2/PostgreSQL)              │
└──────────────────────────────────────────────────────────┘
```

---

## 🚀 Como Executar

### Pré-requisitos
- Java 17 ou superior
- Maven 3.6 ou superior

### Instalação

1. **Clone o repositório**
```bash
git clone https://github.com/migueleng-dev/anime-saas.git
cd anime-saas
```

2. **Compile o projeto**
```bash
mvn clean install
```

3. **Execute a aplicação**
```bash
mvn spring-boot:run
```

A aplicação estará disponível em: `http://localhost:8080`

---

## 📡 Endpoints

### 🔐 Autenticação

```http
POST   /api/auth/register     - Registrar novo usuário
POST   /api/auth/login        - Login (retorna JWT token)
POST   /api/auth/refresh      - Refresh token
GET    /api/auth/me           - Dados do usuário logado
```

### 🎬 Animes

```http
GET    /api/animes                    - Listar todos os animes
GET    /api/animes/{id}               - Buscar anime por ID
POST   /api/animes                    - Criar anime (ADMIN)
PUT    /api/animes/{id}               - Atualizar anime (ADMIN)
DELETE /api/animes/{id}               - Deletar anime (ADMIN)
GET    /api/animes/search             - Buscar animes (filtros)
GET    /api/animes/genero/{genero}    - Buscar por gênero
GET    /api/animes/top                - Top animes por nota
GET    /api/animes/{id}/episodios     - Listar episódios
```

### ⭐ Avaliações

```http
POST   /api/avaliacoes/anime/{animeId}     - Avaliar anime
PUT    /api/avaliacoes/{id}                 - Atualizar avaliação
DELETE /api/avaliacoes/{id}                 - Deletar avaliação
GET    /api/avaliacoes/anime/{animeId}     - Ver avaliações do anime
GET    /api/avaliacoes/usuario/{usuarioId} - Avaliações do usuário
```

### ❤️ Favoritos

```http
POST   /api/favoritos/{animeId}    - Adicionar aos favoritos
DELETE /api/favoritos/{animeId}    - Remover dos favoritos
GET    /api/favoritos              - Listar meus favoritos
```

### 👤 Usuários

```http
GET    /api/usuarios/me          - Meu perfil
PUT    /api/usuarios/me          - Atualizar perfil
PUT    /api/usuarios/me/senha    - Alterar senha
GET    /api/usuarios/{id}        - Ver perfil público
POST   /api/usuarios/upgrade     - Upgrade de plano (ADMIN)
```

---

## 📊 Modelos de Dados

### Usuario
- ID, username, email, senha
- Role (USER, PREMIUM, ADMIN)
- Plano de assinatura (FREE, BASIC, PREMIUM, ENTERPRISE)
- Data de expiração do plano
- Favoritos, avaliações

### Anime
- ID, título (português, inglês, japonês)
- Sinopse, tipo, status
- Datas de lançamento e finalização
- Número de episódios, duração
- Estúdio, temporada, gêneros
- URLs (poster, trailer)
- Nota média, total de avaliações
- Flag premium only

### Episodio
- ID, anime, número
- Título, descrição
- Duração, data de lançamento
- URLs (vídeo, thumbnail)
- Flag premium only

### Avaliacao
- ID, usuário, anime
- Nota (0-10), comentário
- Datas de criação e atualização

---

## 🎯 Planos de Assinatura

| Recurso | FREE | BASIC | PREMIUM | ENTERPRISE |
|---------|------|-------|---------|------------|
| Animes gratuitos | ✅ | ✅ | ✅ | ✅ |
| Avaliações | ✅ | ✅ | ✅ | ✅ |
| Favoritos | Até 10 | Ilimitado | Ilimitado | Ilimitado |
| Animes premium | ❌ | Limitado | ✅ | ✅ |
| Sem anúncios | ❌ | ❌ | ✅ | ✅ |
| Download offline | ❌ | ❌ | ✅ | ✅ |
| Múltiplos perfis | ❌ | ❌ | ❌ | ✅ |
| Suporte prioritário | ❌ | ❌ | ❌ | ✅ |

---

## 🔐 Segurança

- **Autenticação JWT**: Tokens seguros com expiração
- **BCrypt**: Hash de senhas com salt
- **CORS**: Configuração de origens permitidas
- **HTTPS**: Recomendado em produção
- **Rate Limiting**: Proteção contra abuso (a implementar)
- **SQL Injection**: Prevenido pelo JPA/Hibernate

---

## 📚 Documentação da API

Acesse a documentação interativa Swagger:
```
http://localhost:8080/swagger-ui.html
```

Documentação JSON da API:
```
http://localhost:8080/api-docs
```

---

## 🧪 Testes

```bash
mvn test
```

---

## 🗄️ Banco de Dados

### Desenvolvimento (H2)
Console H2: `http://localhost:8080/h2-console`
- JDBC URL: `jdbc:h2:mem:animedb`
- Username: `sa`
- Password: (vazio)

### Produção (PostgreSQL)
Configure no `application.properties`:
```properties
spring.datasource.url=jdbc:postgresql://localhost:5432/animedb
spring.datasource.username=seu_usuario
spring.datasource.password=sua_senha
spring.jpa.hibernate.ddl-auto=update
```

---

## 🎨 Gêneros Disponíveis

- Ação, Aventura, Comédia, Drama
- Fantasia, Horror, Mistério, Romance
- Ficção Científica, Slice of Life
- Esportes, Sobrenatural, Thriller
- Seinen, Shounen, Shoujo, Josei
- Mecha, Isekai, Magia, Militar
- Musical, Psicológico, Histórico

---

## 📈 Próximas Features

- [ ] Sistema de notificações
- [ ] Recomendações personalizadas (ML)
- [ ] Chat entre usuários
- [ ] Fóruns de discussão
- [ ] Sistema de conquistas
- [ ] Estatísticas de visualização
- [ ] Integração com APIs externas (MyAnimeList, AniList)
- [ ] Sistema de pagamento (Stripe/PagSeguro)
- [ ] App mobile (React Native)
- [ ] CDN para streaming
- [ ] Sistema de legendas
- [ ] Modo offline

---

## 👨‍💻 Desenvolvido por

**Miguel Eng**
- GitHub: [@migueleng-dev](https://github.com/migueleng-dev)
- LinkedIn: [Miguel Eng](https://linkedin.com/in/migueleng)

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Veja [CONTRIBUTING.md](CONTRIBUTING.md) para detalhes.

---

## 🌟 Mostre seu apoio

Se este projeto te ajudou, dê uma ⭐️!

---

## 📞 Suporte

- Abra uma [issue](https://github.com/migueleng-dev/anime-saas/issues)
- Entre em contato: dev@animesaas.com

---

<div align="center">

**Feito com ❤️ e Java**

</div>
