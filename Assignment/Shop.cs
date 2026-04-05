using System;
using System.Collections.Generic;

namespace Assignment
{
    [Serializable]
    public class Shop
    {
        // This is the list that manages the items in the shop inventory
        private List<Item> _shopList = new List<Item>();
        private List<Item> _masterList = new List<Item>();

        // getter for the _shopList
        public List<Item> ShopList
        {
            get
            {
                return _shopList;
            }
        }

        public List<Item> MasterList
        {
            get
            {
                return _masterList;
            }
        }

        // This method should add an item to the shop
        public void AddItem(Item item)
        {
            _shopList.Add(item);
            _masterList.Add(item);
            _shopList.Sort();
        }

        // This method should remove an item from the shop
        // If it is successful it should return true otherwise false
        //Called when a player buys something.
        public bool RemoveItem(Item item)
        {
            return _shopList.Remove(item);
        }

        //Called when an item is deleted in the GUI.
        public bool DeleteItem(Item item)
        {
            //Frees up the name to be reused
            _masterList.Remove(item);
            return _shopList.Remove(item);
        }
    }
}
