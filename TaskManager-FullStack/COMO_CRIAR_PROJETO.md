# 🚀 Como Criar o Projeto Business Dashboard Full Stack

## 📋 Pré-requisitos
- Java 17+
- Node.js 18+
- Maven
- Git

---

## 🔧 PASSO 1: Criar Backend Spring Boot

### 1.1 Criar projeto via Spring Initializr

Acesse: https://start.spring.io/

**Configurações:**
- Project: Maven
- Language: Java
- Spring Boot: 3.2.0
- Group: com.dashboard
- Artifact: business-dashboard
- Java: 17

**Dependencies:**
- Spring Web
- Spring Data JPA
- Spring Security
- H2 Database
- Lombok

### 1.2 Estrutura de Diretórios

```
backend/
└── src/main/java/com/dashboard/
    ├── Application.java
    ├── config/
    │   ├── SecurityConfig.java
    │   └── CorsConfig.java
    ├── controller/
    │   ├── AuthController.java
    │   ├── DashboardController.java
    │   └── UserController.java
    ├── dto/
    │   ├── LoginRequest.java
    │   ├── AuthResponse.java
    │   ├── DashboardMetrics.java
    │   └── SalesData.java
    ├── entity/
    │   ├── User.java
    │   └── Sale.java
    ├── repository/
    │   ├── UserRepository.java
    │   └── SaleRepository.java
    ├── service/
    │   ├── AuthService.java
    │   ├── DashboardService.java
    │   └── UserService.java
    └── security/
        ├── JwtUtils.java
        └── UserDetailsServiceImpl.java
```

---

## 🎨 PASSO 2: Criar Frontend React

### 2.1 Criar projeto React com TypeScript

```bash
npx create-react-app frontend --template typescript
cd frontend
```

### 2.2 Instalar dependências

```bash
npm install axios react-router-dom
npm install recharts
npm install @heroicons/react
npm install tailwindcss postcss autoprefixer
npx tailwindcss init -p
```

### 2.3 Estrutura de Diretórios

```
frontend/
└── src/
    ├── components/
    │   ├── Dashboard/
    │   │   ├── MetricCard.tsx
    │   │   ├── SalesChart.tsx
    │   │   └── RecentSales.tsx
    │   ├── Auth/
    │   │   ├── Login.tsx
    │   │   └── PrivateRoute.tsx
    │   └── Layout/
    │       ├── Sidebar.tsx
    │       └── Header.tsx
    ├── pages/
    │   ├── Dashboard.tsx
    │   ├── Users.tsx
    │   └── Reports.tsx
    ├── services/
    │   ├── api.ts
    │   └── authService.ts
    ├── context/
    │   └── AuthContext.tsx
    ├── types/
    │   └── index.ts
    └── App.tsx
```

---

## 💾 PASSO 3: Código dos Principais Arquivos

### Backend - Application.java
```java
package com.dashboard;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class Application {
    public static void main(String[] args) {
        SpringApplication.run(Application.class, args);
    }
}
```

### Backend - DashboardController.java
```java
package com.dashboard.controller;

import org.springframework.web.bind.annotation.*;
import java.util.*;

@RestController
@RequestMapping("/api/dashboard")
@CrossOrigin(origins = "http://localhost:3000")
public class DashboardController {

    @GetMapping("/metrics")
    public Map<String, Object> getMetrics() {
        Map<String, Object> metrics = new HashMap<>();
        metrics.put("totalSales", 50000.00);
        metrics.put("totalUsers", 1234);
        metrics.put("totalRevenue", 120000.00);
        metrics.put("totalProducts", 450);
        metrics.put("salesGrowth", 15.5);
        return metrics;
    }

    @GetMapping("/sales-chart")
    public Map<String, Object> getSalesChart() {
        Map<String, Object> chart = new HashMap<>();
        chart.put("labels", Arrays.asList("Jan", "Fev", "Mar", "Abr", "Mai", "Jun"));
        chart.put("data", Arrays.asList(12000, 15000, 18000, 22000, 25000, 30000));
        return chart;
    }
}
```

