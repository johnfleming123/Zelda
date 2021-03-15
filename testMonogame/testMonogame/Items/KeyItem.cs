﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace testMonogame
{
    class KeyItem : IObject, ISprite
    {
        //drawing stuff
        Texture2D texture;
        Rectangle sourceRect = new Rectangle(0, 13, 8, 17);
        Rectangle destRect;
        Color color = Color.White;


        //location stuff
        public int X { get; set; }
        public int Y { get; set; }
        const int width = 16;
        const int height = 34;


        public KeyItem(Texture2D inTexture, Vector2 position)
        {
            texture = inTexture;
            X = (int)position.X;
            Y = (int)position.Y;

            //Non-moving block so instantiate dest rectangle
            destRect = new Rectangle(X, Y, width, height);

        }
        public Rectangle getDestRect()
        {
            return destRect;
        }
        public void Draw(SpriteBatch spriteBatch)
        {




            spriteBatch.Draw(texture, destRect, sourceRect, color);

        }

        public void Interact(IPlayer player)
        {
            //perhapse add code to distinguish keys
            player.ObtainItem("Key");
        }

        public void Update(GameManager game)
        {
            //Nothing Needed here
        }
    }
}
