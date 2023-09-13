using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineState
{
    internal class DispenseState : IVMState
    {
        private readonly int _money;
        private readonly string _item;
        private readonly int _n;

        readonly Dictionary<string, Tuple<int, int>> _data;

        internal DispenseState(int _money, string _item, int _n, Dictionary<string, Tuple<int, int>> _data)
        {
            this._money = _money;
            this._item = _item;
            this._n = _n;
            this._data = _data;
        }
        public bool DispenseItem()
        {
            int newValue = _data[_item].Item1 - _n;
            Tuple<int , int> updatedTuple = new( newValue , _data[_item].Item2 );
            _data[_item] = updatedTuple;

            Console.WriteLine($"Recieved amount : {_money} \n Dispensed {_n} nos. of {_item}");
            return true;
        }

        public bool InsertMoney(int money)
        {
            Console.WriteLine("Already inserted money");
            return false;
        }

        public bool SelectItem(string item, int n)
        {
            Console.WriteLine("Wait till items are dispensed to buy more");
            return false;
        }
        public string GetStateString()
        {
            return "Items are being dispensed";
        }
    }
}
