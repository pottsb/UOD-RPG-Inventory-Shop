using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    [Serializable]
    class LeftHandItem : HandItem
    {
        public LeftHandItem(string name, int cost, int weight, int cleaningMagic, int protectiveMagic, string description) : base(ItemType.LeftHand, name, cost, weight, cleaningMagic, protectiveMagic, description)
        {

        }
    }
}
