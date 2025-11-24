# Day 6: Steps to Create the Books API

This document outlines the steps taken to create the Books API.

1.  **Created `DAY-6.md`:**
    *   A `DAY-6.md` file was created to outline the plan for the assignment.

2.  **Created Documentation:**
    *   The `docs/` directory was created to hold documentation files.
    *   `docs/asp-net-core-web-api-tutorial.md` was created with a summary of how to create an ASP.NET Core Web API.
    *   `docs/mvc-pattern-in-asp-net-core.md` was created to explain the MVC pattern.
    *   `docs/routing-in-asp-net-core.md` was created to explain routing in ASP.NET Core.

3.  **Defined the Book Model:**
    *   The `Models/` directory was created.
    *   `Models/Book.cs` was created to define the `Book` class with `Id`, `Title`, and `Author` properties.

4.  **Created the API Controller:**
    *   The `Controllers/` directory was created.
    *   `Controllers/BooksController.cs` was created to handle the API requests for books.

5.  **Implemented In-Memory Data Storage:**
    *   Inside `BooksController.cs`, a `static` list of `Book` objects was added to serve as an in-memory database.

6.  **Implemented API Endpoints:**
    *   **GET /api/books**: An endpoint to retrieve all books.
    *   **GET /api/books/{id}**: An endpoint to retrieve a single book by its ID.
    *   **POST /api/books**: An endpoint to create a new book.
    *   **PUT /api/books/{id}**: An endpoint to update an existing book.
    *   **DELETE /api/books/{id}**: An endpoint to delete a book.

7.  **Configured Routing:**
    *   The `Program.cs` file was modified to register and map the API controllers, enabling the application to route requests to the `BooksController`.
    *   The default weather forecast example code was removed to keep the application focused on the Books API.
