
# **BackEndTest Project**

## **Overview**
BackEndTest is a backend application built using **ASP.NET Core**. It provides RESTful APIs for managing **Departments** and **Employees**, demonstrating modern backend design practices like layered architecture, dependency injection, and database integration.

---

## **Features**
- Manage **Departments** and **Employees** with CRUD operations.
- **Database**: SQLite with Entity Framework Core for ORM.
- **Swagger**: Interactive API documentation for testing.
- **Async Programming**: Ensures non-blocking operations.

---

## **Getting Started**

### **Setup**
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Access Swagger UI:  
   **https://localhost:7131/swagger/index.html**

---

## **API Overview**

### **Departments**
- **GET** `/api/Departments`: Retrieve all departments.
- **POST** `/api/Departments`: Create a department.
- **GET** `/api/Departments/{id}`: Retrieve a department by ID.

### **Employees**
- **GET** `/api/Employees`: Retrieve all employees.
- **POST** `/api/Employees`: Create an employee.
- **GET** `/api/Employees/{id}`: Retrieve an employee by ID.
- **PUT** `/api/Employees/{id}`: Update employee details.
- **DELETE** `/api/Employees/{id}`: Delete an employee.

---

## **Highlights**
- **Layered Architecture**: Clean separation of concerns.
- **Database Relationships**: 1-to-Many between departments and employees.
- **Best Practices**: Dependency injection, input validation, and modularity.
