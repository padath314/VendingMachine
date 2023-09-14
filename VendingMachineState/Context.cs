/******************************************************************************
* Filename    = Context.cs
*
* Author      = Susan Varghese Padath
*
* Product     = VendingMachine
* 
* Project     = VendingMachineState
*
* Description = This file contains the implementation of a vending machine using
*               the State Design Pattern. The Context class represents the main
*               vending machine and implements the IVMState interface to handle
*               different vending machine states.
*****************************************************************************/

namespace VendingMachineState
{
    /// <summary>
    /// The Context class represents the main vending machine and implements the IVMState interface.
    /// </summary>
    public class Context : IVMState
    {
        private IVMState _currentState; // Stores the current state of the vending machine.
        private int _money; // Stores the amount of money inserted.
        private int _n; // Stores the quantity of items selected.

        public string Item { get; private set; } // Represents the selected item.

        public Dictionary<string , Tuple<int , int>> Data { get; private set; } // Stores item data (stock and price).

        /// <summary>
        /// Constructor to initialize the vending machine with initial data and state.
        /// </summary>
        public Context()
        {
            Data = new Dictionary<string , Tuple<int , int>>
            {
                ["coffee"] = Tuple.Create( 20 , 15 ) ,
                ["tea"] = Tuple.Create( 20 , 12 ) ,
                ["milk"] = Tuple.Create( 20 , 10 )
            };

            // Initial state is set to WaitState.
            _currentState = new WaitState( Data );
            _money = 0;
            _n = 0;
            Item = "";
        }

        /// <summary>
        /// DispenseItem method transitions the machine to the WaitState after dispensing.
        /// </summary>
        public bool DispenseItem()
        {
            if (_currentState.DispenseItem())
            {
                _currentState = new WaitState( Data );
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// GetStateString method returns the name of the current state.
        /// </summary>
        public string GetStateString()
        {
            return _currentState.GetStateString();
        }

        /// <summary>
        /// InsertMoney method handles money insertion and transitions to DispenseState if successful.
        /// </summary>
        public bool InsertMoney( int money )
        {
            if (_currentState.InsertMoney( money ))
            {
                _money = money;
                _currentState = new DispenseState( _money , Item , _n , Data );
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// SelectItem method handles item selection and transitions to AskMoneyState if successful.
        /// </summary>
        public bool SelectItem( string item , int n )
        {
            Item = item;
            _n = n;
            if (_currentState.SelectItem( item , n ))
            {
                _currentState = new AskMoneyState( Item , _n , Data );
                return true;
            }

            return false;
        }
    }
}
