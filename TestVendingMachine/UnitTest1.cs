using VendingMachineState;

namespace TestVendingMachine
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSimple()
        {
            // Arrange
            Context vendingMachine = new Context();

            // Get the initial amount of coffee
            int initialCoffeeAmount = vendingMachine.data["coffee"].Item1;

            // Act
            bool itemSelected = vendingMachine.SelectItem("coffee", 2);
            bool moneyInserted = vendingMachine.InsertMoney(30);
            bool itemDispensed = vendingMachine.DispenseItem();

            // Get the updated amount of coffee
            int updatedCoffeeAmount = vendingMachine.data["coffee"].Item1;

            // Assert
            Assert.IsTrue(itemSelected, "Item selection failed.");
            Assert.IsTrue(moneyInserted, "Money insertion failed.");
            Assert.IsTrue(itemDispensed, "Item dispensing failed.");

            // Check if the amount of coffee has changed
            Assert.AreEqual(initialCoffeeAmount - 2, updatedCoffeeAmount, "Coffee amount did not change as expected.");

        }

        [TestMethod]
        public void TestBuyItemNotAvailable()
        {
            // Arrange
            Context vendingMachine = new Context();

            // Act
            bool itemSelected = vendingMachine.SelectItem("green tea", 1); // Attempt to buy green tea
            bool moneyInserted = vendingMachine.InsertMoney(10);
            bool itemDispensed = vendingMachine.DispenseItem();

            // Assert
            Assert.IsFalse(itemSelected, "Item selection should fail (green tea is not available).");
            Assert.IsFalse(moneyInserted, "Money insertion should fail (item not selected).");
            Assert.IsFalse(itemDispensed, "Item dispensing should fail (no item selected).");
        }

        [TestMethod]
        public void TestBuyCoffeeInsufficientQuantity()
        {
            // Arrange
            Context vendingMachine = new Context();

            // Act
            bool itemSelected = vendingMachine.SelectItem("coffee", 15); // Buy 15 coffees
            bool itemSelectRepeated = vendingMachine.SelectItem("coffee", 10); // Buy 15 more coffees
            bool moneyInserted = vendingMachine.InsertMoney(200); // Insert money for coffees
            bool itemDispensed = vendingMachine.DispenseItem(); // Try to dispense  coffees

            // Assert
            Assert.IsTrue(itemSelected, "First item selection should succeed.");
            Assert.IsFalse(itemSelectRepeated, "Trying to select more coffee, but should fail as insufficient stock");
            Assert.IsFalse(moneyInserted, "Money insertion should not succeed.");
            Assert.IsFalse(itemDispensed, "Item dispensing should fail.");
        }

        [TestMethod]
        public void TestResetItem()
        {
            // Arrange
            Context vendingMachine = new Context();

            int initialMilkCount = vendingMachine.data["milk"].Item1;

            // Act - Select 6 coffees, then reset with 10 milks
            bool coffeeSelected = vendingMachine.SelectItem("coffee", 6);
            bool milkSelected = vendingMachine.SelectItem("milk", 10);
            string currentItem = vendingMachine.item;
            bool milkMoneyInserted = vendingMachine.InsertMoney(100); // Assuming coffee costs 15 each
            bool milkDispensed = vendingMachine.DispenseItem();

            int finalMilkCount = vendingMachine.data["milk"].Item1;

            // Assert - Check selection and purchase
            Assert.IsTrue(coffeeSelected, "Coffee selection should succeed.");
            Assert.AreEqual("milk", currentItem, "Item succesfully resetted to milk");
            Assert.IsTrue(milkMoneyInserted, "Money insertion for milk should succeed.");
            Assert.IsTrue(milkDispensed, "Milk dispensing should succeed.");

            // Check Milk Count
            Assert.AreEqual(10, initialMilkCount - finalMilkCount, "Decrement in milk count is correct");

        }

        [TestMethod]
        public void TestInsertMoneyBeforeSelectingItem()
        {
            // Arrange
            Context vendingMachine = new Context();

            // Act
            bool moneyInserted = vendingMachine.InsertMoney(10);

            // Assert
            Assert.IsFalse(moneyInserted, "Money insertion should fail without selecting an item.");
        }

        [TestMethod]
        public void TestDispenseBeforeSelectingItem()
        {
            // Arrange
            Context vendingMachine = new Context();

            // Act
            bool itemDispensed = vendingMachine.DispenseItem();

            // Assert
            Assert.IsFalse(itemDispensed, "Item dispensing should fail without selecting an item.");
        }

        [TestMethod]
        public void TestDispenseBeforeInsertingMoney()
        {
            // Arrange
            Context vendingMachine = new Context();

            // Act
            bool itemSelected = vendingMachine.SelectItem("coffee", 2);
            bool itemDispensed = vendingMachine.DispenseItem();

            // Assert
            Assert.IsTrue(itemSelected, "Item selection should succeed.");
            Assert.IsFalse(itemDispensed, "Item dispensing should fail without inserting money.");
        }

        [TestMethod]
        public void TestInsertingInsufficientMoney()
        {
            // Arrange
            Context vendingMachine = new Context();

            // Act - Select coffee and insert insufficient money
            bool itemSelected = vendingMachine.SelectItem("coffee", 2);
            bool wrongMoneyInserted = vendingMachine.InsertMoney(20); // Assuming coffee costs 15 each
            bool correctMoneyInserted = vendingMachine.InsertMoney(30);
            bool itemDispensed = vendingMachine.DispenseItem();

            // Assert
            Assert.IsTrue(itemSelected, "Item selection should succeed.");
            Assert.IsFalse(wrongMoneyInserted, "Money insertion should not succeed.");
            Assert.IsTrue(correctMoneyInserted, "Money insertion should succeed.");
            Assert.IsTrue(itemDispensed, "Item dispensing should succeed.");
        }

        [TestMethod]
        public void TestBuyMultipleCoffeesAndMilk()
        {
            // Arrange
            Context vendingMachine = new Context();

            // Act - Buy 5 coffees, insert money, and dispense
            bool coffeeSelected = vendingMachine.SelectItem("coffee", 5);
            bool coffeeMoneyInserted = vendingMachine.InsertMoney(5 * 15); // Assuming coffee costs 15 each
            bool coffeeDispensed = vendingMachine.DispenseItem();

            // Assert - Check coffee selection and purchase
            Assert.IsTrue(coffeeSelected, "Coffee selection should succeed.");
            Assert.IsTrue(coffeeMoneyInserted, "Money insertion for coffee should succeed.");
            Assert.IsTrue(coffeeDispensed, "Coffee dispensing should succeed.");

            // Act - Buy 10 milk
            bool milkSelected = vendingMachine.SelectItem("milk", 10);
            bool milkMoneyInserted = vendingMachine.InsertMoney(10 * 10); // Assuming milk costs 10 each
            bool milkDispensed = vendingMachine.DispenseItem();

            // Assert - Check milk selection
            Assert.IsTrue(milkSelected, "Milk selection should succeed.");
            Assert.IsTrue(milkMoneyInserted, "Money insertion for milk should succeed.");
            Assert.IsTrue(milkDispensed, "Milk dispensing should succeed initially.");

            // Act - Buy 12 more milks
            bool milkSelected1 = vendingMachine.SelectItem("milk", 12);

            // Assert - Check milk selection
            Assert.IsFalse(milkSelected1, "Milk selection should fail due to insufficient stock");

            Assert.AreEqual(10, vendingMachine.data["milk"].Item1, "Milk quantity before buying should be 10.");
        }


    }
}