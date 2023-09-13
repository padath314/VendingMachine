using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineState
{
    internal class DispenseState : IVMState
    {
        private int money;
        private string item;
        private int n;

        Dictionary<string, Tuple<int, int>> data;

        internal DispenseState(int _money, string _item, int _n, Dictionary<string, Tuple<int, int>> _data)
        {
            money = _money;
            item = _item;
            n = _n;
            data = _data;
        }
        public bool DispenseItem()
        {
            int newValue = data[item].Item1 - n;
            Tuple<int, int> updatedTuple = new Tuple<int, int>(newValue, data[item].Item2);
            data[item] = updatedTuple;

            Console.WriteLine($"Recieved amount : {money} \n Dispensed {n} nos. of {item}");
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
