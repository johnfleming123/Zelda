﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace testMonogame
{
    class GoriyaEnemy : ISprite
    {
        public int X { get; set; }
        public int Y { get; set; }
        int health;
        public IGoriyaState state;
        Texture2D texture;
        Texture2D projTexture;
        bool throwing;
        int throwCounter;

        public GoriyaEnemy(Texture2D inTexture, Texture2D inProjTexture, Vector2 position)
        {
            texture = inTexture;
            projTexture = inProjTexture;
            state = new GoriyaWL(texture, projTexture, this);
            health = 3;
            X = (int)position.X;
            Y = (int)position.Y;
        }

        public void Move(int xChange, int yChange)
        {
            X += xChange;
            Y += yChange;
            // TEMP: To show off movement
            if (X > 792) {
                changeState(3);

            } else if (X < 8)
            {
                changeState(4);

            } else if (Y > 472)
            {
                changeState(2);

            } else if (Y < 8)
            {
                changeState(1);

            }
        }

        public void takeDamage(int dmg)
        {
            health -= dmg;
        }

        public void Attack(IPlayer player)
        {
            // Collide with player = attack
        }

        public void setThrow(bool isThrow)
        {
            throwing = isThrow;
        }

        public bool getThrow()
        {
            return throwing;
        }

        public void changeState(int direction)
        {
            /*
             * 1 = Down
             * 2 = Up
             * 4 = Right
             * 3 = Left
             * Default = Down
             */
            switch (direction)
            {
                case 1:
                    state = new GoriyaWD(texture, projTexture, this);
                    break;
                case 2:
                    state = new GoriyaWU(texture, projTexture, this);
                    break;
                case 3:
                    state = new GoriyaWL(texture, projTexture, this);
                    break;
                case 4:
                    state = new GoriyaWR(texture, projTexture, this);
                    break;
                default:
                    state = new GoriyaWD(texture, projTexture, this);
                    break;
            }
        }

        //public int getX()
        //{
        //    return x;
        //}

        //public int getY()
        //{
        //    return y;
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public void Update(Game1 game)
        {
            throwCounter += 1;
            if (throwCounter > 600)
            {
                setThrow(true);
                state.spawnBoomerang(game);
                throwCounter = 0;
            }
            state.Update(game);
        }
    }
}
