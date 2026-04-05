using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    [Serializable]
    class SpellItem : Item
    {
        public SpellItem(string name, int cost, int weight, int cleaningMagic, int protectiveMagic, string description) : base(ItemType.Spell, name, cost, weight, cleaningMagic, protectiveMagic, description)
        {
            _iconName = "spell-icon";
        }
    }
}
