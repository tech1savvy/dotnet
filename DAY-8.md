# Day 8: Entity Framework Core – Part 1

This document provides an overview of the tasks for Day 8, focusing on integrating Entity Framework Core into the Books API.

## Topic

Entity Framework Core – Part 1

## Learning Resources

*   EF Core Getting Started
*   Code First Approach
*   DbContext Class

## Assignment

1.  **Replace In-Memory Data:** Transition from the current in-memory list of books to a persistent database using EF Core.
2.  **Choose a Database:** Implement the solution using SQLite for simplicity and ease of setup.
3.  **Create Entities:**
    *   Define `Book` and `Author` classes as EF Core entities.
    *   Establish a one-to-many relationship between `Author` and `Book` (one author can have many books).
4.  **Implement DbContext:**
    *   Create a `BookstoreContext` class that inherits from `DbContext`.
    *   Register the `DbSet` properties for `Book` and `Author` entities.
5.  **Database Migrations:**
    *   Use EF Core tools to create an initial migration based on the entities.
    *   Apply the migration to generate the database schema.
6.  **Update Controllers:**
    *   Refactor the `BooksController` (v1 and v2) to use the `BookstoreContext` for all data operations (CRUD).
7.  **Seed Initial Data:**
    *   Add initial data to the database to ensure the API is functional and testable upon startup.
