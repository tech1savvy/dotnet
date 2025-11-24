# DbContext Class

The `DbContext` class is a central piece of Entity Framework Core. An instance of `DbContext` represents a session with the database, which can be used to query and save instances of your entities.

## Key Responsibilities

1.  **Database Connection:** It manages the connection to the database. The connection string is typically passed to the `DbContext` through its constructor.
2.  **Entity Sets (`DbSet<T>`):** For each entity type in your model, you include a `DbSet<T>` property on your `DbContext` class. A `DbSet<T>` represents a collection of entities of a given type that can be queried from the database.
    ```csharp
    public class BookstoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        // ... constructor and other members
    }
    ```
3.  **Querying:** It is the primary API for writing and executing queries. LINQ queries against the `DbSet<T>` properties are translated into database queries (e.g., SQL) and executed.
    ```csharp
    var books = await context.Books.ToListAsync();
    ```
4.  **Change Tracking:** When you query for entities, the `DbContext` begins tracking them. Any changes you make to these entities (adding, modifying, or deleting) are detected by the change tracker.
5.  **Saving Changes:** The `SaveChanges()` or `SaveChangesAsync()` method is called on the `DbContext` instance to persist the tracked changes to the database. EF Core generates the appropriate `INSERT`, `UPDATE`, or `DELETE` statements and executes them within a transaction.

## Configuration and Lifetime

*   **Configuration:** The `DbContext` is typically configured in `Program.cs` (or `Startup.cs`) using dependency injection. You register it as a service and provide options, such as the database provider (e.g., SQLite, SQL Server) and the connection string.
*   **Lifetime:** For web applications, the `DbContext` is usually configured with a **scoped lifetime**. This means a new `DbContext` instance is created for each web request, it is used for all database operations within that request, and then it is disposed of when the request is finished. This is a safe and efficient pattern that avoids issues with tracking changes across multiple requests.
