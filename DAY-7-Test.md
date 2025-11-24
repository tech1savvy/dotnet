# Day 7: Testing the Enhanced Books API with cURL

This file provides `curl` commands to test the enhanced Books API, including validation and API versioning.

**Note:** The port number `5275` is used based on `Properties/launchSettings.json`. If you change the port in `launchSettings.json`, you will need to update the commands accordingly.

### Testing Validation

#### 1. Attempt to Create a Book with Missing Title (Validation Error)

```bash
curl -X POST -H "Content-Type: application/json" -d '{"author":"Test Author"}' http://localhost:5275/api/v1/books
```
Expected: `400 Bad Request` with validation error for missing Title.

#### 2. Attempt to Create a Book with Title and Author being the same (Custom Validation Error)

```bash
curl -X POST -H "Content-Type: application/json" -d '{"title":"Same Name","author":"Same Name"}' http://localhost:5275/api/v1/books
```
Expected: `400 Bad Request` with custom validation error.

#### 3. Successfully Create a Valid Book

```bash
curl -X POST -H "Content-Type: application/json" -d '{"title":"Valid Title","author":"Valid Author"}' http://localhost:5275/api/v1/books
```
Expected: `201 Created` with the new book details.

### Testing API Versioning

#### 1. Get All Books (v1)

```bash
curl -X GET http://localhost:5275/api/v1/books
```
Expected: `200 OK` with a list of books in the original format (`Id`, `Title`, `Author`).

#### 2. Get a Single Book (v1)

```bash
curl -X GET http://localhost:5275/api/v1/books/1
```
Expected: `200 OK` with a single book in the original format.

#### 3. Get All Books (v2)

```bash
curl -X GET http://localhost:5275/api/v2/books
```
Expected: `200 OK` with a list of books in the v2 format (`Id`, `FullTitle`).

#### 4. Get a Single Book (v2)

```bash
curl -X GET http://localhost:5275/api/v2/books/1
```
Expected: `200 OK` with a single book in the v2 format.

#### 5. Create a Book (v2 - uses base Book model)

```bash
curl -X POST -H "Content-Type: application/json" -d '{"title":"V2 New Book","author":"V2 New Author"}' http://localhost:5275/api/v2/books
```
Expected: `201 Created` with the new book details (will return base Book model).

#### 6. Update a Book (v1)

```bash
curl -X PUT -H "Content-Type: application/json" -d '{"id": 1, "title":"Updated Title V1","author":"Updated Author V1"}' http://localhost:5275/api/v1/books/1
```
Expected: `204 No Content`.

#### 7. Delete a Book (v2)

```bash
curl -X DELETE http://localhost:5275/api/v2/books/2
```
Expected: `204 No Content`.
