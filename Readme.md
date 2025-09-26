# Trading System

A simple console-based trading system written in C# (.NET 9). This project allows users to register, log in, add items for trade, browse other users' items, and request trades. The system is designed for learning and demonstration purposes.

## Features

- **User Registration & Login**: Create an account, log in, and log out.
- **Item Management**: Add items to your account and view your own or others' items.
- **Trade Requests**: Request trades with other users (feature under development).
- **Message System**: Receive notifications about trade requests and actions.
- **Console Menus**: User-friendly, color-coded menus for navigation.

## Project Structure

- `Program.cs` — Main application logic and menu system
- `Classes/`
  - `User.cs` — User model and authentication
  - `Item.cs` — Item model
  - `Trade.cs` — Trade model and status
  - `Utils.cs` — Utility and menu display functions
- `trading_system.csproj` — Project file

## How to Run

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

3. **Usage**:
   - Follow the on-screen menu to register, log in, add items, and request trades.
   - Use the menu numbers to navigate.

## Notes
- The trade request and management features are still under development.
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
