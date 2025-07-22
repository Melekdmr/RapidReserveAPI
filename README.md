# 🏨 Hotel Management & Booking Dashboard (RapidAPI Integration)

A multi-layered web application built with **ASP.NET Core 8.0**, featuring a RESTful API backend and an MVC frontend consuming that API. It uses **MSSQL** with Entity Framework Core and follows clean architectural separation for maintainability. The project also integrates external services via **RapidAPI** to display real-time data.


> 📌 Note: The application UI and internal language are in Turkish. This documentation is written in English for global accessibility.

---

## 👤 User Interface Overview
- Room Browsing: Users can view available rooms with details and images.  
- Booking System: Users can create, update, or cancel reservations.  
- Contact & Subscription: Users can send messages via contact form and subscribe to the mailing list.  
- Profile Management: Users can update their profile information.  
- Notification Center: Users receive alerts for booking confirmations and messages.  
- Secure Access: Authentication ensures user-specific data privacy and protection.

## 👨‍💼 Admin Panel Features
- Full Data Management: Add, update, and delete rooms, guests, bookings, services, and testimonials.
- Real-time Updates: Use of Ajax for smooth CRUD operations without page reloads.
- Dashboard Overview: Visual stats on total bookings, guests, rooms, and messages.
- Message Management: View, respond, and mark contact messages as read.
- Role-Based Access: Only users with "Admin" role can access the admin panel; others are redirected.
- Quick Navigation: Easy switch between admin panel and main site.
- Custom Error Pages: Friendly 401 and 404 pages for unauthorized or missing pages.
 
## 📦 NuGet Packages Used

- **AutoMapper** – A convention-based object-object mapper
- **AutoMapper.Extensions.Microsoft.DependencyInjection** – Integrates AutoMapper with ASP.NET Core dependency injection
- **FluentValidation.AspNetCore** – FluentValidation support for ASP.NET Core
- **FluentValidation.DependencyInjectionExtensions** – Enables FluentValidation to work with dependency injection
- **Microsoft.AspNetCore.Identity** – Membership system for adding login functionality
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore** – Identity support with Entity Framework Core
- **Microsoft.EntityFrameworkCore** – Core components for using EF Core in .NET
- **Microsoft.EntityFrameworkCore.Design** – Design-time tools for EF Core (e.g., migrations)
- **Microsoft.EntityFrameworkCore.SqlServer** – SQL Server database provider for EF Core
- **Microsoft.EntityFrameworkCore.Tools** – Tools for working with EF Core (e.g., `Update-Database`, `Add-Migration`)
- **Microsoft.VisualStudio.Web.CodeGeneration.Design** – Enables scaffolding (code generation) in ASP.NET Core projects
- **NETCore.MailKit** – Enables sending emails using the MailKit SMTP client
- **Swashbuckle.AspNetCore** – Provides Swagger integration for documenting and testing ASP.NET Core APIs



## 🚀 Tech Stack

- ASP.NET Core 8.0 Web API
- ASP.NET Core MVC (Web UI)
- N Tier Architecture
- Entity Framework Core (Code First)
- Repository & Unit of Work Pattern
- Identity & JWT Authentication
- RapidAPI Integration
- MailKit Email Service
- FluentValidation
- MSSQL
- Swagger / Postman / AJAX
- X.PagedList (Pagination)

---

## 🔧 Project Architecture

```bash
📦HotelProject
 ┣ 📂HotelProject.API           # Web API Layer (RESTful)
 ┣ 📂HotelProject.WebUI         # MVC Layer (API Consumer)
 ┣ 📂HotelProject.EntityLayer   # Data Models
 ┣ 📂HotelProject.DataAccessLayer # EF Core + Dapper
 ┣ 📂HotelProject.BusinessLayer # Business Logic
 ┣ 📂HotelProject.DTOLayer      # Data Transfer Objects
 ┗ 📜HotelProject.sln           # Solution File
 ┗ 📜JWtProject                 # Json Web Token
 ┗ 📜Rapid Api                  # 🌐 RapidAPI Integration Layer (3rd-party APIs)
 ```


## 📱 User Interface Preview

![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Hoteller-RapidReserveAPI-GoogleChrome2025-07-2117-38-02-ezgif.com-crop%20(1).gif)

Here is a GIF that showcases the main page UI and the user interaction flow.

### 🔐 Login Screen

![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20191300.png)
Secure user login with validation and error handling.


### 📝 Register Screen

![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20190038.png)
New user sign-up with form checks and feedback.

## 🛠️ Admin Panel – Media Management  
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/admindashboard.png)

Admins can upload, manage, and organize photos directly from the admin panel, ensuring up-to-date visual content across the platform.

## 📑 Swagger UI – API Documentation

This project uses **Swagger** for interactive API documentation and testing.

![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20185330.png)
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20185400.png)
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20185605.png)
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20185633.png)
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20193237.png)
**🔹 All APIs are fully developed and accessible through the Web UI, working reliably without issues.**
**🔹 API Controllers use layered architecture to ensure efficient and well-organized request handling.**

## 🗄️ Database Design Overview

![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20194303.png)
**🔹The app uses ASP.NET Core Identity with custom tables for contacts, message categories, and work locations. It includes standard Identity relationships (users-roles, users-claims) plus custom links connecting contacts to categories and users to locations.**

## 🛠️ How to Run the Project on Another Machine

**1. Clone the repository**
   ```bash
   git clone https://github.com/Melekdmr/RapidReserveAPI.git
   cd RapidReserveAPI
```
**2. Open the solution in Visual Studio**

 • Open the RapidReserveAPI.sln file

**3. Restore NuGet packages**
 ```bash
    dotnet restore
```
**4. Configure the database connection**
• Open appsettings.json

• Update the "DefaultConnection" string with your own SQL Server details:
 ```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=RapidReserveDb;Trusted_Connection=True;"
}
```
**5. Apply migrations and update the database**

 ```bash
Update-Database
```
**6. **Run the project**
• Press Ctrl + F5 or click "Run Without Debugging" in Visual Studio

✅ Your API should now be up and running at https://localhost:PORT/swagger.
