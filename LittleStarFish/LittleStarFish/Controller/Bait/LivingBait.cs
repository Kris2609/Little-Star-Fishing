using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class LivingBait :Bait
    {
        public LivingBait(string textureName, ContentManager Content, Vector2 position) : base(textureName, Content, position)
        {

        }
    }
}