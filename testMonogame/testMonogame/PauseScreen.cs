﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace testMonogame
{
    class PauseScreen
    {
        Texture2D texture;
        SpriteFont header;
        SpriteFont font;

        Rectangle blackBackground = new Rectangle(0, 0, 256, 175);
        Rectangle destRect = new Rectangle(130, 0, 256 * 2, 175 * 2);
        public PauseScreen(Texture2D intexture,SpriteFont smallFont,SpriteFont bigFont)
        {
            texture = intexture;
            font = smallFont;
            header = bigFont;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, blackBackground, Color.Black);
            spriteBatch.DrawString(header, "Game Paused", new Vector2(200, 0), Color.White);
            spriteBatch.DrawString(font, "Press \"C\" to resume", new Vector2(300, 100), Color.White);


        }
        public void Update(GameManager game)
        {
            //NA
        }
    }
}
