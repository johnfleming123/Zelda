﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace testMonogame.Commands
{
    public class QuitCommand : ICommand
    {
        Game1 game;
        public QuitCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            //quit logic
            game.Exit();
        }
    }
}
