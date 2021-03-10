﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace testMonogame.Interfaces
{
    public interface IRoom
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update(Game1 game);

        public List<IObject> GetBlocks();
        public List<IObject> GetItems();
        public List<IEnemy> GetEnemies();
        public List<IPlayerProjectile> GetPlayerProjectiles();
        public List<IEnemyProjectile> GetEnemeyProjectile();

        public void CloseRoom();
        public void AddEnemyProjectile(IEnemyProjectile projectile);
        public void RemoveEnemyProjectile(IEnemyProjectile projectile);
        public void AddPlayerProjectile(IPlayerProjectile projectile);
        public void RemovePlayerProjectile(IPlayerProjectile projectile);
    }
}