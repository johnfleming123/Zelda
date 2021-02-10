﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace testMonogame
{
    class DungeonBlock : IObject, ISprite
    {

        Texture2D texture;
        Rectangle destRect;
        int x;
        int y;

        Rectangle sourceRect = new Rectangle(18, 0, 34, 16);
        Color color = Color.Green;

        public DungeonBlock(Texture2D incTexture, Vector2 pos)
        {
            texture = incTexture;
            x = (int)pos.X;
            y = (int)pos.Y;
            destRect = new Rectangle(x, y, 16, 16);
        }

        public void Update(Game1 game)
        {
            // COLLISION WILL GO HERE
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, sourceRect, color);
        }

        public void Interact(IPlayer player)
        {
            // NULL
        }
    }
}
