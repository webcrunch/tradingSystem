# 🌟 Trading System

A simple console-based trading system written in C# (.NET 9). This project allows users to register, log in, add items for trade, browse other users' items, and request trades. The system is designed for learning and demonstration purposes.

## Features

- **User Registration & Login**: Create an account, log in, and log out.
- **Item Management**: Add items to your account and view your own or others' items.
- **Trade Requests**: Request trades with other users (feature under development).
- **Message System**: Receive notifications about trade requests and actions.
- **Console Menus**: User-friendly, color-coded menus for navigation.
- **Data Persistence**: Uses JSON for saving user, users item and trade data between sessions.


## 🚀 How to Run

1. **Requirements**:
   - [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) or later
   - Windows, Linux, or macOS

2. **Build and Run**:
   - Open a terminal in the project root directory.
   - Run the following commands:
     ```bash
     dotnet build
     dotnet run
     ```

3. **Usage(Quick Guide)**:
   - Follow the on-screen menu to register, log in, add items, and request trades.
   - Use the menu numbers to navigate.

## 💾 Data Backup and Loading (JSON)

The application automatically handles data persistence using JSON files.

Backup Strategy
When the program starts, it attempts to load data from two files in the root directory:

- users.json

- trades.json

If a file is missing, the program starts with an empty list instead of crashing. When the user selects the Exit option, the current state of the User and Trade lists is saved back to these files. This ensures that all changes and accounts are preserved between sessions.

## 🧠 Implementation Choices and Rationale

The following points detail the key design decisions made during the development, adhering to good Object-Oriented Programming (OOP) principles.

1. Separation of Concerns (SRP)
I have chose to strictly separate logic into distinct files based on responsibility:

Program.cs: Handles the high-level application flow (the main loop and the primary switch-statement) and centralizes data management (calling the JSON load/save methods).

Extra.cs (Utility Class): handles user input validation (GetIntegerInput, GetRequiredInput)

Menu.cs (Input and Navigation Class) Prints all menus (e.g., MainMenu).

Display.cs (Output and Presentation) Shows color-coded messages (AlertText, SuccessText) and formatted data (lists of users/items).

FileHandler.cs (Data Persistence) Handles JSON serialization/deserialization and all disk I/O operations.

Rationale: This structure adheres to the Single Responsibility Principle (SRP). The main program logic is clean and readable because it delegates all messy input validation and utility tasks to the Extra class.

2. Input Handling Philosophy
I have intentionally avoided mixing input reading (Console.ReadLine()) and complex validation logic in the main application flow.

Custom Input Functions: Functions like Extra.GetIntegerInput() loop internally until the user provides valid data (e.g., a number).

Extra.WaitForInput(): Used instead of Thread.Sleep().

Rationale: This design choice provides a superior User Experience (UX) by giving control to the user, who can press a key when ready. Furthermore, it follows the DRY (Don't Repeat Yourself) principle by centralizing all input validation code in one place, making the application robust and easy to update.

3. Composition over Inheritance
The class relationships were designed using Composition, avoiding complex Inheritance hierarchies.

Composition Used:

The User class has-a list of Item objects.

The Trade class has-a reference to two User objects (Sender/Receiver) and two Item objects.

Rationale: Using Composition (the "has-a" relationship) results in clear, flexible, and decoupled classes. Since our classes (User, Item, Trade) do not share a strong "is-a" relationship, using Inheritance would have introduced unnecessary complexity and tightly coupled code, making future changes harder.


## Project Structure

- `Program.cs` — Main application logic and menu system
- `Classes/`
  - `User.cs` — User model and authentication
  - `Item.cs` — Item model
  - `Trade.cs` — Trade model and status
  - `Utils.cs` — Utility and menu display functions
- `trading_system.csproj` — Project file

## Notes
- The project uses in-memory lists for users and items (no database).
- Default test users and items are created at startup for demonstration.

## Example Menu
```
  ╔════════════════════════════════╗
  ║    --  Trading System  --      ║
  ║        Choose a number         ║
  ║       User <username>          ║
  ╠════════════════════════════════╣
  ║        1. (Login)              ║
  ║        2. (Account)            ║
  ║        3. (Item)               ║
  ║        4. (Trade)              ║
  ║        7. (Exit)               ║
  ╚════════════════════════════════╝
```

## Author
- Jarl Lindquist

---
