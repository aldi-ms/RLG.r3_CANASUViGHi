namespace RLG.R3_CANASUViGHi.Framework
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    //using System;
    using System.Collections.Generic;

    internal class MouseHelp
    {
        private bool
            leftButton,
            rightButton;
        private MouseState
            prevMouseState,
            currentMouseState;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseHelp"/> class.
        /// </summary>
        public MouseHelp()
        {
            this.prevMouseState = Mouse.GetState();
            this.LeftButton = false;
            this.RightButton = false;
            this.Update();
        }

        public Point Position
        {
            get { return this.currentMouseState.Position; }
        }

        /// <summary>
        /// True if the Left Mouse Button was pressed. False otherwise.
        /// </summary>
        public bool LeftButton 
        {
            get 
            {
                bool result = this.leftButton;
                this.leftButton = false;
                return result;
            }

            private set
            {
                this.leftButton = value;
            }
        }

        /// <summary>
        /// True if the Right Mouse Button was pressed. False otherwise.
        /// </summary>
        public bool RightButton
        {
            get
            {
                bool result = this.rightButton;
                this.rightButton = false;
                return result;
            }

            private set 
            { 
                this.rightButton = value;
            }
        }

        public void Update()
        {
            this.currentMouseState = Mouse.GetState();

            if (this.currentMouseState.LeftButton == ButtonState.Pressed &&
                this.prevMouseState.LeftButton == ButtonState.Released)
            {
                this.LeftButton = true;
            }

            if (this.currentMouseState.RightButton == ButtonState.Pressed &&
                this.prevMouseState.RightButton == ButtonState.Released)
            {
                this.RightButton = true;
            }

            this.prevMouseState = this.currentMouseState;
        }
    }
}
