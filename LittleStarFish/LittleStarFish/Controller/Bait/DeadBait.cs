using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class DeadBait : Bait
    {
        public DeadBait(string name, int weight) : base(false,true, name, weight)
        {

        }
    }
}