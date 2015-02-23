using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace RLG.R3_CANASUViGHi.Framework
{
    /// <summary>
    /// Auxiliary class to process keyboard input.
    /// </summary>
    internal class KeyboardBuffer
    {
        private KeyboardState
            prevKeyState,
            currentKeyState;
        private Queue<Keys> buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardBuffer"/> class.
        /// </summary>
        public KeyboardBuffer()
        {
            this.prevKeyState = Keyboard.GetState();
            this.buffer = new Queue<Keys>();
        }

        /// <summary>
        /// Gets the count of Keys in the buffer.
        /// </summary>
        public int KeyCount
        {
            get { return this.buffer.Count; }
        }

        /// <summary>
        /// Gets the first (top) key, and removes it from the buffer.
        /// </summary>
        /// <returns>The first <see cref="Keys"/> object in the buffer.</returns>
        public Keys PopFirstKey()
        {
            return this.buffer.Dequeue();
        }
        
        /// <summary>
        /// Get the pressed Keys and send them to the buffer
        /// awaiting to be processed.
        /// </summary>
        public void Update()
        {
            this.currentKeyState = Keyboard.GetState();

            foreach (Keys key in currentKeyState.GetPressedKeys())
            {
                if (CheckKey(key))
                {
                    buffer.Enqueue(key);
                }
            }

            this.prevKeyState = this.currentKeyState;
        }

        /// <summary>
        /// Removes all Keys objects contained in the buffer.
        /// </summary>
        public void ClearBuffer()
        {
            this.buffer.Clear();
        }

        /// <summary>
        /// Check if any of the keys was pressed. Returns true once per key press.
        /// </summary>
        /// <param name="keysDown">The key to check for.</param>
        /// <returns>True if any of the keys is down for the first time. Otherwise false.</returns>
        private bool CheckKey(Keys key)
        {
            if (this.prevKeyState.IsKeyUp(key) &&
                this.currentKeyState.IsKeyDown(key))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Parse all Keys contained in the buffer to a String object.
        /// </summary>
        /// <returns>The character values of all Keys in the buffer to a String.</returns>
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            foreach (Keys key in this.buffer)
            {
                sb.Append((char)key);
            }

            return sb.ToString();
        }
    }
}
