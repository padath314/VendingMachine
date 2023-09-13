using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineState
{
    internal class AskMoneyState : IVMState
    {
        private int n;
        private string item;
        private Dictionary<string, Tuple<int,int>> data;
        internal AskMoneyState(string _item, int _n, Dictionary<string, Tuple<int, int>> _data)
        {
            n = _n;
            item = _item;
            data = _data;
        }
        public bool InsertMoney(int money)
        {
            Console.WriteLine($"Amount inserted is {money}");
            if (money == n * data[item].Item2)
                return true;
            else if( money > n * data[item].Item2)
            {
                Console.WriteLine("You paid extra! We'ree keeping it");
                return true;
            }
            
            Console.WriteLine($"Amount Insufficient. Rejecting ${money}");
            return false;
        }
        public bool SelectItem(string _item, int _n)
        {
            if (item == _item)
            {
                if(n + _n > data[item].Item2)
                {
                    Console.WriteLine("Quantity not sufficient");
                    return false;
                }
                else
                {
                    Console.WriteLine($"Number of ${item} incremented by {_n}");
                    n = n + _n;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Item resetted");
                item = _item;
                n = _n;
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
            return $"Select more or Insert Money\nCurrently Selected: {item} x {n} \nTotal Money to be inserted: {data[item].Item2*n}";
        }

    }
}
