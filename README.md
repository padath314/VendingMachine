# Vending Machine with State Design Pattern

## Introduction to State Design Pattern

The State Design Pattern is a behavioral design pattern that allows an object to alter its behavior when its internal state changes. It enables an object to change its class when its state changes, which is particularly useful for managing complex state-based behaviors. In the context of this project, we utilize the State Design Pattern to efficiently handle various vending machine states, such as selecting items, processing payments, and dispensing products.

Key concepts of the State Design Pattern:

- **State:** Represents a specific state of an object and defines the behaviors associated with that state.

- **Context:** Maintains a reference to the current state and delegates state-specific operations to the state objects.

- **Concrete State:** Implements the behaviors associated with a particular state and transitions between states as required.
  
## Design

This project leverages the State Design Pattern to effectively manage different vending machine states. Each state, such as selecting items, processing payments, and dispensing products, is encapsulated within separate classes. This approach promotes code clarity, making it easier to understand and extend.

### Vending Machine States
![State Diagram](https://github.com/padath314/VendingMachine/blob/master/stateDiagram.jpg)

#### WaitState
The `WaitState` represents the initial state of the vending machine, allowing the user to select the items they want to buy. From this state:

- If an item and the number of items are selected (and if there is enough stock available), the machine transitions to the `InsertMoneyState`.

- The `WaitState` also provides options to reset the selected item or select more of the same item, both of which return the machine to the same `WaitState`.

#### InsertMoneyState
In the `InsertMoneyState`, users can insert money to complete their purchase. The following actions can occur:

- If the inserted money is sufficient to cover the cost of the selected item(s), the machine moves to the `DispenseState`.

- If the inserted money is not enough, the machine remains in the `InsertMoneyState`, asking for the additional amount needed.

#### DispenseState
The `DispenseState` is reached when the machine is ready to dispense the selected item(s) due to successful item selection and sufficient payment. Here's how it works:

- Upon user prompt, the selected item(s) are dispensed, and the stock of items is updated accordingly.

- After dispensing, the machine returns to the `WaitState`, allowing users to make additional selections.

This state transition flow ensures that the vending machine operates smoothly and provides a clear path for users to select items, make payments, and receive their chosen products.

### Dependency Diagram
![Dependancy Diagram](https://github.com/padath314/VendingMachine/blob/master/deoendancyDiagram.jpg)

## Implementation

The project includes C# code files that serve as practical examples of the State Design Pattern. It comprises the main vending machine class, state interfaces, and example state classes, demonstrating how to implement the pattern effectively.
