![.NET](https://img.shields.io/badge/.NET%208-blueviolet?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-In%20Development-orange?style=for-the-badge)


# 🎥 CreatorFlow API

A **REST API for content creators** to organize projects, plan videos/streams/posts, track schedules, and measure productivity — built with **.NET 8**, **EF Core**, **JWT Authentication**, and **clean architecture practices**.

---

## 🚀 Project Purpose

CreatorFlow API is designed as a productivity tool for creators who manage multiple content platforms.  
It allows users to:

- Create and manage **projects** (e.g., YouTube channel, TikTok series, Twitch streams).
- Organize all their **content items** (videos, shorts, livestreams, posts).
- Generate a **publication schedule**.
- Check **productivity and performance stats**.
- Use a clean, professional API built with real-world patterns.

Perfect for building a strong backend portfolio piece.

---

## 🧱 Technologies

- **.NET 8 (ASP.NET Core Web API)**
- **Entity Framework Core** (SQL Server)
- **JWT Bearer Authentication**
- **AutoMapper**
- **Swagger / OpenAPI**
- **Repository + Service Pattern**
- **System.Text.Json** DTO-based serialization

---

## 📂 Project Architecture

Simplified structure:

CreatorFlowApi/
├─ Controllers/
│ ├─ AuthController.cs
│ ├─ UsersController.cs
│ ├─ ProjectsController.cs
│ ├─ ContentController.cs
│ └─ StatsController.cs
│
├─ Data/
│ └─ CreatorFlowDbContext.cs
│
├─ DTOs/
│ ├─ Users/
│ ├─ Projects/
│ ├─ Content/
│ └─ Stats/
│
├─ Entities/
│ ├─ User.cs
│ ├─ Project.cs
│ └─ ContentItem.cs
│
├─ Mapping/
│ └─ MappingProfile.cs
│
├─ Repositories/
│ ├─ IRepository.cs
│ ├─ Repository.cs
│ ├─ Users/
│ ├─ Projects/
│ └─ Content/
│
├─ Security/
│ ├─ PasswordHasher.cs
│ └─ ClaimsExtensions.cs
│
├─ Services/
│ ├─ Auth/
│ └─ Stats/
│
└─ Program.cs


### Architecture Highlights

- **Entities** → domain models  
- **DTOs** → API-safe models  
- **Repositories** → data layer  
- **Services** → business logic  
- **Controllers** → orchestrators for HTTP routes  

---

## ⚙️ Setup & Installation

### 1️⃣ Requirements

- .NET 8 SDK  
- SQL Server  
- Visual Studio / VS Code / Rider  

### 2️⃣ Clone the repository

```bash
git clone https://github.com/your-username/creatorflow-api.git
cd creatorflow-api
```

### 3️⃣ Configure appsettings.json

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CreatorFlowDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "CHANGE_THIS_TO_A_LONG_SECURE_KEY",
    "Issuer": "CreatorFlowApi",
    "Audience": "CreatorFlowUsers",
    "ExpiresInMinutes": 60
  }
}


### 4️⃣ Apply database migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```


---

## 🤝 Contributing

Contributions are welcome!  
If you'd like to improve the project, feel free to submit a PR or open an issue.

---

## 📄 License

This project is licensed under the **MIT License**.

---

## 👤 Author

**Johan Franco**  
Full Stack developer  
GitHub: https://github.com/JohanFranco 