### Frontend - Dashboard.tsx
```typescript
import React, { useEffect, useState } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip } from 'recharts';
import api from '../services/api';

interface Metrics {
  totalSales: number;
  totalUsers: number;
  totalRevenue: number;
  totalProducts: number;
  salesGrowth: number;
}

const Dashboard: React.FC = () => {
  const [metrics, setMetrics] = useState<Metrics | null>(null);
  const [chartData, setChartData] = useState<any[]>([]);

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    const metricsRes = await api.get('/dashboard/metrics');
    const chartRes = await api.get('/dashboard/sales-chart');
    
    setMetrics(metricsRes.data);
    
    const formatted = chartRes.data.labels.map((label: string, index: number) => ({
      name: label,
      vendas: chartRes.data.data[index]
    }));
    setChartData(formatted);
  };

  if (!metrics) return <div>Carregando...</div>;

  return (
    <div className="p-6">
      <h1 className="text-3xl font-bold mb-6">Dashboard</h1>
      
      {/* Cards de Métricas */}
      <div className="grid grid-cols-4 gap-4 mb-8">
        <MetricCard title="Vendas" value={`R$ ${metrics.totalSales.toLocaleString()}`} />
        <MetricCard title="Usuários" value={metrics.totalUsers} />
        <MetricCard title="Receita" value={`R$ ${metrics.totalRevenue.toLocaleString()}`} />
        <MetricCard title="Produtos" value={metrics.totalProducts} />
      </div>

      {/* Gráfico */}
      <div className="bg-white p-6 rounded-lg shadow">
        <h2 className="text-xl font-semibold mb-4">Vendas - Últimos 6 Meses</h2>
        <LineChart width={800} height={300} data={chartData}>
          <CartesianGrid strokeDasharray="3 3" />
          <XAxis dataKey="name" />
          <YAxis />
          <Tooltip />
          <Line type="monotone" dataKey="vendas" stroke="#8884d8" strokeWidth={2} />
        </LineChart>
      </div>
    </div>
  );
};

const MetricCard: React.FC<{ title: string; value: number | string }> = ({ title, value }) => (
  <div className="bg-white p-6 rounded-lg shadow">
    <h3 className="text-gray-500 text-sm">{title}</h3>
    <p className="text-2xl font-bold mt-2">{value}</p>
  </div>
);

export default Dashboard;
```

### Frontend - api.ts
```typescript
import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:8080/api',
  headers: {
    'Content-Type': 'application/json'
  }
});

api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default api;
```

---

## ▶️ PASSO 4: Rodar o Projeto

### Backend
```bash
cd backend
mvn clean install
mvn spring-boot:run
```
Disponível em: http://localhost:8080

### Frontend
```bash
cd frontend
npm install
npm start
```
Disponível em: http://localhost:3000

---

## 📸 Screenshots para o LinkedIn

### Dashboard Principal
- Cards com métricas
- Gráfico de linha
- Tabela de dados

### Features para Destacar
- ✅ Full Stack (Java + React)
- ✅ API REST
- ✅ Gráficos interativos
- ✅ Design responsivo
- ✅ Autenticação JWT
- ✅ Clean Architecture

---

## 🚀 Próximos Passos

1. Adicionar mais gráficos (pizza, barra)
2. Implementar CRUD de usuários
3. Adicionar filtros de data
4. Export de relatórios
5. Testes unitários
6. Deploy (Heroku + Vercel)

---

## 📦 Como Adicionar ao GitHub

```bash
git init
git add .
git commit -m "feat: business dashboard full stack"
git branch -M main
git remote add origin https://github.com/seu-usuario/business-dashboard.git
git push -u origin main
```

---

**🎯 Projeto pronto para o LinkedIn!**
