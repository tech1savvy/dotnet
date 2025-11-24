# Enabling the Swagger UI

This document outlines the changes made to the project to enable the interactive Swagger UI.

The initial setup used `Microsoft.AspNetCore.OpenApi`, which only exposes the `openapi.json` file and does not include a UI. To provide the full interactive Swagger UI, the project was updated to use `Swashbuckle.AspNetCore`.

The following changes were made:

### 1. Updated NuGet Packages

First, the necessary NuGet packages were updated.

- **Added `Swashbuckle.AspNetCore`:** This package provides the Swagger UI and is the standard for ASP.NET Core applications.

  ```bash
  dotnet add package Swashbuckle.AspNetCore
  ```

- **Removed `Microsoft.AspNetCore.OpenApi`:** This package was removed to avoid conflicts and keep the project clean.

  ```bash
  dotnet remove package Microsoft.AspNetCore.OpenApi
  ```

### 2. Updated `Program.cs`

Next, the `Program.cs` file was updated to configure and use Swashbuckle.

- **Service Configuration:** The service registration was updated from `AddOpenApi()` to `AddSwaggerGen()`. `AddEndpointsApiExplorer()` is also added, which is required for API exploration.

  **Before:**
  ```csharp
  builder.Services.AddOpenApi();
  ```

  **After:**
  ```csharp
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();
  ```

- **Pipeline Configuration:** The request pipeline was updated to use the Swagger and Swagger UI middleware.

  **Before:**
  ```csharp
  if (app.Environment.IsDevelopment())
  {
      app.MapOpenApi();
  }
  ```

  **After:**
  ```csharp
  if (app.Environment.IsDevelopment())
  {
      app.UseSwagger();
      app.UseSwaggerUI();
  }
  ```

### Accessing the Swagger UI

After these changes, the interactive Swagger UI can be accessed at the `/swagger` endpoint when the application is running.

**URL:** [http://localhost:5275/swagger](http://localhost:5275/swagger)
