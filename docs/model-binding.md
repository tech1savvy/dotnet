# Model Binding in ASP.NET Core

Model binding in ASP.NET Core is a mechanism that maps data from incoming HTTP requests to the parameters of an action method. This process automates the parsing of request data (form fields, query strings, route values, request body, headers) and converts it into strongly-typed .NET objects.

## Default Binding Sources

Model binding typically looks for data in the following order:

1.  **Form values:** `application/x-www-form-urlencoded` or `multipart/form-data`.
2.  **Route values:** Data from the URL path.
3.  **Query string parameters:** Data appended to the URL after a `?`.
4.  **Request Body:** Data from the request body (e.g., JSON, XML). This is the default for complex types in API controllers.
5.  **HTTP Headers:** Data from HTTP headers.

## Explicitly Specifying Binding Source

You can explicitly control the binding source using attributes:

*   **`[FromQuery]`**: Binds from the query string.
*   **`[FromRoute]`**: Binds from route data.
*   **`[FromForm]`**: Binds from form fields.
*   **`[FromBody]`**: Binds from the request body (only one per action).
*   **`[FromHeader]`**: Binds from an HTTP header.

**Example:**

```csharp
[HttpGet("{id}")]
public IActionResult GetProduct(
    [FromRoute] int id,
    [FromQuery] string color,
    [FromHeader(Name = "Accept-Language")] string language)
{
    // ...
}
```

## Binding to Simple and Complex Types

Model binding handles both simple types (int, string) and complex types (custom classes). For complex types, it attempts to bind the properties of the object from the request sources.

## Custom Model Binders

For advanced scenarios, you can create custom model binders by implementing `IModelBinder` and registering a `IModelBinderProvider`.

## Validation and Model Binding

Model binding works with validation. After binding, validation attributes on model properties are checked.

*   **`[Required]`**: A validation attribute that checks if a property has a value *after* model binding.
*   **`[BindRequired]`**: An attribute that ensures a value for the property was present in the request *during* model binding.
