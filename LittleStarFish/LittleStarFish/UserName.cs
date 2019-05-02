using LittleStarFish.Controles;
using LittleStarFish.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class UserName : State
    {
        private Keys[] lastPressedkeys = new Keys[5];
        private string myUser = string.Empty;
        private Texture2D userName;
        private SpriteFont Userfont;
        
        private List<Component> _component = new List<Component>();
        
        public UserName(GameWorld gameWorld, GraphicsDevice graphicsDevice, ContentManager content) : base(gameWorld, graphicsDevice, content)
        {
            
            userName = content.Load<Texture2D>("Username");
            Userfont = content.Load<SpriteFont>("userpass");
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("Font");
            var doneButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(600, 600),
                Text = "Done",
            };
            doneButton.Click += DoneButton_Click;
            _component = new List<Component>()
            {
                doneButton,

            };
        }
        private void DoneButton_Click(object sender, EventArgs e)
        {

            _gameWorld.ChangeState(new Login(_gameWorld, _graphichsDevice, _content));
        }
        public void GetKeys()
        {
            KeyboardState kbState = Keyboard.GetState();
            Keys[] pressedKeys = kbState.GetPressedKeys();

            foreach (Keys key in lastPressedkeys)
            {
                if (!pressedKeys.Contains(key))
                {
                    //Key is no longer pressed
                    OnKeyUp(key);
                }
            }
            foreach (Keys key in pressedKeys)
            {
                if (!lastPressedkeys.Contains(key))
                {
                    //Key is pressed
                    OnKeyDown(key);
                }
            }
            lastPressedkeys = pressedKeys;
            
        }
        public void OnKeyUp(Keys key)
        {
            
        }

        public void OnKeyDown(Keys key)
        {
            if (key == Keys.Back && myUser.Length > 0)
            {
                myUser = myUser.Remove(myUser.Length - 1);
            }
            else if (key == Keys.Space)
            {
                myUser = myUser + new string(' ', 1);
            }
            else if (key == Keys.Enter)
            {
                return;
            }
            else if (key == Keys.LeftAlt)
            {
                return;
            }
            else if (key == Keys.LeftShift)
            {
                myUser.ToUpperInvariant();
                myUser.ToLowerInvariant();
            }
            else
            {
                myUser += key.ToString();
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var component in _component)
            {
                component.Draw(gameTime, spriteBatch);
            }
            spriteBatch.Draw(userName, new Vector2(600, 400), Color.White);
            spriteBatch.DrawString(Userfont, myUser, new Vector2(700, 500), Color.Black);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _component)
            {
                component.Update(gameTime);
            }
            GetKeys();
        }
    }
}