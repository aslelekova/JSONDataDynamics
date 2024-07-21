# JSON Data Dynamics

## Overview

**JSON Data Dynamics** is a C# application designed to handle JSON data through a robust library and a user-friendly console interface. This project enables efficient data management, including reading, manipulating, and saving JSON data, while providing mechanisms for real-time updates and user interaction.

## Class Library

### Components

1. **Data Models**

   - **Class Definitions**: Replace the placeholder name `MyType` with descriptive class names that accurately represent the JSON data structures. Define classes to model each entity based on the JSON schema.
   - **Read-Only Properties**: Implement properties with private setters to maintain encapsulation and integrity of data. Include constructors for proper initialization.
   - **`ToJSON` Method**: Add a `ToJSON` method to each class to serialize the object into a JSON string representation.

2. **Event Handling**

   - **`Updated` Event**: Each class should include an `EventHandler<EventArgs>` event called `Updated` to signal changes to subscribed handlers.
   - **Custom `EventArgs`**: Create a custom class derived from `EventArgs` to capture and store the timestamp of each update event.

3. **AutoSaver Class**

   - **Event Subscription**: The `AutoSaver` class subscribes to `Updated` events from the data model classes.
   - **Automatic Saving**: When two updates occur within a 15-second window, the `AutoSaver` class automatically saves the current data state to a new JSON file with a `_tmp.json` suffix.

### Design Principles

- **Encapsulation**: Protect data by restricting direct access and modification, exposing only necessary operations through methods.
- **Single Responsibility Principle**: Each class should perform a single function or responsibility.
- **Liskov Substitution Principle**: Ensure subclasses can replace their base classes without altering the correct functioning of the application.
- **Dependency Inversion Principle**: Depend on abstractions rather than concrete implementations to reduce coupling.

## Console Application

### Features

1. **Data Management**

   - **File Operations**: Users can specify paths to read from or write JSON data to files.
   - **Sorting and Filtering**: Users can sort and filter data based on selected fields.

2. **Object Editing**

   - **Field Updates**: Allows users to update fields in data objects, excluding identifiers and fields affected by events.
   - **Input Validation**: Ensures user inputs are valid and prompts for corrections if necessary.

3. **Event Handling**

   - **Event Management**: Handles specific events as defined in the individual variant, triggering appropriate responses and actions.

### User Interaction

- **Menu System**: The application features a menu-driven interface for:
  1. Providing file paths for data operations.
  2. Sorting and filtering the data.
  3. Editing fields in data objects.
  4. Saving or displaying modified data.
- **Error Management**: Includes comprehensive error handling for file operations and data processing.

## How to Use

1. **Starting the Application**

   - Launch the console application and follow the interactive menu to manage JSON data.

2. **Data Operations**

   - **Load Data**: Import JSON data from files or console input.
   - **Edit Data**: Modify object fields as needed.
   - **Save Data**: Save changes to a specified file path.

3. **Event Handling**

   - **Automatic Updates**: The application manages automatic saving based on detected changes and event triggers.

## Development Guidelines

- **Error Handling**: Implement robust error handling for file I/O and data processing.
- **Code Quality**: Follow best practices and conventions for C# and .NET 6.0.
- **No External Dependencies**: The project is free from third-party libraries or NuGet packages.
