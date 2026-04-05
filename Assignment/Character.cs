using System;
using System.Collections.Generic;

namespace Assignment
{
    [Serializable]
    public class Character
    {
        // This is the list that manages the items in the characters inventory
        private List<Item> _inventoryList = new List<Item>();
        // This is the list that manages the hand items that are equipped to the character        
        private List<Item> _handItemList = new List<Item>();
        // This is the list that manages the clothing items that are equipped to the character
        private List<Item> _clothingList = new List<Item>();
        // This is the list that manages the spell items that are equipped to the character
        private List<Item> _spellList = new List<Item>();
        //Sets the max equipable items
        private const int _maxLeftHandEquipped = 1;
        private const int _maxRightHandEquipped = 1;
        private const int _maxTwoHandEquipped = 1;
        private const int _maxClothingEquipped = 2;
        private const int _maxSpellsEquipped = 2;
        // Keeps track of the number of items equipped to each area of the character
        private int _numberLeftHandEquipped = 0;
        private int _numberRightHandEquipped = 0;
        private int _numberTwoHandEquipped = 0;
        private int _numberSpellsEquipped = 0;
        private int _numberClothingEquipped = 0;
        // Keeps track of the characters attributes
        private int _gold;
        private int _currentWeight;
        private int _cleaningMagic;
        private int _protectiveMagic;
        private int _maxWeight;

        public Character(int gold, int maxWeight)
        {
            _gold = gold;
            _maxWeight = maxWeight;
        }

        public List<Item> InventoryList { get { return _inventoryList; } }
        public List<Item> HandItemList { get { return _handItemList; } }
        public List<Item> ClothingList { get { return _clothingList; } }
        public List<Item> SpellList { get { return _spellList; } }
        public int Gold { get { return _gold; } }
        public int CurrentWeight { get { return _currentWeight; } }
        public int CleaningMagic { get { return _cleaningMagic; } }
        public int ProtectiveMagic { get { return _protectiveMagic; } }
        public int MaxWeight { get { return _maxWeight; } }


        // TODO: Check if the character has enough weight left to carry the given item.
        // If it is successful it should return true otherwise false
        public bool EnoughWeight(Item item)
        {
            return  _currentWeight + item.Weight <= _maxWeight;
        }

        // TODO: Check if the character has enough gold left to buy the item.
        // If it is successful it should return true otherwise false
        public bool EnoughGold(Item item)
        {   
           return _gold >= item.Cost;
        }

        // TODO: Equip the character with a given item based on its type.
        // Either a left-hand, right-hand, two-hand, clothing or spell item.
        // This should add an item from the correct character’s list and remove it from the inventory.
        // If it is successful it should return true otherwise false.
        public bool EquipItem(Item item)
        {
            bool equipSuccess = false;

            if (EnoughWeight(item))
            {
                switch (item.TypeOfItem)
                {
                    case ItemType.Clothing:
                        if (_numberClothingEquipped < _maxClothingEquipped)
                        {
                            _clothingList.Add(item);
                            _numberClothingEquipped++;
                            equipSuccess = true;
                        }
                        break;

                    case ItemType.RightHand:
                        if (_numberRightHandEquipped < _maxRightHandEquipped && _numberTwoHandEquipped == 0)
                        {
                            _handItemList.Add(item);
                            _numberRightHandEquipped++;
                            equipSuccess = true;
                        }
                        break;

                    case ItemType.LeftHand:
                        if (_numberLeftHandEquipped < _maxLeftHandEquipped && _numberTwoHandEquipped == 0)
                        {
                            _handItemList.Add(item);
                            _numberLeftHandEquipped++;
                            equipSuccess = true;
                        }
                        break;

                    case ItemType.TwoHand:
                        if (_numberTwoHandEquipped < _maxTwoHandEquipped && _numberLeftHandEquipped == 0 && _numberRightHandEquipped == 0)
                        {
                            _handItemList.Add(item);
                            _numberTwoHandEquipped++;
                            equipSuccess = true;
                        }
                        break;

                    case ItemType.Spell:
                        if (_numberSpellsEquipped < _maxSpellsEquipped)
                        {
                            _spellList.Add(item);
                            _numberSpellsEquipped++;
                            equipSuccess = true;
                        }
                        break;
                }
            }

            if (equipSuccess) { 
                AddMagic(item);
                _inventoryList.Remove(item);
            }

            return equipSuccess;
        }

        private void AddMagic(Item item)
        {
            _cleaningMagic += item.CleaningMagic;
            _protectiveMagic += item.ProtectiveMagic;
            _currentWeight += item.Weight;
        }

        private void RemoveMagic(Item item)
        {
            _cleaningMagic -= item.CleaningMagic;
            _protectiveMagic -= item.ProtectiveMagic;
            _currentWeight -= item.Weight;
        }

        // TODO: Unequip an item from the character.
        // This should remove an item from the correct character’s list and add it to the inventory.
        // If it is successful it should return true otherwise false.
        public bool UnequipItem(Item item)
        {
            bool equipRemovalSuccess = false;

            switch (item.TypeOfItem)
            {
                case ItemType.Clothing:
                        equipRemovalSuccess = _clothingList.Remove(item);
                        _numberClothingEquipped--;
                    break;

                case ItemType.RightHand:
                        equipRemovalSuccess = _handItemList.Remove(item);
                        _numberRightHandEquipped--;
                    break;

                case ItemType.LeftHand:
                        equipRemovalSuccess = _handItemList.Remove(item);
                        _numberLeftHandEquipped--;
                    break;

                case ItemType.TwoHand:
                        equipRemovalSuccess = _handItemList.Remove(item);
                        _numberTwoHandEquipped--;
                    break;

                case ItemType.Spell:
                        equipRemovalSuccess = _spellList.Remove(item);
                        _numberSpellsEquipped--;
                    break;
            }

            if (equipRemovalSuccess) {
                RemoveMagic(item);
                _inventoryList.Add(item);
            }

            return equipRemovalSuccess;
        }

        // TODO: This item should buy an item if the character has enough gold. 
        // It should then be added to the characters inventory list.
        // return true if successful, false otherwise.
        public bool BuyItem(Item item)
        {
            if (EnoughGold(item))
            {
                InventoryList.Add(item);
                _gold -= item.Cost;
                return true;
            }
            else
            {
                return false;
            }
        }

        // TODO: This should remove an item from the characters inventory list
        // If it is successful it should return true otherwise false
        public bool SellItem(Item item)
        {
            if (InventoryList.Contains(item))
            {
                InventoryList.Remove(item);
                _gold += item.Cost;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
