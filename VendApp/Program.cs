using VendingMachineState;

namespace VendApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVMState? currContext = new Context();

            string input = "";

            while(currContext != null && input != "q")
            {
                Console.WriteLine(currContext.GetStateString());
                Console.WriteLine("Input S:[item],[quantity] to try and select the given item in given quantiy");
                Console.WriteLine("Input M:[amount] to try and insert this amount of money");
                Console.WriteLine("Input D: to collect the dispensed items");
                input = Console.ReadLine();

                switch (input[0])
                {
                    case 'S':
                        var inputs = input.Split(':')[1].Split(',');
                        currContext.SelectItem(inputs[0], Int32.Parse(inputs[1]));
                        break;
                    case 'M':
                        currContext.InsertMoney(Int32.Parse(input.Split(':')[1]));
                        break;
                    case 'D':
                        currContext.DispenseItem();
                        break;
                    default: 
                        Console.WriteLine("Unknown input");
                        break;
                }
                
            }
            
        }
    }
}