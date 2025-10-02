# 📚 Library Management System API

A robust and scalable backend API for managing books, members, and borrowing operations in a library. Built with ASP.NET Core and Entity Framework, this system enforces borrowing rules, tracks stock, and supports clean architecture principles.

---

## 🚀 Features

- ✅ Add, update, search, and delete books
- 📦 Track book stock and availability
- 👥 Manage members with contact details
- 🔄 Borrow and return books with validations
- 🔍 Search books by title (autocomplete-ready)
- 📊 Enforce borrowing limits (max 3 unique books per member)
- 📞 Retrieve borrower contact info for follow-up
- 🧱 Clean service layer with dependency injection

---

## 🧰 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)
- LINQ & Asynchronous Programming

---

## 🛠️ Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/library-management-api.git
   cd library-management-api

**2. Configure the database**
- Update appsettings.json with your SQL Server connection string.
- 
**3. Apply migrations**

   dotnet ef database update

**4. Run the project**
    dotnet run
   
**5. Access Swagger UI**
   https://localhost:{port}/swagger

 📦 Seeded Book Data
The database is seeded with popular titles like:
- Life of Pi by Yann Martel
- The Alchemist by Paulo Coelho
- Sapiens by Yuval Noah Harari
- The Hobbit by J.R.R. Tolkien
You can customize this in OnModelCreating() inside LibraryDbContext.cs.
📬 API Highlights
🔄 Borrow Book
POST /api/Borrow


{
  "memberId": 101,
  "bookIds": [1, 2, 3]
}


📞 Get Borrowers of a Book
GET /api/Borrow/borrowers/{bookId}


🔍 Search Books by Title
GET /api/Books/search?title=life



🧪 Testing
Use Postman or Swagger to test endpoints. All operations are async and follow RESTful conventions.

