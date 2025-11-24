# Model Validation in ASP.NET Core

Model validation in ASP.NET Core ensures that user input conforms to business rules and maintains data integrity. This is primarily achieved through validation attributes applied to model properties.

## 1. Data Annotation Attributes

ASP.NET Core provides built-in validation attributes in the `System.ComponentModel.DataAnnotations` namespace:

*   **`[Required]`**: Ensures a property has a value.
*   **`[StringLength(maxLength, MinimumLength = minLength)]`**: Defines string length constraints.
*   **`[Range(min, max)]`**: Validates a numerical property within a specified range.
*   **`[EmailAddress]`**: Checks for a valid email format.
*   **`[Phone]`**: Validates a phone number format.
*   **`[RegularExpression("pattern")]`**: Validates against a regular expression.
*   **`[Compare("PropertyName")]`**: Compares two properties (e.g., password confirmation).

**Example Model:**

```csharp
using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
}
```

## 2. Checking Model Validity in the Controller

The ASP.NET Core runtime automatically performs validation. In your controller, you can check the `ModelState.IsValid` property:

```csharp
[HttpPost]
public IActionResult Register(RegisterViewModel model)
{
    if (ModelState.IsValid)
    {
        // Model is valid, proceed with logic
        return Ok();
    }

    // Model is invalid, return errors
    return BadRequest(ModelState);
}
```

For API controllers with `[ApiController]`, the framework automatically returns a `400 Bad Request` with validation errors if `ModelState.IsValid` is `false`.

## 3. Custom Validation Attributes

For complex validation logic, you can create custom validation attributes by inheriting from `ValidationAttribute` and overriding the `IsValid` method.

**Example Custom Attribute:**

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class NoFutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date && date.Date > DateTime.Now.Date)
        {
            return new ValidationResult(ErrorMessage ?? "The date cannot be in the future.");
        }
        return ValidationResult.Success;
    }
}
```
