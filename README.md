# 🏨 Hotel Management & Booking Dashboard (RapidAPI Integration)

A multi-layered web application built with **ASP.NET Core 8.0**, featuring a RESTful API backend and an MVC frontend consuming that API. It uses **MSSQL** with Entity Framework Core and follows clean architectural separation for maintainability. The project also integrates external services via **RapidAPI** to display real-time data.


> 📌 Note: The application UI and internal language are in Turkish. This documentation is written in English for global accessibility.

---

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
Below is a GIF showcasing the main page UI and user interaction flow:

![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Hoteller-RapidReserveAPI-GoogleChrome2025-07-2117-38-02-ezgif.com-crop%20(1).gif)

### 🔐 Login Screen
Secure user login with validation and error handling.
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20191300.png)


### 📝 Register Screen
New user sign-up with form checks and feedback.
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20190038.png)

## 📑 Swagger UI – API Documentation

This project uses **Swagger** for interactive API documentation and testing.

![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20185330.png)
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20185400.png)
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20185605.png)
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-21%20185633.png)
![ ](https://github.com/Melekdmr/RapidReserveAPI/blob/master/Media/Hoteller-RapidReserveAPI-GoogleChrome2025-07-2117-38-02-ezgif.com-crop%20(1).gif)
