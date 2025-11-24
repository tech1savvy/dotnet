# Day 7: Enhancing the Books API

This file outlines the plan to enhance the Books API with data validation and API versioning.

## Plan

1.  **Create Documentation:**
    *   Create markdown files in the `docs/` directory for the new topics:
        *   `model-binding.md`
        *   `model-validation.md`
        *   `api-versioning.md`

2.  **Implement Data Validation:**
    *   **Attribute Validation:** Add validation attributes (e.g., `[Required]`, `[StringLength]`) to the `Book` model.
    *   **Custom Validation:** Create a custom validation attribute to enforce a rule, for example, that the `Title` and `Author` cannot be the same.

3.  **Implement API Versioning:**
    *   **Add Versioning Package:** Add the `Asp.Versioning.Mvc` package to the project.
    *   **Configure Services:** Configure API versioning in `Program.cs`.
    *   **Create v1 Controller:** Move the existing `BooksController` to a `Controllers/v1` directory and mark it as API version 1.0.
    *   **Create v2 Controller:** Create a new `BooksController` in a `Controllers/v2` directory for API version 2.0. This version will return a different response format for books.
    *   **Update Routing:** Modify the controller routes to include the API version (e.g., `api/v{version:apiVersion}/books`).

4.  **Document and Test:**
    *   Create `DAY-7-Steps.md` to document the implementation process.
    *   Create `DAY-7-Test.md` with `curl` commands to test the validation and both API versions.
