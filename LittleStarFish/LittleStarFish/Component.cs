﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleStarFish
{
   public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBath);
        public abstract void Update(GameTime gameTime);
    }
}
