# Day 6: Testing the Books API with cURL

This file provides `curl` commands to test the Books API endpoints.

**Note:** The port number `5275` is used based on `Properties/launchSettings.json`. If you change the port in `launchSettings.json`, you will need to update the commands accordingly.

### 1. Get All Books

This command retrieves the list of all books.

```bash
curl -X GET http://localhost:5275/api/books
```

### 2. Get a Single Book

This command retrieves the book with `Id = 1`.

```bash
curl -X GET http://localhost:5275/api/books/1
```

### 3. Create a New Book

This command creates a new book. The new book's data is sent in the request body as a JSON object.

```bash
curl -X POST -H "Content-Type: application/json" -d '{"title":"The Lord of the Rings","author":"J.R.R. Tolkien"}' http://localhost:5275/api/books
```

### 4. Update an Existing Book

This command updates the book with `Id = 1`. The updated book data is sent in the request body.

```bash
curl -X PUT -H "Content-Type: application/json" -d '{"id": 1, "title":"The Hobbit","author":"J.R.R. Tolkien"}' http://localhost:5275/api/books/1
```

### 5. Delete a Book

This command deletes the book with `Id = 2`.

```bash
curl -X DELETE http://localhost:5275/api/books/2
```
