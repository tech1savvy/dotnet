# Code-First Approach

The Code-First approach is a workflow in Entity Framework Core where you define your database structure using C# classes (entities) rather than designing the database schema first. This is the primary and recommended workflow for most new applications.

## Core Principles

1.  **Model as the Source of Truth:** Your .NET entity classes and `DbContext` are the definitive source of truth for your database schema.
2.  **Database from Code:** The database schema is generated or updated based on your code model.
3.  **Migrations:** Changes to your model are managed through a series of incremental migration files. Each migration file contains the code to apply and revert a specific change to the schema.

## Advantages

*   **Developer-Centric:** It allows developers to stay within the .NET ecosystem and use their C# skills to define the database model.
*   **Version Control:** Since the model is just code, it can be managed under source control (like Git) just like any other part of your application.
*   **Simplified Development:** You don't need to switch to a separate database design tool. The entire application stack, including the database definition, is in one place.

## Typical Workflow

1.  **Create/Modify Entity Classes:** Start by creating or modifying your POCO (Plain Old CLR Object) entity classes. For example, you might add a new `PublicationDate` property to your `Book` class.
2.  **Add a Migration:** Use the `dotnet ef migrations add <MigrationName>` command. EF Core compares your current model against a snapshot of the last migration and generates a new migration file with the `Up()` and `Down()` methods needed to update the database.
3.  **Update the Database:** Use the `dotnet ef database update` command. EF Core executes the `Up()` method in the new migration to apply the changes to the database, for instance, by adding a new `PublicationDate` column to the `Books` table.
