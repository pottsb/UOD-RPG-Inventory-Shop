using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    [Serializable]
    class RightHandItem : HandItem
    {
        public RightHandItem(string name, int cost, int weight, int cleaningMagic, int protectiveMagic, string description) : base(ItemType.RightHand, name, cost, weight, cleaningMagic, protectiveMagic, description)
        {

        }
    }
}
