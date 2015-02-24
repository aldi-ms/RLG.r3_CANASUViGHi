/* *
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

namespace RLG.R3_CANASUViGHi.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.Interfaces;
    using System;
    using System.Text;

    internal sealed class MessageLog : IMessageLog
    {
        private const int Padding = 5;
        private Color textColor;
        private StringBuilder[] lines;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private Rectangle rectangle;
        private Point[] lineCoordinates;

        public MessageLog(SpriteBatch spriteBatch, Rectangle logRectangle, SpriteFont spriteFont)
        {
            this.spriteBatch = spriteBatch;
            this.rectangle = logRectangle;
            this.spriteFont = spriteFont;
            
            // Default text color
            this.textColor = Color.Gray;

            int lineCount = this.rectangle.Height / this.FontHeight;
            this.lines = new StringBuilder[lineCount];
            this.lineCoordinates = new Point[lineCount];

            // Initialize line coordinates, from bottom [0] to top [Length - 1].
            for (int i = 0; i < lineCount; i++)
            {
                this.lines[i] = new StringBuilder();

                this.lineCoordinates[i] = new Point(
                    this.rectangle.Left + Padding,
                    this.rectangle.Bottom + i * this.FontHeight);
            }
        }

        public Color TextColor
        {
            get { return this.textColor; }
            set { this.textColor = value; }
        } 

        private int FontHeight
        {
            get { return this.spriteFont.LineSpacing; }
        }

        public bool SendMessage(string text)
        {
            if (this.TextLengthOnScreen(new StringBuilder(text)) <= this.rectangle.Width)
            {
                for (int i = this.lines.Length - 1; i > 0; i--)
                {
                    lines[i].Clear();
                    lines[i].Append(lines[i - 1]);  // + new string(' ', this.rectangle.Width - lines[i - 1].Length));
                }

                lines[0].Clear();
                lines[0].Append(text);

                PrintMessageLog();
                // WriteLogFile(text);     //make log file save on game save instead of every message?
            }
            //else block also present (copied from here) in Window.Write
            else
            {
                string[] splitText = text.Split(' ');
                int firstUnappendedString = 0;
                StringBuilder firstPartText = new StringBuilder();

                for (int i = firstUnappendedString; i < splitText.Length; i++)
                {
                    int textLength = this.TextLengthOnScreen(firstPartText) + this.TextLengthOnScreen(splitText[i]);

                    if (!(textLength > this.rectangle.Width))
                    {
                        firstPartText.Append(splitText[i]);
                        firstPartText.Append(" ");
                    }
                    else
                    {
                        firstUnappendedString = i;
                        break;
                    }
                }

                StringBuilder secondPartText = new StringBuilder();
                for (int i = firstUnappendedString; i < splitText.Length; i++)
                    secondPartText.AppendFormat("{0} ", splitText[i]);

                SendMessage(firstPartText.ToString());
                SendMessage(secondPartText.ToString());
            }

            throw new NotImplementedException();
        }

        public void ClearLog()
        {
            throw new NotImplementedException();
        }

        private void PrintMessageLog()
        {
            throw new NotImplementedException();
        }

        private int TextLengthOnScreen(string text)
        {
            return (int)this.spriteFont.MeasureString(text).X;
        }

        private int TextLengthOnScreen(StringBuilder text)
        {
            return this.TextLengthOnScreen(text.ToString());
        }
    }
}
