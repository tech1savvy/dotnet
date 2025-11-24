# Day 8: Testing the EF Core Implementation

This document provides instructions on how to test the API now that it is connected to a SQLite database.

## 1. Verify Database Creation

*   After running the application for the first time (or running `dotnet ef database update`), a new file named `bookstore.db` should be present in the root directory of the project. This is the SQLite database file.

## 2. Test with Swagger UI

### Start the Application

Run the application using `dotnet run`. The Swagger UI should open automatically in your browser.

### Test API v1

Navigate to the `v1` endpoints in Swagger.

*   **`GET /api/v1/Books`**
    *   **Test:** Execute this endpoint.
    *   **Expected Result:** It should return a list of books seeded in the database. Each book object should now include an `author` object, not just an `author` string.
    *   **Example Response Body:**
        ```json
        [
          {
            "id": 1,
            "title": "The Hobbit",
            "author": {
              "id": 1,
              "name": "J.R.R. Tolkien",
              "books": []
            },
            "authorId": 1
          }
        ]
        ```

*   **`POST /api/v1/Books`**
    *   **Test:** Create a new book. Note that you now need to provide an `authorId` that exists in the database.
    *   **Example Request Body:**
        ```json
        {
          "title": "A New Book",
          "authorId": 1
        }
        ```
    *   **Expected Result:** A `201 Created` response with the newly created book.

*   **`GET /api/v1/Books/{id}`**
    *   **Test:** Fetch the book you just created by its ID.
    *   **Expected Result:** The book object is returned successfully.

### Test API v2

Navigate to the `v2` endpoints in Swagger.

*   **`GET /api/v2/Books`**
    *   **Test:** Execute this endpoint.
    *   **Expected Result:** It should return a list of books with the `fullTitle` format, combining the book title and the author's name.
    *   **Example Response Body:**
        ```json
        [
          {
            "id": 1,
            "fullTitle": "The Hobbit by J.R.R. Tolkien"
          }
        ]
        ```

## 3. Test with .http File

You can also use the `dotnet.http` file to send requests.

*   Update the `GET` requests to the v1 and v2 endpoints and send them.
*   Verify that the responses match the expected results described above.
