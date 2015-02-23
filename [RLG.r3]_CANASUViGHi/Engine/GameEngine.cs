using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RLG.R3_CANASUViGHi.Enums;
using RLG.R3_CANASUViGHi.Framework;
using RLG.R3_CANASUViGHi.GameData;
using RLG.R3_CANASUViGHi.Models;
using RLG.R3_CANASUViGHi.Interfaces;

namespace RLG.R3_CANASUViGHi.Engine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameEngine : Game
    {
        private bool inGame = false;

        /// <summary>
        /// Screen resolution in pixels.
        /// <remarks>Default resolution is 1024x640,
        /// 16:10 aspect ratio.</remarks>
        /// </summary>
        internal const int 
            ScreenWidth = 1024,
            ScreenHeight = 640;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardBuffer keyboardBuffer;
        private Map<ITile> testMap;
        private IActor playerActor;
        private PriorityQueue<IActor> actorQueue;

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

            for (int i = 0; i < this.keyboardBuffer.KeyCount; i++)
            {
                switch (this.keyboardBuffer.PopFirstKey()) 
                {
                    case Keys.Escape:
                        {
                            this.Exit();
                            break;
                        }

                    case Keys.Home:
                        {
                            this.NewGame();
                            break;
                        }

                    case Keys.OemPlus:
                        {
                            Point nextPoint = new Point(
                                this.testMap.ViewBoxTileSize.X + 1,
                                this.testMap.ViewBoxTileSize.Y + 1
                                );

                            this.testMap.ViewBoxTileSize = nextPoint;
                            break;
                        }

                    case Keys.OemMinus:
                        {
                            Point prevPoint = new Point(
                                this.testMap.ViewBoxTileSize.X - 1,
                                this.testMap.ViewBoxTileSize.Y - 1
                                );

                            this.testMap.ViewBoxTileSize = prevPoint;
                            break;
                        }

                    #region Movement Keys

                    case Keys.NumPad8:
                    case Keys.K:
                    case Keys.Up:
                        {
                            this.playerActor.Move(CardinalDirection.North);
                            break;
                        }

                    case Keys.NumPad2:
                    case Keys.J:
                    case Keys.Down:
                        {
                            this.playerActor.Move(CardinalDirection.South);
                            break;
                        }

                    case Keys.NumPad4:
                    case Keys.H:
                    case Keys.Left:
                        {
                            this.playerActor.Move(CardinalDirection.West);
                            break;
                        }

                    case Keys.NumPad6:
                    case Keys.L:
                    case Keys.Right:
                        {
                            this.playerActor.Move(CardinalDirection.East);
                            break;
                        }

                    case Keys.NumPad7:
                    case Keys.Y:
                        {
                            this.playerActor.Move(CardinalDirection.NorthWest);
                            break;
                        }

                    case Keys.NumPad9:
                    case Keys.U:
                        {
                            this.playerActor.Move(CardinalDirection.NorthEast);
                            break;
                        }

                    case Keys.NumPad1:
                    case Keys.B:
                        {
                            this.playerActor.Move(CardinalDirection.SouthWest);
                            break;
                        }

                    case Keys.NumPad3:
                    case Keys.N:
                        {
                            this.playerActor.Move(CardinalDirection.SouthEast);
                            break;
                        }
                    #endregion

                    default:
                        // Send message for unknown command?
                        break;
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

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
                new Point(0, 0),
                Sprite.Player.HumanM,
                Enums.Flags.IsPlayerControl);

            this.actorQueue.AddActor(playerActor);

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
