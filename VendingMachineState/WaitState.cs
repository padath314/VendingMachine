/******************************************************************************
 * Filename    = WaitState.cs
 *
 * Author      = Susan Varghese Padath
 *
 * Product     = VendingMachineState
 * 
 * Project     = VendingMachineState
 *
 * Description = The WaitState represents the state of the vending machine where users can select items.
 *****************************************************************************/

namespace VendingMachineState
{
    /// <summary>
    /// The WaitState represents the state of the vending machine where users can select items.
    /// </summary>
    internal class WaitState : IVMState
    {
        private readonly Dictionary<string , Tuple<int , int>> _data; // Stores item data.

        /// <summary>
        /// Initializes a new instance of the WaitState class with item data and displays available items.
        /// </summary>
        /// <param name="_data">The dictionary containing item data.</param>
        public WaitState( Dictionary<string , Tuple<int , int>> _data )
        {
            this._data = _data;
            Console.WriteLine( "Items Available are:\n" );
            Console.WriteLine( "Item\t\tQuantity\tCost" );

            // Iterate through item data and display item information.
            foreach (KeyValuePair<string , Tuple<int , int>> kvp in this._data)
            {
                string itemName = kvp.Key;
                int quantity = kvp.Value.Item1;
                int cost = kvp.Value.Item2;

                Console.WriteLine( $"{itemName}\t\t{quantity}\t\t${cost}" );
            }
        }

        /// <summary>
        /// Checks if the selected item is available and has sufficient quantity.
        /// </summary>
        /// <param name="item">The name of the item to select.</param>
        /// <param name="n">The quantity of the item to select.</param>
        /// <returns>True if the item can be selected; otherwise, false.</returns>
        public bool SelectItem( string item , int n )
        {
            if (_data.ContainsKey( item ))
            {
                if (_data[item].Item1 >= n)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine( "Quantity not sufficient" );
                    return false;
                }
            }
            else
            {
                Console.WriteLine( "Item not available" );
                return false;
            }
        }

        /// <summary>
        /// Informs the user to select an item first before dispensing.
        /// </summary>
        /// <returns>Always returns false.</returns>
        public bool DispenseItem()
        {
            Console.WriteLine( "First select the item" );
            return false;
        }

        /// <summary>
        /// Informs the user to select an item first before inserting money.
        /// </summary>
        /// <param name="money">The amount of money to insert.</param>
        /// <returns>Always returns false.</returns>
        public bool InsertMoney( int money )
        {
            Console.WriteLine( "First select the item" );
            return false;
        }

        /// <summary>
        /// Returns a description of the current state.
        /// </summary>
        /// <returns>A string describing the state.</returns>
        public string GetStateString()
        {
            return "Waiting for the user to select items\n";
        }
    }
}
