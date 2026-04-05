using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Assignment
{
    class SelfTest
    {
        public static void RunTest(Shop shop, Character chara)
        {

            if (!TestItemLoad(shop))
            {
                Debug.WriteLine("Items not loaded correctly");
            }
            else
            {
                Debug.WriteLine("Load shop success");
            }

            if(!TestGoldCalculation(shop, chara))
            {
                Debug.WriteLine("Gold not calculated correctly, buying or selling not working");
            }
            else
            {
                Debug.WriteLine("Gold calculated correctly, buying and selling working");
            }

            if (!TestBankruptcy(shop, chara))
            {
                Debug.WriteLine("Player just robbed the store");
            }
            else
            {
                Debug.WriteLine("Bankruptcy correct");
            }

            if (!TestEquipRules(chara))
            {
                Debug.WriteLine("Player has more than two hands??");
            }
            else
            {
                Debug.WriteLine("Equip rules working");
            }

        }

        //Tests all items in the text file get loaded into the shop.
        private static bool TestItemLoad(Shop shop)
        {
            string lineReadFromFile;
            List<string[]> itemNames = new List<string[]>();

            StreamReader fileIn = new StreamReader("items.txt");

            lineReadFromFile = fileIn.ReadLine();
            while (lineReadFromFile != null)
            {
                itemNames.Append(lineReadFromFile.Split('|'));
                lineReadFromFile = fileIn.ReadLine();
            }

            fileIn.Close();

            bool success = true;
            foreach (string[] itemStringArray in itemNames)
            {
                Item test = shop.MasterList.Find(item => item.Name == itemStringArray[0]);
                if (test == null) { success = false; }
            }

            return success;
        }

        //Buys and sells items to check if gold is calculated correctly and if buying and selling items works
        private static bool TestGoldCalculation(Shop shop, Character chara)
        {

            int startingGold = chara.Gold;
            int endingGold;
            int midGold;

            int budget = (int)(chara.Gold * 0.9);

            int item1Price = (int)(budget * 0.5);
            int item2Price = (int)(budget * 0.3);
            int item3Price = (int)(budget * 0.2);

            Item test1 = Tasks.CreateItem("C", "Test Clothing", item1Price, 50, 50, 50, "description");
            Item test2 = Tasks.CreateItem("S", "Test Spell", item2Price, 50, 50, 50, "description");
            Item test3 = Tasks.CreateItem("H1R", "Test 1HR", item3Price, 50, 50, 50, "description");
            
            int goldSpent = (test1.Cost + test2.Cost + test3.Cost);

            shop.AddItem(test1);
            shop.AddItem(test2);
            shop.AddItem(test3);

            chara.BuyItem(test1);
            chara.BuyItem(test2);
            chara.BuyItem(test3);

            midGold = chara.Gold;

            chara.SellItem(test1);
            chara.SellItem(test2);
            chara.SellItem(test3);

            endingGold = chara.Gold;

            shop.DeleteItem(test1);
            shop.DeleteItem(test2);
            shop.DeleteItem(test3);

            if(startingGold == endingGold && midGold == (startingGold - goldSpent))
            {
                return true;
            }

            return false;
        }

        //Tests if player can buy an item they cannot afford
        private static bool TestBankruptcy(Shop shop, Character chara)
        {
            Item test1 = Tasks.CreateItem("C", "Test Clothing", chara.Gold+20, 50, 50, 50, "description");
            bool success = true;

            shop.AddItem(test1);

            if (chara.BuyItem(test1))
            {
                chara.SellItem(test1);
                success = false;
            }

            shop.DeleteItem(test1);

            return success;
        }

        private static bool TestEquipRules(Character chara)
        {
            bool success = true;

            Item test1 = Tasks.CreateItem("C", "Test Clothing", 1, 1, 50, 50, "description");
            Item test2 = Tasks.CreateItem("S", "Test Spell", 1, 1, 50, 50, "description");
            //Item test3 = Tasks.CreateItem("H1R", "Test H1R", 1, 1, 50, 50, "description");
            //Item test4 = Tasks.CreateItem("H1L", "Test H1L", 1, 1, 50, 50, "description");
            //Item test5 = Tasks.CreateItem("H2", "Test H2", 1, 1, 50, 50, "description");


            chara.EquipItem(test1);
            chara.EquipItem(test1);
            chara.EquipItem(test2);
            chara.EquipItem(test2);

            //This should return false as we are wearing to much
            if (chara.EquipItem(test1)) { success = false; } //Tests Clothing
            if (chara.EquipItem(test2)) { success = false; } //Tests Spells

            chara.UnequipItem(test1);
            chara.UnequipItem(test2);

            //This should return true
            if (!chara.EquipItem(test1)) { success = false; } //Tests Clothing
            if (!chara.EquipItem(test2)) { success = false; } //Tests Spells

            chara.UnequipItem(test1);
            chara.UnequipItem(test1);
            chara.UnequipItem(test2);
            chara.UnequipItem(test2);
            chara.InventoryList.Remove(test1);
            chara.InventoryList.Remove(test1);
            chara.InventoryList.Remove(test2);
            chara.InventoryList.Remove(test2);

            return success;
        }
    }
}
