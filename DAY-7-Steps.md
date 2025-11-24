# Day 7: Steps to Enhance the Books API

This document outlines the steps taken to enhance the Books API with data validation and API versioning.

### 1. Created Documentation

Markdown files were created in the `docs/` directory to cover the new topics:
*   `docs/model-binding.md`
*   `docs/model-validation.md`
*   `docs/api-versioning.md`

### 2. Implemented Data Validation

*   **Attribute Validation:**
    *   The `Models/Book.cs` file was updated to include `[Required]` and `[StringLength]` attributes on the `Title` and `Author` properties.
    *   `using System.ComponentModel.DataAnnotations;` was added to `Models/Book.cs`.

*   **Custom Validation:**
    *   A `Validation/` directory was created.
    *   A custom validation attribute, `Validation/TitleAuthorMustBeDifferentAttribute.cs`, was created to ensure that the `Title` and `Author` of a book are not the same.
    *   The `[TitleAuthorMustBeDifferent]` attribute was applied to the `Book` class in `Models/Book.cs`.
    *   `using dotnet.Validation;` was added to `Models/Book.cs`.

### 3. Implemented API Versioning

*   **Added Versioning Packages:**
    *   The `Asp.Versioning.Mvc` and `Asp.Versioning.Mvc.ApiExplorer` NuGet packages were added to the project.

*   **Configured Versioning in `Program.cs`:**
    *   API versioning services were configured in `Program.cs` to set the default API version to 1.0, assume a default version when unspecified, report API versions, and use URL segment and header version readers.
    *   `using Asp.Versioning;` and `using Asp.Versioning.ApiExplorer;` were added to `Program.cs`.

*   **Created Versioned Controllers:**
    *   `Controllers/v1` and `Controllers/v2` directories were created.
    *   The original `Controllers/BooksController.cs` was deleted.
    *   **v1 Controller:**
        *   A new `Controllers/v1/BooksController.cs` was created.
        *   It was decorated with `[ApiVersion("1.0")]` and its route was updated to `[Route("api/v{version:apiVersion}/[controller]")]`.
        *   The namespace was changed to `dotnet.Controllers.v1`.
    *   **v2 Controller:**
        *   A `Models/BookDtoV2.cs` was created to define a different response format for v2.
        *   A new `Controllers/v2/BooksController.cs` was created.
        *   It was decorated with `[ApiVersion("2.0")]` and its route was updated to `[Route("api/v{version:apiVersion}/[controller]")]`.
        *   The `GET` endpoints in the v2 controller were modified to return `BookDtoV2` objects, combining `Title` and `Author` into a `FullTitle` property.
        *   The namespace was changed to `dotnet.Controllers.v2`.
