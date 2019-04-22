using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Player : GameObject
    {
        public Player(string textureName, ContentManager Content, Vector2 position) : base(textureName, Content, position)
        {

        }
    }
}