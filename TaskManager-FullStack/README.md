# 📊 Business Dashboard - Full Stack Application

Sistema completo de Dashboard Empresarial desenvolvido com **Java Spring Boot** (Backend) e **React** (Frontend).

## 🚀 Tecnologias Utilizadas

### Backend
- **Java 17**
- **Spring Boot 3.2**
- **Spring Security + JWT**
- **Spring Data JPA**
- **H2 Database** (desenvolvimento)
- **PostgreSQL** (produção)
- **Maven**
- **Swagger/OpenAPI**

### Frontend
- **React 18**
- **TypeScript**
- **Tailwind CSS**
- **Recharts** (gráficos)
- **Axios** (HTTP client)
- **React Router**
- **React Query**

## 📋 Funcionalidades

### Dashboard Principal
- ✅ Visão geral de métricas (vendas, usuários, receita)
- ✅ Gráficos interativos (linha, barra, pizza)
- ✅ Tabelas de dados em tempo real
- ✅ Filtros por período
- ✅ Export de relatórios (PDF/Excel)

### Autenticação & Segurança
- ✅ Login/Logout com JWT
- ✅ Refresh tokens
- ✅ Roles e permissões (Admin, User, Viewer)
- ✅ Rotas protegidas

### Gestão de Usuários
- ✅ CRUD de usuários
- ✅ Atribuição de roles
- ✅ Perfil do usuário

### Relatórios
- ✅ Vendas por período
- ✅ Performance por categoria
- ✅ Ranking de produtos
- ✅ Análise de tendências

## 🏗️ Arquitetura do Projeto

```
business-dashboard/
├── backend/                    # Spring Boot API
│   ├── src/main/java/
│   │   └── com/dashboard/
│   │       ├── config/         # Configurações (Security, CORS)
│   │       ├── controller/     # REST Controllers
│   │       ├── dto/           # Data Transfer Objects
│   │       ├── entity/        # Entidades JPA
│   │       ├── repository/    # Repositórios
│   │       ├── service/       # Lógica de negócio
│   │       ├── security/      # JWT, UserDetails
│   │       └── exception/     # Tratamento de erros
│   └── src/main/resources/
│       ├── application.yml    # Configurações
│       └── data.sql          # Dados iniciais
│
└── frontend/                  # React App
    ├── public/
    ├── src/
    │   ├── components/       # Componentes React
    │   │   ├── Dashboard/
    │   │   ├── Charts/
    │   │   ├── Tables/
    │   │   └── Auth/
    │   ├── pages/           # Páginas
    │   ├── services/        # API calls
    │   ├── hooks/          # Custom hooks
    │   ├── context/        # Context API
    │   └── utils/          # Utilitários
    └── package.json
```

## 🔧 Como Executar

### Backend

```bash
cd backend
mvn clean install
mvn spring-boot:run
```

API disponível em: `http://localhost:8080`

### Frontend

```bash
cd frontend
npm install
npm start
```

App disponível em: `http://localhost:3000`

## 📡 API Endpoints

### Autenticação
```
POST   /api/auth/login       # Login
POST   /api/auth/register    # Registrar
POST   /api/auth/refresh     # Refresh token
POST   /api/auth/logout      # Logout
```

### Dashboard
```
GET    /api/dashboard/metrics           # Métricas principais
GET    /api/dashboard/sales-chart       # Dados para gráfico de vendas
GET    /api/dashboard/category-stats    # Estatísticas por categoria
GET    /api/dashboard/recent-sales      # Vendas recentes
```

### Usuários
```
GET    /api/users              # Listar usuários
GET    /api/users/{id}         # Buscar usuário
POST   /api/users              # Criar usuário
PUT    /api/users/{id}         # Atualizar usuário
DELETE /api/users/{id}         # Deletar usuário
```

### Relatórios
```
GET    /api/reports/sales?startDate=&endDate=    # Relatório de vendas
GET    /api/reports/export/pdf                   # Export PDF
GET    /api/reports/export/excel                 # Export Excel
```

## 🎨 Layout do Dashboard

