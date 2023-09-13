using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineState
{
    public class Context : IVMState
    {
        private IVMState _currentState;
        private int _money;
        private int _n;
        public string item { get; private set; }

        public Dictionary<string, Tuple<int, int>> data { get; private set; }

        public Context()
        {
            data = new Dictionary<string , Tuple<int , int>>
            {
                ["coffee"] = Tuple.Create( 20 , 15 ) ,
                ["tea"] = Tuple.Create( 20 , 12 ) ,
                ["milk"] = Tuple.Create( 20 , 10 )
            };

            _currentState = new WaitState(data);
            _money = 0;
            _n = 0;
            item = "";


        }
        public bool DispenseItem()
        {
            if (_currentState.DispenseItem())
            {
                _currentState = new WaitState(data);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetStateString()
        {
            return _currentState.GetStateString();
        }

        public bool InsertMoney(int _money)
        {
            if (_currentState.InsertMoney(_money))
            {
                this._money = _money;
                _currentState = new DispenseState( this._money , item , _n , data );
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SelectItem(string _item, int _n)
        {
            item = _item;
            this._n = _n;
            if (_currentState.SelectItem(_item, _n))
            {
                _currentState = new AskMoneyState( item , this._n, data );
                return true;
            }
            
            return false;
        }
    }
}
