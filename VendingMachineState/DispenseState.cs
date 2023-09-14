/******************************************************************************
 * Filename    = DispenseState.cs
 *
 * Author      = Susan Varghese Padath
 *
 * Product     = VendingMachine
 * 
 * Project     = VendingMachineState
 *
 * Description = The DispenseState class represents the state of the vending machine where items are being dispensed.
 *****************************************************************************/

namespace VendingMachineState
{
    /// <summary>
    /// The DispenseState class represents the state of the vending machine where items are being dispensed.
    /// </summary>
    internal class DispenseState : IVMState
    {
        private readonly int _money; // Amount of money inserted.
        private readonly string _item; // Selected item.
        private readonly int _n; // Quantity of the selected item.

        readonly Dictionary<string , Tuple<int , int>> _data; // Stores item data.

        /// <summary>
        /// Initializes a new instance of the DispenseState class with money, item, quantity, and item data.
        /// </summary>
        /// <param name="_money">The amount of money inserted.</param>
        /// <param name="_item">The name of the selected item.</param>
        /// <param name="_n">The quantity of the selected item.</param>
        /// <param name="_data">The dictionary containing item data.</param>
        internal DispenseState( int _money , string _item , int _n , Dictionary<string , Tuple<int , int>> _data )
        {
            this._money = _money;
            this._item = _item;
            this._n = _n;
            this._data = _data;
        }

        /// <summary>
        /// Dispenses the selected item and updates the item quantity.
        /// </summary>
        /// <returns>Always returns true.</returns>
        public bool DispenseItem()
        {
            int newValue = _data[_item].Item1 - _n;
            Tuple<int , int> updatedTuple = new( newValue , _data[_item].Item2 );
            _data[_item] = updatedTuple;

            Console.WriteLine( $"Received amount: {_money} \nDispensed {_n} nos. of {_item}" );
            return true;
        }

        /// <summary>
        /// Informs the user that money is already inserted.
        /// </summary>
        /// <param name="money">The amount of money inserted.</param>
        /// <returns>Always returns false.</returns>
        public bool InsertMoney( int money )
        {
            Console.WriteLine( "Already inserted money" );
            return false;
        }

        /// <summary>
        /// Informs the user to wait until items are dispensed before buying more.
        /// </summary>
        /// <param name="item">The name of the item to select.</param>
        /// <param name="n">The quantity of the item to select.</param>
        /// <returns>Always returns false.</returns>
        public bool SelectItem( string item , int n )
        {
            Console.WriteLine( "Wait till items are dispensed to buy more" );
            return false;
        }

        /// <summary>
        /// Returns a description of the current state.
        /// </summary>
        /// <returns>A string describing the state.</returns>
        public string GetStateString()
        {
            return "Items are being dispensed";
        }
    }
}
