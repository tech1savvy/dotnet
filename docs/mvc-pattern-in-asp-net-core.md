# MVC Pattern in ASP.NET Core

The Model-View-Controller (MVC) pattern is an architectural design that separates an application into three main components. This separation of concerns is key to creating scalable and maintainable web applications.

## The Three Components

1.  **Model:**
    *   Represents the application's data and business logic.
    *   Manages the state of the application, including reading and writing data.
    *   In ASP.NET Core, Models are typically C# classes.

2.  **View:**
    *   The user interface (UI) of the application.
    *   Presents data to the user and captures user input.
    *   In ASP.NET Core, Views are typically `.cshtml` files using Razor syntax.

3.  **Controller:**
    *   Acts as an intermediary between the Model and the View.
    *   Receives user requests from the View, interacts with the Model, and selects a View to return to the user.
    *   In ASP.NET Core, Controllers are C# classes that inherit from `ControllerBase` or `Controller`.

## Request Lifecycle in ASP.NET Core MVC

1.  **Routing:** An incoming request is mapped to a specific controller and action method.
2.  **Controller Initialization:** The framework creates an instance of the controller.
3.  **Model Binding:** Request data is mapped to the parameters of the action method.
4.  **Action Execution:** The action method is executed, which may involve interacting with the model.
5.  **Result Execution:** The action method returns a result, such as a `ViewResult`.
6.  **View Rendering:** The view is rendered into HTML and sent as the response.

## Project Structure

A typical ASP.NET Core MVC project has the following folder structure:

*   `Controllers/`: Contains controller classes.
*   `Models/`: Contains model classes.
*   `Views/`: Contains view files, organized into subfolders for each controller.
*   `wwwroot/`: Contains static files like CSS, JavaScript, and images.
*   `Program.cs`: The application's entry point for configuration.
