namespace RLG.R3_CANASUViGHi.Framework
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of a FIFO (First In First Out) generic collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Buffer<T>
    {
        private Queue<T> buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Buffer"/> class.
        /// </summary>
        public Buffer()
        {
            this.buffer = new Queue<T>();
        }   
        
        /// <summary>
        /// Gets the count of elements in the buffer.
        /// </summary>
        public int Count
        {
            get { return this.buffer.Count; }
        }

        /// <summary>
        /// Gets the first (top) element, and removes it from the buffer.
        /// </summary>
        /// <returns>The first <see cref="T"/> element in the buffer or the 
        /// default (null/0/none) type value if such is not present.</returns>
        public T Dequeue()
        {
            if (this.buffer.Count > 0)
            {
                return this.buffer.Dequeue();
            }

            return default(T);
        }

        /// <summary>
        /// Enqueue an element to the buffer manually.
        /// </summary>
        /// <param name="element">Element to push.</param>
        public void Enqueue(T element)
        {
            this.buffer.Enqueue(element);
        }

        /// <summary>
        /// Removes all elements contained in the buffer.
        /// </summary>
        public void ClearBuffer()
        {
            this.buffer.Clear();
        }
 
        /// <summary>
        /// Parse all elements contained in the buffer to a String object, each separated with a space.
        /// </summary>
        /// <returns>The string values of all element in the buffer to a String.</returns>
        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            foreach (T element in this.buffer)
            {
                sb.Append(element.ToString());
            }

            return sb.ToString();
        }
    }
}
