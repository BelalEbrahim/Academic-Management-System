"# Academic Management System 🎓

A robust, full-featured ASP.NET Core MVC web application designed to manage academic institutions. This was developed as a graduation project for the Information Technology Institute (ITI). It demonstrates modern software development practices with a clean, scalable architecture for performing CRUD operations on students, courses, and departments.






---

## ✨ Features

- 🔧 Full CRUD Operations: Create, Read, Update, and Delete academic entities (Students, Courses, Departments).
- 🏗️ Clean Architecture: Built using the MVC pattern with a Repository Layer for separation of concerns and testability.
- 🔄 Dependency Injection: Heavily utilized throughout the application for loose coupling and ease of testing.
- ✅ Advanced Data Validation: Implements both client-side and server-side validation, including unique field validation using Remote Attributes and Fluent API.
- 🗃️ Soft Delete System: Records are marked as inactive instead of being physically deleted, preserving data integrity.
- ⚡ Performance Optimization: Uses Eager Loading (.Include()) to solve the N+1 query problem.
- 🔐 Data Integrity: Configures unique constraints at the database level (e.g., unique student email).

---

## 🛠️ Technology Stack

- Backend Framework: ASP.NET Core 6.0 MVC
- ORM: Entity Framework Core 6.0
- Database: Microsoft SQL Server
- Frontend: Razor Views, Bootstrap, jQuery, JavaScript
- Architecture: MVC, Repository Pattern, Dependency Injection
- Development Environment: Visual Studio 2022

---

## 🚀 Getting Started

### Prerequisites

- .NET 6.0 SDK
- SQL Server (Express Edition is sufficient)
- An IDE (Recommended: Visual Studio 2022)

### Installation & Setup

1.  Clone the Repository
    bash<br>    git clone https://github.com/BelalEbrahim/Academic-Management-System.git<br>    cd Academic-Management-System<br>    

2.  Database Setup
    - Update the connection string in appsettings.json to point to your local SQL Server instance.
    - Run the following commands in the Package Manager Console to create the database:
    powershell<br>    Update-Database<br>    

3.  Run the Application
    - Build and run the solution in Visual Studio.
    - Alternatively, use the command line:
    bash<br>    dotnet run<br>    
    - Navigate to https://localhost:7000 (or the URL provided in the terminal).

---

## 📖 Usage

- Home Page: Navigate to the homepage to see an overview.
- Departments Management: View a list of all departments, and create, edit, or (soft) delete them.
- Students Management: Manage student records. The system enforces age range validation and unique email addresses.
- Courses Management: Manage course offerings with validation on course name and duration.

---

## 🏗️ Project Structure

<br>Academic-Management-System/<br>│<br>├── Controllers/          # MVC Controllers (Course, Department, Student)<br>├── Models/              # Domain Models (Course, Department, Student) with Data Annotations<br>├── Views/               # Razor views for each controller action<br>├── Reposatory/          # Repository interfaces and implementations<br>├── Data/                # DbContext (ITIContext) and database configuration<br>└── Program.cs           # Application entry point and service configuration<br>

---

## 🤝 Contributing

This is a graduation project. While it is not actively seeking contributions, suggestions and feedback are always welcome. Please feel free to fork the repository and experiment.

---

## 📜 License

This project was created for educational purposes as part of the ITI curriculum.

---

## 🙏 Acknowledgments

- Information Technology Institute (ITI) for the guidance and curriculum.
- Instructors and peers at ITI for their support and feedback."
