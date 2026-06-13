# DevHunter: Job Finder System

Welcome to **DevHunter** - a dynamic web application developed as part of my graduation project. This project demonstrates key principles of ASP.NET development and modern web practices.

The project was later refactored to improve security, code quality, query performance, and test reliability while preserving its original UI and features.

## 📝 Overview

**DevHunter** is a comprehensive job-finding platform built using **ASP.NET MVC**, **C#**, **SQL Server**, and **Entity Framework Core**. It was created as part of a graduation project to showcase modern web development techniques, including database integration, user authentication, and rich interactive features.

## 📅 Description

**Project Duration:** December 2023 - May 2024  
**Technologies Used:** C#, ASP.NET MVC, SQL Server, Entity Framework Core

This web application is designed to facilitate job searches by enabling job seekers to browse listings, submit applications, and save jobs. It also allows companies to post and manage their own job offers, while administrators oversee the system.

## 🚀 Key Features

- 🔒 **User Authentication:** Secure login for companies, job seekers, and administrators.
- 💼 **Job Interaction:** Users can explore job offers, apply to positions, and save jobs for later.
- 🏢 **Company Dashboard:** Employers can create, update, and manage their own job listings and company profiles.
- 🛠 **Admin Dashboard:** Administrators can manage users, companies, technologies, and development categories.

## ⚙️ Advanced Features

- 📝 **Rich Text Job Descriptions:** Detailed formatting with server-side HTML sanitization.
- 🏷 **Tag Suggestions:** Multi-select technology tags for job listings and searches.
- 🔍 **Dynamic Filtering & Search:** Job search with filtering and server-side pagination.
- 📩 **Contact Page:** Users can send direct messages through configured SMTP email.
- ☁️ **Cloud Uploads:** Images and application documents can be uploaded through Cloudinary.

## 📸 Screenshots

### 🏠 Home Page

<p align="center">
  <img src="docs/common/FireShot%20Capture%20045%20-%20-%20DevHunter%20-%20localhost.png" width="300px" height="150px" alt="DevHunter home page" />
  <img src="docs/common/FireShot%20Capture%20046%20-%20-%20DevHunter%20-%20localhost.png" width="300px" height="150px" alt="DevHunter home page features"/>
</p>

### 💼 Job Offers

<p align="center">
  <img src="docs/common/FireShot%20Capture%20047%20-%20-%20DevHunter%20-%20localhost.png" width="300px" height="150px" alt="DevHunter job offers"/>
  <img src="docs/common/FireShot%20Capture%20048%20-%20-%20DevHunter%20-%20localhost.png" width="300px" height="150px" alt="DevHunter job offer details"/>
  <img src="docs/common/FireShot%20Capture%20051%20-%20-%20DevHunter%20-%20localhost.png" width="300px" height="150px" alt="DevHunter job search"/>
</p>

### 🛠 Admin Panel

<p align="center">
  <img src="docs/admin/FireShot%20Capture%20049%20-%20-%20DevHunter%20-%20localhost.png" width="300px" height="150px" alt="DevHunter admin panel"/>
  <img src="docs/company/FireShot%20Capture%20050%20-%20-%20DevHunter%20-%20localhost.png" width="300px" height="150px" alt="DevHunter company panel"/>
</p>

### 😎 Use Case Diagram

<p align="center">
  <img src="docs/Use%20Case%20Diagram.png" alt="DevHunter use case diagram"/>
</p>

## 🚀 Getting Started

### Requirements

- .NET SDK with .NET 6 targeting support
- SQL Server or SQL Server Express
- Cloudinary account
- SMTP account for the contact form

### Setup

1. Clone the repository and open the `src/DevHunter.sln` solution.
2. Review the required configuration keys in [`src/DevHunter.Web/appsettings.example.json`](src/DevHunter.Web/appsettings.example.json).
3. Store real credentials using .NET user-secrets or environment variables. Do not commit credentials to `appsettings.json`.
4. Restore dependencies, build the solution, and run the web project.

```powershell
cd src
dotnet restore DevHunter.sln

cd DevHunter.Web
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "your-sql-server-connection-string"
dotnet user-secrets set "AccountSettings:CloudName" "your-cloud-name"
dotnet user-secrets set "AccountSettings:ApiKey" "your-cloudinary-api-key"
dotnet user-secrets set "AccountSettings:ApiSecret" "your-cloudinary-api-secret"
dotnet user-secrets set "EmailConfiguration:To" "recipient@example.com"
dotnet user-secrets set "EmailConfiguration:SmtpServer" "smtp.example.com"
dotnet user-secrets set "EmailConfiguration:Port" "465"
dotnet user-secrets set "EmailConfiguration:Username" "smtp-user@example.com"
dotnet user-secrets set "EmailConfiguration:Password" "your-smtp-password"

dotnet run
```

The application applies database migrations and seeds development data during startup.

### Demo Accounts

Recruiters and reviewers can use these seeded development accounts to explore the application:

**Administrator**

- Email: `admin@gmail.com`
- Password: `Admin12345678!`

**Job Seeker**

- Email: `defi@gmail.com`
- Password: `123456`

These credentials are intended only for the seeded local demo environment and must not be used in production.

## 🧪 Build and Tests

Run the following commands from the `src` directory:

```powershell
dotnet build DevHunter.sln
dotnet test DevHunter.Services.Tests/DevHunter.Services.Tests.csproj
```

The service tests cover job filtering, pagination, salary formatting, saved jobs, creating and editing job offers, ownership checks, and HTML sanitization.

## 💻 Usage

Feel free to explore the codebase by cloning or downloading this repository. This project provides a hands-on example of ASP.NET concepts, database integration, authentication, service-layer testing, and interactive web application development.

## 🔮 Future Improvements

- Upgrade the project from .NET 6 to a supported .NET release.
- Update packages with outstanding security advisories.
- Add integration tests for controller authorization workflows.
- Add continuous integration checks for formatting, builds, and tests.

## 🤝 Contributing

Contributions to this project are welcome! If you find bugs, security vulnerabilities, or have suggestions for improvements, please open an issue or submit a pull request.

## 📜 Credits

This project was developed and is maintained by Hristian Ivanov. It was created as part of my school graduation project and later refactored for better code quality.

![GitHub repo size](https://img.shields.io/github/repo-size/hristianivanov/ITJob-Finder-ASP.NET-MVC)
![GitHub Repo stars](https://img.shields.io/github/stars/hristianivanov/ITJob-Finder-ASP.NET-MVC)
![GitHub forks](https://img.shields.io/github/forks/hristianivanov/ITJob-Finder-ASP.NET-MVC)
[![.NET](https://github.com/hristianivanov/ITJob-Finder-ASP.NET-MVC/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hristianivanov/ITJob-Finder-ASP.NET-MVC/actions/workflows/dotnet.yml)
