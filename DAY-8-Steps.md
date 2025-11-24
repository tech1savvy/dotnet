# Day 8: Steps to Implement EF Core

This document outlines the steps taken to integrate Entity Framework Core with a SQLite database.

### 1. Created Documentation

*   `DAY-8.md`: Overview of the assignment.
*   `DAY-8-Steps.md`: This file, detailing the implementation steps.
*   `DAY-8-Test.md`: Instructions for testing the new database-driven API.
*   `docs/ef-core-getting-started.md`: Documentation for EF Core basics.
*   `docs/code-first-approach.md`: Documentation for the Code-First workflow.
*   `docs/dbcontext-class.md`: Documentation for the `DbContext` class.

### 2. Added EF Core Packages

The following NuGet packages were added to `dotnet.csproj`:
*   `Microsoft.EntityFrameworkCore.Design`: For EF Core design-time tooling.
*   `Microsoft.EntityFrameworkCore.Sqlite`: The database provider for SQLite.

### 3. Created Author Entity

*   A new `Models/Author.cs` file was created to define the `Author` entity, including a collection of `Book` entities to represent the one-to-many relationship.

### 4. Updated Book Entity

*   The `Models/Book.cs` file was updated to:
    *   Remove the custom validation attribute, as it will be handled differently.
    *   Add `AuthorId` and a navigation property `Author` to establish the foreign key relationship to the `Author` entity.

### 5. Created DbContext

*   A `Data/` directory was created.
*   A `Data/BookstoreContext.cs` file was created, inheriting from `DbContext`.
*   `DbSet<Book>` and `DbSet<Author>` properties were added to the context.
*   The `OnModelCreating` method was overridden to seed the database with initial data (authors and books).

### 6. Configured Services in `Program.cs`

*   The `appsettings.json` file was updated with a `BookstoreDb` connection string.
*   `Program.cs` was updated to:
    *   Register `BookstoreContext` with the dependency injection container, configuring it to use SQLite.
    *   Remove the singleton registration for the in-memory book list.

### 7. Created and Applied Migrations

*   An initial migration was created using the command: `dotnet ef migrations add InitialCreate`.
*   The migration was applied to the database using: `dotnet ef database update`.

### 8. Refactored Controllers

*   The `Controllers/v1/BooksController.cs` and `Controllers/v2/BooksController.cs` were refactored to:
    *   Inject the `BookstoreContext` via the constructor.
    *   Replace all interactions with the in-memory list with asynchronous database operations using EF Core (e.g., `_context.Books.ToListAsync()`, `_context.SaveChangesAsync()`).
    *   Use `Include(b => b.Author)` to ensure author data is loaded and returned with book data.
    *   Update the `POST` method to handle the new `Book` entity structure.
