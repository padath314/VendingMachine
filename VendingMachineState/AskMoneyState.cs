/******************************************************************************
 * Filename    = AskMoneyState.cs
 *
 * Author      = Susan Varghese Padath
 *
 * Product     = VendingMachine
 * 
 * Project     = VendingMachineState
 *
 * Description = The AskMoneyState class represents the state of the vending machine where users are prompted to insert money.
 *****************************************************************************/

namespace VendingMachineState
{
    /// <summary>
    /// The AskMoneyState class represents the state of the vending machine where users are prompted to insert money.
    /// </summary>
    internal class AskMoneyState : IVMState
    {
        private int _n; // Number of items selected.
        private string _item; // Selected item.
        private readonly Dictionary<string , Tuple<int , int>> _data; // Stores item data.

        /// <summary>
        /// Initializes a new instance of the AskMoneyState class with item data, item name, and quantity.
        /// </summary>
        /// <param name="_item">The name of the selected item.</param>
        /// <param name="_n">The quantity of the selected item.</param>
        /// <param name="_data">The dictionary containing item data.</param>
        internal AskMoneyState( string _item , int _n , Dictionary<string , Tuple<int , int>> _data )
        {
            this._n = _n;
            this._item = _item;
            this._data = _data;
        }

        /// <summary>
        /// Checks if the inserted money is correct for the selected item and quantity.
        /// </summary>
        /// <param name="money">The amount of money inserted.</param>
        /// <returns>True if the money is correct; otherwise, false.</returns>
        public bool InsertMoney( int money )
        {
            Console.WriteLine( $"Amount inserted is {money}" );
            if (money == _n * _data[_item].Item2)
            {
                return true;
            }
            else if (money > _n * _data[_item].Item2)
            {
                Console.WriteLine( "You paid extra! We're keeping it" );
                return true;
            }

            Console.WriteLine( $"Amount Insufficient. Rejecting ${money}" );
            return false;
        }

        /// <summary>
        /// Handles item selection or reset.
        /// </summary>
        /// <param name="_item">The name of the item to select or reset.</param>
        /// <param name="_n">The quantity of the item to select.</param>
        /// <returns>True if the selection or reset is successful; otherwise, false.</returns>
        public bool SelectItem( string _item , int _n )
        {
            if (this._item == _item)
            {
                if (this._n + _n > _data[this._item].Item2)
                {
                    Console.WriteLine( "Quantity not sufficient" );
                    return false;
                }
                else
                {
                    Console.WriteLine( $"Number of ${this._item} incremented by {_n}" );
                    this._n += _n;
                    return true;
                }
            }
            else
            {
                Console.WriteLine( "Item resetted" );
                this._item = _item;
                this._n = _n;
            }
            return false;
        }

        /// <summary>
        /// Informs the user to insert money before dispensing.
        /// </summary>
        /// <returns>Always returns false.</returns>
        public bool DispenseItem()
        {
            Console.WriteLine( "Insert Money!" );
            return false;
        }

        /// <summary>
        /// Returns a description of the current state.
        /// </summary>
        /// <returns>A string describing the state.</returns>
        public string GetStateString()
        {
            return $"Select more or Insert Money\nCurrently Selected: {_item} x {_n} \nTotal Money to be inserted: {_data[_item].Item2 * _n}";
        }
    }
}
