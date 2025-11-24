# Project Structure

This document outlines the structure of the dotnet project.

- **appsettings.Development.json**: Configuration settings specific to the Development environment. This file can override settings in `appsettings.json`.
- **appsettings.json**: The main configuration file for the application. It contains settings that are not environment-specific.
- **dotnet.csproj**: The project file for this .NET project. It contains information about the project, such as dependencies, build settings, and target framework.
- **dotnet.http**: A file used for making HTTP requests, often for testing APIs exposed by the application.
- **Program.cs**: The main entry point for the application. This is where the application is configured and started.
- **.git/**: This directory contains the Git version control history and configuration for the project.
- **obj/**: This directory contains intermediate files generated during the build process, such as compiled object files. It is typically safe to delete this directory as it will be regenerated on the next build.
- **Properties/**: This directory contains project-specific settings.
  - **launchSettings.json**: This file contains profiles for launching the application, including environment variables and command-line arguments. It is used by Visual Studio and the `dotnet run` command.
