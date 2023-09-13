using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineState
{
    internal class WaitState : IVMState
    {
        private readonly Dictionary<string, Tuple<int, int>> _data;
        public WaitState(Dictionary<string, Tuple<int, int>> _data) 
        {
            this._data = _data;
            Console.WriteLine("Items Available are :\n");
            Console.WriteLine("Item\t\tQuantity\tCost");
            foreach (KeyValuePair<string , Tuple<int , int>> kvp in this._data)
            {
                string itemName = kvp.Key;
                int quantity = kvp.Value.Item1;
                int cost = kvp.Value.Item2;

                Console.WriteLine($"{itemName}\t\t{quantity}\t\t${cost}");
            }
        }
        public bool SelectItem(string item, int n)
        {
            if (_data.ContainsKey(item))
            {
                if (_data[item].Item1 >= n)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Quantity not sufficient");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Item not available");
                return false;
            }
        }
        public bool DispenseItem()
        {
            Console.WriteLine("First select the item");
            return false;
        }

        public bool InsertMoney(int money)
        {
            Console.WriteLine("First select the item");
            return false;
        }

        public string GetStateString()
        {
            return "Waiting for user to select items\n";
        }


    }
}
