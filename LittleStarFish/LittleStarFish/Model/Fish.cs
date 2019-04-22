using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Fish : GameObject
    {
        public Fish(string textureName, ContentManager Content, Vector2 position) : base(textureName, Content, position)
        {

        }
    }
}