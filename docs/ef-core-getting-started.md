# EF Core Getting Started

Entity Framework (EF) Core is a modern, object-relational mapper (O/RM) for .NET. It enables developers to work with a database using .NET objects, eliminating the need for most of the data-access code they usually need to write.

## Key Features

*   **LINQ Queries:** Write database queries in C# using Language Integrated Query (LINQ). EF Core translates these queries into the database's native query language (e.g., SQL) and executes them.
*   **Change Tracking:** EF Core automatically tracks changes made to your entities. When you call `SaveChanges()`, it generates and executes the necessary `INSERT`, `UPDATE`, and `DELETE` statements.
*   **Migrations:** As your model changes over time, EF Core migrations provide a way to incrementally update the database schema to keep it in sync with your application's model.
*   **Database Providers:** EF Core supports a wide range of databases (SQL Server, SQLite, PostgreSQL, MySQL, etc.) through a provider model.

## Workflow

The most common workflow, and the one used in this project, is **Code-First**.

1.  **Define Models:** You create your entity classes (e.g., `Book`, `Author`) in C#. These are plain old CLR objects (POCOs).
2.  **Create DbContext:** You create a class that inherits from `DbContext`. This class represents a session with the database and contains `DbSet<T>` properties for each entity in your model.
3.  **Generate Migrations:** You use EF Core command-line tools to generate a migration based on your model. The migration contains the code to create or update the database schema.
4.  **Apply Migrations:** You apply the migration to create or update the database.
