# Routing in ASP.NET Core

Routing is the process of mapping incoming HTTP requests to application endpoints, such as controller actions.

## Two Types of Routing

1.  **Convention-Based Routing:**
    *   Defines global route templates that apply to all controllers.
    *   Typically configured in `Program.cs`.
    *   A default route might look like: `{controller=Home}/{action=Index}/{id?}`.

2.  **Attribute-Based Routing:**
    *   Defines routes directly on controllers and action methods using attributes like `[Route]`, `[HttpGet]`, `[HttpPost]`, etc.
    *   Provides more granular control and is preferred for REST APIs.
    *   Example:
        ```csharp
        [ApiController]
        [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
            [HttpGet("{id}")]
            public IActionResult GetProductById(int id)
            {
                // ...
            }
        }
        ```

## Routing Middleware

Routing is handled by two middleware components:

1.  **`UseRouting()`:** Matches the request URL to an endpoint.
2.  **`UseEndpoints()`:** Executes the code for the matched endpoint.

In recent versions of .NET, these are often configured automatically. The separation allows other middleware (like authentication) to be placed between them.