### Tela Principal
```
┌─────────────────────────────────────────────────────────┐
│  Logo          Dashboard          User Menu   Logout   │
├─────────────────────────────────────────────────────────┤
│                                                         │
│  📊 Cards de Métricas                                  │
│  ┌──────────┐ ┌──────────┐ ┌──────────┐ ┌──────────┐ │
│  │ Vendas   │ │ Usuários │ │ Receita  │ │ Produtos │ │
│  │ R$ 50k   │ │   1.2k   │ │ R$ 120k  │ │   450    │ │
│  └──────────┘ └──────────┘ └──────────┘ └──────────┘ │
│                                                         │
│  📈 Gráfico de Vendas (Últimos 6 meses)               │
│  ┌─────────────────────────────────────────────────┐  │
│  │                                                   │  │
│  │     [Gráfico de Linha Interativo]               │  │
│  │                                                   │  │
│  └─────────────────────────────────────────────────┘  │
│                                                         │
│  🔥 Top Produtos        📊 Vendas por Categoria       │
│  ┌──────────────────┐  ┌────────────────────────┐    │
│  │ 1. Produto A     │  │  [Gráfico de Pizza]    │    │
│  │ 2. Produto B     │  │                        │    │
│  │ 3. Produto C     │  │                        │    │
│  └──────────────────┘  └────────────────────────┘    │
│                                                         │
└─────────────────────────────────────────────────────────┘
```

## 💾 Modelo de Dados

### User
```java
- id: Long
- username: String
- email: String
- password: String (encrypted)
- role: UserRole (ADMIN, USER, VIEWER)
- createdAt: LocalDateTime
```

### Sale
```java
- id: Long
- productName: String
- quantity: Integer
- price: BigDecimal
- totalAmount: BigDecimal
- category: String
- saleDate: LocalDateTime
- userId: Long
```

### Metric
```java
- id: Long
- metricName: String
- value: Double
- date: LocalDate
```

## 🔐 Autenticação JWT

O sistema usa JWT (JSON Web Token) para autenticação:

1. **Login**: Usuário envia credenciais
2. **Token gerado**: Backend retorna access_token e refresh_token
3. **Requisições autenticadas**: Frontend envia token no header
4. **Refresh**: Quando token expira, usa refresh_token

```javascript
// Exemplo de request autenticada
headers: {
  'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...'
}
```

## 📊 Exemplos de Dados Retornados

### Métricas Dashboard
```json
{
  "totalSales": 50000.00,
  "totalUsers": 1234,
  "totalRevenue": 120000.00,
  "totalProducts": 450,
  "salesGrowth": 15.5,
  "usersGrowth": 8.2
}
```

### Gráfico de Vendas
```json
{
  "labels": ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun"],
  "data": [12000, 15000, 18000, 22000, 25000, 30000]
}
```

## 🎯 Features Avançadas

- **Real-time updates**: WebSocket para atualização em tempo real
- **Dark mode**: Tema claro/escuro
- **Responsivo**: Funciona em mobile, tablet e desktop
- **Testes**: Testes unitários e de integração
- **CI/CD**: Pipeline configurado
- **Docker**: Containerização completa

## 🚀 Deploy

### Backend (Heroku)
```bash
heroku create business-dashboard-api
git push heroku main
```

### Frontend (Vercel/Netlify)
```bash
npm run build
vercel deploy
```

## 📝 Credenciais Padrão

Para testar o sistema:

**Admin:**
- Username: `admin`
- Password: `admin123`

**User:**
- Username: `user`
- Password: `user123`

## 🛠️ Melhorias Futuras

- [ ] Notificações push
- [ ] Export de relatórios agendados
- [ ] Integração com Google Analytics
- [ ] Dashboard customizável (drag-and-drop)
- [ ] Multi-idiomas (i18n)
- [ ] Modo offline (PWA)

## 📄 Licença

MIT License

## 👨‍💻 Autor

**Seu Nome**
- LinkedIn: [seu-perfil]
- GitHub: [seu-github]
- Email: [seu-email]

---

⭐ **Projeto desenvolvido para demonstrar habilidades Full Stack em Java e React**

## 🎓 Conhecimentos Demonstrados

- ✅ Java 17 & Spring Boot
- ✅ Spring Security & JWT
- ✅ REST API Design
- ✅ JPA & Hibernate
- ✅ React & TypeScript
- ✅ State Management
- ✅ Responsive Design
- ✅ Chart Libraries
- ✅ Clean Architecture
- ✅ Git & Version Control
