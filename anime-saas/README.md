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

Sempre quis criar um projeto que unisse minha paixão por animes com desenvolvimento backend. Anime SaaS nasceu dessa ideia - uma plataforma para gerenciar e descobrir animes, com sistema de assinaturas e controle de acesso.

O projeto começou como um desafio pessoal para aprender mais sobre Spring Security e JWT, mas acabou evoluindo para algo muito maior.

### 🎯 Por Que Este Projeto?

Queria praticar conceitos de SaaS real:
- Arquitetura escalável que eu pudesse usar em projetos profissionais
- Autenticação JWT (sempre quis implementar do zero)
- Sistema de planos de assinatura (tipo Netflix, Crunchyroll)
- Controle de acesso granular
- API REST bem estruturada

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

## 📈 Roadmap

Coisas que quero adicionar quando tiver tempo:

**Curto Prazo:**
- [ ] Sistema de notificações (push quando novo episódio sair)
- [ ] Integração com MyAnimeList API
- [ ] Sistema de pagamento com Stripe

**Médio Prazo:**
- [ ] Recomendações baseadas no histórico (estudando ML pra isso)
- [ ] App mobile - provavelmente vou fazer em React Native
- [ ] Dashboard de analytics

**Longo Prazo:**
- [ ] Sistema de fóruns/comunidade
- [ ] Chat entre usuários
- [ ] CDN para streaming (cara mas seria legal)
- [ ] Conquistas e gamificação

Se você tem ideias, abre uma issue! Sempre aberto a sugestões.

---

## 👨‍💻 Autor

Desenvolvido por **Miguel Eng**

Sou desenvolvedor backend apaixonado por criar soluções escaláveis. Este projeto foi uma jornada de aprendizado incrível!

- GitHub: [@migueleng-dev](https://github.com/migueleng-dev)
- LinkedIn: [Miguel Eng](https://linkedin.com/in/migueleng)

Se curtiu o projeto ou tem dúvidas, me chama!

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 🤝 Contribuindo

Pull requests são bem-vindos! Se encontrar bugs ou tiver sugestões:

1. Abre uma issue descrevendo o problema/ideia
2. Fork o projeto
3. Cria uma branch (`git checkout -b feature/nova-funcionalidade`)
4. Commit suas mudanças (`git commit -m 'Adiciona nova funcionalidade'`)
5. Push para a branch (`git push origin feature/nova-funcionalidade`)
6. Abre um Pull Request

Obs: Tento revisar PRs rapidinho, mas as vezes demoro uns dias (trabalho full-time). Paciência! 😅

---

## 🌟 Mostre Apoio

Se o projeto te ajudou de alguma forma:
- Dá uma ⭐️ no repositório
- Compartilha com outros devs
- Abre issues com sugestões
- Contribui com código

Qualquer apoio é muito apreciado!

---

## 📞 Dúvidas?

Tem alguma dúvida sobre o projeto?

- Abre uma [issue](https://github.com/migueleng-dev/animelist-saas/issues) com a tag `question`
- Me manda mensagem no [LinkedIn](https://linkedin.com/in/migueleng)

Tento responder o mais rápido possível!

---

<div align="center">

**Feito com ☕ e muito Java**

*Se curtiu o projeto, não esquece da ⭐!*

</div>
