﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace testMonogame
{
    public class CaveDoor : ISprite, IObject
    {
        int x;
        int y;

        Texture2D texture;
        Rectangle destRect;
        Rectangle sourceRect;

        public CaveDoor(int direction, Vector2 pos, Texture2D texture)
        {
            this.texture = texture;
            x = (int)pos.X;
            y = (int)pos.Y;
            destRect = new Rectangle(x, y, 33, 33);

            switch (direction)
            {
                case 0:     //north door
                    sourceRect = new Rectangle(99, 0, 32, 32);
                    break;
                case 1:     //west door
                    sourceRect = new Rectangle(99, 33, 32, 32);
                    break;
                case 2:     //east door
                    sourceRect = new Rectangle(99, 66, 32, 32);
                    break;
                case 3:     //south door
                    sourceRect = new Rectangle(99, 99, 32, 32);
                    break;
                default:
                    sourceRect = new Rectangle(99, 0, 32, 32);
                    break;

            }
        }

        public void Update(Game1 game)
        {
            //collision
        }

        public void Interact(IPlayer player)
        {
            // add level changing logic
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
        }
    }
}
