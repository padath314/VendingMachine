using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineState
{
    internal class AskMoneyState : IVMState
    {
        private int _n;
        private string _item;
        private readonly Dictionary<string, Tuple<int,int>> _data;
        internal AskMoneyState(string _item, int _n, Dictionary<string, Tuple<int, int>> _data)
        {
            this._n = _n;
            this._item = _item;
            this._data = _data;
        }
        public bool InsertMoney(int money)
        {
            Console.WriteLine($"Amount inserted is {money}");
            if (money == _n * _data[_item].Item2)
            {
                return true;
            }
            else if( money > _n * _data[_item].Item2)
            {
                Console.WriteLine("You paid extra! We'ree keeping it");
                return true;
            }
            
            Console.WriteLine($"Amount Insufficient. Rejecting ${money}");
            return false;
        }
        public bool SelectItem(string _item, int _n)
        {
            if (this._item == _item)
            {
                if(this._n + _n > _data[this._item].Item2)
                {
                    Console.WriteLine("Quantity not sufficient");
                    return false;
                }
                else
                {
                    Console.WriteLine($"Number of ${this._item} incremented by {_n}");
                    this._n += _n;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Item resetted");
                this._item = _item;
                this._n = _n;
            }
            return false;
        }

        public bool DispenseItem()
        {
            Console.WriteLine("Insert Money!");
            return false;
        }
        public string GetStateString()
        {
            return $"Select more or Insert Money\nCurrently Selected: {_item} x {_n} \nTotal Money to be inserted: {_data[_item].Item2*_n}";
        }

    }
}
