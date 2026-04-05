using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment
{
    public partial class Tasks
    {
        private const int startingGold = 200;
        private const int maxWeight = 150;


        [Serializable]
        struct State
        {
            public Shop shop;
            public Character character;

            public State(Shop _shop, Character _character)
            {
                shop = _shop;
                character = _character;
            }
        }

        // Create an instance of the shop
        // This is used to keep track of the shops current state
        private Shop _theShop = new Shop();

        // Create an instance of the character
        // This is used to keep track of the characters current state
        private Character _theCharacter = new Character(startingGold, maxWeight);


        // TASK 1 -----------------------------------------------
        // 1a - Create the item hierarchy
        // 1b - Load the items from the file and create instances of the items
        // 1c - Add the items to the shop list
        // ------------------------------------------------------

        // TODO: This should load the items from the file and create instances of the items adding them to the shop.
        public void LoadShop()
        {

            //Used for testing.
            _theShop.AddItem(new RightHandItem("A \"Magical\"  Rock", 150, 120, 20 ,20, "Why would you want this??"));

            string lineReadFromFile;
            string[] lineArray;

            StreamReader fileIn = new StreamReader("items.txt");

            lineReadFromFile = fileIn.ReadLine();

            while (lineReadFromFile != null)
            {
                lineArray = lineReadFromFile.Split('|');

                _theShop.AddItem(CreateItem(lineArray[0], lineArray[1], int.Parse(lineArray[4]), int.Parse(lineArray[3]), int.Parse(lineArray[5]), int.Parse(lineArray[6]), lineArray[2]));

                lineReadFromFile = fileIn.ReadLine();
            }

            fileIn.Close();

            SelfTest.RunTest(_theShop, _theCharacter); //RUN DEBUG
   
        }

        public static Item CreateItem(string itemCode, string name, int cost, int weight, int cleaningMagic,
            int protectiveMagic, string description)
        {
            switch (itemCode)
            {
                case "C":
                    return new ClothingItem(name, cost, weight, cleaningMagic, protectiveMagic, description);
                case "S":
                    return new SpellItem(name, cost, weight, cleaningMagic, protectiveMagic, description);
                case "H1L":
                    return new LeftHandItem(name, cost, weight, cleaningMagic, protectiveMagic, description);
                case "H1R":
                    return new RightHandItem(name, cost, weight, cleaningMagic, protectiveMagic, description);
                case "H2":
                    return new TwoHandItem(name, cost, weight, cleaningMagic, protectiveMagic, description);
                default:
                    return null;
            }
        }

        // TASK 2 -------------------------------------------------------
        // 2a - Buy Items from the shop into the inventory 
        // 2b - Sell items from the inventory into the shop 
        // 2c - Update the character's constructur so that when it is created it starts with the correct gold and max weight
        //      Update the characters gold based on the items that the character has equipped in their 3 type inventories
        //      Update the Buy Items to only buy items if the player has enough gold
        // 2d - Add a new item to the shop 
        // 2e - Remove a selected item from the shop 
        // --------------------------------------------------------------


        // TODO: This is called when the Buy button is clicked.
        // The selected item in the shop has been passed to this method for you.
        // This should call the appropriate methods provided by the shop and character classes
        public bool BuyItemFromShop(Item item)
        {
            if(_theCharacter.BuyItem(item))
            {
                return _theShop.RemoveItem(item);
            }
            return false;
        }

        // TODO: This is called when the Sell button is clicked.
        // The selected item in the inventory has been passed to this method for you.
        // This should call the appropriate methods provided by the shop and character classes
        public bool SellItemToShop(Item item)
        {
            if (_theCharacter.SellItem(item))
            {
                _theShop.AddItem(item);
                return true;
            }
            return false;
        }

        // TODO: This is called when the Create button is clicked.
        // This should create a new dialog box which allows a new item to be created.
        public void CreateShopItem()
        {
            //Creates the GUI window passing the master list of items used to check if names are unique.
            CreateShopItemPopup _createItem = new CreateShopItemPopup(_theShop.MasterList);

            if (_createItem.ShowDialog() == DialogResult.OK)
            {
                _theShop.AddItem(_createItem.Item);
            }
            _createItem.Dispose();
        }

        // TODO: This is called when the Remove button is clicked.
        // This should remove the selected item from the shop.
        public bool RemoveShopItem(Item item)
        {
            return _theShop.DeleteItem(item);
        }

        // TASK 3 -------------------------------------------------------
        // 3a - Eqiup character with item in correct list (hand, clothing or spell)
        // 3b - Unequip the selected item so it appears back in the inventory
        // 3c - Update the cleaning magic label
        // 3d - Update the protective magic label
        // 3e - Update the Equip character so that it only Equips based on the equipping rules
        // 3f - Sort any list of type List<Item> by implementing the IComparable interface.
        //      You will need to call sort in the right places. 
        // --------------------------------------------------------------

        // TODO: This is called when the Euip button is clicked.
        // The selected item in the inventory has been passed to this method for you.
        // This should call the appropriate method provided by the character class
        public bool EquipItem(Item item)
        {
            return _theCharacter.EquipItem(item);
        }

        // TODO: This is called when the Uneuip button is clicked.
        // The selected item in the character’s panel has been passed to this method for you.
        // This should call the appropriate method provided by the character class
        public bool UnequipItem(Item item)
        {
            return _theCharacter.UnequipItem(item);
        }


        // TASK 4 -------------------------------------------------------
        // 4a - Save the current state of the program
        // 4b - Load the current state of the program
        // --------------------------------------------------------------

        // TODO: This is called when the Save menu item is clicked.
        // This should save the state of the program.
        public void SaveState()
        {
            if (SaveExists()) {
                DialogResult d;
                d = MessageBox.Show("Do you want to overwrite the existing save file?", "Game Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    WriteSaveFile();
                }
            }
            else
            {
                WriteSaveFile();
            }
        }

        public void WriteSaveFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream;
            State state = new State(_theShop, _theCharacter);

            stream = new FileStream("state.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, state);
            stream.Close();

            MessageBox.Show("Save Complete.", "Game Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private bool SaveExists()
        {
            Stream readStream;

            try { 
                readStream = new FileStream("state.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                readStream.Close();
            }
            catch(FileNotFoundException) { 
                return false; 
            }

            return true;
        }



        // TODO: This is called when the Load menu item is clicked.
        // This should load a previous state of the program.
        public void LoadState()
        {
            if (SaveExists())
            { 
                IFormatter formatter = new BinaryFormatter();
                Stream readStream;
                State state;

                readStream = new FileStream("state.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                state = (State)formatter.Deserialize(readStream);
                readStream.Close();

                _theShop = state.shop;
                _theCharacter = state.character;
            }
            else
            {
                MessageBox.Show("No Save File Found.", "Game Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
