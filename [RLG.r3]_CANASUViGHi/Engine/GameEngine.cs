﻿/* *
* Canas Uvighi, a RogueLike Game / RPG project.
* Copyright (C) 2015 Aleksandar Dimitrov (screen name SCiENiDE)
* 
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
* 
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* */

namespace RLG.R3_CANASUViGHi.Engine
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using RLG.R3_CANASUViGHi.Enums;
    using RLG.R3_CANASUViGHi.Framework;
    using RLG.R3_CANASUViGHi.GameData;
    using RLG.R3_CANASUViGHi.Models;
    using RLG.R3_CANASUViGHi.Interfaces;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        private bool
            inGame = false,
            expectCommand = false;

        /// <summary>
        /// Screen resolution in pixels.
        /// <remarks>Default resolution is 1024x640,
        /// 16:10 aspect ratio.</remarks>
        /// </summary>
        internal const int 
            ScreenWidth = 1024,
            ScreenHeight = 640;
        
        /// <summary>
        /// The minimal energy cost for an Actor taking a turn.
        /// </summary>
        internal const int MinTurnCost = 100;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardBuffer keyboardBuffer;
        private Map<ITile> testMap;
        private IActor playerActor;
        private PriorityQueue<IActor> actorQueue;
        private IMessageLog messageLog;
        private SpriteFont testFont;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine" /> class.
        /// </summary>
        public GameEngine()
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            this.graphics.PreferredBackBufferWidth = ScreenWidth;
            this.graphics.PreferredBackBufferHeight = ScreenHeight;
            this.graphics.ApplyChanges();

            this.keyboardBuffer = new KeyboardBuffer();
            this.actorQueue = new PriorityQueue<IActor>();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.testFont = Content.Load<SpriteFont>("Fonts/Consolas16");

            // Load all needed sprites.
            Sprite.LoadSprites(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        { }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.keyboardBuffer.Update();

            #region Energy-Independent Commands
            Keys key = this.keyboardBuffer.PopKey();
            switch (key)
            {
                case Keys.Escape:
                    {
                        // Exit the game.
                        this.Exit();
                        break;
                    }

                case Keys.Home:
                    {
                        // Start a new game.
                        this.NewGame();
                        break;
                    }

                case Keys.OemPlus:
                    {
                        // Increase the play field (map-view-box size).
                        Point nextPoint = new Point(
                            this.testMap.ViewBoxTileSize.X + 1,
                            this.testMap.ViewBoxTileSize.Y + 1
                            );

                        this.testMap.ViewBoxTileSize = nextPoint;
                        break;
                    }

                case Keys.OemMinus:
                    {
                        // Reduce the play field (map-view-box size).
                        Point prevPoint = new Point(
                            this.testMap.ViewBoxTileSize.X - 1,
                            this.testMap.ViewBoxTileSize.Y - 1
                            );

                        this.testMap.ViewBoxTileSize = prevPoint;
                        break;
                    }

                case Keys.Q:
                    {
                        // Summon a monster on the field.
                        IActor monster = Tools.GenerateMonster();
                        if (monster.Spawn(this.testMap, new Point(5, 5)))
                        {
                            this.actorQueue.Add(monster);
                        }
                        break;
                    }

                default:
                    {
                        // The key is not a energy-independent command,
                        // return it to the buffer!
                        this.keyboardBuffer.PushKey(key);
                        break;
                    }
            }
            #endregion

            if (!expectCommand)
            {
                actorQueue.AccumulateEnergy();
            }

            
            foreach (IActor actor in actorQueue)
            {
                if (actor.Energy >= MinTurnCost)
                {
                    if (actor.Flags.HasFlag(Flags.IsPlayerControl))
                    {
                        // Actor is player controlled, wait for input command
                        this.expectCommand = true;

                        switch (this.keyboardBuffer.PopKey())
                        {
                            #region Energy-Dependent Commands
                            case Keys.NumPad8:
                            case Keys.K:
                            case Keys.Up:
                                {
                                    actor.Energy -= this.playerActor.Move(CardinalDirection.North);
                                    this.expectCommand = false;
                                    break;
                                }

                            case Keys.NumPad2:
                            case Keys.J:
                            case Keys.Down:
                                {
                                    actor.Energy -= this.playerActor.Move(CardinalDirection.South);
                                    this.expectCommand = false;
                                    break;
                                }

                            case Keys.NumPad4:
                            case Keys.H:
                            case Keys.Left:
                                {
                                    actor.Energy -= this.playerActor.Move(CardinalDirection.West);
                                    this.expectCommand = false;
                                    break;
                                }

                            case Keys.NumPad6:
                            case Keys.L:
                            case Keys.Right:
                                {
                                    actor.Energy -= this.playerActor.Move(CardinalDirection.East);
                                    this.expectCommand = false;
                                    break;
                                }

                            case Keys.NumPad7:
                            case Keys.Y:
                                {
                                    actor.Energy -= this.playerActor.Move(CardinalDirection.NorthWest);
                                    this.expectCommand = false;
                                    break;
                                }

                            case Keys.NumPad9:
                            case Keys.U:
                                {
                                    actor.Energy -= this.playerActor.Move(CardinalDirection.NorthEast);
                                    this.expectCommand = false;
                                    break;
                                }

                            case Keys.NumPad1:
                            case Keys.B:
                                {
                                    actor.Energy -= this.playerActor.Move(CardinalDirection.SouthWest);
                                    this.expectCommand = false;
                                    break;
                                }

                            case Keys.NumPad3:
                            case Keys.N:
                                {
                                    actor.Energy -= this.playerActor.Move(CardinalDirection.SouthEast);
                                    this.expectCommand = false;
                                    break;
                                }

                            default:
                                // Send message for unknown command!
                                break;
                            #endregion
                        }
                    }
                    else
                    {
                        if (!expectCommand)
                        {
                            // The Actor is non-player character.
                            // AI to be implemented. . .
                            actor.Energy -= actor.Move(Tools.DrunkardWalk());
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (inGame)
            {
                this.testMap.Draw(this.spriteBatch, this.playerActor.Position);
            }

            base.Draw(gameTime);
        }

        private void NewGame()
        {
            string playerName = "SCiENiDE";

            playerActor = new Actor(
                0,
                playerName, 
                0,
                11, 
                Sprite.Player.HumanM,
                Enums.Flags.IsPlayerControl);

            this.actorQueue.Add(playerActor);

            this.testMap = new Map<ITile>(
                Framework.Tools.GenerateMap(new Point(30, 30)),
                0, 
                "Testing Grounds");
            this.testMap.ViewBoxTileSize = new Point(24, 15);

            bool outerBreak = false;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (!testMap[x, y].Flags.HasFlag(Flags.IsBlocked))
                    {
                        playerActor.Spawn(this.testMap, new Point(x, y));
                        outerBreak = true;
                        break;
                    }
                }

                if (outerBreak) { break; }
            }

            // Indicate that we are currently in game.
            inGame = true;
        }
    }
}
