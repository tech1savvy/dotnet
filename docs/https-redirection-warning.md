# HTTPS Redirection Warning

When running the application, you may encounter the following warning:

```
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.
```

## Cause

This warning is caused by the HTTPS Redirection Middleware (`app.UseHttpsRedirection();` in `Program.cs`). This middleware is responsible for automatically redirecting all HTTP requests to HTTPS.

When you run the application using a launch profile that only specifies an HTTP URL (like the `http` profile in `Properties/launchSettings.json`), the middleware is still active but cannot find a corresponding HTTPS port to redirect to, which results in the warning.

## Fixes

There are two common ways to resolve this issue:

### 1. Run with the `https` Profile

The `https` launch profile is typically configured to listen on both HTTP and HTTPS. By using this profile, the redirection middleware will know where to redirect HTTP requests.

You can run the application with the `https` profile using the following command:

```bash
dotnet run --launch-profile https
```

### 2. Remove HTTPS Redirection

If your application does not require HTTPS, you can simply remove the HTTPS redirection middleware. To do this, delete or comment out the following line in `Program.cs`:

```csharp
app.UseHttpsRedirection();
```

This will stop the application from attempting to redirect HTTP requests, and the warning will no longer appear.
