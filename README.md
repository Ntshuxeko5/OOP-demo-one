# OOP Demo

This workspace contains a set of small C# console applications that demonstrate core object-oriented programming concepts using .NET.

## Projects

### 1. Abstraction
Folder: `Abstraction/Abstraction`

Demonstrates abstraction and loose coupling through an interface-based notification system.
- `INotificationService` defines a generic `Send` contract.
- `EmailNotificationService` and `SmsNotificationService` implement the interface.
- `OrderService` depends on `INotificationService`, allowing the notification implementation to be swapped without changing the order placement logic.

### 2. Inheritance
Folder: `Inheritence/Inheritence`

Demonstrates inheritance and method overriding.
- `Vehicle` is a base class with shared vehicle properties.
- `Car` and `Truck` extend `Vehicle` and override `GetDescription()`.
- `ElectricCar` is a sealed derived class that further extends `Car`.

### 3. Pillars of OOP
Folder: `Pillars of OOP/Pillars of OOP`

Demonstrates encapsulation and class-level validation.
- `BankAccount` encapsulates account data behind private fields.
- Public properties expose read-only account information.
- `Deposit`, `Withdraw`, and PIN validation methods enforce business rules.

### 4. Polymorphism
Folder: `Polymorphism/Polymorphism`

Demonstrates polymorphism through an abstract base class.
- `Shape` is an abstract class with an abstract `Area()` method.
- `Circle`, `Rectangle`, and `Triangle` implement `Area()` and inherit the shared `Describe()` behavior.
- Uses a list of `Shape` objects to process different shape types uniformly.

## Prerequisites

- .NET SDK 10.0 or later

## Build and Run

From the repository root, run a specific project:

```powershell
dotnet run --project "Abstraction/Abstraction.csproj"
dotnet run --project "Inheritence/Inheritence.csproj"
dotnet run --project "Pillars of OOP/Pillars of OOP.csproj"
dotnet run --project "Polymorphism/Polymorphism.csproj"
```

You can also build all projects from root by navigating into each folder or by opening the corresponding solution file.

## Folder structure

- `Abstraction/`
- `Inheritence/`
- `Pillars of OOP/`
- `Polymorphism/`

## Notes

Each project is a standalone console application meant for learning and demonstration of OOP principles.
