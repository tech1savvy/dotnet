# Day 6: ASP.NET Core Web API

## Assignment:

Create a basic Books API with GET, POST, PUT, and DELETE endpoints. Use an in-memory list for data storage and implement proper HTTP status codes.

## Plan:

1.  **Create Documentation:**
    *   Create a `docs/` directory.
    *   Populate the `docs/` directory with markdown files explaining the core concepts:
        *   `asp-net-core-web-api-tutorial.md`
        *   `mvc-pattern-in-asp-net-core.md`
        *   `routing-in-asp-net-core.md`

2.  **Define the Book Model:**
    *   Create a `Models/Book.cs` file to define the structure of a book with properties like `Id`, `Title`, and `Author`.

3.  **Create the API Controller:**
    *   Create a `Controllers/BooksController.cs` file.
    *   This controller will contain the logic for handling API requests.

4.  **Implement In-Memory Data Storage:**
    *   Inside the `BooksController`, a `static` list of `Book` objects will be used to store the book data.

5.  **Implement API Endpoints:**
    *   **GET /api/books**: Retrieve all books.
    *   **GET /api/books/{id}**: Retrieve a single book by its ID.
    *   **POST /api/books**: Create a new book.
    *   **PUT /api/books/{id}**: Update an existing book.
    *   **DELETE /api/books/{id}**: Delete a book.

6.  **Configure Routing:**
    *   Update `Program.cs` to ensure the API controllers are recognized by the application.
