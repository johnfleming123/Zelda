﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using testMonogame.Interfaces;
using testMonogame.Rooms;

namespace testMonogame
{
    public class PlayerObjectCollision
    {

        Rectangle playerRect;
        Rectangle objectRect;
        Rectangle collisionRect;

        const int height = 16;
        const int width = 16;

        const int screenX = 130;
        const int screenY = 110;
        //The factor that each block is scaled up by
        const int blockSizeMod = 2;
        //the base dimensions of a block square
        const int blockBaseDimension = 16;

        public void detectCollision(IPlayer player, List<IObject> items, List<IObject> blocks,IRoom r, GameManager game)
        {


            playerRect = player.getDestRect();
            bool isIgnored;
            foreach (IObject block in blocks)
            {
                isIgnored = false;
                objectRect = block.getDestRect();
                //playerRect = player.getDestRect();
                collisionRect = Rectangle.Intersect(playerRect, objectRect);
                if (block is BlueSandBlock || block is DragonBlock || block is FishBlock) isIgnored = true;

                if (!collisionRect.IsEmpty && (block is CaveDoor || block is ClosedDoor || block is OpenDoor || block is LockedDoor))
                {
                    isIgnored = true;
                    doorCollisionHandler(player, block, game, collisionRect);

                }
                //if they've collided
                if (!collisionRect.IsEmpty & !isIgnored)
                {
                    //generate collision rectangle
                    blockCollisionHandler(collisionRect, player, block);
                }
            }
            IObject[] itemArr = items.ToArray();
            foreach (IObject item in itemArr)
            {
                isIgnored = false;
                objectRect = item.getDestRect();
                //playerRect = player.getDestRect();
                collisionRect = Rectangle.Intersect(playerRect, objectRect);
                //if they've collided
                if (!collisionRect.IsEmpty & !isIgnored)
                {
                    //generate collision rectangle
                    itemCollisionHandler(collisionRect, player, item,r);
                }
            }
        }
        public void doorCollisionHandler(IPlayer player, IObject collided, GameManager game, Rectangle collisionRect)
        {
            IDoor door = (IDoor)collided;

            //handle collision
            switch (door.getSide())
            {
                case 0:
                    if (player.getState() is UpMovingPlayerState)
                    {
                        //test door open or closed
                        if (door.getIsClosed())
                        {
                            //interact with closed door
                            door.Interact(player);
                            blockCollisionHandler(collisionRect, player, collided);
                        }
                        else
                        {
                            //go through open door
                            game.LoadRoom(door.getNextRoom());
                            int x = 10 + screenX + (6 * blockBaseDimension * blockSizeMod) + ((blockBaseDimension * blockSizeMod));
                            int y = screenY + (9 * blockBaseDimension * blockSizeMod) - 16 - 30;
                            player.X = x;
                            player.Y = y;
                        }
                        
                    }
                    else
                    {
                        blockCollisionHandler(collisionRect, player, collided);
                    }
                    break;
                case 1:
                    if (player.getState() is LeftMovingPlayerState)
                    {
                        //test door open or closed
                        if (door.getIsClosed())
                        {
                            //interact with closed door
                            door.Interact(player);
                            blockCollisionHandler(collisionRect, player, collided);
                        }
                        else
                        {
                            //go through open door
                            game.LoadRoom(door.getNextRoom());
                            int y = 10 + screenY + (5 * blockBaseDimension * blockSizeMod) - blockBaseDimension;
                            int x = screenX + (blockSizeMod * blockBaseDimension * 14) - 30 - 16;
                            player.X = x;
                            player.Y = y;
                        }
                        
                    }
                    else
                    {
                        blockCollisionHandler(collisionRect, player, collided);
                    }
                    break;
                case 2:
                    if (player.getState() is RightMovingPlayerState)
                    {
                        //test door open or closed
                        if (door.getIsClosed())
                        {
                            //interact with closed door
                            door.Interact(player);
                            blockCollisionHandler(collisionRect, player, collided);
                        }
                        else
                        {
                            //go through open door
                            game.LoadRoom(door.getNextRoom());
                            int y = 10 + screenY + (5 * blockBaseDimension * blockSizeMod) - blockBaseDimension;
                            int x = screenX + 24;
                            player.X = x;
                            player.Y = y;
                        }
                        
                    }
                    else
                    {
                        blockCollisionHandler(collisionRect, player, collided);
                    }
                    break;
                case 3:
                    if (player.getState() is DownMovingPlayerState)
                    {
                        //test door open or closed
                        if (door.getIsClosed())
                        {
                            //interact with closed door
                            door.Interact(player);
                            blockCollisionHandler(collisionRect, player, collided);
                        }
                        else
                        {
                            //go through open door
                            game.LoadRoom(door.getNextRoom());
                            int x = screenX + (6 * blockBaseDimension * blockSizeMod) + ((blockBaseDimension * blockSizeMod)) + 10;
                            int y = screenY + 30 + 16;
                            player.X = x;
                            player.Y = y;
                        }
                        
                    }
                    else
                    {
                        blockCollisionHandler(collisionRect, player, collided);
                    }
                    break;
                default:
                    break;
            }
        }
        public void itemCollisionHandler(Rectangle collisionRect, IPlayer player, IObject collided,IRoom room)
        {
            collided.Interact(player);
            room.RemoveItem(collided);

        }
        public void blockCollisionHandler(Rectangle collisionRect, IPlayer player, IObject collided)
        {
            collided.Interact(player);
            int x = collisionRect.Width;
            int y = collisionRect.Height;
            if (x > y)
            {
                //if player is above the collided thing
                if (player.Y < collided.Y)
                {
                    player.Y -= y;
                }
                //otherwise player is below object
                else
                {
                    player.Y += y;
                }
            }
            else
            {
                if (player.X < collided.X)
                {
                    player.X -= x;
                }
                //otherwise player is below object
                else
                {
                    player.X += x;
                }
            }
           
        }
    }
}
