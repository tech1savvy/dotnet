# API Versioning in ASP.NET Core

API versioning is essential for evolving APIs without breaking existing client applications. It allows you to introduce changes and new features while maintaining backward compatibility.

## Why API Versioning?

*   **Backward Compatibility:** Allows older clients to continue using the API while new versions are developed.
*   **Controlled Evolution:** Manages breaking changes by introducing them in new versions.
*   **Client Migration:** Gives clients time to migrate to newer API versions.

## Common API Versioning Strategies

1.  **URL Path Versioning (Most Common):**
    *   Version number is part of the URL path.
    *   Example: `https://api.example.com/v1/products`

2.  **Query String Versioning:**
    *   Version specified as a query parameter.
    *   Example: `https://api.example.com/products?api-version=1.0`

3.  **Header Versioning:**
    *   Version specified in a custom HTTP header.
    *   Example: `X-Api-Version: 1.0`

4.  **Media Type Versioning (Content Negotiation):**
    *   Version specified in the `Accept` header.
    *   Example: `Accept: application/json;v=1.0`

## Implementing API Versioning

Use the `Asp.Versioning.Mvc` and `Asp.Versioning.Mvc.ApiExplorer` NuGet packages.

1.  **Install NuGet Packages:**
    ```bash
    Install-Package Asp.Versioning.Mvc
    Install-Package Asp.Versioning.Mvc.ApiExplorer
    ```

2.  **Configure Versioning Services (in `Program.cs`):**
    ```csharp
    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader(); // For URL path versioning
    });
    ```

3.  **Apply Versioning to Controllers:**
    Use the `[ApiVersion("X.0")]` attribute on controllers. For URL path versioning, update the `[Route]` attribute.

    ```csharp
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        // Actions for v1.0
    }

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class ProductsV2Controller : ControllerBase
    {
        // Actions for v2.0
    }
    ```

## Best Practices

*   Start versioning from the beginning.
*   Use a consistent strategy.
*   Document each version.
*   Communicate deprecations.
*   Consider semantic versioning.
