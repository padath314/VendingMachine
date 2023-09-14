# Vending Machine using State Design Pattern

## Overview

This GitHub repository contains an implementation of a vending machine using the State Design Pattern. Software design patterns are proven solutions to recurring design problems in software development. The State Design Pattern is a behavioral pattern that allows an object to alter its behavior when its internal state changes. In the context of a vending machine, it is crucial to manage different states such as "idle," "item selected," "payment pending," and "dispensing" seamlessly. This repository showcases the application of the State Design Pattern to create a robust vending machine system.

## Design

The vending machine implemented in this project is designed to demonstrate the State Design Pattern. The State Pattern is ideal for managing the various states that a vending machine can be in, such as selecting an item, processing payment, and dispensing the item. The design separates these states into individual classes, making it easier to understand, extend, and maintain the vending machine's behavior.

The key components of the design include:

- **VendingMachine:** The main class representing the vending machine. It holds a reference to the current state and delegates operations to the state objects.

- **VendingMachineState:** An interface that defines the contract for all vending machine states. Each state (e.g., IdleState, ItemSelectedState, PaymentPendingState) implements this interface and handles specific operations associated with that state.

- **Item:** Represents an item that can be selected and purchased from the vending machine. It includes properties such as name, price, and availability.

- **Coin:** Represents a coin used for payment. It includes properties such as value and currency.

The State Design Pattern allows the vending machine to transition seamlessly between states based on user interactions, ensuring that the machine behaves correctly and consistently throughout the purchase process.

## Implementation

The implementation of the vending machine using the State Design Pattern can be found in the source code within this repository. It includes:

- **VendingMachine.cs:** The main class representing the vending machine, responsible for managing states and processing user interactions.

- **VendingMachineState.cs:** The interface defining the contract for vending machine states.

- **IdleState.cs:** An example state class representing the idle state of the vending machine.

- **ItemSelectedState.cs:** An example state class representing the state when an item has been selected by the user.

- **PaymentPendingState.cs:** An example state class representing the state when payment is pending for the selected item.

- **Item.cs:** A class representing the items available in the vending machine.

- **Coin.cs:** A class representing the coins used for payment.

## Usage

To use this vending machine implementation, you can follow these steps:

1. Clone the repository to your local machine.

2. Open the project in your preferred C# development environment (e.g., Visual Studio or Visual Studio Code).

3. Build and run the project to see the vending machine in action. You can interact with it by selecting items, adding coins, and completing the purchase process.

## Dependencies

This project was developed using C# and does not have any external dependencies beyond the standard C# libraries.

## Environment

The project has been tested and developed using the following environment:

- .NET Framework or .NET Core SDK installed on your system.
- Integrated Development Environment (IDE) of your choice (e.g., Visual Studio or Visual Studio Code).

Please make sure you have the necessary C# development tools installed in your environment to build and run the project.

## Contributing

If you wish to contribute to this project, please fork the repository and create a pull request with your changes. We welcome any contributions that improve the design, functionality, or documentation of the vending machine implementation.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Thank you for your interest in this vending machine implementation using the State Design Pattern. We hope you find it useful for understanding and applying design patterns in your own software projects. If you have any questions or feedback, please feel free to open an issue or contact the project maintainers.

Happy coding!
