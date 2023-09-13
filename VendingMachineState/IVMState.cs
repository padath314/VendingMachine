using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineState
{
    public interface IVMState
    {
        bool SelectItem(string item, int n);
        bool InsertMoney(int money);
        bool DispenseItem();

        string GetStateString();

    }
}
