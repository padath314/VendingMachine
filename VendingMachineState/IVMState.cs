/******************************************************************************
 * Filename    = IVMState.cs
 *
 * Author      = Susan Varghese Padath
 * 
 * Product     = VendingMachine
 * 
 * Project     = VendingMachineState
 *
 * Description = This file contains the definition of the IVMState interface,
 *               which defines the contract for various states of a vending machine
 *               using the State Design Pattern. Classes that implement this
 *               interface represent different states of the vending machine.
 *****************************************************************************/

namespace VendingMachineState
{
    /// <summary>
    /// The IVMState interface defines the contract for various states of a vending machine.
    /// Classes that implement this interface represent different states of the vending machine.
    /// </summary>
    public interface IVMState
    {
        /// <summary>
        /// Selects an item with a specified quantity.
        /// </summary>
        /// <param name="item">The name of the item to select.</param>
        /// <param name="n">The quantity of the item to select.</param>
        /// <returns>True if the item selection is successful; otherwise, false.</returns>
        bool SelectItem( string item , int n );

        /// <summary>
        /// Inserts money into the vending machine.
        /// </summary>
        /// <param name="money">The amount of money to insert.</param>
        /// <returns>True if the money insertion is successful; otherwise, false.</returns>
        bool InsertMoney( int money );

        /// <summary>
        /// Dispenses the selected item(s).
        /// </summary>
        /// <returns>True if the item(s) are successfully dispensed; otherwise, false.</returns>
        bool DispenseItem();

        /// <summary>
        /// Gets a string representation of the current state.
        /// </summary>
        /// <returns>A string representing the current state.</returns>
        string GetStateString();
    }
}
