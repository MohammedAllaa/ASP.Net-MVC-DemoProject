📦 IKEA MVC Management System

A complete ASP.NET Core MVC application built using N-Tiers Architecture principles, Identity Authentication, Entity Framework Core, Unit of Work, Repository Pattern, AutoMapper, and File Upload Services.
The system manages Departments and Employees, including authentication, authorization, and role-based access control.

🌐 Overview

This project is a real-world ASP.NET Core MVC application designed to manage company departments and employees.
It supports:

✔ CRUD operations  
✔ Searching  
✔ Authentication (Login/Register)  
✔ Authorization using roles  
✔ File Upload (Employee images)  
✔ Unit of Work & Repository patterns  
✔ AutoMapper DTO mapping  
✔ Validation through DataAnnotations  
✔ Lazy Loading using EF Core proxies  
<br>
<br>
The project is built with clean separation between DAL, BLL, and PL, making it scalable, testable, and enterprise-ready.

🏗 Project Architecture

The application follows Clean Architecture + Onion Architecture concepts:

IKEA.PL (Presentation Layer)  
-------------↓--------------    
IKEA.BLL (Business Logic Layer)  
-------------↓--------------    
IKEA.DAL (Data Access Layer)  


Each layer is fully separated and communicates only via interfaces.  
<br>
<br>
🛠 Technologies Used:-  
Backend  
ASP.NET Core MVC 8  
Entity Framework Core 8  
ASP.NET Identity  
SQL Server  
C# 12  
Design & Architecture  
Repository Pattern  
Unit of Work Pattern  
AutoMapper  
Dependency Injection  
DTO Mapping  
Model Binding & Validation  
Lazy Loading Proxies  
Clean Code Practices  
SOLID Principles  
Security  
ASP.NET Identity (UserManager, SignInManager)  
Hashing & Password Validation  
Cookie Authentication  
Role-based Authorization  
File Handling  
IFormFile  
FileStream  
Custom Attachment Service  
Validation (extension, size)  
<br>
<br>
🔥 Key Features:-
Employee Module

Create / Update / Delete employees

Upload employee images

Search employees

Display department name (via AutoMapper)

Enum mapping for:

Gender

EmployeeType

Department Module

Full CRUD

Validation

Department details page

Auto-mapping to DTOs

Authentication Module

Register with:

First name

Last name

Username

Email

Password + Confirm

Login / Logout

Role-based access using [Authorize(Roles = "NUser")]

Global Services

AutoMapper

Unit of Work

Generic Repository

Image Handling Service

📁 Layers Structure
IKEA.DAL (Data Access Layer)<br>
│── Contexts/<br>
│── Models/<br>
│── Configurations/ (FLUENT API)<br>
│── Repositories/<br>
│── UOW/<br>
│── Migrations/<br>
<br>
IKEA.BLL (Business Logic Layer)<br>
│── Services/<br>
│── DTOs/<br>
│── MappingProfiles/<br>
│── Factory (DTO → Entity Converters)<br>
│── Attachment Services<br>
<br>
IKEA.PL (Presentation Layer)<br>
│── Controllers/<br>
│── Views/<br>
│── ViewModels/<br>
│── wwwroot/ files, images<br>
│── Program.cs<br>
<br>
<br>
🧩 Design Patterns Implemented
✔ Repository Pattern

A GenericRepository that handles:

Add

Update

Delete

GetById

GetAll (with/without tracking)

✔ Unit of Work Pattern

Wraps all repositories and ensures:

Single transaction per request

SaveChanges() is called only once

✔ Factory Pattern

Used to convert:

DTO → Entity

Entity → DTO

✔ AutoMapper Pattern

Profiles map:

Employee ↔ DTO

Department ↔ DTO

🗄 Database & EF Core Details
Entity Configuration

Using Fluent API:

Custom identity columns

builder.Property(d => d.Id).UseIdentityColumn(10, 10);


One-to-many Department → Employees

OnDelete(DeleteBehavior.SetNull)


Enum to string conversions

builder.Property(e => e.Gender).HasConversion(

EF Core Features Used

✔ Migrations<br>
✔ Lazy Loading<br>
✔ Navigation properties<br>
✔ Fluent API configuration<br>
✔ Custom column types (varchar, decimal)<br>
<br>
<br>
🔐 Authentication & Authorization
ASP.NET Identity

UserManager

SignInManager

IdentityUser extended with:

FirstName

LastName

Cookie Authentication

Configured in Program.cs:

builder.Services.AddAuthentication()

Authorization

Examples:

Entire controller:

[Authorize]


Role-only actions:

[Authorize(Roles = "NUser")]
<br>
<br>
🔄 AutoMapper Configuration

A dedicated mapping profile:

public class ProjectMapperProfile : Profile
{
    public ProjectMapperProfile()<br>
    {<br>
        CreateMap<Employee, EmployeeDto>().ReverseMap();<br>
        CreateMap<Employee, EmployeeDetailsDto>().ReverseMap();<br>
        CreateMap<Employee, CreatedEmployeeDto>().ReverseMap();<br>
        CreateMap<Employee, UpdatedEmployeeDto>().ReverseMap();<br>
    }<br>
}<br>


Configured in Program.cs:

builder.Services.AddAutoMapper(typeof(ProjectMapperProfile));

🖼 File Upload System
AttachmentServices

Supports:

Validation:

Allowed extensions (.jpg, .jpeg, .png, etc.)

Max size = 5 MB

Creates folder if not exists

Deletes old image on update

Returns unique filename using GUID

Location:

wwwroot/files/Images/

▶ How to Run the Project

Clone the repository:

git clone https://github.com/MohammedAllaa/IKEA-MVC.git


Update appsettings.json with your SQL Server connection string.

Run EF migrations:

update-database


Run the app:

dotnet run

