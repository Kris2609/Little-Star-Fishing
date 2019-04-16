using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class LivingBait : Bait
    {
        public LivingBait(string name, int weight) :base (true, false, name,weight)
        {
            
        }
    }
}