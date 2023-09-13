using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineState
{
    public class Context : IVMState
    {
        private IVMState currentState;
        private int money;
        private int n;
        public string item { get; private set; }

        public Dictionary<string, Tuple<int, int>> data { get; private set; }

        public Context()
        {
            data = new Dictionary<string, Tuple<int, int>>();

            data["coffee"] = Tuple.Create(20,15);
            data["tea"] = Tuple.Create(20, 12);
            data["milk"] = Tuple.Create(20, 10);

            currentState = new WaitState(data);
            money = 0;
            n = 0;
            item = "";


        }
        public bool DispenseItem()
        {
            if (currentState.DispenseItem())
            {
                currentState = new WaitState(data);
                return true;
            }
            else 
                return false;
        }

        public string GetStateString()
        {
            return currentState.GetStateString();
        }

        public bool InsertMoney(int _money)
        {
            if (currentState.InsertMoney(_money))
            {
                money = _money;
                currentState = new DispenseState(money, item, n, data);
                return true;
            }
            else
                return false;
        }

        public bool SelectItem(string _item, int _n)
        {
            item = _item;
            n = _n;
            if (currentState.SelectItem(_item, _n))
            {
                currentState = new AskMoneyState(item, n, data);
                return true;
            }
            
            return false;
        }
    }
}
